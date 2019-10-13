using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTokenService.Api.Models.Statements
{
    public class StatementUpdateRequest
    {
        [Required]
        public int Id { get; set; }

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
