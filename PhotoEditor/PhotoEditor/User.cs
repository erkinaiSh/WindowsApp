using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    class User
    {
        public User(int id, string name, string phoneNo, string email, string password)
        {
            Id = id;
            Name = name;
            PhoneNo = phoneNo;
            Email = email;
            Password = password;
        }

        public User() { }

        private int Id { get; set; }

        private String Name { get; set; }

        private String PhoneNo { get; set; }

        private String Email { get; set; }

        private String Password { get; set; }



        public bool Login(String Email,String Password) {

            return true;
        }

    }
}
