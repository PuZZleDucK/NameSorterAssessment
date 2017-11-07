using System;

namespace Helpers
{
    public class Platform
    {
        public static bool IsPosix
        {
            get
            {
                int p = (int) Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

    }
}
