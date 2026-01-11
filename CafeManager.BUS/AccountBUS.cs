using CafeManager.DAL.Models;
using CafeManager.DTO;
using CafeManager.DAL;
namespace CafeManager.BUS
{
    public class AccountBUS
    {
        private readonly AccountDAL _accountDal;

        public AccountBUS(AccountDAL accountDal) 
        { 
            _accountDal = accountDal;
        }

        public AccountDTO Login(string username, string password)
        {
            var accountEntity = _accountDal.GetAccount(username, password);

            if (accountEntity == null)
                return null;
            return new AccountDTO
            {   
                Id= accountEntity.Id,
                Displayname= accountEntity.Displayname,
                Type= accountEntity.Type
            };

        }
    }
}
