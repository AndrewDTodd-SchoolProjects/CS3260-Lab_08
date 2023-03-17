// Project Prolog
// Name: Andrew Todd
// CS3260 Section 001
// Project: Lab_03
// Date: 09/11/22
// Purpose: This Project is the first stages of a banking program. The program impements
// the basic functionality and error checking of a bank account structure, as well as Console
// based input for testing and usabuility.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------

using System.Security.Principal;
using System.Text;

namespace Banking_Program
{
    ///<summary>
    /// This class is the program entrypoint and is responsible for handling input and output for the program.
    ///</summary>
    internal class Program
    {
        private static readonly uint MajorRevision = 1;
        private static readonly uint MinorRevision = 0;
        private static readonly uint MacroRevision = 3;
        private static readonly uint BuildRevision = 0;

        private static AccountBank bank = new(10);

        static void Main(string[] args)
        {
            MainMenue();
        }

        static void MainMenue()
        {
            do
            {
                Console.Clear();

                //Header
                Console.WriteLine("UVU Bank | BankNet");
                Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                Console.WriteLine("User: Admin");

                Console.WriteLine("*Main Menue*\n");

                Console.WriteLine("Enter one of the following numbers to enter sub-menue");
                Console.WriteLine("1.) Add Account(s)");
                Console.WriteLine("2.) Search Accounts");
                Console.WriteLine("3.) Account Info Menue");
                Console.WriteLine("Q or esc to quit program\n");

                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                        AddAcountMenue();
                        break;
                    case ConsoleKey.Oem1:
                        AddAcountMenue();
                        break;

                    case ConsoleKey.NumPad2:
                        SearchAccountsMenue();
                        break;
                    case ConsoleKey.Oem2:
                        SearchAccountsMenue();
                        break;

                    case ConsoleKey.NumPad3:
                        DisplayAccountInfoMenue();
                        break;
                    case ConsoleKey.Oem3:
                        DisplayAccountInfoMenue();
                        break;

                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Q:
                        return;
                }
            } while (true);
        }

        static void AddAcountMenue()
        {
            Account _account;
            uint accountNumber;
            do
            {
                Console.Clear();

                //Header
                Console.WriteLine("UVU Bank | BankNet");
                Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                Console.WriteLine("User: Admin");

                Console.WriteLine("*Account Creation Menue*\n");

                Console.WriteLine("How many accounts do you want to add?\nHit escape key to cancel operation and return to Main Menue.");

                if (!CancelableReadLine(out string input))
                    return;
                else if (uint.TryParse(input, out accountNumber))
                    break;
                else
                {
                    Console.WriteLine("Invalid Input, could not parse number. Try again. (Hit key to continue)");
                    Console.ReadKey();
                }
            } while (true);

            for (int i = 0; i < accountNumber; i++)
            {
            Type: do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Account Creation Menue*\n");
                    Console.WriteLine("Making new account...");

                    Console.WriteLine("Enter Account type.\nS for Savings, C for checking, or D for Certificate of Deposit");
                    string? type = Console.ReadLine();

                    type = type.ToLower();

                    switch (type)
                    {
                        case "s":
                            _account = new SavingsAccount();
                            break;
                        case "c":
                            _account = new CheckingAccount();
                            break;
                        case "d":
                            _account = new CDAccount();
                            break;
                        default:
                            Console.WriteLine($"Invalid input. {type} not recognized option. (Hit key to continue)");
                            Console.ReadKey();
                            goto Type;
                    }
                    break;
                } while (true);

                do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Account Creation Menue*\n");
                    Console.WriteLine("Making new account...");

                    Console.WriteLine("Enter the name that will appear on the account.");
                    if (_account.SetName(Console.ReadLine()))
                        break;
                    else
                    {
                        Console.WriteLine("Invalid name entered. Enter a non empty name. (Hit key to continue)");
                        Console.ReadKey();
                    }

                } while (true);

                do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Account Creation Menue*\n");
                    Console.WriteLine("Making new account...");

