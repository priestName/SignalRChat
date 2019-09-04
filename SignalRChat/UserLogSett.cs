using SignalRChat.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class UserLogSett
    {
        private static TestSocked _dbContext = DbContextFactory.GetIntance();
        private static DbSet<UserLogs> _UserLogdbSet = _dbContext.Set<UserLogs>();
        private static DbSet<SockedUser> _UserdbSet = _dbContext.Set<SockedUser>();
        public bool AddUserLog(UserLogs userLogs)
        {
            _UserLogdbSet.Add(userLogs);
            return _dbContext.SaveChanges() > 0;
        }
        public List<UserLogs> SetUserLog()
        {
            
            //var aa = _UserLogdbSet.Join(
            //                _UserdbSet,//join 对象
            //                userlog => userlog.UserId,//外部的key
            //                userlist => userlist.ID,//内部的key
            //                (userlog, userlist) => new//结果
            //                {
            //                    userlog.Message,
            //                    userlog.Operate,
            //                    userlog.AddTime,
            //                    userlist.Name
            //                }).ToList();

            return _UserLogdbSet.Where(u => true).ToList();
        }
    }
}