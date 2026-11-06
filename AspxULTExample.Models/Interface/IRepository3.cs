
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{

    public interface IRepository3<T>
    {
        IEnumerable<T> GetAll_Ten();

        IEnumerable<T> GetAll_Thirty();

    }

}
