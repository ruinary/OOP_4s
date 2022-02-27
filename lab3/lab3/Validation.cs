using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab3
{
    public class IndexValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string checkedIndex = value.ToString();
                if (Regex.IsMatch(checkedIndex, @"^[1-9][0-9]{5}$"))
                    return true;
                else
                    this.ErrorMessage = "Индекс должен содержать 6 цифр!";
            }
            return false;
        }
    }
    //internal class UserValidationAttribute : Attribute
    //{
    //}

}
