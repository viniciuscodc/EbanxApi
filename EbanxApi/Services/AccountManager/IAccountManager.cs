using EbanxApi.Models.Events;

namespace EbanxApi.Services.AccountManager
{
    public interface IAccountManager
    {
        public List<Account> Accounts { get; set; }
        public OperationResultModel? MakeTransaction(string type, OperationModel details);
        public Account? GetAccount(string id);
    }
}
