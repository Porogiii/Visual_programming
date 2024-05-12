using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_11.Struct
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayAttribute : Attribute
    {
        public DisplayAttribute()
        {
        }
    }
}
