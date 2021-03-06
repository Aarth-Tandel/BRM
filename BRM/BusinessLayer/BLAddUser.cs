﻿using System.Linq;
using DatabaseLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class BLAddUser
    {
        public BRMContext db = new BRMContext();
        

        public void AddUser(string firstName, string lastName, string username, string password, string email)
        {
            UserDetails user = new UserDetails();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Username = username;
            user.Password = password;
            user.Email = email;

            db.UserContext.Add(user);
            db.SaveChanges();
        }

        public bool CheckUser(string username)
        {
            if (db.UserContext.Any(o => o.Username == username))    return false;
            else return true;
        }
    }
}
