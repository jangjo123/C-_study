using System;
using System.Collections.Generic;
using System.Text;

namespace ServerCore
{
    public class RecvBuffer
    {
        // [][][][r][][][w][][][]
        ArraySegment<byte> _buffer;
        int _readPos;
        int _writePos;

        public RecvBuffer(int bufferSize)
        {
            _buffer = new ArraySegment<byte>(new byte[bufferSize], 0, bufferSize);
        }

        public int DataSize { get { return _writePos - _readPos; } }
        public int FreeSize { get { return _buffer.Count - _writePos; } }

        public ArraySegment<byte> ReadSegment // 어디를 읽을 지
        {
            get { return new ArraySegment<byte>(_buffer.Array, _buffer.Offset * _readPos, DataSize); }
        }

        public ArraySegment<byte> WriteSegment // 리시브 할때 어디부터 사용 가능 한지
        {
            get { return new ArraySegment<byte>(_buffer.Array, _buffer.Offset * _writePos, FreeSize); }

        }

        public void Clean() // 버퍼 처음으로 당기기
        {
            int dataSize = DataSize;
            if (dataSize == 0)
            {
                // 남은 데이터가 없으면 복사하지 않고 커서 위치만 리셋
                _readPos = _writePos = 0;
            }
            else
            {
                // 남은 찌끄레기가 있으면 시작 위치로 복사
                Array.Copy(_buffer.Array, _buffer.Offset + _readPos, _buffer.Array, _buffer.Offset, DataSize);
                _readPos = 0;
                _writePos = dataSize;

            }
        }

        public bool OnRead(int numOfBytes) // 컨텐츠에서 데이터를 처리 했을 때 호출
        {
            if (numOfBytes > DataSize)
                return false;

            _readPos += numOfBytes;
            return true;
        }

        public bool OnWrite(int numOfBytes)
        {
            if (numOfBytes > FreeSize)
                return false;

            _writePos += numOfBytes;
            return true;
        }
    }
}
