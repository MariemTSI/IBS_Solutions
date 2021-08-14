using System;

namespace Tsi.Template.Core.Exceptions
{
    public class CoreException: ApplicationException
    {
        public CoreException()
        {
        }
         
        public CoreException(string message)
            : base(message)
        {
        }
         
        public CoreException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        } 

        public CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
