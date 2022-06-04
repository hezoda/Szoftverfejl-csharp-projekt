using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torpedo.Model;

namespace Torpedo.Repositories
{
    public static class ResultRepository
    {
        public static void Eredmeny_Hozzaadas(Result result)
        {
            using (var database = new ResultContext())
            {
                database.Eredmenyek.Add(result);
                database.SaveChanges();
            }

        }
        public static List<Result> Eredmeny_Lekeres()
        {
            using (var database = new ResultContext())
            {
                var result = database.Eredmenyek.ToList();
                return result;
            }

        }
    }
}
