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
            StringBuilder name = new StringBuilder();
            int name_count = random.Next(4)+1;
            for (int i = 0; i < name_count; i++)
            {
                int character_count = random.Next(max_characters_in_name)+1;
                for (int j = 0; j < character_count; j++)
                {
                    name.Append(name_characters[random.Next(name_characters.Length)]);
                }
                if(i < (name_count - 1))
                {
                    name.Append(" ");
                }
            }
            return name.ToString();
        }

        public static string[] Names(int name_count, int max_characters_in_name = 100)
        {
            string[] random_names = new string[name_count];
            for(var i = 0; i < name_count; i++)
            {
                random_names[i] = GenerateName(max_characters_in_name);
            }
            return random_names;
        }


    }
}
