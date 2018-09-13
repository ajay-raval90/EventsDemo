using EventManagement.Common;
using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public EventRepository()
        {
            this.context = new EventDbContext();
        }

        public IQueryable<Event> All(string []include = null)
        {
            var eventsQuery = context.Events.AsQueryable();
            if (include != null)
            {
                foreach (var inc in include)
                {
                    eventsQuery = eventsQuery.Include(inc);
                }
            }
            return eventsQuery;
        }

        public Event Find(int? id,string [] include = null)
        {
            var eventsQuery = context.Events.AsQueryable();
            if (include != null)
            {
                foreach (var inc in include)
                {
                    eventsQuery = eventsQuery.Include(inc);
                }
            }
            return eventsQuery.Where(p => p.id == id).FirstOrDefault();
        }

        public void InsertOrUpdate(Event ev)
        {
            if (ev.id == 0)
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

        public void SeedEvents()
        {
            if(context.Events.Count()==0)
            {
                using (StreamReader reader = new StreamReader(string.Format(@"D:\Projects\Angular6\events.json")))
                {
                    string content = reader.ReadToEnd();
                    //dynamic d = new ExpandoObject();
                    //d = JsonConvert.DeserializeObject<dynamic>(content);

                    SeedProfiles();
                    List<Event> eventList = new List<Event>();
                    eventList  = JsonConvert.DeserializeObject<List<Event>>(content);
                    foreach (var eventobject in eventList)
                    {
                        eventobject.id = 0;
                        eventobject.locationId = null;
                                                 
                        eventobject.sessions.ToList().ForEach(s => {
                            s.id = 0;
                            s.VoterList = new List<Voter>();
                            s.voters.ToList().ForEach(voter =>
                            {
                                Voter voterItem = new Voter();
                                Profile exists = context.Profiles.Where(p => p.Email == voter + "@gmail.com").FirstOrDefault();
                                if (exists != null)
                                {
                                    voterItem.profile = exists;
                                }
                                s.VoterList.Add(voterItem);
                            });
                        });
                        context.Events.Add(eventobject);
                    }
                    context.SaveChanges();
                }
            }
            
        }

        private void SeedProfiles()
        {
            string [] voterList = new string[] { "bradgreen", "martinfowler", "igorminar", "johnpapa" };
            foreach (var voter in voterList)
            {
                Profile exists = context.Profiles.Where(p => p.Email == voter + "@gmail.com").FirstOrDefault();
                if (exists == null)
                {

                    Profile P = new Profile();
                    P.FirstName = voter;
                    P.LastName = voter;
                    P.Email = voter + "@gmail.com";
                    P.Password = "eventmanagement";
                    P.Salt = "salt";
                    P.UserName = voter;
                    P.CreatedAt = DateTime.Now;
                    context.Profiles.Add(P);
                }
                else
                {
                    exists.UpdatedAt = DateTime.Now;
                    context.Entry(exists).State = EntityState.Modified;
                }
                context.SaveChanges();
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