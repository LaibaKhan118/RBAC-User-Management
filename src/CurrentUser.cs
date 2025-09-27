using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherForm
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static bool IsActive { get; set; }
        public static int RoleId { get; set; }
        public static string RoleName { get; set; }

        public static bool IsAdmin => RoleName == "Admin";
        public static bool IsMaker => RoleName == "Maker";
        public static bool IsChecker => RoleName == "Checker";
        public static List<string> Groups { get; set; } = new List<string>();
        public static List<string> Permissions { get; set; } = new List<string>();

        public static bool HasPermission(string screen, string action)
        {
            return Permissions.Contains($"{screen}:{action}");
        }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            IsActive = false;
            Groups.Clear();
            Permissions.Clear();
        }
    }
}
