using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Business.Coomon
{
    public class Descriptor
    {
        public OrderBy? orderBy { get; set; }
        public Pagination? pagination { get; set; }
        public Filter[]? filter { get; set; }

    }
    public class OrderBy
    {
        public String orderName { get; set; }
        public String OrderType { get; set; }

    }
    public class Pagination
    {

        public int pageSize { get; set; }
        public int pageIndex { get; set; }

    }
    public class Filter
    {

        public String ColName { get; set; }
        public String Opration { get; set; }  // in , Equal , like
        public String ColValue { get; set; }

    }

    public static class DescriptorProccer
    {

        public static IQueryable<T> QuryExcuter<T>(Descriptor descriptor, IQueryable<T> query)
        {



            if (descriptor.pagination?.pageIndex != null)
            {
                query = query.Skip(((int)descriptor.pagination.pageIndex - 1) * (int)descriptor.pagination.pageSize);

            }

            if (descriptor.pagination?.pageSize != null)
            {
                query = query.Take((int)descriptor.pagination.pageSize);
            }


            if (descriptor.orderBy?.orderName != null && descriptor.orderBy?.OrderType != null)
            {
                if (descriptor.orderBy.OrderType == "DESC" || descriptor.orderBy.OrderType == "ASC")
                    query = query.OrderBy(descriptor.orderBy.orderName + " " + descriptor.orderBy.OrderType);

            }



            foreach (var item in descriptor.filter)
            {

                switch (item.Opration.ToLower())
                {
                    case "in":
                        query = query.Where(item.ColName + " in ( " + item.ColValue + ")");

                        break;


                    case "equal":

                        query = query.Where($"{item.ColName} = \"{item.ColValue}\" ");

                        break;

                    case "contains":
                        query = query.Where($"{item.ColName}.Contains(\"{item.ColValue}\")");

                        break;

                    case "betweenNumeric":
                        String[] bteewns = item.ColValue.Split(',');
                        query = query.Where($"{item.ColName} >= @0.start && {item.ColName} <= @0.end", new { start = int.Parse(bteewns[0]), end = int.Parse(bteewns[1]) }); ;
                        break;

                    case "betweenDate":
                        String[] bteewnsDate = item.ColValue.Split(',');
                        query = query.Where($"{item.ColName} >= @0.start && {item.ColName} <= @0.end", new { start = DateTime.Parse(bteewnsDate[0]), end = DateTime.Parse(bteewnsDate[1]) }); ;
                        break;

                    default:
                        break;
                }



            }




            return query;
        }



    }




}
