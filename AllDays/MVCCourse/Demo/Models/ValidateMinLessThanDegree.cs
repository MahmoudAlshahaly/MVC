using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class ValidateMinLessThanDegree : ValidationAttribute
    {
        DBHelper db = new DBHelper();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           //var a= db.courses.Where(a => a.mindegree < a.degree);
            var otherProperty = validationContext.ObjectType.GetProperty("degree");
            int otherPropertyValue =(int) otherProperty.GetValue(validationContext.ObjectInstance, null);
            if ((int)value >= otherPropertyValue)
            {
                return new ValidationResult("min degree must less than degree");
                //return new ValidationResult("course name already exist");
            }
            return ValidationResult.Success;
        }
    }
}
