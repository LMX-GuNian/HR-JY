using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class TextConfiger : EntityTypeConfiguration<Text>
    {
        public TextConfiger()
        {
            this.ToTable(nameof(Text));
            this.Property(e => e.name).HasMaxLength(50);//标记字符串的最大长度
        }
    }
}
