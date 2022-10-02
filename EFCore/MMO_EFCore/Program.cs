using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace MMO_EFCore
{
    class Program
    {
        // 초기화 시간이 좀 걸림
        static void InitiakuzeDB(bool forceReset = false)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (!forceReset && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Console.WriteLine("DB INitialized");
            }
        }

        static void Main(string[] args)
        {
            InitiakuzeDB(forceReset: true);
        }
    }
}