                    Console.WriteLine("Enter the address that will appear on the account");
                    if (_account.SetAddress(Console.ReadLine()))
                        break;
                    else
                    {
                        Console.WriteLine("Invalid address entered. Enter a non empty address. (Hit key to continue)");
                        Console.ReadKey();
                    }

                } while (true);

                do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Account Creation Menue*\n");
                    Console.WriteLine("Making new account...");

                    Console.WriteLine("Enter the Balance for the new account");

                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        if (_account.SetBalance(num))
                            break;
                        else
                            Console.WriteLine($"Invalid Balance entered. Enter a non-negative balance greater than new account minimum {_account.MinBalance}\n");
                    }
                    else
                    {
                        Console.WriteLine("Input could not be parsed to double. Enter a valid non-negative number. (Hit key to continue)");
                        Console.ReadKey();
                    }

                } while (true);

            State: do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Account Creation Menue*\n");
                    Console.WriteLine("Making new account...");

                    Console.WriteLine("Enter the state for the new account. Default is new (entering null will result in new)");

                    string? input = Console.ReadLine();

                    if (uint.TryParse(input, out uint num))
                    {
                        switch (num)
                        {
                            case 0:
                                Console.WriteLine("Setting state to new");
                                _account.SetState(Account.AccountState._new);
                                break;
                            case 1:
                                Console.WriteLine("Setting state to active");
                                _account.SetState(Account.AccountState._active);
                                break;
                            case 2:
                                Console.WriteLine("Setting state to underAudit");
                                _account.SetState(Account.AccountState._underAudit);
                                break;
                            case 3:
                                Console.WriteLine("Setting state to frozen");
                                _account.SetState(Account.AccountState._frozen);
                                break;
                            case 4:
                                Console.WriteLine("Setting state to closed");
                                _account.SetState(Account.AccountState._closed);
                                break;
                            default:
                                Console.WriteLine("Unrecognized Input. Try again. (Hit Key to continue)");
                                Console.ReadKey();
                                goto State;
                        }
                        Console.WriteLine();
                        break;
                    }
                    else if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Null or Empty string entered. Setting Account State to defualt new state");
                        _account.SetState();
                        Console.WriteLine();
                        break;
                    }
                } while (true);

                if (!_account.GenAccountNumber())
                    Console.WriteLine("Was unable to Generate Account number. Trashing Account");
                else
                {
                    try
                    {
                        bank.StoreAccount(_account);

                        Console.WriteLine("New Account created and added to bank\n");
                        DisplayAccount(bank.FindAccountByNum(_account.GetAccountNumber()));
                        Console.WriteLine("\nHit any Key to continue");
                        Console.ReadKey();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("An Exeption occured!");
                        Console.WriteLine(e.ToString());
                        break;
                    }
                }

                Console.WriteLine();
            }
        }

        static void SearchAccountsMenue()
        {
            List<Account?>? _account = null;

            do
            {
                Console.Clear();

                //Header
                Console.WriteLine("UVU Bank | BankNet");
                Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                Console.WriteLine("User: Admin");

                Console.WriteLine("*Search Accounts Menue*");
                Console.WriteLine($"Bank Total Accounts: {bank.Bank.Count}\n");

                Console.WriteLine("Enter one of the following numbers to enter sub-menue");
                Console.WriteLine("1.) Search Account by account number");
                Console.WriteLine("2.) Search Account by account holder name");
                Console.WriteLine("Q or esc to exit back to Main Menue\n");

                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                        if(bank.Bank.Count == 0)
                        {
                            break;
                        }

                        try
                        {
                            Console.Write("Enter Account Number: ");
                            Account? account = bank.FindAccountByNum(Console.ReadLine());
                            if (account != null)
                            {
                                _account = new();
                                _account.Add(account);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem1:
                        if (bank.Bank.Count == 0)
                        {
                            break;
                        }

                        try
                        {
                            Console.Write("Enter Account Number: ");
                            Account? account = bank.FindAccountByNum(Console.ReadLine());
                            if (account != null)
                            {
                                _account = new();
                                _account.Add(account);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.NumPad2:
                        if (bank.Bank.Count == 0)
                        {
                            break;
                        }

                        try 
                        {
                            Console.Write("Enter Account Holder Name: ");
                            _account = bank.FindAccountByName(Console.ReadLine());
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem2:
                        if (bank.Bank.Count == 0)
                        {
                            break;
                        }

                        try
                        {
                            Console.Write("Enter Account Holder Name: ");
                            _account = bank.FindAccountByName(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Q:
                        return;
                }

                Loop: do
                {
                    Console.Clear();

                    //Header
                    Console.WriteLine("UVU Bank | BankNet");
                    Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                    Console.WriteLine("User: Admin");

                    Console.WriteLine("*Search Accounts Menue*\n");

                    if (_account != null)
                    {
                        Console.WriteLine("Account(s) Found\nDisplay the Account(s) info(y/n)?");
                        ConsoleKeyInfo key = Console.ReadKey();
                        Console.WriteLine();
                        switch (key.Key)
                        {
                            case ConsoleKey.Y:
                                foreach (Account acc in _account)
                                {
                                    DisplayAccount(acc);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input.");
                                goto Loop;
                        }
                        Console.WriteLine("\nHit any Key to continue");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        if(bank.Bank.Count == 0)
                            Console.WriteLine("There are no accounts in the collection");

                        Console.WriteLine("No Account Found");
                        Console.WriteLine("Hit any Key to continue");
                        Console.ReadKey();
                        break;
                    }
                } while (true);
            } while (true);
        }

        static void DisplayAccountInfoMenue()
        {
            Account? _account = null;

            do
            {
                Console.Clear();

                //Header
                Console.WriteLine("UVU Bank | BankNet");
                Console.WriteLine($"UVU Bank Console Interface Version {MajorRevision}.{MinorRevision}.{MacroRevision}.{BuildRevision}");
                Console.WriteLine("User: Admin");

                Console.WriteLine("*Account Info Menue*\n");

                Console.WriteLine("Enter one of the following numbers to enter sub-menue");
                Console.WriteLine("1.) Display all account numbers");
                Console.WriteLine("2.) Display all account holder names");
                Console.WriteLine("3.) Display all accounts general info (number, name, balance");
                Console.WriteLine("4.) Display all accounts full info");
                Console.WriteLine("Q or esc to exit back to Main Menue\n");

                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountNumbers(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem1:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountNumbers(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.NumPad2:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountNames(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem2:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountNames(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.NumPad3:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountGeneralInfo(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem3:
                        try
                        {
                            Console.WriteLine();
                            bank.ReadAllAccountGeneralInfo(out string? output);
                            Console.WriteLine(output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.NumPad4:
                        try
                        {
                            Console.WriteLine();
                            foreach(KeyValuePair<string, Account> pair in bank.Bank)
                            {
                                DisplayAccount(pair.Value);
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case ConsoleKey.Oem4:
                        try
                        {
                            Console.WriteLine();
                            foreach (KeyValuePair<string, Account> pair in bank.Bank)
                            {
                                DisplayAccount(pair.Value);
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An exeption occured!");
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Q:
                        return;

                    default:
                        Console.WriteLine("Input Not recognized. Try again.");
                        break;
                }

                Console.WriteLine("\nHit any key to continue");
                Console.ReadKey();
            } while (true);
        }

        public static bool CancelableReadLine(out string value)
        {
            value = string.Empty;
            var buffer = new StringBuilder();
            var key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.Backspace && Console.CursorLeft > 0)
                {
                    var cli = --Console.CursorLeft;
                    buffer.Remove(cli, 1);
                    Console.CursorLeft = 0;
                    Console.Write(new String(Enumerable.Range(0, buffer.Length + 1).Select(o => ' ').ToArray()));
                    Console.CursorLeft = 0;
                    Console.Write(buffer.ToString());
                    Console.CursorLeft = cli;
                    key = Console.ReadKey(true);
                }
                else if (Char.IsLetterOrDigit(key.KeyChar) || Char.IsWhiteSpace(key.KeyChar))
                {
                    var cli = Console.CursorLeft;
                    buffer.Insert(cli, key.KeyChar);
                    Console.CursorLeft = 0;
                    Console.Write(buffer.ToString());
                    Console.CursorLeft = cli + 1;
                    key = Console.ReadKey(true);
                }
                else if (key.Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0)
                {
                    Console.CursorLeft--;
                    key = Console.ReadKey(true);
                }
                else if (key.Key == ConsoleKey.RightArrow && Console.CursorLeft < buffer.Length)
                {
                    Console.CursorLeft++;
                    key = Console.ReadKey(true);
                }
                else
                {
                    key = Console.ReadKey(true);
                }
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                value = buffer.ToString();
                return true;
            }
            return false;
        }

        static void DisplayAccount(Account? account)
        {
            if (account == null)
            {
                Console.WriteLine("Account is null! No data to display!");
                return;
            }

            try
            {
                Console.WriteLine($"Account type: {account.GetAccountType()}");
                Console.WriteLine($"Name associated with account: {account.GetName()}");
                Console.WriteLine($"Address associated with account: {account.GetAddress()}");
                Console.WriteLine($"Account Number: {account.GetAccountNumber()}");
                Console.WriteLine($"Account Balance: {account.GetBalance()}");
                Console.WriteLine($"Account State: {account.GetState().ToString()}");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Exeption occured in retrieving account data.\n Exeption Type {e.ToString()}");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }
}