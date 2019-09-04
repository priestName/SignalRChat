using SignalRChat.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class SockedUserSett
    {
        private static TestSocked _dbContext = DbContextFactory.GetIntance();
        private static DbSet<SockedUser> _UserdbSet = _dbContext.Set<SockedUser>();
        public bool AddUser(SockedUser sockedUser)
        {
            _UserdbSet.Add(sockedUser);
            return _dbContext.SaveChanges() > 0;
        }
        public SockedUser SetUser(SockedUser sockedUser)
        {
            List<SockedUser> UserList = new List<SockedUser> { } ;
            if (string.IsNullOrEmpty(sockedUser.Password))
            {
                UserList = _UserdbSet.Where(u => u.Name == sockedUser.Name).ToList();
            }
            else {
                UserList = _UserdbSet.Where(u => u.Name == sockedUser.Name && u.Password == sockedUser.Password).ToList();
            }

            return UserList.First() ?? null;
        }
        public bool UpdateUser(SockedUser sockedUser)
        {
            _UserdbSet.Attach(sockedUser);
            return _dbContext.SaveChanges() > 0;
        }
        public bool DelUser(SockedUser sockedUser)
        {
            _UserdbSet.Remove(sockedUser);
            return _dbContext.SaveChanges() > 0;
        }
    }
}