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
    }
}
