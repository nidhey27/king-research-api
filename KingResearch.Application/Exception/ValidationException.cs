using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using FluentValidation.Results;

namespace KingResearch.Application.Exception
{
    public class ValidationException : ApplicationException
    {
        public List<ApplicationException> applicationExceptions = new List<ApplicationException>();

        public ValidationException(string message)
        {
            applicationExceptions.Add(new ApplicationException(message));
        }

        public ValidationException(List<ValidationFailure> errors)
        {
            foreach (var item in errors)
            {
                applicationExceptions.Add(new ApplicationException(item.ErrorMessage));
            }
           // return this.applicationExceptions;
        }
    }
}
