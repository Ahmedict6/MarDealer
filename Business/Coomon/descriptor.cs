using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Coomon
{
    public class Descriptor
    {
        public OrderBy orderBy { get; set; }
        public Pagination pagination { get; set; }
        public String[] Filter { get; set; }


    }
    public class OrderBy
    {

        public String orderName {  get; set; }
        public String OrderType {  get; set; }


    }
    public class Pagination
    {

        public int pageSize { get; set; }
        public int pageIndex { get; set; }

    }
}
