using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
    //EntityRepository'i yapılandırıyoruz
    //Bütün veritabanı nesneleri için generic çalışacak bir model oluşturuyoruz. 
    //Bunu interface tanımlarken 'T' olarak verdik
    //Ayrıca bu repository'i başka ORM(Nhibernate, entityFramWork gibi) de kullanabiliriz.

    // FrameWorkümüzü kullanacak programcı hata yapmasın diye Interfacemize bir kısıt getiriyoruz.
    // Kısıtımız T'nin bir class olması , IEntity Olması ve newlenebilir olmasıdır
    // IEntity'yi burda bir imza olarak düşünebiliriz. Nesnelerin belirli bir standarta sahip
    // olması ve ona göre kural yazılması için sıklıkla kullanırız  

    // Bu kısımda aslında yapacağımız veritabanı işlemlerini tanımladık
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  // Datanın where koşuluyla belirtilmiş kısmını
                                                               // getirmek için Linq Expression kullandık
        T Get(Expression<Func<T,bool>>filter);  // Tek bir nesne de döndürebileceğimiz için bu kısmı yazdık
        T Add(T entity);    //T tipinde bir nesne ekleme operasyonu
        T Update(T entity);  //T tipinde bir nesneyi Güncelleme operasyonu
        void Delete(T entity);  // Silme operasyonu


    }
}
