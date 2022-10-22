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
            var player = new Player()
            {
                Name = "Gunal"
            };

            List<Item> items = new List<Item>()
            {
                new Item()
                {
                    TemplateId = 101,
                    CreateDate = DateTime.Now,
                    Owner = player
                },

                new Item()
                {
                    TemplateId = 102,
                    CreateDate = DateTime.Now,
                    Owner = player
                },

                new Item()
                {
                    TemplateId = 103,
                    CreateDate = DateTime.Now,
                    Owner = new Player() { Name = "Dohee" }
                }
            };

            db.Items.AddRange(items);
            db.SaveChanges();
        }

        public static void ReadAll()
        {
            using (var db = new AppDbContext())
            {
                // AsNoTracking : ReadOnly << Tracking Snapshot이라고 데이터 변경 탐지하는 것 때문
                // Include : Eager Loading (즉시 로딩) << 나중에 알아볼 것
                foreach (Item item in db.Items.AsNoTracking().Include(i => i.Owner))
                {
                    Console.WriteLine($"TemplateId({item.TemplateId}) Owner({item.Owner.Name}) Created({item.CreateDate})");
                }
            }
        }

        public static void ShowItems()
        {
            Console.WriteLine("플레이어 이름을 입력하세요");
            Console.WriteLine(" > ");
            string name = Console.ReadLine();

            //using(var db = new AppDbContext())
            //{
            //    foreach(Player player in db.Players.AsNoTracking().Where(p => p.Name == name).Include(p => p.Items))
            //    {
            //        foreach (Item item in player.Items)
            //        {
            //            Console.WriteLine($"{item.TemplateId}");
            //        }
            //    }
            //}
        }



    }
}
