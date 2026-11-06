
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    public interface IRepository<T>
    {

    IEnumerable<T> GetAll();

    T GetById(int id);

    T Insert(T entity);

    T Update(T entity);

    T Delete(int id, T entity);

    }

    }
  