
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{

    public interface IRepository2<T>
    {
        IEnumerable<T> GetAllById(int id);
    }

}
