using System.ComponentModel;

namespace SimpleTokenService.Data.Entities
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
