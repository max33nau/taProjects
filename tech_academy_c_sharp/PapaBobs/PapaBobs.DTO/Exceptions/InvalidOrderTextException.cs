using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO.Exceptions
{
    public class InvalidOrderTextException : Exception
    {
        public string RequiredTextField { get; set; }

        public InvalidOrderTextException(string requiredTextField)
        {
            RequiredTextField = requiredTextField;
        }
    }

}
