using DummyClient;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Text;

class PacketHandler
{
	public static void S_BroadcastEnterGameHandler(PacketSession session, IPacket packet)
	{
		S_BroadcastEnterGame pkt = packet as S_BroadcastEnterGame;
		ServerSession serverSession = session as ServerSession;

	}

	public static void S_BroadcastLeaveGameHandler(PacketSession session, IPacket packet)
	{
		S_BroadcastLeaveGame pkt = packet as S_BroadcastLeaveGame;
		ServerSession serverSession = session as ServerSession;

	}

	public static void S_playerListHandler(PacketSession session, IPacket packet)
	{
		S_playerList pkt = packet as S_playerList;
		ServerSession serverSession = session as ServerSession;

	}

	public static void S_BoradcastMoveHandler(PacketSession session, IPacket packet)
	{
		S_BoradcastMove pkt = packet as S_BoradcastMove;
		ServerSession serverSession = session as ServerSession;

	}
}
