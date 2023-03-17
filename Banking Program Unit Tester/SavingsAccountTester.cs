using Banking_Program;

namespace Banking_Program_Unit_Tester
{
    [TestClass]
    public class SavingsAccountTester
    {
        private readonly SavingsAccount _savingsAccount;

        public SavingsAccountTester()
        {
            _savingsAccount = new SavingsAccount("Test Account", "Test Address", 500.0);
        }

        [TestMethod]
        public void AccountType()
        {
            Assert.AreEqual("Savings", _savingsAccount.GetAccountType());
        }

        [TestMethod]
        public void TestConstructor()
        {
            CDAccount account = new CDAccount();

            Assert.AreEqual("Savings", _savingsAccount.GetAccountType());

            Assert.AreEqual(100.0, _savingsAccount.MinBalance);

            Assert.AreEqual(0.0, _savingsAccount.ServiceFee);
        }

        [TestMethod]
        public void AccountSetAndGetName()
        {
            Assert.IsFalse(_savingsAccount.SetName(null));
            Assert.IsFalse(_savingsAccount.SetName(""));

            Assert.IsTrue(_savingsAccount.SetName("New Account Name"));

            Assert.AreEqual("New Account Name", _savingsAccount.GetName());
        }

        [TestMethod]
        public void AccountSetAndGetAddress()
        {
            Assert.IsFalse(_savingsAccount.SetAddress(null));
            Assert.IsFalse(_savingsAccount.SetAddress(""));

            Assert.IsTrue(_savingsAccount.SetAddress("New Address"));

            Assert.AreEqual("New Address", _savingsAccount.GetAddress());
        }

        [TestMethod]
        public void TestAccountNumberFunction()
        {
            Assert.IsNotNull(_savingsAccount.GetAccountNumber());
            Assert.AreEqual('S', _savingsAccount.GetAccountNumber()[^1]);
        }

        [TestMethod]
        public void TestPayInFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _savingsAccount.PayInFunds(-1.0));

            double balance = _savingsAccount.GetBalance();

            _savingsAccount.PayInFunds(50.0);
            Assert.AreEqual((balance + 50.0), _savingsAccount.GetBalance());
        }

        [TestMethod]
        public void TestWithdrawFunds()
        {
            Assert.ThrowsException<ArgumentException>(() => _savingsAccount.WithdrawFunds(-1.0));

            Assert.IsFalse(_savingsAccount.WithdrawFunds(_savingsAccount.GetBalance()));

            _savingsAccount.PayInFunds(50.0);
            double balance = _savingsAccount.GetBalance();

            _savingsAccount.WithdrawFunds(50.0);
            Assert.AreEqual((balance - 50.0), _savingsAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetBalance()
        {
            Assert.IsFalse(_savingsAccount.SetBalance(_savingsAccount.MinBalance - 50.0));

            Assert.IsTrue(_savingsAccount.SetBalance(1000.0));

            Assert.AreEqual(1000.0, _savingsAccount.GetBalance());
        }

        [TestMethod]
        public void TestSetAndGetAccountState()
        {
            _savingsAccount.SetState(Account.AccountState._underAudit);

            Assert.AreEqual(Account.AccountState._underAudit, _savingsAccount.GetState());
        }

        [TestMethod]
        public void TestSetAndGetServiceFee()
        {
            Assert.IsFalse(_savingsAccount.SetServiceFee(-1.0));

            Assert.IsTrue(_savingsAccount.SetServiceFee(10.0));

            Assert.AreEqual(10.0, _savingsAccount.GetServiceFee());
        }

        [TestMethod]
        public void TestGetAccountType()
        {
            Assert.AreEqual("Savings", _savingsAccount.GetAccountType());
        }
    }
}
