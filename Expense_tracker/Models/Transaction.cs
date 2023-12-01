using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_tracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greatear than 0")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; }= DateTime.Now;


        [NotMapped]

        public string? CategoryTitleWithIcon {
            get
            {
                return Category == null ? " " : Category.Title + " " + Category.Icon;
            }
        }

        [NotMapped]

        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString("c0");
            }
        }

    }
}
