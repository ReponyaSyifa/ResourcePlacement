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
        public int Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> Get()
        {
            throw new NotImplementedException();
        }

        public Entity Get(Key key)
        {
            throw new NotImplementedException();
        }

        public int Insert(Entity e)
        {
            throw new NotImplementedException();
        }

        public int Update(Entity e, Key key)
        {
            throw new NotImplementedException();
        }
    }
}
