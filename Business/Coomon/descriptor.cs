using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
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


    public static class DescriptorProccer {


        public static IQueryable<T> QuryExcuter<T>(Descriptor descriptor , IQueryable<T> query)
        {

           

            if (descriptor.pagination.pageIndex != null)
            {
                query = query.Skip(((int)descriptor.pagination.pageIndex - 1) * (int)descriptor.pagination.pageSize);
             
            }

            if (descriptor.pagination.pageSize != null)
            {
                query = query.Take((int)descriptor.pagination.pageSize);
            }



            if (descriptor.orderBy.orderName != null && descriptor.orderBy.OrderType == "DESC")
            {


                //var param = "Address";
                //var pi = typeof(T).GetProperty(param);
                //var orderByAddress = query.OrderBy(x => pi.GetValue(x, null));

                query.OrderBy(descriptor.orderBy.orderName + " " + descriptor.orderBy.OrderType);
               
            }
          

            return query;
        }
    
    
    
    }




}
