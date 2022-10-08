using System.Collections.Generic;

namespace api.Models.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> errorMessages { get; }

        public ErrorResponse(string errorMessage) : this(new List<string>() { errorMessage })
        {

        }

        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            this.errorMessages = errorMessages;
        }
    }
}
