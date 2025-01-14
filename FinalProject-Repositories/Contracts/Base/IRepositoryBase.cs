using FinalProject_Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories.Contracts.Base
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        // entity her nesneyi trackliyordu asno tracking metotu ile takip etmesini kesebiliriz  
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindAllCondation(Expression<Func<T, bool>> condition, bool trackChanges);
        T? FindById(int id,bool trackChanges);
        T? FindByCondation(Expression<Func<T, bool>> condition, bool trackChanges);

        //expression nedir ? LINQ sorgularının temellerini oluşturan güçlü bir yapıdır.
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
