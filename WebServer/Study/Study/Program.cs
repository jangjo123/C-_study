using System;
using System.Threading.Tasks;

namespace Study
{
    // async/awiat
    // async 이름만 봐도.. 비동기 프로그래밍!
    // 게임서버) 비동기 = 멀티쓰레드? -> 꼭 그렇지는 않습니다.
    // 유니티) Coroutine = 일종의 비동기 but 싱글쓰레드


    class Program
    {
        static Task Test()
        {
            Console.WriteLine("Start Test");
            Task t = Task.Delay(3000);
            return t;
        }

        // 아이스 아메리카노를 제조 중 (1분)
        // 주문 대기
        static async Task<int> TestAsync()
        {
            Console.WriteLine("Start TestAsync");
            //Task t = Task.Delay(3000);

            //await t;
            await Task.Delay(3000); // 복잡한 작업
            Console.WriteLine("end TestAsync");
            return 1;

        }

        static async Task Main(string[] args)
        {
            //Task t = Test();
            //t.Wait();
            Task<int> t = TestAsync();

            Console.WriteLine("while start");
            
            int ret = await t;
            Console.WriteLine(ret);


            while (true)
            {

            }
        }
    }
}
