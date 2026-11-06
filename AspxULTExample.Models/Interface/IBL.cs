
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    public interface IBL<T>
    {

    IEnumerable<T> GetAll();

    T GetById(int id);

    bool Insert(T entity);

    bool Update(T entity);

    bool Delete(int id, T entity);

    Dictionary<string, string> IsValid(T entity);

    }

    }
  