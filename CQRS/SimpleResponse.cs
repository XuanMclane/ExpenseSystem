using ExpenseSystem.Interface;

namespace ExpenseSystem.CQRS
{
    public class SimpleResponse : IResponse
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public SimpleResponse()
        {
            IsSuccess = true;
        }
        public SimpleResponse(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }
    }
}