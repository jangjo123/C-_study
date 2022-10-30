using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
                    CreateDate = DateTime.Now,
                    Owner = Gunal
                },

                new Item()
                {
                    TemplateId = 102,
                    CreateDate = DateTime.Now,
                    Owner = Faker
                },

                new Item()
                {
                    TemplateId = 103,
                    CreateDate = DateTime.Now,
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
            db.SaveChanges();
        }

        // 1 + 2) 특정 길드에 있는 길드원들이 소지한 모든 아이템들을 보고 싶다!

        // 장점 : DB 접근 한 번으로 다 로딩 (JOIN)
        // 단점 : 다 필요한지 모르겠는데?
        public static void EagerLoading()
        {
            Console.WriteLine("길드 이름을 입력하세요");
            Console.Write(" > ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                Guild guild = db.Guilds.AsNoTracking()
                    .Where(g => g.GuildName == name)
                    .Include(g => g.Members)
                        .ThenInclude(p => p.Item)
                    .First();

                foreach (Player player in guild.Members)
                {
                    Console.WriteLine($"ItemId({player.Item.TemplateId}) Owner({player.Name}) ");
                }
            }
        }

        // 장점 : 필요한 시점에 필요한 데이터만 로딩 가능
        // 단점 : DB 접근 비용
        public static void ExplicitLoading()
        {
            Console.WriteLine("길드 이름을 입력하세요");
            Console.Write(" > ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                Guild guild = db.Guilds
                    .Where(g => g.GuildName == name)
                    .First();

                // 명시적
                db.Entry(guild).Collection(g => g.Members).Load();

                foreach (Player player in guild.Members)
                {
                    db.Entry(player).Reference(p => p.Item).Load();
                }

                foreach (Player player in guild.Members)
                {
                    Console.WriteLine($"ItemId({player.Item.TemplateId}) Owner({player.Name}) ");
                }
            }
        }

        // 3) 특정 길드에 있는 길드원 수는?

        // SELECT COUNT(*)
        // 장점 : 필요한 정보만 쏘옥 빼서 로딩
        // 단점 : 일일히 Select 안에 만드렁줘야 함
        public static void SelectLoading()
        {
            Console.WriteLine("길드 이름을 입력하세요");
            Console.Write(" > ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var info = db.Guilds
                    .Where(g => g.GuildName == name)
                    .MapGuildToDto()
                    .First();

                Console.WriteLine($"GuildName({info.Name}), MemberCount({info.MemberCount})");
            }
        }
    }
}
