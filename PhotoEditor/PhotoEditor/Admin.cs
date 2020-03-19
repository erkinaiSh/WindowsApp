using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    public class Admin : User
    {
        
        private List<Client> Clients { get; set; }

        private Client Client { get; set; }

        public Admin(int id, string name, string phoneNo, string email, string password) : base(id, name, phoneNo, email, password)
        {
            
        }

        public Admin() { }

        public Client getClient(int Id) {

            return Client;
        }

        public bool deleteClient(int Id)
        {
            return true;
        }

        public bool addFilter(int Id,int Name) {

            return true;
        }

        public bool deleteFilter(int Id) {

            return true;
        }

    }
}
