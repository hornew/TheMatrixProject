using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMatrixProject
{
    internal class DimensionException : Exception
    {
        internal DimensionException(string err)
            : base(err)
        {
        }
    }
}