using System;

// These are functions which may be useful anywhere in the OpenPractice project.
namespace Helpers
{
    public class Platform
    {
        public static bool IsPosix
        {
            get
            {
                int platform_identifier = (int) Environment.OSVersion.Platform;
                return (platform_identifier == 4)
                    || (platform_identifier == 6)
                    || (platform_identifier == 128);
            }
        }

        public static string Delimiter
        {
            get
            {
                if(IsPosix)
                {
                    return "\n";
                } else
                {
                    return "\r\n";
                }
            }
        }
    }
}
