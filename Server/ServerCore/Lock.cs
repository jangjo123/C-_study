using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ServerCore
{
    // 재귀적 락을 허용할지 (Yes) WriteLock -> WriteLcok OK, WriteLock -> ReadLock OK, ReadLock -> WriteLock NO
    // 스핀락 정책 (5000번 -> Yield)

    class Lock
    {
        const int EMPTY_FLAG = 0x00000000;
        const int WRITE_MASK = 0x7FFF0000;
        const int READ_MASK = 0x0000FFFF;
        const int MAX_SPIN_COUNT = 5000;

        // [Unused(1bit) [WriteThreadId(15bit)] [ReadCount(16bit)]]

        int _flag = EMPTY_FLAG;
        int _wirteCount = 0;

        public void WriteLock()
        {
            // 동일 쓰레드가 WriteLock을 이미 흭득하고 있는지 확인
            int lockThreadId = (_flag & WRITE_MASK) >> 16;
            if (Thread.CurrentThread.ManagedThreadId == lockThreadId)
            {
                _wirteCount++;
                return;
            }

            // 아무도 WriteLcok or ReadLock을 흭득하고 있지 않을 때, 경합해서 소유권을 얻는다.
            int desired = (Thread.CurrentThread.ManagedThreadId << 16) & WRITE_MASK; // Thread.CurrentThread.ManagedThreadId 쓰레드 마다 1씩 커지는 ID 부여 write이기 때문에 16비트 이동
            while (true)
            {
                for (int i = 0; i < MAX_SPIN_COUNT; i++)
                {
                    if (Interlocked.CompareExchange(ref _flag, desired, EMPTY_FLAG) == EMPTY_FLAG)
                    {
                        _wirteCount = 1;
                        return;
                    }
                }

                Thread.Yield();
            }
        }

        public void WriteUnlock()
        {
            int lockCount = --_wirteCount;
            if (lockCount == 0)
                Interlocked.Exchange(ref _flag, EMPTY_FLAG); // 문닫기 
        }

        public void ReadLock()
        {
            // 동일 쓰레드가 WriteLock을 이미 흭득하고 있는지 확인
            int lockThreadId = (_flag & WRITE_MASK) >> 16;
            if (Thread.CurrentThread.ManagedThreadId == lockThreadId)
            {
                Interlocked.Increment(ref _flag);
                return;
            }

            // 아무도 WriteLcok을 흭득하고 있지 않으면 ReadCount를 1 늘린다.
            while (true)
            {
                for (int i = 0; i < MAX_SPIN_COUNT; i++)
                {
                    int expected = (_flag & READ_MASK); // 예상하는 값 Writeflag를 밀어버림
                    if (Interlocked.CompareExchange(ref _flag, expected + 1, expected) == expected) // _flag에 writeflag가 있었다면 통과하지 못함.
                        return;
                }

                Thread.Yield();
            }
        }

        public void ReadUnlock()
        {
            Interlocked.Decrement(ref _flag); // _flag--;
        }
    }
}
