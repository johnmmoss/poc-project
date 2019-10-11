using System;

namespace SimpleTokenService.Api.Models.Statements
{
    public class StatementsGetAllResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal OpeningBalance { get; set; }

        public decimal? ClosingBalance { get; set; }
    }
}
