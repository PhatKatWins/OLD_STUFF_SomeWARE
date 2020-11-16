using Microsoft.AspNetCore.SignalR;
using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T obj) where T : class;
        void AddAll<T>(IEnumerable<T> objects) where T : class;
        T Get<T>(object id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(object id) where T : class;
        void RemoveAll<T>(IEnumerable<T> objects) where T : class;
        Task<bool> SaveChangesAsync(); 
    }
}
