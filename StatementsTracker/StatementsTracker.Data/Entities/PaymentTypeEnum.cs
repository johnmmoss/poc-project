using System.ComponentModel;

namespace StatementsTracker.Data
{
    public enum PaymentTypeEnum
    {
        [Description("Debit")]
        Debit = 1,

        [Description("Credit")]
        Credit
    }
}
