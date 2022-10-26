using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entitiy;

namespace MvcCv.Repositories
{
    public class GenericRepositories<T> where T : class, new()
    {
        DbCvEntities1 db = new DbCvEntities1();
        public List<T> List() {
            return db.Set<T>().ToList();
        }
        public void tAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void tDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T tGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void tUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return (T)db.Set<T>().FirstOrDefault(where);   //İlk değeri getir.
        }

    }
    
}