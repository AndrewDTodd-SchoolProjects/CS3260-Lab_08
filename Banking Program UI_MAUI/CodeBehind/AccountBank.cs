using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Program
{
    public class AccountBank : IAccountBank
    {
        #region MEMBERS
        //private List<Account> bank = new();
        private Dictionary<string, Account> bank = new();
        #endregion

        #region CONSTRUCTORS
        public AccountBank(uint bankCap)
        {
            bank.EnsureCapacity((int)bankCap);
        }
        #endregion

        #region PUBLIC_METHODS
        public bool StoreAccount(Account? account)
        {
            if (account == null)
                throw new NullReferenceException();

            try
            {
                bank.Add(account.GetAccountNumber(), account);
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            return true;
        }
        public Account? FindAccountByNum(string? accountNum)
        {
            if (string.IsNullOrEmpty(accountNum))
                return null;

            try
            {
                if(bank.TryGetValue(accountNum, out Account? account))
                    return account;
                else
                    return null;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
        }
        public List<Account?>? FindAccountByName(string? holderName)
        {
            if (string.IsNullOrEmpty(holderName))
                return null;

            List<Account> accountList = new List<Account>();

            foreach(KeyValuePair<string, Account> pair in bank)
            {
                if(pair.Value.GetName() == holderName)
                    accountList.Add(pair.Value);
            }

            if (accountList.Count > 0)
                return accountList;

            return null;
        }

        public void ReadAllAccountNumbers(out string? output)
        {
            output = null;

            foreach(KeyValuePair<string,Account> pair in bank)
            {
                output += pair.Key;
                output += '\n';
            }
        }
        public void ReadAllAccountNames(out string? output)
        {
            output = null;

            foreach(KeyValuePair<string,Account> pair in bank)
            {
                output += pair.Value.GetName();
                output += '\n';
            }
        }
        public void ReadAllAccountGeneralInfo(out string? output)
        {
            output = null;

            foreach (KeyValuePair<string, Account> pair in bank)
            {
                output += $"{pair.Key}: {pair.Value.GetName()}, balance ({pair.Value.GetBalance()})\n";
            }
        }

        #endregion

        #region GET_SET
        public ref Dictionary<string, Account> Bank 
        {
            get { return ref bank; }
        }

        public int Count
        {
            get => bank.Count;
        }
        #endregion
    }
}
