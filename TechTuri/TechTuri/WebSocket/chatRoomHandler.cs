using System.Net.WebSockets;
using System.Text;

namespace TechTuri.WebSocket
{
    public class chatRoomHandler:WebSocketHandler
    {
        public chatRoomHandler(ConnectionManager wsCM) : base(wsCM) { }

        public override async Task ReceiveAsync(System.Net.WebSockets.WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = $"uj item: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
        }
    }
}
