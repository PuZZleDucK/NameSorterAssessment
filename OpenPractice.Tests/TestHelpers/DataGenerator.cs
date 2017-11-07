using System;
using System.Diagnostics;
using System.Text;
using Helpers;
using TestHelpers;

namespace TestHelpers
{
    public class DataGenerator
    {
        private static Random random = new Random();
        private static string name_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.,()_'";

        private static string GenerateName(int max_characters_in_name)
        {
            StringBuilder new_name = new StringBuilder();
            int name_parts_count = random.Next(4)+1;
            for (; name_parts_count > 0; name_parts_count--)
            {
                for (int character_count = random.Next(max_characters_in_name); character_count > 0; character_count--)
                {
                    new_name.Append(name_characters[random.Next(name_characters.Length)]);
                }
                if(name_parts_count > 0)
                {
                    new_name.Append(" ");
                }
            }
            return new_name.ToString();
        }

        public static string[] Names(int name_count, int max_characters_in_name = 100)
        {
            string[] random_names = new string[name_count];
            for(; name_count > 0 ; name_count--)
            {
                random_names[name_count-1] = GenerateName(max_characters_in_name);
            }
            return random_names;
        }


    }
}
