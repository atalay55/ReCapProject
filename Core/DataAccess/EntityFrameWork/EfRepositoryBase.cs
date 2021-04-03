using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFrameWork
{
    public class EFRepositoryBase<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity items)
        {
            using (TContext context = new TContext())
            {
                var addeditem = context.Entry(items);
                addeditem.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity items)
        {
            using (TContext context = new TContext())
            {
                var deleteditem = context.Entry(items);
                deleteditem.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity items)
        {
            using (TContext context = new TContext())
            {
                var updateitem = context.Entry(items);
                updateitem.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
