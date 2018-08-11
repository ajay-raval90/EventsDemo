using EventManagement.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Interfaces
{
    public interface IProfileRepository : IDisposable
    {
        IQueryable<Profile> All();
        Profile Find(int? id);
        void InsertOrUpdate(Profile ev);
        void Delete(int id);
        void Save();

        Profile FindByEmailAndPassword(string Email, string Password);
    }
}