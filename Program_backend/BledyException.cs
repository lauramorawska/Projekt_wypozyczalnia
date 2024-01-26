using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class BledyException : Exception
    {
        public BledyException(string message): base(message) 
        {

        }
    }
    public class BledyNrDowoduException : Exception
    {
        public BledyNrDowoduException(string? message) : base(message)
        {
        }
    }
    public class BlednaDataZwrotuException : Exception
    {
        public BlednaDataZwrotuException(string? message) : base(message)
        {
        }
    }
    public class BlednyNumerTelefonuException : Exception
    {
        public BlednyNumerTelefonuException(string? message) : base(message)
        {
        }
    }
    public class BlednyPeselException : Exception
    {
        public BlednyPeselException(string? message) : base(message)
        {
        }
    }
}
