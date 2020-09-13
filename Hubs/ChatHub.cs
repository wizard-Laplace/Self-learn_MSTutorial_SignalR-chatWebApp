using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    // Hubはクライアントサーバー通信を処理するハイレベルパイプラインとして機能するクラス
    // Hubクラスでは、接続、グループ、およびメッセージングが管理される
    public class ChatHub : Hub
    {
        /// <summary>
        /// メッセージをすべてのクライアントに送信する為に、接続されたクラインとによって呼び出される場合があります。
        /// 最大のスケーラビリティｗ実現するために、SignalRコードは非同期とする
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}