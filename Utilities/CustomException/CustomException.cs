using System;

namespace Utilities.CustomException
{
    public class CustomException : Exception
    {
        /// <summary>
        /// Custom Exception
        /// </summary>
        /// <param name="typeCustomException"></param>
        /// <param name="message"></param>
        public CustomException(TypeCustomException typeCustomException,string message):base(message)
        {
            TypeException = typeCustomException;
        }
        /// <summary>
        /// Type Custom Exception
        /// </summary>
        public TypeCustomException TypeException { private set; get; }
    }
}
