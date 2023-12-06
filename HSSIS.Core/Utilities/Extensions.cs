using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Core
{
    public static class Extensions
    {
        #region Int32 Methods
        public static bool IsNotZero(this Int32 value)
        {
            return value != default(Int32);
        }

        public static bool IsZero(this Int32 value)
        {
            return value == default(Int32);
        }
        #endregion
    }
}
