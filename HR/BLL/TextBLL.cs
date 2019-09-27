using IBLL;
using IDAO;
using DAO;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class TextBLL : ITextBLL
    {
        ITextDAO td = IOC.ModelIOC.GetDAL<TextDAO>();

        public int GetInsert(TextModel m)
        {
            return td.GetInsert(m);
        }

        public int GetDelete(TextModel m)
        {
            return td.GetDelete(m);
        }

        public int GetUpdata(TextModel m)
        {
            return td.GetUpdata(m);
        }

        public List<TextModel> Select()
        {
            return td.Select();
        }
    }
}
