using MyCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyCv.Repo
{
    public class GenericRepository<X> where X : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<X> List()
        {
            return db.Set<X>().ToList();
        }

        public void XAdd(X p)
        {
            db.Set<X>().Add(p);
            db.SaveChanges();
        }

        public void Delete(X p)
        {
            db.Set<X>().Remove(p);
            db.SaveChanges();
        }

        public X XGet(int id)
        {
            return db.Set<X>().Find(id);
        }

        public void XUpdate(X p)
        {
            db.SaveChanges();
        }

        public X Find(Expression<Func<X, bool>> where)
        {
            return db.Set<X>().FirstOrDefault(where);
        }
    }
}