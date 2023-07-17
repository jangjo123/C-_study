using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    public class DbCommands
    {
        // 초기화 시간이 좀 걸림
        public static void InitiakuzeDB(bool forceReset = false) // 초기화를 할지 말지
        {
            using (AppDbContext db = new AppDbContext())
            {
                // DB가 만들어져 있는지 체크
                if (!forceReset && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                string command =
                    @"CREATE FUNCTION GetAverageReviewScore (@itemId INT) RETURNS FLOAT
                      AS
                      BEGIN

                      DECLARE @result AS FLOAT

                      SELECT @result = AVG(CAST([Score] AS FLOAT))
                      FROM ItemReview AS r
                      WHERE @itemId = r.itemId

                      RETURN @result
                      END";

                db.Database.ExecuteSqlRaw(command);

                CreateTestData(db);
                Console.WriteLine("DB INitialized");
            }
        }


        public static void CreateTestData(AppDbContext db)
        {
            var Gunal = new Player() { Name = "Gunal" };
            var Faker = new Player() { Name = "Faker" };
            var Dohee = new Player() { Name = "Dohee" };

            List<Item> items = new List<Item>()
            {
                new Item()
                {
                    TemplateId = 101,
                    Owner = Gunal
                }
            };

            Guild guild = new Guild()
            {
                GuildName = "T1",
                Members = new List<Player>() { Gunal, Faker, Dohee }
            };

            db.Items.AddRange(items);
            db.Guilds.Add(guild);

            db.SaveChanges();
        }


        public static void ShowItems()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var item in db.Items.Include(i => i.Owner).IgnoreQueryFilters().ToList())
                {
                    if (item.SoftDeleted)
                    {
                        Console.WriteLine($"DELETED - ItemId({item.ItemId}) TemplateId({item.TemplateId})");
                    }
                    else
                    {
                        if (item.Owner == null)
                            Console.WriteLine($"ItemId({item.ItemId}) TemplateId({item.TemplateId}) Owner(0)");
                        else
                            Console.WriteLine($"ItemId({item.ItemId}) TemplateId({item.TemplateId}) OwnerId({item.Owner.PlayerId}), Owner({item.Owner.Name})");
                    
                    }
                    
                }
            }
        }


        public static void ShowGuild()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var guild in db.Guilds.Include(g => g.Members).ToList())
                {
                    Console.WriteLine($"GuildId({guild.GuildId}) GuildName({guild.GuildName}) MemberCount({guild.Members.Count})");
                }
            }
        }

        public static void TestUpdateAttach()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // State 조작
                {
                    Player p = new Player() { Name = "StateTest" };
                    db.Entry(p).State = EntityState.Added; // Tracked로 변환
                    //db.Players.Add(p);
                    db.SaveChanges();
                }

                // TrackGraph
                {
                    // Disconnected 상태에서,
                    // 모두 갱신하는게 아니라 플레이어 이름'만' 갱신하고 싶다면?
                    Player p = new Player()
                    {
                        PlayerId = 2,
                        Name = "Faker_New"
                    };

                    p.OwnedItem = new Item() { TemplateId = 777 }; // 아이템 정보 가정
                    p.Guild = new Guild() { GuildName = "TrackGraphGuild" }; // 길드 정보 가정

                    db.ChangeTracker.TrackGraph(p, e =>
                    {
                        if (e.Entry.Entity is Player)
                        {
                            e.Entry.State = EntityState.Unchanged;
                            e.Entry.Property("Name").IsModified = true;
                        }
                        else if (e.Entry.Entity is Guid)
                        {
                            e.Entry.State = EntityState.Unchanged;
                        }
                        else if (e.Entry.Entity is Item)
                        {
                            e.Entry.State = EntityState.Unchanged;
                        }
                    });
                    db.SaveChanges();
                }
            }
        }



    }
}
