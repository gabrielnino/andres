using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.TypeField
{
    /// <summary>
    ///  Validation Strategy
    /// </summary>
    public interface IValidationStrategy 
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeField">Is Validate</param>
        /// <returns></returns>
        bool Validate(TypeField typeField);
    }

    /// <summary>
    /// Type Field
    /// </summary>
    public class TypeField
    {
        /// <summary>
        /// Field Value
        /// </summary>
        public string FieldValue { get; set; }
    }
    /// <summary>
    /// Validation Type Fiel Strategy
    /// </summary>
    public class ValidationTypeFielStrategy
    {
        /// <summary>
        /// Validation Strategy
        /// </summary>
        private readonly IValidationStrategy _validationStrategy;

        /// <summary>
        /// Validation Type Field Strategy
        /// </summary>
        public ValidationTypeFielStrategy()
        {
        }

        /// <summary>
        /// Validation Type Field Strategy
        /// </summary>
        /// <param name="validationStrategy">validation strategy</param>
        public ValidationTypeFielStrategy(IValidationStrategy validationStrategy)
        {
            _validationStrategy = validationStrategy;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeField"></param>
        /// <returns>Is Validate</returns>
        public bool Validate(TypeField typeField)
        {
            return _validationStrategy.Validate(typeField);
        }
    }
    /// <summary>
    /// Validation String
    /// </summary>
    public class ValidationString: IValidationStrategy 
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeField"></param>
        /// <returns></returns>
        public bool Validate(TypeField typeField)
        {
            return true;
        }
    }
    /// <summary>
    /// Validation Strategy
    /// </summary>
    public class ValidationInt : IValidationStrategy 
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeField"></param>
        /// <returns>Is Validate</returns>
        public bool Validate(TypeField typeField)
        {
            return int.TryParse(typeField.FieldValue, out _);
        }
    }
    /// <summary>
    /// ValidationDecimal
    /// </summary>
    public class ValidationDecimal : IValidationStrategy
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeField"></param>
        /// <returns>Is Validate</returns>
        public bool Validate(TypeField typeField)
        {
            return decimal.TryParse(typeField.FieldValue, out _);
        }
    }
}
