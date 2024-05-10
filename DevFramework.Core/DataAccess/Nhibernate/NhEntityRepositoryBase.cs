using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;


//EntityFrameworkte olduğu gibi bir TEntity getirdik ama context getirmedik
// Çünkü Context'i session olarak NHibernateHelper'dan alacağız


namespace DevFramework.Core.DataAccess.Nhibernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;  // bu kısmı (session) generic çalışmadığımız için aldık
        // yani kullanıcı hangi veritabanına göre çalışıyorsa onun helperini getirecek diyebiliriz
        public NhEntityRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session=_nHibernateHelper.OpenSession())  // Veritabanına göre o veritabanına uygun session açacak
            {
                session.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nHibernateHelper.OpenSession())  
            {
                return filter == null
                    ?session.Query<TEntity>().ToList():session.Query<TEntity>().Where(filter).ToList();

            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
