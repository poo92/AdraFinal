using BusinessLayer.Services;
using DataAccessLibrary;
using DataAccessLibrary.Repository.Interface;
using EntityClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerUnitTests
{
    [TestFixture]
    class AccountBalanceServiceTest
    {
        [Test]
        public void UploadBalance_Balance_Already_In_Db()
        {
            AccountBalance accountBalanceDAL = new AccountBalance();
            accountBalanceDAL.year = 2016;
            accountBalanceDAL.month = 1;
            accountBalanceDAL.rnd = 10000.00;
            accountBalanceDAL.canteen = 150000.25;
            accountBalanceDAL.ceocar = 2500.36;
            accountBalanceDAL.marketing = 69354.25;
            accountBalanceDAL.parking = 25369.25;

            AccountBalanceEntity accountBalanceBAL = new AccountBalanceEntity();
            accountBalanceBAL.year = 2016;
            accountBalanceBAL.month = 1;
            accountBalanceBAL.rnd = 10000.00;
            accountBalanceBAL.canteen = 150000.25;
            accountBalanceBAL.ceocar = 2500.36;
            accountBalanceBAL.marketing = 69354.25;
            accountBalanceBAL.parking = 25369.25;

            string expected = "Balances of this month already exsists in the database";
            Mock<IAccountBalanceRepo> mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns(accountBalanceDAL);

            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
            string status = accountBalanceService.UploadBalance(accountBalanceBAL);

            Assert.AreEqual(status, expected);

        }

        [Test]
        public void UploadBalance_Balance_Not_In_Db()
        {
            AccountBalance accountBalanceDAL = new AccountBalance();
            accountBalanceDAL.year = 2016;
            accountBalanceDAL.month = 1;
            accountBalanceDAL.rnd = 10000.00;
            accountBalanceDAL.canteen = 150000.25;
            accountBalanceDAL.ceocar = 2500.36;
            accountBalanceDAL.marketing = 69354.25;
            accountBalanceDAL.parking = 25369.25;

            AccountBalanceEntity accountBalanceBAL = new AccountBalanceEntity();
            accountBalanceBAL.year = 2016;
            accountBalanceBAL.month = 1;
            accountBalanceBAL.rnd = 10000.00;
            accountBalanceBAL.canteen = 150000.25;
            accountBalanceBAL.ceocar = 2500.36;
            accountBalanceBAL.marketing = 69354.25;
            accountBalanceBAL.parking = 25369.25;

            string expected = "uploaded succesfully";

            Mock<IAccountBalanceRepo> mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns((AccountBalance)null);
            mockAccountBalanceRepo.Setup(x => x.UploadBalance(It.IsAny<AccountBalance>())).Returns("uploaded succesfully");

            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
            string status = accountBalanceService.UploadBalance(accountBalanceBAL);

            Assert.AreEqual(status, expected);

        }


        [Test]
        public void ViewBalance_Balance_Exists_In_Db()
        {
            AccountBalance accountBalanceDAL = new AccountBalance();
            accountBalanceDAL.year = 2016;
            accountBalanceDAL.month = 1;
            accountBalanceDAL.rnd = 10000.00;
            accountBalanceDAL.canteen = 150000.25;
            accountBalanceDAL.ceocar = 2500.36;
            accountBalanceDAL.marketing = 69354.25;
            accountBalanceDAL.parking = 25369.25;

            AccountBalanceEntity expected = new AccountBalanceEntity();
            expected.year = 2016;
            expected.month = 1;
            expected.rnd = 10000.00;
            expected.canteen = 150000.25;
            expected.ceocar = 2500.36;
            expected.marketing = 69354.25;
            expected.parking = 25369.25;

            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns(accountBalanceDAL);
            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);


            AccountBalanceEntity actual = accountBalanceService.ViewBalance(2016, 1);

            AssertObjects.PropertyValuesAreEquals(actual, expected);

        }

        [Test]
        public void ViewBalance_Balance_Not_Exists_In_Db()
        {
            AccountBalanceEntity expected = new AccountBalanceEntity();
            expected.year = 0;
            expected.month = 0;
            expected.rnd = 0;
            expected.canteen = 0;
            expected.ceocar = 0;
            expected.marketing = 0;
            expected.parking = 0;

            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns((AccountBalance)null);
            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);


            AccountBalanceEntity actual = accountBalanceService.ViewBalance(2016, 1);

            AssertObjects.PropertyValuesAreEquals(actual, expected);

        }

        [Test]
        public void ViewBalanceChart_No_Data_Available_In_DB()
        {
            List<AccountBalance> resultDAL = null;
            int startYear = 2017;
            int startMonth = 1;
            int endYear = 2017;
            int endMonth = 5;

            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalanceChart(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(resultDAL);

            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
            List<AccountBalanceEntity> actual = accountBalanceService.ViewBalanceChart(startYear, startMonth, endYear, endMonth);

            Assert.IsEmpty(actual);
        }
        [Test]
        public void ViewBalanceChart_Data_Available_In_DB()
        {

            int startYear = 2017;
            int startMonth = 1;
            int endYear = 2017;
            int endMonth = 2;

            List<AccountBalance> resultDAL = new List<AccountBalance>();

            AccountBalance resultDALValue1 = new AccountBalance();
            resultDALValue1.year = 2017;
            resultDALValue1.month = 1;
            resultDALValue1.rnd = 1200.36;
            resultDALValue1.canteen = 4563.36;
            resultDALValue1.ceocar = -635.89;
            resultDALValue1.marketing = 1456.25;
            resultDALValue1.parking = 788.26;
            resultDAL.Add(resultDALValue1);

            AccountBalance resultDALValue2 = new AccountBalance();
            resultDALValue2.year = 2017;
            resultDALValue2.month = 2;
            resultDALValue2.rnd = 10000.00;
            resultDALValue2.canteen = 150000.25;
            resultDALValue2.ceocar = 2500.36;
            resultDALValue2.marketing = 69354.25;
            resultDALValue2.parking = 25369.25;
            resultDAL.Add(resultDALValue2);



            List<AccountBalanceEntity> expected = new List<AccountBalanceEntity>();

            AccountBalanceEntity expectedValue1 = new AccountBalanceEntity();
            expectedValue1.year = 2017;
            expectedValue1.month = 1;
            expectedValue1.rnd = 1200.36;
            expectedValue1.canteen = 4563.36;
            expectedValue1.ceocar = -635.89;
            expectedValue1.marketing = 1456.25;
            expectedValue1.parking = 788.26;
            expected.Add(expectedValue1);

            AccountBalanceEntity expectedValue2 = new AccountBalanceEntity();
            expectedValue2.year = 2017;
            expectedValue2.month = 2;
            expectedValue2.rnd = 10000.00;
            expectedValue2.canteen = 150000.25;
            expectedValue2.ceocar = 2500.36;
            expectedValue2.marketing = 69354.25;
            expectedValue2.parking = 25369.25;
            expected.Add(expectedValue2);



            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewBalanceChart(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(resultDAL);

            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
            List<AccountBalanceEntity> actual = accountBalanceService.ViewBalanceChart(startYear, startMonth, endYear, endMonth);

            for (int i = 0; i < actual.Count; i++)
            {
                AssertObjects.PropertyValuesAreEquals(expected[i], actual[i]);
            }
        }


        [Test]
        public void ViewCurrentBalance_Balance_Exists_In_Db()
        {
            string accountType = "canteen";

            AccountBalance accountBalanceDAL = new AccountBalance();
            accountBalanceDAL.year = 2016;
            accountBalanceDAL.month = 1;
            accountBalanceDAL.rnd = 10000.00;
            accountBalanceDAL.canteen = 150000.25;
            accountBalanceDAL.ceocar = 2500.36;
            accountBalanceDAL.marketing = 69354.25;
            accountBalanceDAL.parking = 25369.25;

            double[] expected = new double[] { 0, 150000.25 };


            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
            mockAccountBalanceRepo.Setup(x => x.ViewCurrentBalance()).Returns(accountBalanceDAL);
            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);


            double[] actual = accountBalanceService.ViewCurrentBalance(accountType);

            Assert.AreEqual(expected, actual);


        }
    }
}
