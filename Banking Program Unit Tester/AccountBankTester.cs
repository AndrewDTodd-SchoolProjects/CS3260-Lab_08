using Banking_Program;

namespace Banking_Program_Unit_Tester
{
    [TestClass]
    public class AccountBankTester
    {
        private readonly AccountBank _bank;

        public AccountBankTester()
        {
            _bank = new(3);
        }

        [TestMethod]
        public void TestStoreAccount()
        {
            Assert.ThrowsException<NullReferenceException>(() => _bank.StoreAccount(null));

            Assert.ThrowsException<ArgumentNullException>(() => _bank.StoreAccount(new CDAccount()));

            _bank.StoreAccount(new CDAccount("New Test CD Account", "New Account Address", 1000.0));

            Assert.AreEqual(1, _bank.Count);
        }

        [TestMethod]
        public void TestFindAccountByNum()
        {
            SavingsAccount account = new SavingsAccount("New Savings Account", "Saving Account Address", 550.25);

            string accNum = account.GetAccountNumber();

            Assert.IsNotNull(accNum);

            _bank.StoreAccount(account);

            Assert.IsNull(_bank.FindAccountByNum(null));

            Assert.IsNotNull(_bank.FindAccountByNum(accNum));
        }

        [TestMethod]
        public void TestFindAccountByName()
        {
            CheckingAccount account = new("New Checking Account", "Checking Address", 523.2);

            _bank.StoreAccount(account);

            Assert.IsNull(_bank.FindAccountByName(null));

            Assert.IsNotNull(_bank.FindAccountByName("New Checking Account"));
        }

        [TestMethod]
        public void TestReadAllAccountNumbers()
        {
            CDAccount account = new("Yet Another CD Account", "And another address", 520.0);

            new AccountBank(1).ReadAllAccountNumbers(out string? numbers);
            Assert.IsNull(numbers);

            _bank.StoreAccount(account);
            _bank.ReadAllAccountNumbers(out string? _bankNumbers);
            Assert.IsNotNull(_bankNumbers);
        }

        [TestMethod]
        public void TestReadAllAccountNames()
        {
            SavingsAccount account = new("Yet Another Savings Account", "And yet another address", 520.0);

            new AccountBank(1).ReadAllAccountNames(out string? names);
            Assert.IsNull(names);

            _bank.StoreAccount(account);
            _bank.ReadAllAccountNames(out string? _bankNames);
            Assert.IsNotNull(_bankNames);
        }

        [TestMethod]
        public void TestReadAllAccountGeneralInfo()
        {
            CheckingAccount account = new("Yet Another Checking Account", "Third Address", 580.0);

            new AccountBank(1).ReadAllAccountGeneralInfo(out string? info);
            Assert.IsNull(info);

            _bank.StoreAccount(account);
            _bank.ReadAllAccountNames(out string? _bankInfo);
            Assert.IsNotNull(_bankInfo);
        }
    }
}
