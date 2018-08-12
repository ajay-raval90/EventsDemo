using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Repository
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {

        EventDbContext context;
        public ProfileRepository()
        {
            this.context = new EventDbContext();
        }
        public ProfileRepository(EventDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Profile> All()
        {
            return context.Profiles;
        }

        public Profile Find(int? id)
        {
            Profile prof = context.Profiles.Where(p => p.Id == id).FirstOrDefault();
            return prof;
        }

        public void InsertOrUpdate(Profile prof)
        {
            if (prof.Id == 0)
            {
                // New entity
                context.Profiles.Add(prof);
            }
            else
            {
                // Existing entity
                context.Entry(prof).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var prof = context.Profiles.Find(id);
            if (prof != null)
            {
                context.Profiles.Remove(prof);
            }
        }

        public Profile FindByEmailAndPassword(string Email,string Password)
        {
            return context.Profiles.Where(t => t.Email == Email && t.Password == Password).FirstOrDefault();
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