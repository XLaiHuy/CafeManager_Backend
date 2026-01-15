
using CafeManager.DAL.Models;
namespace CafeManager.DAL

{
    public class AccountDAL
    {
        private readonly CafeContext _context; // readonly để đảm bảo rằng biến này không thể bị thay đổi sau khi khởi tạo

        public AccountDAL(CafeContext context) // khởi tạo với CafeContext được truyền vào
        {
            _context = context;
        }
        public Account GetAccount(string username, string pass)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username && a.Password == pass && a.Isdeleted == false);
        }
        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.Where(x => x.Isdeleted == false).ToList(); // can xem lai
        }
        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id && a.Isdeleted == false);
        }
        public Account GetAccountByUserName(string username)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username && a.Isdeleted == false);
        }
        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
        public void DeleteAccount(Account account)
        {
            account.Isdeleted = true;
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
    }
}
/**/