using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.TypeField
{
    public static class BuilderType
    {
        /// <summary>
        /// Get Stratey
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Stratety by TypeField</returns>
        public static IValidationStrategy GetStratey(TypeFieldType type)
        {
            return type switch
            {
                TypeFieldType.TypeString => new ValidationString(),
                TypeFieldType.TypeInt => new ValidationInt(),
                TypeFieldType.TypeDecimal => new ValidationDecimal(),
                _ => new ValidationString(),
            };
        }
    }
}
