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

        public static void Test()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // FromSql
                {
                    string name = "Gunal";
                    // string name2 = "Anything OR 1=1";
                    // SQL Injection (Web Hacking)

                    var list = db.Players
                        .FromSqlRaw("SELECT * FROM dbo.Player WHERE Name = {0}", name)
                        .Include(p => p.OwnedItem)
                        .ToList();

                    foreach (var p in list)
                    {
                        Console.WriteLine($"{p.Name}, {p.PlayerId}");
                    }

                    // String Interpolation C#6.0
                    var list2 = db.Players
                        .FromSqlInterpolated($"SELECT * FROM dbo.Player WHERE Name = {name}")
                        .ToList();

                    foreach (var p in list2)
                    {
                        Console.WriteLine($"{p.Name}, {p.PlayerId}");
                    }

                }

                // ExcuteSqlCommand (Non-Query SQL) + Reload
                {
                    Player p = db.Players.Single(p => p.Name == "Faker");

                    string prevName = "Faker";
                    string afterName = "Faker_New";
                    db.Database.ExecuteSqlInterpolated($"UPDATE dbo.Player SET Name = {afterName} WHERE Name = {prevName}");

                    db.Entry(p).Reload();
                    Console.WriteLine(p.Name);
                }
            }
        }



    }
}
