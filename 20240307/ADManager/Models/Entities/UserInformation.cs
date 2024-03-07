using Microsoft.AspNetCore.Mvc;

namespace ADManager.Models.Entities
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string LogonName { get; set; }
        public string LogonPassword { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Rank { get; set; }
        public DateTime Timer { get; set; }
    }
}
