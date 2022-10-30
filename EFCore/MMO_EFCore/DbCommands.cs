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

        // 오늘의 주제 : STate (상태)
        // 0) Detached (No Tracking ! 추적되지 않는 상태. SaveChanges를 해도 존재도 모름)
        // 1) Unchanged (DB에 있고, 딱히 수정사항도 없었음. SaveChanges를 해도 아무 것도 X)
        // 2) Deleted (DB에는 아직 있지만, 삭제되어야 함. SaveChanges로 DB에 적용)
        // 3) Modified (DB에 있고, 클라에서 수정된 상태, SaveChanges로 DB에 적용)
        // 4) Added (DB에는 아직 없음, SaveChanges로 DB에 적용)


        // SaveChanges 호출하면 어떤 일이?
        // 1) 추가된 객체들의 상태가 Unchanged로 바뀜
        // 2) SQL Identity PK를 관리
        // - 데이터 추가 후 ID 받아와서 객체의 ID property를 채워준다
        // - Relationship 참고해서, FK 세팅 및 객체 참조 연결

        // 이미 존재하는 사용자를 연동하려면?
        // 1) Tracked instance (추적되고 있는 객체)를 얻어와서
        // 2) 데이터 연결

        public static void CreateTestData(AppDbContext db)
        {
            var Gunal = new Player() { Name = "Gunal" };
            var Faker = new Player() { Name = "Faker" };
            var Dohee = new Player() { Name = "Dohee" };

            // 1) Detached
            // Console.WriteLine(db.Entry(Gunal).State);

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

            //db.Players.Add(Gunal);
            db.Items.AddRange(items);
            db.Guilds.Add(guild);

            // 2) Added
            // Console.WriteLine(db.Entry(Gunal).State);

            // Console.WriteLine(Gunal.PlayerId);

            db.SaveChanges();

            {
                var owner = db.Players.Where(p => p.Name == "Gunal").First();

                Item item = new Item()
                {
                    TemplateId = 300,
                    CreateDate = DateTime.Now,
                    Owner = owner
                };
                db.Items.Add(item);
                db.SaveChanges();
                
            }

            // Console.WriteLine(Gunal.PlayerId);

            // 3) Unchanged
            // Console.WriteLine(db.Entry(Gunal).State);
        }

    }
}
