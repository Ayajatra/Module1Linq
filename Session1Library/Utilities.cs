using System.Linq;

namespace Session1Library
{
    public static class Utilities
    {
        public static int GetLastUserID()
        {
            using (var session = new Session1Entities())
            {
                if (int.TryParse(session.Users.Max(u => u.ID).ToString(), out int maxID))
                {
                    return maxID;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}