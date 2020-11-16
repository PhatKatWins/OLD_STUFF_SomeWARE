using Microsoft.EntityFrameworkCore;
using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Data.Repository
{
    public class Repository : IRepository
    {
        private SomewareContext _context;

        public Repository(SomewareContext context)
        {
            _context = context;
        }

        public void Add<T>(T obj) where T : class
        {
            _context.Set<T>().Add(obj);
        }

        public void AddAll<T>(IEnumerable<T> objects) where T : class
        {
            _context.Set<T>().AddRange(objects);
        }

        public T Get<T>(object id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Update<T>(T obj) where T : class
        {
            _context.Set<T>().Update(obj);
        }

        public void Remove<T>(object id) where T : class
        {
            var obj = Get<T>(id);
            _context.Set<T>().Remove(obj);
        }

        public void RemoveAll<T>(IEnumerable<T> objects) where T : class
        {
            _context.Set<T>().RemoveRange(objects);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0) return true;
            else return false;
        }
    }
}
