using System.ComponentModel;

namespace StatementsTracker.Data
{
    public enum PaymentMethodEnum
    {
        [Description("Debit Card")]
        DebitCard = 1,

        [Description("Cheque")]
        Cheque,

        [Description("Direct Debit")]
        DirectDebit,

        [Description("Bank Transfer")]
        BankTransfer
    }
}
