using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO.Exceptions
{
    public class InvalidOrderNumberException : Exception
    {
        public string RequiredIntField { get; set; }

        public InvalidOrderNumberException(string requiredIntField)
        {
            RequiredIntField = requiredIntField;
        }
    }
}
