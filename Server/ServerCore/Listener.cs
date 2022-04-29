using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    public class Listener
    {
        Socket _listenSocket;
        Func<Session> _sessionFactory;

        public void init(IPEndPoint endPoint, Func<Session> sessionFactory)
        {
            // 문지기
            _listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _sessionFactory += sessionFactory;

            // 문지기 교육
            _listenSocket.Bind(endPoint);

            // 영업 시작
            // backlog : 최대 대기수 (Listen(backlog))
            _listenSocket.Listen(10);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            RegisterAccept(args); // Register -> 등록하다

        }

        void RegisterAccept(SocketAsyncEventArgs args)
        {
            args.AcceptSocket = null; // SocketAsyncEventArgs를 재사용할땐 전에 쓴걸 밀어줌

            bool pending = _listenSocket.AcceptAsync(args); // pending -> 보류중 // AcceptAsync -> 비동기화

            if (pending == false)
                OnAcceptCompleted(null, args);

        }

        void OnAcceptCompleted(object sender, SocketAsyncEventArgs args)
        {
            if (args.SocketError == SocketError.Success)
            {
                Session session = _sessionFactory.Invoke();
                session.Start(args.AcceptSocket);
                session.OnConnected(args.AcceptSocket.RemoteEndPoint);
                //_onAcceptHandler.Invoke(args.AcceptSocket); // AcceptSocket -> 대리인 소켓
            }
            else
                Console.WriteLine(args.SocketError.ToString());

            RegisterAccept(args); // 모든 일이 끝나고 새롭게 등록
        }
    }
}
