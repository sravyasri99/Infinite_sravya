using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon_Caching
{
    public sealed class SingleTonCache : IMyCache
    {
        private ConcurrentDictionary<object, object> cd = new ConcurrentDictionary<object, object>();

        public static readonly SingleTonCache singleobj = new SingleTonCache();

        //only called once a constuctor
        private SingleTonCache()
        {
            Console.WriteLine("Singleton instance created...");
        }

        public static SingleTonCache GetINstance()
        {
            return singleobj;
        }


        public bool Add(object key, object value)
        {
            return cd.TryAdd(key, value);
        }

        public bool AddOrUpdate(object key, object value)
        {
            if (cd.ContainsKey(key))
            {
                //cd.TryRemove(key, out object removedvalue);
                cd.TryUpdate(key, "Sree", "Sowmya");
            }
            return cd.TryAdd(key, value);

        }
            //public bool AddOrUpdate(object key, object value)
            //{
            //    cd.AddOrUpdate(key, value, (k, oldValue) => value);
            //    return true;
            //}
            //public bool AddOrUpdate(object key, object value)
            //{
            //    if(cd.ContainsKey(key))
            //    {
            //        cd[key] = value;
            //        return true;
            //    }
            //    return cd.TryAdd(key, value);
            //}

        public object Get(object key)
        {
            if(cd.ContainsKey(key))
            {
                return cd[key];
            }
            return null;
        }

        public bool Remove(object key)
        {
            return cd.TryRemove(key, out object removedval);
        }

        public void Clear()
        {
            cd.Clear();
        }

        public ConcurrentDictionary<object, object> GetAll()
        {
            return cd;

        }
    }
}
