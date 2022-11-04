using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    // 오늘의 주제 : STate (상태)
    // 0) Detached (No Tracking ! 추적되지 않는 상태. SaveChanges를 해도 존재도 모름)
    // 1) Unchanged (DB에 있고, 딱히 수정사항도 없었음. SaveChanges를 해도 아무 것도 X)
    // 2) Deleted (DB에는 아직 있지만, 삭제되어야 함. SaveChanges로 DB에 적용)
    // 3) Modified (DB에 있고, 클라에서 수정된 상태, SaveChanges로 DB에 적용)
    // 4) Added (DB에는 아직 없음, SaveChanges로 DB에 적용)

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


        // Update 3단계
        // 1) Tracked Entitiy를 얻어 온다
        // 2) Entity 클래스의 property를 변경 (set)
        // 3) SaveChanges 호출!

        // 그런데 궁금한 점!
        // update를 할 때 전체 수정을 하는 것일까? 수정사항이 있는 애들만 골라서 하는 것일까?

        // 1) SaveChanges 호출 할 때 -> 내부적으로 DetectChanges 호출
        // 2) DetectChange에서 -> 최초 Snapshop / 현재 Snapshot 비교

        /*
         
        SELECT TOP(2) GuildId, GuildName
        FROM [Guilds]
        WHERE GuildName = N'T1';

        SET NOCOUNT ON;
        UPDATE [Guilds]
        SET GuildName = @p0
        WHERE GuildId = @p1;
        SELECT @@ROWCOUNT;
         
         */
        public static void UpdateTest()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // 최초
                var guild = db.Guilds.Single(g => g.GuildName == "T1");

                guild.GuildName = "DWG";
                // 현재

                db.SaveChanges();
            }
        }

    }
}
