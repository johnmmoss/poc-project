using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTokenService.Api.Models.Statements
{
    public class StatementAddRequest
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public decimal? OpeningBalance { get; set; }
    }
}
