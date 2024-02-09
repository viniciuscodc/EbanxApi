using EbanxApi.Models.Events;

namespace EbanxApi.Services.AccountManager
{
    public class Operations
    {
        public OperationResultModel Deposit(OperationModel details, List<Account> accounts)
        {
            var account = accounts.FirstOrDefault(x => x.Id == details.Destination);

            if (account == null)
            {
                var newAccount = new Account
                {
                    Id = details.Destination!,
                    Balance = details.Amount
                };

                accounts.Add(newAccount);

                return new OperationResultModel
                {
                    Destination = newAccount,
                };
            }

            var newBalance = account.Balance += details.Amount;

            return new OperationResultModel 
            { 
                Destination = new Account
                {
                    Id = details.Destination!,
                    Balance = newBalance
                }
            };
        }

        public OperationResultModel? Withdraw(OperationModel details, List<Account> accounts)
        {
            var account = accounts.FirstOrDefault(x => x.Id == details.Origin);

            if(account == null) { return null; }

            account.Balance -= details.Amount;

            return new OperationResultModel {
                Origin = account
            };
        }

        public OperationResultModel? Transfer(OperationModel details, List<Account> accounts)
        {
            var originAccount = accounts.FirstOrDefault(x => x.Id == details.Origin);

            if (originAccount == null) { return null; }

            var destinationAccount = accounts.FirstOrDefault(x => x.Id == details.Destination);

            if(destinationAccount == null)
            {
                destinationAccount = new Account { 
                    Id = details.Destination!,
                    Balance = 0
                };
            }

            originAccount.Balance -= details.Amount;
            destinationAccount.Balance += details.Amount;

            return new OperationResultModel
            {
                Origin = originAccount,
                Destination = destinationAccount
            };
        }
    }
}
