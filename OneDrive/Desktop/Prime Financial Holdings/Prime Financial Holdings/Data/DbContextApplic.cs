using Microsoft.EntityFrameworkCore;
using Prime_Financial_Holdings.Controllers;
using Prime_Financial_Holdings.Models;
using System.Linq;

namespace Prime_Financial_Holdings.Data
{
    public class DbContextApplic :DbContext
    {
        public DbContextApplic(DbContextOptions<DbContextApplic> options) :base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Feedback> Feedbacks    { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet <Bill> Bills { get; set; }

        public String searchUser(User obj)
        {
            return "Select * from Users Where Username = '" + obj.Username + "'";
        }

        public User verifyUser(User obj)
        {
            User possibleUser = (User) Users.FromSqlRaw("Select * from Users where Username = '" + obj.Username+"' AND Password = '"+obj.Password+"'").FirstOrDefault();
            return possibleUser;
        }

        public Account getAccount(int obj)
        {
            Account searchedAccount = (Account)Accounts.FromSqlRaw("Select * from Accounts where accountNumber = '" + obj + "'").FirstOrDefault();
            return searchedAccount;
        }

        public void updateBalance(int accountNum, float newAmount)
        {
            Database.ExecuteSqlRaw("Update Accounts Set balance = '" + newAmount+ "' Where accountNumber = '"+accountNum+"'");
        }
        public void SaveTransaction(Transaction t, String type)
        {
            Database.ExecuteSqlRaw("insert into Transactions values ('" + t.accountNumber + "','" + t.amount + "','" + t.beneficiaryAccount + "','" + t.Date + "','" + t.time + "','"+type+"')");
        }

        public Boolean SaveFeedback(Feedback obj)
        {
            User possibleUser = (User)Users.FromSqlRaw("Select * from Users where Username = '" + obj.userName + "'").FirstOrDefault();
            if(possibleUser != null)
            {
                Database.ExecuteSqlRaw("insert into Feedbacks values ('" + obj.userName + "','" + obj.feedbackMessage + "')");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Bill FindBill(Bill obj)
        {
            Bill searchBill = Bills.FromSqlRaw("Select * from Bills where billReferenceNumber = '" + obj.billReferenceNumber + "' and billAmount='"+obj.billAmount+ "' and companyName='"+obj.companyName+"'").FirstOrDefault();
            return searchBill;
        }

        public IEnumerable<Transaction> FetchTransactions(Account t)
        {
            IEnumerable<Transaction> obj = Transactions.FromSqlRaw("Select * from Transactions where accountNumber = '" + t.accountNumber + "' or beneficiaryAccount = '"+t.accountNumber+"'");
            return obj;
        }

        public void updateBill(int billRefernceNo, int accountNumber)
        {
            Database.ExecuteSqlRaw("Update Bills Set paidby = '" + accountNumber + "' Where billReferenceNumber = '" + billRefernceNo + "'");
        }

        public void updateChequeStatus(bool flag, int accountNumber)
        {
            Database.ExecuteSqlRaw("Update Accounts Set requestedCheckbook = '" + flag + "' Where accountNumber = '" + accountNumber + "'");
        }

        public Boolean applyForLoan(Loan obj)
        {
            if (HomeController.loggedInAccount.LoanID == 1)
            {
                Database.ExecuteSqlRaw("Update Accounts Set LoanID = '" + obj.LoanId + "', loanAmount = '"+obj.amount+"' Where accountNumber = '" + HomeController.loggedInAccount.accountNumber + "'");
                return true;
            }
            return false;
        }

        public Loan searchLoan(string obj)
        {

            Loan loan = Loans.FromSqlRaw("Select * from Loans where Type = '" + obj + "'").FirstOrDefault();
            return loan;
        }
    }
    }
    //Code first approach

