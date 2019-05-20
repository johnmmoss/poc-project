namespace StatementsTracker.Models.Statements
{
    public class StatementAddRequest
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string DebitOrCredit { get; set; }
        public string isMonthlyPayment { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
    }
}
