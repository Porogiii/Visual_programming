using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Account
    {
        private decimal _balance;
        private List<INotifyer> _notifyer;

        public Account()
        {
            _balance = 0;
            _notifyer = [];
        }

        public Account(decimal balance)
        {
            _balance = balance;
            _notifyer = [];
        }

        public void AddNotifyer(INotifyer notifyer)
        {
            _notifyer.Add(notifyer);
        }

        public void ChangeBalance(decimal value)
        {
            _balance += value;
            Notification();
        }

        public decimal Balance()
        {
            return _balance;
        }

        private void Notification()
        {
            foreach (var INotifyer in _notifyer)
            {
                INotifyer.Notify(_balance);
            }
        }
    }

    public interface INotifyer
    {
        void Notify(decimal _balance);
    }

    class SMSLowBalanceNotifyer : INotifyer
    {
        private string _phone;
        private decimal _lowBalanceValue;

        public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue)
        {
            _phone = phone;
            _lowBalanceValue = lowBalanceValue;
        }

        public void Notify(decimal _balance)
        {
            if (_balance <= _lowBalanceValue)
            {
                Console.WriteLine("SMSLowBalanceNotifyer");
                Console.WriteLine(_phone);
                Console.WriteLine($"SMS: Внимание, у вас мало средств на вашем балансе! Текущий баланс составляет {_balance}");
            }
        }
    }

    class EMailBalanceChangedNotifyer : INotifyer
    {
        private string _email;

        public EMailBalanceChangedNotifyer(string email)
        {
            _email = email;
        }

        public void Notify(decimal _balance)
        {
            Console.WriteLine("EMailBalanceChangedNotifyer");
            Console.WriteLine(_email);
            Console.WriteLine($"Email: Внимание, ваш баланс поменялся! Текущий баланс {_balance}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример без использования конструктора с полями\n");

            // Создаём аккаунт и базовые уведомления
            Account account = new Account();
            EMailBalanceChangedNotifyer emailNotification = new EMailBalanceChangedNotifyer("artemrusetskiy2004@gmail.com");
            SMSLowBalanceNotifyer smsNotification = new SMSLowBalanceNotifyer("+79833244599", 999);

            // Отправляем уведомления в лист, меняем баланс
            account.AddNotifyer(emailNotification);
            account.AddNotifyer(smsNotification);
            account.ChangeBalance(2000);
            account.ChangeBalance(-100);
            account.ChangeBalance(-1400);
            //Console.WriteLine(account.Balance());

            Console.WriteLine("\nПример с использованием конструктора с полями\n");

            // Всё то же самое, что и выше
            Account account1 = new Account(1500);
            //Console.WriteLine(account1.Balance());
            account1.AddNotifyer(emailNotification);
            account1.AddNotifyer(smsNotification);
            account1.ChangeBalance(4300);
            account1.ChangeBalance(-1400);
            account1.ChangeBalance(-5000);
        }
    }
}