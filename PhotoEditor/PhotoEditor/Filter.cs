using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    class Filter
    {
        public Filter(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Filter() { }
        private int Id { get; set; }
        
        private String Name { get; set; }    
    }
}
