using EbanxApi.Models.Events;
using EbanxApi.Services.AccountManager;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject
{
    public class AccountManagerTests
    {
        private readonly IAccountManager _accountManager;

        public AccountManagerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IAccountManager, AccountManager>()
                .BuildServiceProvider();

            _accountManager = serviceProvider.GetRequiredService<IAccountManager>();
        }

        [Fact]
        public void DepositToNonExistingAccountReturnsDepositValue()
        {
            var type = "deposit";
            var details = new OperationModel
            {
                Amount = 29,
                Destination = "40",
            };

            var result = _accountManager.MakeTransaction(type, details);

            Assert.True(result?.Destination?.Balance == details.Amount);
        }

        [Fact]
        public void WithdrawFromExistingAccountReducesOriginBalance()
        {
            var initialBalance = 80;

            var account = new Account
            {
                Id = "1",
                Balance = initialBalance
            };
            _accountManager.Accounts.Add(account);

            var type = "withdraw";
            var details = new OperationModel
            {
                Amount = 70,
                Origin = "1",
            };

            var result = _accountManager.MakeTransaction(type, details);

            Assert.True(result?.Origin?.Balance == initialBalance - details.Amount);
        }

        [Fact]
        public void TransferForExistingAccountReducesOriginBalance()
        {
            var originInitialBalance = 80;

            var originAccount = new Account
            {
                Id = "1",
                Balance = originInitialBalance
            };

            var destinationAccount = new Account
            {
                Id = "2",
                Balance = 40
            };

            _accountManager.Accounts.Add(originAccount);
            _accountManager.Accounts.Add(destinationAccount);

            var type = "transfer";
            var details = new OperationModel
            {
                Origin = "1",
                Destination = "2",
                Amount = 10
            };

            var result = _accountManager.MakeTransaction(type, details);

            Assert.True(result?.Origin?.Balance == originInitialBalance - details.Amount);
        }

        [Fact]
        public void TransferForExistingAccountIncreasesDestinationBalance()
        {
            var originAccount = new Account
            {
                Id = "1",
                Balance = 90
            };

            var destinationInitialBalance = 50;

            var destinationAccount = new Account
            {
                Id = "2",
                Balance = destinationInitialBalance
            };

            _accountManager.Accounts.Add(originAccount);
            _accountManager.Accounts.Add(destinationAccount);

            var type = "transfer";
            var details = new OperationModel
            {
                Origin = "1",
                Destination = "2",
                Amount = 10
            };

            var result = _accountManager.MakeTransaction(type, details);

            Assert.True(result?.Destination?.Balance == destinationInitialBalance + details.Amount);
        }
    }
}