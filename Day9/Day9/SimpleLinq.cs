using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLinq
{
    class profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            profile[] arrProfile =
            {
                new profile(){Name = "정우성", Height = 186},
                new profile(){Name = "김태희", Height = 158},
                new profile(){Name = "고현정", Height = 172},
                new profile(){Name = "이문세", Height = 178},
                new profile(){Name = "하하", Height = 171}
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}
