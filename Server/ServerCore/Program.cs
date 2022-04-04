using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    // [ JobQueue ] -> 일이 있을 때 락을 걸고 최대한 TLS에 옮기고 거기서 일을함. (ThreadLocal)

    class Program
    {
        // 쓰레드 마다 고유하게 갖는 값                                       // ThreadName이 null 일때 여기서 만듬..
        static ThreadLocal<string> ThreadName = new ThreadLocal<string>(() => { return $"My Name is {Thread.CurrentThread.ManagedThreadId}"; }); 
        // static string ThreadName // Program.cs 안에 있는 쓰레드들이 모두 공유

        static void WhoAmI()
        {
            bool repeat = ThreadName.IsValueCreated;
            if(repeat)
                Console.WriteLine(ThreadName.Value + " (repeat)");

            else
                Console.WriteLine(ThreadName.Value);
        }

        static void Main(string[] args)
        {

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(3, 3);

            Parallel.Invoke(WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI);

            ThreadName.Dispose(); // 지우기
        }
    }
}
