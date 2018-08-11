using EventManagement.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Interfaces
{
    public interface IEventRepository : IDisposable
    {
        IQueryable<Event> All();
        Event Find(int? id);
        void InsertOrUpdate(Event ev);
        void Delete(int id);
        void Save();
    }
}