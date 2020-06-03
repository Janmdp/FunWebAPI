using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsClasslibrary;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFUser
    {
        private DataContext _db;
        public EFUser(DataContext db)
        {
            _db = db;
        }
        public void DeleteById(int Id)
        {
            var result = _db.Users.SingleOrDefault(b => b.UserId == Id);
            if (result != null)
            {
                result.Active = 0;
                _db.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            var accounts = _db.Users.ToList();
            List<User> result = new List<User>();
            foreach (EFUser account in accounts)
            {
                result.Add(new User()
                {
                    UserId = account.UserId,
                    Username = account.Username,
                    Password = account.Password,
                    Active = account.Active,
                    Email = account.Email
                });
            }
            return result;
        }

        public User GetById(int Id)
        {
            return Converter.ToUser(_db.Users.Find(Id));
        }

        public void UpdateById(int id, User user)

        {
            User newversion = user;
            var result = _db.Users.SingleOrDefault(u => u.UserId == id);
            if (result != null)
            {
                result.Username = newversion.Username;
                result.Password = newversion.Password;
                result.Email = newversion.Email;
                result.Active = newversion.Active;
                _db.SaveChanges();
            }
        }
        public void Add(User user)
        {
            EFUser newUser = new EFUser()
            {
                Active = user.Active,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email
            };
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        public User Login(User Login)
        {
            EFUser returned = _db.Users.SingleOrDefault(a => a.Email == Login.Email && a.Password == Login.Password);
            User LoggedIn = new User()
            {
                UserId = returned.UserId,
                Active = returned.Active,
                Email = returned.Email,
                Password = returned.Password,
                Username = returned.Username
            };
            return LoggedIn;
        }
    }
}
