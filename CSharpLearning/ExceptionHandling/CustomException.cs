using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.ExceptionHandling
{
    class CustomException
    {
        public void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or older.");
            }
        }
    }

    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

   
}
