using EbanxApi.Models.Events;

namespace EbanxApi.Services.AccountManager
{
    public class AccountManager : IAccountManager
    {
        public List<Account> Accounts { get; set; }

        public AccountManager()
        {
            Accounts = new List<Account>();
        }

        public Account? GetAccount(string id)
        {
            var account = Accounts.FirstOrDefault(x => x.Id == id);

            return account;
        }

        public OperationResultModel? MakeTransaction(string type, OperationModel details)
        {
            var operations = new Operations();

            return type switch
            {
                "deposit" => operations.Deposit(details, Accounts),
                "withdraw" => operations.Withdraw(details, Accounts),
                "transfer" => operations.Transfer(details, Accounts),
                _ => null
            };
        }
    }
}
