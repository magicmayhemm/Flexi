using System;
using Flexi.SQL;
using Flexi.Users;

namespace Flexi.Commands.Methods
{
    public static class SaveLogs
    {
        public static void Execute(User UserThatCalled, string[] Params)
        {
            if (Permissions.IsStaff(UserThatCalled))
                SQLQueue.ExecutePendingQueries();
        }
    }
}
