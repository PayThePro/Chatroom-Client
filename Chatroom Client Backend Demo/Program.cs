﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatroom_Client_Backend;
using Chatroom_Client_Backend.Packets.ClientPackets;

namespace Chatroom_Client_Backend_Demo
{
	class Program
	{
		public static int clientID;

		static void Main(string[] args)
		{
			bool running = true;
			string nickName = "Kresten";
			// Starter klienten
			NetworkClient client = new NetworkClient(nickName);
			bool connected = client.Connect("10.29.133.16", 25565);

			client.onUserIDReceivedAction += onUserIDReceivedActionMethod;
			
			Console.WriteLine(connected);
			
			while (running)
			{
				client.Update();

				string input = Console.ReadLine();
				
				switch (input)
				{
					case "2":
						client.SendPacket(new SendMessagePacket("Hej kresten!"));
						break;
					case "4":
						client.SendPacket(new TellNamePacket(nickName));
						break;
					case "10":
						client.SendPacket(new DisconnectPacket());
						break;
					case "start":
						Main(new string[0]);
						break;
					default:
						break;
				}
			}
		}

		private static void onUserIDReceivedActionMethod(int id)
		{
			clientID = id;
		}
	}
}
