using System;

namespace CrimeReportingSystem.Exceptions
{
    public class CaseNumberNotFoundException : Exception
    {
        public CaseNumberNotFoundException() : base("Case number not found")
        {
        }

        public CaseNumberNotFoundException(string message) : base(message)
        {
        }

        public CaseNumberNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}