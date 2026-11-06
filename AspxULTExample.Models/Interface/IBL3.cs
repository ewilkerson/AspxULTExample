
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{

    public interface IBL3<T>
    {
        IEnumerable<T> GetAll_Ten();

        IEnumerable<T> GetAll_Thirty();
    }

}
