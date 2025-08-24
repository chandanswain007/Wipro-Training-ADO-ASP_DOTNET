using System;

namespace CrimeReportingSystem.Exceptions
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException() : base("Incident number not found")
        {
        }

        public IncidentNumberNotFoundException(string message) : base(message)
        {
        }

        public IncidentNumberNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}