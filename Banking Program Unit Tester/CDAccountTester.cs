using Banking_Program;

namespace Banking_Program_Unit_Tester
{
    [TestClass]
    public class CDAccountTester
    {
        private readonly CDAccount _cdAccount;

        public CDAccountTester()
        {
            _cdAccount = new CDAccount("Test Account","Test Address",500.0);
        }

        [TestMethod]
        public void AccountType()
        {
            Assert.AreEqual("Certificate of Deposit", _cdAccount.GetAccountType());
        }

        [TestMethod]
        public void TestConstructor()
        {
            CDAccount account = new();

            Assert.AreEqual("Certificate of Deposit", _cdAccount.GetAccountType());

            Assert.AreEqual(500.0, _cdAccount.MinBalance);

            Assert.AreEqual(8.0, _cdAccount.ServiceFee);
        }

        [TestMethod]
        public void AccountSetAndGetName()
        {
            Assert.IsFalse(_cdAccount.SetName(null));
            Assert.IsFalse(_cdAccount.SetName(""));

            Assert.IsTrue(_cdAccount.SetName("New Account Name"));

            Assert.AreEqual("New Account Name", _cdAccount.GetName());
        }

        [TestMethod]
        public void AccountSetAndGetAddress()
        {
            Assert.IsFalse(_cdAccount.SetAddress(null));
            Assert.IsFalse(_cdAccount.SetAddress(""));

            Assert.IsTrue(_cdAccount.SetAddress("New Address"));

            Assert.AreEqual("New Address", _cdAccount.GetAddress());
        }

        [TestMethod]
        public void TestAccountNumberFunction()
        {
            Assert.IsNotNull(_cdAccount.GetAccountNumber());
            Assert.AreEqual('D', _cdAccount.GetAccountNumber()[^1]);
        }

        [TestMethod]
        public void TestPayInFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _cdAccount.PayInFunds(-1.0));

            double balance = _cdAccount.GetBalance();

            _cdAccount.PayInFunds(50.0);
            Assert.AreEqual((balance + 50.0), _cdAccount.GetBalance());
        }

        [TestMethod]
        public void TestWithdrawFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _cdAccount.WithdrawFunds(-1.0));

            Assert.IsFalse(_cdAccount.WithdrawFunds(_cdAccount.GetBalance()));

            _cdAccount.PayInFunds(50.0);
            double balance = _cdAccount.GetBalance();

            _cdAccount.WithdrawFunds(50.0);
            Assert.AreEqual((balance - 50.0), _cdAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetBalance()
        {
            Assert.IsFalse(_cdAccount.SetBalance(_cdAccount.MinBalance - 50.0));

            Assert.IsTrue(_cdAccount.SetBalance(1000.0));

            Assert.AreEqual(1000.0, _cdAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetAndGetAccountState()
        {
            _cdAccount.SetState(Account.AccountState._underAudit);

            Assert.AreEqual(Account.AccountState._underAudit, _cdAccount.GetState());
        }

        [TestMethod]
        public void TestSetAndGetServiceFee()
        {
            Assert.IsFalse(_cdAccount.SetServiceFee(-1.0));

            Assert.IsTrue(_cdAccount.SetServiceFee(10.0));

            Assert.AreEqual(10.0, _cdAccount.GetServiceFee());
        }

        [TestMethod]
        public void TestGetAccountType()
        {
            Assert.AreEqual("Certificate of Deposit", _cdAccount.GetAccountType());
        }
    }
}