using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static int number = 0;

        static void Thread_1()
        {
            // atomic  = 원자성

            // 검 구매 과정
            // 골드 -= 100;
                // 서버 다운(골드는 줄고 검은 안사짐)
            // 인벤 += 검
            
            // 집행검 User2 인벤이 넣어라 - Ok
            // 집행검 User1 인벤에서 없애라 - fail (아이템 복사 문제)

            for (int i = 0; i < 100000; i++)
            {
                // ref를 넣는 이유: number를 참조해야 원자적이게 됨. 

                int affterValue = Interlocked.Increment(ref number); // 원자적으로 이뤄지게 보정 (성능 손해)

                //number++;

                // 어셈블리에서 number++ 이 돌아가는 과정 느낌
                //int temp = number; // 0
                //temp += 1; // 1
                //number = temp; // number = 1
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);

                // number--;
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
