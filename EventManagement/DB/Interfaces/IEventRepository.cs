using EventManagement.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DB.Interfaces
{
    public interface IEventRepository : IDisposable
    {
        IQueryable<Event> All(string [] include = null);
        Event Find(int? id, string[] include = null);
        void InsertOrUpdate(Event ev);
        void Delete(int id);
        void Save();
        void SeedEvents();
    }
}