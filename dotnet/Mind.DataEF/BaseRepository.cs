using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Minds.DataEF
{
    

        public interface IOrderByClause<TEntity>
        {
            IQueryable<TEntity> ApplySort(IQueryable<TEntity> query, bool isFirstSort);
        }

        public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
        {
            protected readonly ApplicationDbContext Context;

            public BaseRepository(ApplicationDbContext context)
            {
                Context = context;
            }

            #region IDisposable Support

            private bool _disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        Context.Dispose();
                    }
                    _disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion

    
   
            public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
                IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null)
            {
                IQueryable<TEntity> query = Context.Set<TEntity>();

                if (where != null)
                {
                    query = query.Where(where);
                }

                if (include != null)
                {
                    foreach (var includeProperty in include)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (orderBy != null)
                {
                    bool isFirstSort = true;
                    foreach (var orderClause in orderBy)
                    {
                        query = orderClause.ApplySort(query, isFirstSort);
                        isFirstSort = false;
                    }
                }

                if (skip > 0)
                {
                    query = query.Skip(skip);
                }

                if (top > 0)
                {
                    query = query.Take(top);
                }

                return query.ToList();
            }


            public TEntity SelectById(long id)
            {
                return Context.Set<TEntity>().Find(id);
            }

            /// <summary>
            /// Inserts a new entity into the database.
            /// </summary>
            /// <param name="item">The entity to insert.</param>
            /// <param name="saveImmediately">If true, SaveChanges is called immediately.</param>
            /// <returns>The inserted entity.</returns>
            public virtual TEntity Insert(TEntity item, bool saveImmediately = true)
            {
                Context.Set<TEntity>().Add(item);

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }

                return item;
            }

            /// <summary>
            /// Updates an existing entity in the database.
            /// </summary>
            /// <param name="item">The entity with updated values.</param>
            /// <param name="saveImmediately">If true, SaveChanges is called immediately.</param>
            /// <returns>The updated entity.</returns>
            public TEntity Update(TEntity item, bool saveImmediately = true)
            {
                // Attach the item if it is not already tracked
                if (Context.Entry(item).State == EntityState.Detached)
                {
                    Context.Set<TEntity>().Attach(item);
                }

                // Mark the entity as modified
                Context.Entry(item).State = EntityState.Modified;

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }

                return item;
            }

            /// <summary>
            /// Deletes an entity from the database.
            /// </summary>
            /// <param name="item">The entity to delete.</param>
            /// <param name="saveImmediately">If true, SaveChanges is called immediately.</param>
            public void Delete(TEntity item, bool saveImmediately = true)
            {
                // Attach the item if it is not already tracked
                if (Context.Entry(item).State == EntityState.Detached)
                {
                    Context.Set<TEntity>().Attach(item);
                }

                Context.Set<TEntity>().Remove(item);

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }
            }

            /// <summary>
            /// Attaches an entity to the context.
            /// </summary>
            /// <param name="item">The entity to attach.</param>
            public void Attach(TEntity item)
            {
                Context.Set<TEntity>().Attach(item);
            }

            /// <summary>
            /// Persists all changes made in this context to the database.
            /// </summary>
            public void Save()
            {
                Context.SaveChanges();
            }
        }
}

