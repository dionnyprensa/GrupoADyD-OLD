using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoADyD.Models.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Client> List
        {
            get
            {
                return db.Clients.ToList();
            }
        }

        public void Add(Client entity)
        {
            db.Clients.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            db.Clients.Remove( FindById(Id) );
            db.SaveChanges();
        }

        public Client FindById(int Id)
        {
            return (from a in List where a.ClientId == Id select a).FirstOrDefault();
        }

        public Client Find(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}