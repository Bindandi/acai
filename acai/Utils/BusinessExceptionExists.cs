using System;

namespace acai.Utils
{
    [System.Serializable]
    class BusinessExceptionExists : BusinessException
    {
        

        public BusinessExceptionExists(string recurso, string paramName, bool validation) : base(comporMessage(recurso, paramName, validation), paramName)
        {
            
        }
        private static string comporMessage(string recurso, string paramName, bool validation)
        {
            string message = "{0} {1} com este {2}";
            const string ehTrue = "Já existe";
            const string ehFalse = "Não existe";


            if (validation)
                message = String.Format(message, ehTrue, recurso, paramName);
            else
                message = String.Format(message, ehFalse, recurso, paramName);
            //message = String.Format(message, paramName); ;
            return message;
        }
    }
}
