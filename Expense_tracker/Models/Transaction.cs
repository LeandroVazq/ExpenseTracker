using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_tracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; }= DateTime.Now;

    }
}
