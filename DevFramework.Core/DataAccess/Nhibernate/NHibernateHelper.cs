using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NHibernate'nin kullanımı oldukça yaygındır. Çünkü hem iyi bir ORM hem de birçok veri tabanını destekliyor.
// Veritabanı SQL server Veya oracle ise EntityFramework kullanmak daha mantıklıdır.
// NHibernate'de farklı veritabanlarının desteklenmesinden dolayı bir Helper yazmalıyız.
// Bu helper farklı veritabanlarına geçişte implemente edilerek kolaylık sağlayacaktır.
// kısaca farklı veritabanlarının konfigurasyonu için helper'a ihtiyaç vardır.


// IDisposible Hazır bir interface

// Tüm veri tabanlarını ayrı ayrı implemente etmesi için classımızı Abstract class yaptık.

namespace DevFramework.Core.DataAccess.Nhibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;   // Factory desing patterninden besleniyor

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }
        }

        protected abstract ISessionFactory InitializeFactory();  // brayı da seçim için abstract yaptık
        // şimdi contextini oluşturalım

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession(); 
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);// GarbageCollection
        }
    }
}
