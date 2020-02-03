using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    class Image
    {
        public Image(int id, string name, string type, DateTime date)
        {
            Id = id;
            Name = name;
            Type = type;
            Date = date;
        }

        public Image() { }

        private int Id { get; set; }

        private String Name { get; set; }

        private String Type { get; set; }

        private DateTime Date { get; set; }

    }
}
