using LOGIC.Contracts;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly SchoolDBContext _schoolDBContext;
        private readonly DbSet<T> _DbSet;
        public GenericRepository(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
            _DbSet = _schoolDBContext.Set<T>();
        }
        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.ToList();
        }

        public T GetById(int id)
        {
            T entity = _DbSet.Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            _DbSet.Attach(entity);
            _schoolDBContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
