using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject4
    {
    [TestClass]
   public class Login
        {

        public static void LoginTest(string email, string password)
            {
            TestSetup.NavigateToUrl(TestSetup.driver, TestSetup.url);

            System.Threading.Thread.Sleep(5000);

            IWebElement loginBtn = TestSetup.driver.FindElement(By.XPath("//div/a[.='Login']"));
            TestSetup.HighlightElement(TestSetup.driver, loginBtn);
            loginBtn.Click();
            System.Threading.Thread.Sleep(3000);

            IWebElement emailInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='UserName']"));
            TestSetup.HighlightElement(TestSetup.driver, emailInput);
            emailInput.SendKeys(email);
            System.Threading.Thread.Sleep(1000);

            IWebElement passwordInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Passwordd']"));
            TestSetup.HighlightElement(TestSetup.driver, passwordInput);
            passwordInput.SendKeys(password);
            System.Threading.Thread.Sleep(1000);

            IWebElement login = TestSetup.driver.FindElement(By.XPath("//div/input[@value='Log in']"));
            TestSetup.HighlightElement(TestSetup.driver, login);
            login.Click();
            System.Threading.Thread.Sleep(5000);
            }


        public static void PositiveLogin(string email, string password)
            {
            LoginTest(email , password);

            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/h1[.='I am a user']"));
            string text = checkElement.GetAttribute("innerText");
            if(text == "I am a user")
                {
                Console.WriteLine("User can logged in successfully");
                Logout();
                }
            }
        [TestMethod]
         public void RunPositiveLogin ()
            {
            Excel excel = new Excel();
            //excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents - Quality_Assurance__Bayan_Alhassoun_.xlsx", 3);
            //open excel and send path and number of sheet 
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 1);
            Random rnd = new Random();
            int row = rnd.Next(2 , 12); // 7

                PositiveLogin(excel.ReadExcel(5, row), excel.ReadExcel(7, row)); // email [5,3] , password [7,3]

               
            excel.CloseExcel();
            }
        public static void Logout()
            {
            IWebElement Logout = TestSetup.driver.FindElement(By.XPath("//div/a[.='Logout']"));
            TestSetup.HighlightElement(TestSetup.driver, Logout);
            Logout.Click();
            System.Threading.Thread.Sleep(3000);

            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/h2[.='Pato Place']"));
            string text = checkElement.GetAttribute("innerText");
            if (text == "Pato Place")
                {
                Console.WriteLine("User Logout Successfuly");
                }
            }

        public void NegativeLogin (string email , string password)
            {
            LoginTest(email, password);

            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/h2[.='Sign In']"));
            string text = checkElement.GetAttribute("innerText");
            if (text == "Sign In")
                {
                Console.WriteLine("User can't login");
                }
            }
        [TestMethod]
        public void RunNegativeLogin()
            {
            string[] emails = { "Bayan@gmail.com", "Bayan123@gmail.com", "Bayan12@gmail.com" };
            string[] passwords = {  "Bayan@12345", "Bayan@123", "Bayan@12" };

            for (int i = 0; i < emails.Length; i++) // i =1
                {
                NegativeLogin(emails[i] , passwords[i]);
                }

            }


        }
    }
