using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace DAO
{
    //Text  TextModel
    public class DaoBase<T, M> where T : class where M : class
    {
        public static MyDbContext GetDbContext()
        {
            MyDbContext db = CallContext.GetData(typeof(MyDbContext).Name) as MyDbContext;
            if (db == null)
            {
                db = new MyDbContext();
                CallContext.SetData(typeof(MyDbContext).Name, db);
            }
            return db;
        }

        public int GetAffected(M m, string instruct)
        {
            int i = -1;
            using (MyDbContext db = GetDbContext())
            {

                switch (instruct)
                {
                    case "insert":
                        db.Set<T>().Add(GetConvert(m));
                        break;
                    case "delete":
                        db.Entry(GetConvert(m)).State = EntityState.Deleted;
                        break;
                    case "updata":
                        db.Set<T>().Attach(GetConvert(m));
                        db.Entry(GetConvert(m)).State = EntityState.Modified;
                        break;
                }
                i = db.SaveChanges();
            }
            return i;
        }

        public int GetInsert(M m)
        {
            return GetAffected(m, "insert");
        }

        public int GetDelete(M m)
        {
            return GetAffected(m, "delete");
        }

        public int GetUpdata(M m)
        {
            return GetAffected(m, "updata");
        }

        public List<M> Select()
        {
            List<M> lm = new List<M>();
            foreach (T t in GetDbContext().Set<T>().AsNoTracking().Select(e => e).ToList())
            {
                M tClass = Activator.CreateInstance<M>();
                foreach (PropertyInfo item in tClass.GetType().GetProperties())
                {
                    item.SetValue(tClass, t.GetType().GetProperty(item.Name).GetValue(t, null), null);
                }
                lm.Add(tClass);
            }
            return lm;
        }

        public T GetConvert(M m)
        {
            T tClass = Activator.CreateInstance<T>();
            foreach (PropertyInfo item in tClass.GetType().GetProperties())
            {
                item.SetValue(tClass, m.GetType().GetProperty(item.Name).GetValue(m, null), null);
            }
            return tClass;
        }
    }
}