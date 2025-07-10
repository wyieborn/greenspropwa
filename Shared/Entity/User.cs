using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreensProPWA.Shared.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Staff";  // or "Admin"
        public string PasswordHash { get; set; } = string.Empty; // placeholder

        public bool IsTrainer { get; set; } = false;
    }
}
