using DataAccessLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class AccountBalanceRepo :IAccountBalanceRepo
    {
        private AdraFullTestFinalContext _DbContext;
        public AccountBalanceRepo()
        {
            _DbContext = new AdraFullTestFinalContext();
        }



        // upload account balance 
        public string UploadBalance(AccountBalance accountBalance)
        {
            _DbContext.AccountBalances.Add(accountBalance);
            int result = _DbContext.SaveChanges();

            if (result != 0)
            {
                return "uploaded succesfully";
            }
            else
            {
                return "An error occured";
            }

        }

        // view balance of an account 
        public AccountBalance ViewBalance(int year, int month)
        {
            AccountBalance accountBalanceresult = _DbContext.AccountBalances.Where(o => o.year == year && o.month == month).FirstOrDefault();
            return accountBalanceresult;
        }

        // view balances of a time period
        public List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            List<AccountBalance> resultList = _DbContext.AccountBalances.Where(o => o.year >= startYear && o.month >= startMonth && o.year <= endYear && o.month <= endMonth).ToList<AccountBalance>();
            return resultList;
        }


        public AccountBalance ViewCurrentBalance()
        {
            // get the last row of the accountbalance table
            AccountBalance maximum = _DbContext.AccountBalances.OrderByDescending(o => o.year).ThenByDescending(o => o.month).FirstOrDefault();
            return maximum;


        }

        public string DeleteAccountBalance(int year, int month)
        {
            AccountBalance accountToDelete = _DbContext.AccountBalances.Where(o => o.year == year && o.month == month).FirstOrDefault();
            _DbContext.Entry(accountToDelete).State = System.Data.Entity.EntityState.Deleted;
            int result = _DbContext.SaveChanges();

            if (result != 0)
            {
                return "deleted successfully";
            }
            else
            {
                return "Error occured while deleting";
            }
        }
    }
}
