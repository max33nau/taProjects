using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO.Exceptions
{
    public class InvalidOrderDropdownException : Exception
    {
        public string RequiredDropdownField { get; set; }

        public InvalidOrderDropdownException(string requiredField)
        {
            RequiredDropdownField = requiredField;
        }
    }
}
