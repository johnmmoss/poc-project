﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementsTracker.Data
{
    public class Statement
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Payment> Payments { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal OpeningBalance { get; set; }

        public decimal? ClosingBalance { get; set; }

    }
}
