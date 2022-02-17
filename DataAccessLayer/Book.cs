using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Book
    {
        public int ID { get; set; }
        public int Category_ID { get; set; }
        public string CategoryName { get; set; }
        public int Writer_ID { get; set; }
        public string WriterName { get; set; }
        public int Publisher_ID { get; set; }
        public string PublisherName { get; set; }
        public string Name { get; set; }
        public short NumberOfPage { get; set; }


    }
}
