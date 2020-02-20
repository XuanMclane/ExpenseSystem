namespace ExpenseSystem.CQRS
{
    public class ResultResponse<TViewModel> : SimpleResponse
    {
        public TViewModel Result { get; set; }
    }
}