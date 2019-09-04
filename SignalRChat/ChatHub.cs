using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using SignalRChat.Model;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        
        public static List<UserList> users = new List<UserList>();
        public void Send(string name, string message)
        {
            //调用BroadcastMessage方法来更新客户端
            Clients.All.broadcastMessage(name, message);
        }
        
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = users.Where(p => p.ConnectionID == Context.ConnectionId).FirstOrDefault();
            //判断用户是否存在，存在则删除  
            if (user != null)
            {
                //删除用户  
                users.Remove(user);
            }
            GetUsers();//获取所有用户的列表  
            return base.OnDisconnected(stopCalled);
        }
        private void GetUsers()
        {
            var list = users.Select(s => new { s.Name, s.ConnectionID }).ToList();
            string jsonList = JsonConvert.SerializeObject(list);
            Clients.All.getUsers(jsonList);
        }

        /// <summary>  
        /// 重写连接事件  
        /// </summary>  
        /// <returns></returns>  
        public override Task OnConnected()
        {
            //查询用户  
            var user = users.Where(w => w.ConnectionID == Context.ConnectionId).SingleOrDefault();
            //判断用户是否存在，否则添加集合  
            if (user == null)
            {
                user = new UserList("", Context.ConnectionId);
                users.Add(user);
            }
            return base.OnConnected();
        }

        
    }
    public class UserList
    {
        public string ConnectionID { get; set; }
        public string Name { get; set; }
        public UserList(string name, string connectionId)
        {
            this.Name = name;
            this.ConnectionID = connectionId;
        }
    }
}