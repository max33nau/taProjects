using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO.Exceptions
{
    public class InvalidOrderRadioException : Exception
    {
        public string RequiredRadioField { get; set; }

        public InvalidOrderRadioException(string requiredField)
        {
            RequiredRadioField = requiredField;
        }
    }
}
