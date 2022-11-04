
using System;

namespace MMO_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            DbCommands.InitiakuzeDB(forceReset: false);

            // CRUD (Create-Read-Update-Delete)
            Console.WriteLine("명령어를 입력하세요");
            Console.WriteLine("[0] ForceReset");

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
                        DbCommands.UpdateTest();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                }
            }
        }
    }
}
