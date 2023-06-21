using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject4
    {
    class GenerateRandomPositiveUsers
        {
        public static string CreateFName()
            {

            string[] names = { "Bayan", "Dana", "Maram", "Noor", "Farah", "Esraa" };
            Random rnd = new Random();
            string result = names[rnd.Next(0,names.Length)];
            return result;
            }

        public static string CreateLName()
            {

            string[] names = { "Alhassoun", "Mohammad" , "Ahmad" , "Osama"};
            Random rnd = new Random();
            string result = names[rnd.Next(0,names.Length)];
            return result;
            }

        public static string CreateGender()
            {
            string[] genders = { "Male", "Female" };
            Random rnd = new Random();
            string gender = genders[rnd.Next(0, genders.Length)];
            return gender;
            }

        public static string CreateEmail()
            {// syeg23ks@gmail.com
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890._"; // {'a' , 'b' , 'c'}

            string result = ""; // qP2
            Random rnd = new Random();

            for (int i = 0; i < 10; i++) // i = 0 , 1
                {
                result += characters[rnd.Next(0, characters.Length)];
                }
            return result + "@gmail.com"; // -------@gmail.com // Bayan@gmail.com , #%#$^@gmail.com // 12345@gmail.com 

            }

      




        public static string CreatePassword()
            {
            string lowerLeters = "abcdefghijklmnopqrstuvwxyz";
            string upperLeters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "1234567890";
            string symbols = "!@#$%&*+_";

            string result = "";
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
                {
                result += (lowerLeters[rnd.Next(0, lowerLeters.Length)]); // l
                result += (upperLeters[rnd.Next(0, upperLeters.Length)]);//S
                result += (numbers[rnd.Next(0, numbers.Length)]);//4
                result += (symbols[rnd.Next(0, symbols.Length)]);//+

                } // result = lS4+iE8%
            return result;
            // result = afu

            }

        public static string CreatePhone()
            {
            string numbers = "1234567890";
            string result = "";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
                {
                result += numbers[rnd.Next(0, numbers.Length)];
                }
            return result;
            }
        }
    }
