using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    public class Client : User
    {
        private List<Image> Images { get; set; }

        private Image Image { get; set; }

        public Client(int id, string name, string phoneNo, string email, string password) : base(id, name, phoneNo, email, password)
        {
        }

        public Client() { }


        public bool addImage(Image I) {

            return true;
        }

        public List<Image> getAllImages() {

            return Images;
        }

        public Image getImage(int Id) {

            return Image;
        }

        public bool updateImage(Image I,int UID)
        {

            return true;
        }

        public bool deleteImage(int Id)
        {

            return true;
        }

        public bool DownloadImage(int Id, int UID) {

            return true;
        }
    }
}
