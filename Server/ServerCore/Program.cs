using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static int number = 0;
        static object _obj = new object();

        static void Thread_1()
        {

            for (int i = 0; i < 100000; i++)
            {
                // 상호배제 Mutual Exclusive
                lock (_obj) // try, finally 예시와 비슷하게 동작함
                {
                    number++;
                }

                //try 
                //{
                //    Monitor.Enter(_obj);
                //    number++;

                //    return;
                //}
                //finally // 데드락 해결
                //{
                //    Monitor.Exit(_obj);
                //}

                //Monitor.Enter(_obj); // 문을 잠구는 행위

                //{
                //    number++;
                //    return; // 문을 안열고 나감.. (데드락, DeadLock)
                //}

                //Monitor.Exit(_obj); // 잠금을 풀어준다.
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_obj) // try, finally 예시와 비슷하게 동작함
                {
                    number--;
                }
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
