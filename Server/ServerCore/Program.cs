using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{

    class Program
    {
        // 1. 근성
        // 2. 양보
        // 3. 갑질

        // 상호배제
        // Monitor
        static object _lock = new object(); 
        static SpinLock _lock2 = new SpinLock(); // 너무 안되면 잠깐 yield
        // 직접 만든다.

        

        static void Main(string[] args)
        {
            lock (_lock)
            {

            }

            bool lockTaken = false; // 결과물
            try
            {
                _lock2.Enter(ref lockTaken);
            }
            finally
            {
                if (lockTaken)
                    _lock2.Exit();
            }

        }
    }
}
