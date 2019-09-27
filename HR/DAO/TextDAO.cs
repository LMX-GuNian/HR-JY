using EF;
using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TextDAO : DaoBase<Text, TextModel>, ITextDAO
    {
    }
}
