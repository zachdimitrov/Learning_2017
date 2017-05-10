using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using ProjectManager.Common.Exceptions;

namespace ProjectManager.Common.Utilities
{
    public class Validator
    {
        public void Validate<T>(T obj) where T : class
        {
            var errors = this.GetValidationErrors(obj);
            if (errors.Count() != 0)
            {
                throw new UserValidationException(errors.First());
            }
        }

        public IEnumerable<string> GetValidationErrors(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] objectProperties = objectType.GetProperties();
            Type attributeType = typeof(ValidationAttribute);

            foreach (var propertyInfo in objectProperties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attributeType, inherit: true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}
