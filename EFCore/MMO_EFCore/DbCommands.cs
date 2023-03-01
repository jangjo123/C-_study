﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
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

        
        // 1) Tracking Entitiy를 얻어오고
        // 2) Remove 호출
        // 3) SaveChanges 호출
        public static void TestDelete()
        {
            ShowItems();

            Console.WriteLine("Select Delete ItemId");
            Console.WriteLine(" > ");
            int id = int.Parse(Console.ReadLine());

            using (AppDbContext db = new AppDbContext())
            {
                Item item = db.Items.Find(id); // db.Find<Item>(id)
                // db.Items.Remove(item);
                item.SoftDeleted = true;
                db.SaveChanges();
            }

            Console.WriteLine("-- TestDelete Complete --");
            ShowItems();

        }
    }
}
