using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    // Burada Context ve Entity'ye ihtiyacımız var Bunlaro kullandık.
    // Ve bu class IEntityRepository'yi implemente edicek
    // Defensive progragramming kapsamında Where kullanacağız
    // Sonra nuget'tan EntityFrameworkü kuracağız
    // Daha sonra IEntityRepository kısmını implemente edeceğiz Ardından içlerini dolduracağız.
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
            where Tentity : class, IEntity, new()
            where TContext : DbContext, new()
    {
        public Tentity Add(Tentity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)   // GetList Değil GetAll
        {
            using (var context = new TContext())
            {
                return filter == null 
                    ? context.Set<Tentity>().ToList()
                    : context.Set<Tentity>().Where(filter).ToList();
            }
        }

        public Tentity Update(Tentity entity)
        {
            using (var context = new TContext())
            {
                var updatedEnitity = context.Entry(entity);
                updatedEnitity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
