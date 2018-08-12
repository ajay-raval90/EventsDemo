using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Repository
{
    public class EventRepository : IEventRepository,IDisposable
    {

        EventDbContext context;
        public EventRepository(EventDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Event> All()
        {
            return context.Events; 
        }

        public Event Find(int? id)
        {
            Event ev = context.Events.Where(p => p.Id == id).FirstOrDefault();
            return ev;
        }

        public void InsertOrUpdate(Event ev)
        {
            if (ev.Id == 0)
            {
                // New entity
                context.Events.Add(ev);
            }
            else
            {
                // Existing entity
                context.Entry(ev).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var ev= context.Events.Find(id);
            if (ev != null)
            {
                context.Events.Remove(ev);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}