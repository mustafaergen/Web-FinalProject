using FinalProject_Entities.Abstracts;
using FinalProject_Repositories.Contexts;
using FinalProject_Repositories.Contracts.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly RepositoryContex _context;
        protected RepositoryBase(RepositoryContex context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        }

        public IQueryable<T> FindAllCondation(Expression<Func<T, bool>> condition, bool trackChanges)
        {

            return trackChanges
                ? _context.Set<T>().Where(condition)
                : _context.Set<T>().Where(condition).AsNoTracking();
        }

        public T? FindByCondation(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(condition).SingleOrDefault()
                : _context.Set<T>().Where(condition).AsNoTracking().SingleOrDefault();
        }

        public T? FindById(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().SingleOrDefault(x => x.Id == id)
                : _context.Set<T>().AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
