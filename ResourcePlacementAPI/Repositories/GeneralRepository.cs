using Microsoft.EntityFrameworkCore;
using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Context : MyContext
        where Entity : class
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }
        public int Delete(Key key)
        {
            var cari = entities.Find(key);
            //entities.Remove(cari);
            myContext.Entry(cari).State = EntityState.Deleted;
            var save = myContext.SaveChanges();
            return save;
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            var findAll = entities.Find(key); //universitiesid tipenya int, sedangkan yg di general repo itu tipenya string
            return findAll;
        }

        public Entity GetById(Key key)
        {
            var findId = entities.Find(key);
            return findId;
        }

        public int Insert(Entity e)
        {
            myContext.Entry(e).State = EntityState.Added;
            var post = myContext.SaveChanges();
            return post;
        }

        public int Update(Entity e, Key key)
        {
            try
            {
                entities.Attach(e);
                var newEntry = myContext.Entry(e);

                newEntry.State = EntityState.Modified;
                var update = myContext.SaveChanges();
                return update;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
