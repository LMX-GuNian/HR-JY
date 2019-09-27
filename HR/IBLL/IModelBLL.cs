using System.Collections.Generic;

namespace IBLL
{
    public interface IModelBLL<M> where M : class
    {
        int GetInsert(M m);

        int GetDelete(M m);

        int GetUpdata(M m);

        List<M> Select();
    }
}
