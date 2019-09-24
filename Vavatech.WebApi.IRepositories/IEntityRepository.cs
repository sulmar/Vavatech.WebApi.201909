using System.Collections.Generic;

namespace Vavatech.WebApi.IRepositories
{
    //public interface ICustomerRepository
    //{
    //    Customer Get(int id);
    //    IEnumerable<Customer> Get();
    //    void Add(Customer customer);
    //    void Update(Customer customer);
    //    void Remove(int id);
    //}


    // interfejs generyczny
    public interface IEntityRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        bool Exists(int id);
    }


}
