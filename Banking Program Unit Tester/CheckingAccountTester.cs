using Banking_Program;

namespace Banking_Program_Unit_Tester
{
    [TestClass]
    public class CheckingAccountTester
    {
        private readonly CheckingAccount _checkingAccount;

        public CheckingAccountTester()
        {
            _checkingAccount = new CheckingAccount("Test Account", "Test Address", 500.0);
        }

        [TestMethod]
        public void AccountType()
        {
            Assert.AreEqual("Checking", _checkingAccount.GetAccountType());
        }

        [TestMethod]
        public void TestConstructor()
        {
            CDAccount account = new CDAccount();

            Assert.AreEqual("Checking", _checkingAccount.GetAccountType());

            Assert.AreEqual(10.0, _checkingAccount.MinBalance);

            Assert.AreEqual(5.0, _checkingAccount.ServiceFee);
        }

        [TestMethod]
        public void AccountSetAndGetName()
        {
            Assert.IsFalse(_checkingAccount.SetName(null));
            Assert.IsFalse(_checkingAccount.SetName(""));

            Assert.IsTrue(_checkingAccount.SetName("New Account Name"));

            Assert.AreEqual("New Account Name", _checkingAccount.GetName());
        }

        [TestMethod]
        public void AccountSetAndGetAddress()
        {
            Assert.IsFalse(_checkingAccount.SetAddress(null));
            Assert.IsFalse(_checkingAccount.SetAddress(""));

            Assert.IsTrue(_checkingAccount.SetAddress("New Address"));

            Assert.AreEqual("New Address", _checkingAccount.GetAddress());
        }

        [TestMethod]
        public void TestAccountNumberFunction()
        {
            Assert.IsNotNull(_checkingAccount.GetAccountNumber());
            Assert.AreEqual('C', _checkingAccount.GetAccountNumber()[^1]);
        }

        [TestMethod]
        public void TestPayInFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _checkingAccount.PayInFunds(-1.0));

            double balance = _checkingAccount.GetBalance();

            _checkingAccount.PayInFunds(50.0);
            Assert.AreEqual((balance + 50.0), _checkingAccount.GetBalance());
        }

        [TestMethod]
        public void TestWithdrawFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _checkingAccount.WithdrawFunds(-1.0));

            Assert.IsFalse(_checkingAccount.WithdrawFunds(_checkingAccount.GetBalance()));

            _checkingAccount.PayInFunds(50.0);
            double balance = _checkingAccount.GetBalance();

            _checkingAccount.WithdrawFunds(50.0);
            Assert.AreEqual((balance - 50.0), _checkingAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetBalance()
        {
            Assert.IsFalse(_checkingAccount.SetBalance(_checkingAccount.MinBalance - 50.0));

            Assert.IsTrue(_checkingAccount.SetBalance(1000.0));

            Assert.AreEqual(1000.0, _checkingAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetAndGetAccountState()
        {
            _checkingAccount.SetState(Account.AccountState._underAudit);

            Assert.AreEqual(Account.AccountState._underAudit, _checkingAccount.GetState());
        }

        [TestMethod]
        public void TestSetAndGetServiceFee()
        {
            Assert.IsFalse(_checkingAccount.SetServiceFee(-1.0));

            Assert.IsTrue(_checkingAccount.SetServiceFee(10.0));

            Assert.AreEqual(10.0, _checkingAccount.GetServiceFee());
        }

        [TestMethod]
        public void TestGetAccountType()
        {
            Assert.AreEqual("Checking", _checkingAccount.GetAccountType());
        }
    }
}
