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
                },

                new Item()
                {
                    TemplateId = 102,
                    Owner = Faker
                    
                },

                new Item()
                {
                    TemplateId = 103,
                    Owner = Dohee
                }
            };

            Guild guild = new Guild()
            {
                GuildName = "T1",
                Members = new List<Player>() { Gunal, Faker, Dohee }
            };

            db.Items.AddRange(items);
            db.Guilds.Add(guild);

            // Added
            Console.WriteLine("1번)" + db.Entry(Gunal).State);


            db.SaveChanges();

            // ------------------------

            // Add Test
            {
                Item item = new Item()
                {
                    TemplateId = 500,
                    Owner = Gunal
                };
                db.Items.Add(item);
                // 아티엠 추가 -> 간접적으로 Player도 영향
                // Player는 Tracking 상태이고, FK 설정은 필요 없음
                Console.WriteLine("2번)" + db.Entry(Gunal).State); // Unchanged
            }

            // Delete Test
            {
                Player p = db.Players.First();

                // 아직 DB는 이 새로운 길드의 존재도 모름 (DB 키 없음 0)
                p.Guild = new Guild() { GuildName = "곧 삭제될 길드" };
                // 위에서 아이템이 이미 DB에 들어간 상태 (DB 키 있음)
                p.OwnedItem = items[0];

                db.Players.Remove(p);

                // Player를 직접적으로 삭제하니까,,
                Console.WriteLine("3번)" + db.Entry(p).State); // Deleted
                Console.WriteLine("4번)" + db.Entry(p.Guild).State); // Added
                Console.WriteLine("5번)" + db.Entry(p.OwnedItem).State); // Deleted

            }

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

        public static void CalcAverage()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (double? average in db.Items.Select(i => Program.GetAverageReviewScore(i.ItemId)))
                {
                    if (average == null)
                        Console.WriteLine("No Review!");
                    else
                        Console.WriteLine($"Average : {average.Value}");
                }
            }
        }



    }
}
