
using CafeManager.DAL.Models;
using CafeManager.DTO;
using CafeManager.DAL;
using System.Security.Cryptography.X509Certificates;
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
                Id = accountEntity.Id,
                Displayname = accountEntity.Displayname,
                Type = accountEntity.Type
            };
        }
        public List<AccountDTO> GetAccount()
        {
            var list = _accountDal.GetAllAccounts();
            return list.Select(a => new AccountDTO
            {
                Id = a.Id,
                Displayname = a.Displayname,
                Type = a.Type,
                
            }).ToList();
        }
        public void createAccount(AccountInputDTO input)
        {
            if (_accountDal.GetAccountByUserName(input.Username) != null)
            {
                throw new Exception("Username already exists");
            }
            else
            {
                var acc = new Account
                {
                    Username = input.Username,
                    Password = input.Password,
                    Displayname = input.Displayname,
                    Type = 0,
                    Isdeleted = false
                };
                _accountDal.AddAccount(acc);
            }
        }
        public void updateAccount(AccountInputDTO input)
        {
            var acc = _accountDal.GetAccountById(input.Id);
            if (acc == null)
            {
                throw new Exception("Account not found");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(input.Username) && input.Username != "user")
                {

                    var checkUser = _accountDal.GetAccountByUserName(input.Username);
                    if (checkUser != null && checkUser.Id != input.Id)
                    {
                        throw new Exception("Tên đăng nhập này đã có người khác sử dụng!");
                    }
                    acc.Username = input.Username;
                }
                if (!string.IsNullOrWhiteSpace(input.Password) && input.Password != "string")
                {
                    acc.Password = input.Password;
                }
                if (!string.IsNullOrWhiteSpace(input.Displayname) && input.Displayname != "string")
                {
                    acc.Displayname = input.Displayname;
                }
                _accountDal.UpdateAccount(acc);
            }
        }
        public void deleteAccount(int id)
        {
            var acc = _accountDal.GetAccountById(id);
            if (acc == null)
            {
                throw new Exception("Account not found");
            }
            else
            {
                _accountDal.DeleteAccount(acc);
            }
        }
    }
}
