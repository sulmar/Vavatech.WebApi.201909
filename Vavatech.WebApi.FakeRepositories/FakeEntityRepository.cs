using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.FakeRepositories
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        private Faker<TEntity> faker;

        public FakeEntityRepository(Faker<TEntity> faker)
        {
            this.faker = faker;

            entities = faker.Generate(100);
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
