using System.ComponentModel;

namespace SimpleTokenService.Data.Entities
{
    public enum PaymentTypeEnum
    {
        [Description("Debit")]
        Debit = 1,

        [Description("Credit")]
        Credit
    }
}
