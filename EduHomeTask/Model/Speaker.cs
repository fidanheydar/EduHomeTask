using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeTask.Model
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string ImageUrl { get; set; }
        public override string ToString()
        {
            return $"{Id}.{FullName}-{Position}-{Company}-{ImageUrl}";
        }
    }
}
