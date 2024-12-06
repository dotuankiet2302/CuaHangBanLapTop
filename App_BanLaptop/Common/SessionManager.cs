using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SessionManager
    {
        public static int CurrentCustomerId { get; set; } = -1;
        public static string CurrentUserName { get; set; } = string.Empty;
        public static string CurrentCustomerName { get; set; } = string.Empty; // Thêm property này
        
        public static void ClearSession()
        {
            CurrentCustomerId = -1;
            CurrentUserName = string.Empty;
            CurrentCustomerName = string.Empty;
        }
    }
}