
using Microsoft.EntityFrameworkCore;
using System;

namespace MMO_EFCore
{
    class Program
    {
        // Annotation (Attribute)
        [DbFunction()]
        public static double? GetAverageReviewScore(int ItemId)
        {
            throw new NotImplementedException("사용 금지!");
        }

        static void Main(string[] args)
        {
            DbCommands.InitiakuzeDB(forceReset: false);

            // CRUD (Create-Read-Update-Delete)
            Console.WriteLine("명령어를 입력하세요");
            Console.WriteLine("[0] ForceReset");
            Console.WriteLine("[1] ShowItems");
            Console.WriteLine("[2] CalcAverage");

            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        DbCommands.InitiakuzeDB(forceReset: true);
                        break;
                    case "1":
                        DbCommands.ShowItems();
                        break;
                    case "2":
                        DbCommands.CalcAverage();
                        break;
                    case "3":
                        break;
                }
            }
        }
    }
}
