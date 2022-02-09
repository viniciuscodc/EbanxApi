using EbanxApi.Models.Events;

namespace EbanxApi.Services.AccountManager
{
    public class Operations
    {
        public OperationResultModel Deposit(OperationModel details, List<Account> accounts)
        {
            var account = accounts.FirstOrDefault(x => x.Id == details.Destination);

            var result = new OperationResultModel();

            if (account == null)
            {
                var newAccount = new Account
                {
                    Id = details.Destination,
                    Balance = details.Amount
                };

                accounts.Add(newAccount);

                result.Destination = newAccount;

                return result;
            }

            var newBalance = account.Balance += details.Amount;

            result.Destination = new Account
            {
                Id = details.Destination,
                Balance = newBalance
            };

            return result;
        }

        public OperationResultModel? Withdraw(OperationModel details, List<Account> accounts)
        {
            var account = accounts.FirstOrDefault(x => x.Id == details.Origin);

            if(account == null) { return null; }

            account.Balance -= details.Amount;

            var result = new OperationResultModel {
                Origin = account
            };

            return result;
        }

        public OperationResultModel? Transfer(OperationModel details, List<Account> accounts)
        {
            var account = accounts.FirstOrDefault(x => x.Id == details.Origin);

            if (account == null) { return null; }

            var destinationAccount = new Account { Id = details.Destination };

            account.Balance -= details.Amount;
            destinationAccount.Balance += details.Amount;

            var result = new OperationResultModel
            {
                Origin = account,
                Destination = destinationAccount
            };

            return result;
        }
    }
}
