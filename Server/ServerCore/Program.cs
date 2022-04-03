using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{

    class Program
    {
        static int _num = 0;

        // AutoResetEvent는 bool 정보만.. (잠금 유무)

        // int (몇개 잠궜는지) ThreadID
        static Mutex _lock = new Mutex(); // 커널 동기화 객체

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _lock.WaitOne();
                _num++;
                _lock.ReleaseMutex();
                _lock.ReleaseMutex();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _num--;
                _lock.ReleaseMutex();
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
