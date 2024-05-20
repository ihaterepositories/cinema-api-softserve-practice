using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Validators
{
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var str = value.ToString();
            if (str == null)
            {
                return true;
            }
            if (str.Any(char.IsDigit))
            {
                return true;
            }
            if (str.Any(char.IsLower))
            {
                return true;
            }
            if (str.Any(char.IsHighSurrogate))
            {
                return true;
            }
            return false;

        }
    }
}
