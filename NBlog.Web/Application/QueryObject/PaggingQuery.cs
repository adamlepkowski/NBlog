using System.Collections.Generic;
using System.Linq;

namespace NBlog.Web.Application.QueryObject
{
    public static class PaggingQuery<T> where T : class
    {
        public static List<T> ToPageList(IEnumerable<T>  entries, int pageSize, int page)
        {
            return entries.Skip((page - 1)*pageSize).Take(pageSize).ToList();
        }
    }
}