using System;

namespace acai.Utils
{
    [System.Serializable]
    class BusinessException : Exception
    {
        private string _message;
        public BusinessException(string message) : base(message)
        {

        }
        public BusinessException(string message, string paramName) : base(message + " (Parameter '" + paramName + "')")
        {

        }
        
    }
}
