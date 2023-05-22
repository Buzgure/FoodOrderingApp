using System.Collections;
using System.Collections.Generic;

namespace Restaurant.Repository
{
    public interface Repository<E>
    {
        E save(E entity);
        E delete(E entity);
        E update(E entity);
        ICollection<E> findAll();

        E findOne(int ID);


    }
}