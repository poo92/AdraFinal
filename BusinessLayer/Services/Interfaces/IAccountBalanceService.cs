using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAccountBalanceService
    {
        // upload balance
        string UploadBalance(AccountBalanceEntity accountbalance);
        // View balance of a month
        AccountBalanceEntity ViewBalance(int year, int month);
        // view balances of a time period
        List<AccountBalanceEntity> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);
        // method to view current account balance
        double[] ViewCurrentBalance(string accountType);
    }
}
