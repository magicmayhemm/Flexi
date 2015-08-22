using System;
using Flexi.Users;

namespace Flexi.Commands
{
    public static class Permissions
    {
        public static bool IsStaff(User User)
        {
            if (User.Rank > 1)
                return true;
            return false;
        }
    }
}