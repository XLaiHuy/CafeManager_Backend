using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CafeManager.DTO
{
    public class AccountDTO
    {   
        public int Id { get; set; }
        public string Displayname { get; set; }

        public int Type { get; set; }
        public string Username { get; set; }
       


    }
    public class AccountInputDTO
    {
      
        public int Id { get; set; }
        [DefaultValue("user")]
        public string Username { get; set; }
        [DefaultValue("")]
        public string Password { get; set; }
        [DefaultValue("")]
        public string Displayname { get; set; }
        [JsonIgnore]
        public int Type { get; set; }
    }
}
