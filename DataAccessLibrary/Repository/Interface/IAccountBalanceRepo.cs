using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository.Interface
{
    public interface IAccountBalanceRepo
    {
        // upload account balance
        string UploadBalance(AccountBalance accountBalance);

        // view balance of an account
        AccountBalance ViewBalance(int year, int month);

        // view balances of a time period
        List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);

        AccountBalance ViewCurrentBalance();
        string DeleteAccountBalance(int year, int month);
    }
}
