using Expense_tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult> Index()
        {
            //Last 7 days 

            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions.Include(x=>x.Category).Where(y=>y.Date >= StartDate && y.Date <= EndDate).ToListAsync();


            //Total income

            int TotalIncome = SelectedTransactions.Where(a=>a.Category.Type == "Income").Sum(a=>a.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //Total Expense
            int TotalExpense = SelectedTransactions.Where(i => i.Category.Type == "Expense").Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //Balance 

            int Balance = TotalIncome - TotalExpense;
            ViewBag.TotalBalance = Balance.ToString("C0");

            //ViewBag Doughnut chart- Expense by category

            ViewBag.DoughnutChartData = SelectedTransactions.Where(e => e.Category.Type == "Expense").
                GroupBy(j => j.Category.CategoryId).
                Select(k => new
                    {
                        categoryTitleWithIcon = k.First().Category.Icon + " " + k.First().Category.Title,
                        amount=k.Sum(j=>j.Amount),
                        formattedAmount = k.Sum(j=>j.Amount).ToString("C0"),
                    }
                ).ToList();

            return View();
        }
    }
}
 