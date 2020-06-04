using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using ModelsClasslibrary.Users;

namespace FunWebAPI.CRUD
{
    public class UserCRUD
    {
        EFUser Account = null;

        public UserCRUD(DataContext db)
        {
            Account = new EFUser(db);
        }
        public User DeleteById(int Id)
        {
           return Account.DeleteById(Id);
        }

        public List<User> GetAll()
        {
            return Account.GetAll();
        }

        public User GetById(int Id)
        {
            return Account.GetById(Id);
        }
        public void UpdateById(int Id, User user)
        {
            Account.UpdateById(Id, user);
        }

        public void Add(User user)
        {
            Account.Add(user);
        }

        public User Login(User user)
        {
            return Account.Login(user);
        }
    }
}
