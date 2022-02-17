using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Manager
    {
        public int ID { get; set; }
        public int ManagerTypeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string mPassword { get; set; }
        public bool mStatus { get; set; }
    }
}
