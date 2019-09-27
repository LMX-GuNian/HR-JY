using System.Collections.Generic;

namespace IDAO
{
    public interface IModelDAL<M> where M : class
    {
        int GetInsert(M m);

        int GetDelete(M m);

        int GetUpdata(M m);

        List<M> Select();
    }
}
