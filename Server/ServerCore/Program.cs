using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class SpinLock
    {
        int _locked = 0;

        public void Acquire()
        {
            while (true)
            {
                //int original = Interlocked.Exchange(ref _locked, 1); // 원본 값을 반환하고 value값으로 변환

                //if (original == 0)
                //    break;

                // CAS Compare-And-Swap
                int expected = 0; // 예상하는 값
                int desired = 1; // 원하는 값
                // int original = Interlocked.CompareExchange(ref _locked, desired, expected); // 원본 값을 반환하고 _locked와 0이 같으면 _locked이 1
                if (Interlocked.CompareExchange(ref _locked, desired, expected) == expected)
                    break;
            }


        }

        public void Release()
        {
            _locked = 0;
        }
    }

    class Program
    {
        static int _num = 0;
        static SpinLock _lock = new SpinLock();

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire();
                _num++;
                _lock.Release();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire();
                _num--;
                _lock.Release();
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);
        }
    }
}
