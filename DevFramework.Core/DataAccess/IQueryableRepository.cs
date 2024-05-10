using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
    // Queryable(sorgulanabilir) operasyonların business tarafında çalıştırabilmesi için
    // (yani context kapanmadan çalışırılabilmesi için) bu Interfaceyi yazıyoruz

    //where ile eklediğimiz kural T'nin IEntityden implemente edilmesi gerekliliği, class olması ve newlenebilirlik.
    public interface IQueryableRepository<T> where T: class, IEntity , new()
    {
        // select operasyonları için olduğu için tek bir implementasyon yapılır
        IQueryable<T> Table { get;}   // bu imza genellikle Table ismi ile adlandırılır 

        //Artık bunları veri erişim katmanıyla beslememiz gerekiyor
    }
}
