using StatementsTracker.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementsTracker.Data
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Statement")]
        public int StatementId { get; set; }
        public Statement Statement { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey("MethodEnum")]
        public PaymentMethod Method { get; set; }
        [Column("MethodId")]
        public PaymentMethodEnum MethodEnum { get; set; } 

        [ForeignKey("TypeEnum")]
        public PaymentType Type { get; set; }
        [Column("TypeId")]
        public PaymentTypeEnum TypeEnum { get; set; }

        public bool IsPending { get; set; } = true;
    }
}
