using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject4
{
    [TestClass]
    public class Register
    {

        public void PositiveRegister(User user)
        {
            TestSetup.NavigateToUrl(TestSetup.driver, TestSetup.url);
            System.Threading.Thread.Sleep(5000);

            IWebElement RegisterBtn = TestSetup.driver.FindElement(By.XPath("//div/a[.='Register']"));
            TestSetup.HighlightElement(TestSetup.driver, RegisterBtn);
            RegisterBtn.Click();
            System.Threading.Thread.Sleep(3000);

            IWebElement fNameInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Fname']"));
            TestSetup.HighlightElement(TestSetup.driver, fNameInput);
            fNameInput.SendKeys(user.FName);
            System.Threading.Thread.Sleep(1000);

            IWebElement lNameInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Lname']"));
            TestSetup.HighlightElement(TestSetup.driver, lNameInput);
            lNameInput.SendKeys(user.LName);
            System.Threading.Thread.Sleep(1000);

            if (user.Gender.ToUpper() == "FEMALE")
            {
                IWebElement femaleInput = TestSetup.driver.FindElement(By.XPath("//div/label[@for='Female']"));
                TestSetup.HighlightElement(TestSetup.driver, femaleInput);
                femaleInput.Click();
                System.Threading.Thread.Sleep(1000);

            }
            else if (user.Gender.ToUpper() == "MALE") // MALE , male , Male => MALE
            {
                IWebElement maleInput = TestSetup.driver.FindElement(By.XPath("//div/label[@for='Male']"));
                TestSetup.HighlightElement(TestSetup.driver, maleInput);
                maleInput.Click();
                System.Threading.Thread.Sleep(1000);
            }

            IWebElement emailInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Email']"));
            TestSetup.HighlightElement(TestSetup.driver, emailInput);
            emailInput.SendKeys(user.Email);
            System.Threading.Thread.Sleep(1000);

            IWebElement phoneInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Phonenumber']"));
            TestSetup.HighlightElement(TestSetup.driver, phoneInput);
            phoneInput.SendKeys(user.Phone);
            System.Threading.Thread.Sleep(1000);


            IWebElement passwordInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Password']"));
            TestSetup.HighlightElement(TestSetup.driver, passwordInput);
            passwordInput.SendKeys(user.Password);
            System.Threading.Thread.Sleep(1000);

            IWebElement Register = TestSetup.driver.FindElement(By.XPath("//div/input[@value='Register']"));
            TestSetup.HighlightElement(TestSetup.driver, Register);
            Register.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement CheckElement = TestSetup.driver.FindElement(By.XPath("//div/h2[.='Sign In']"));
            string text = CheckElement.GetAttribute("innerText");
            if (text == "Sign In")
            {
                Console.WriteLine("User is registerd successfuly");
                Login.PositiveLogin(user.Email, user.Password);
            }



        }

        [TestMethod]
        public void RunPositiveRegister()
        {
            User user1 = new User();
            user1.FName = GenerateRandomPositiveUsers.CreateFName();
            user1.LName = GenerateRandomPositiveUsers.CreateLName();
            user1.Gender = GenerateRandomPositiveUsers.CreateGender();
            user1.Email = GenerateRandomPositiveUsers.CreateEmail();
            user1.Password = GenerateRandomPositiveUsers.CreatePassword();
            user1.Phone = GenerateRandomPositiveUsers.CreatePhone();

            PositiveRegister(user1);
        }





        [TestMethod]
        public void CheckRequirdRegister()
        {
            Excel excel = new Excel();
            //open excel and send path and number of sheet 
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 4);
            Random rnd = new Random();
            int row = rnd.Next(2, 15);
            NegativeRegister(excel.ReadExcel(1, row), excel.ReadExcel(2, row), excel.ReadExcel(3, row), excel.ReadExcel(4, row), excel.ReadExcel(5, row), excel.ReadExcel(6, row));

            excel.CloseExcel();

        }
        [TestMethod]
        public void checkRequirdFirstName()
        {
            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            NegativeRegister("", excel.ReadExcel(2, row), excel.ReadExcel(3, row), excel.ReadExcel(4, row), excel.ReadExcel(5, row), excel.ReadExcel(6, row));
            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Fname-error']"));
            string text = checkElement.GetAttribute("innerText");
            if (text == "First Name is required")
            {
                Console.WriteLine("first name check requird Done");
       

            }
            else
            {
                throw new Exception("first name is requird");
            }
            excel.CloseExcel();


        }


        [TestMethod]
        public void CheckRequirdLastName()
        {
            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            NegativeRegister(excel.ReadExcel(1, row), "", excel.ReadExcel(3, row), excel.ReadExcel(4, row), excel.ReadExcel(5, row), excel.ReadExcel(6, row));
            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Lname-error']"));
            string text = checkElement.GetAttribute("innerText");
            if (text == "Last Name is required")
            {
                Console.WriteLine("last name check requird Done");
                //beacuse without close function its still running
      
            }
            else
            {
                throw new Exception("last name is requird");
            }
            excel.CloseExcel();
        }




        [TestMethod]
        public void CheckRequirdGender()
        {
            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            NegativeRegister(excel.ReadExcel(1, row), excel.ReadExcel(2, row), "", excel.ReadExcel(4, row), excel.ReadExcel(5, row), excel.ReadExcel(6, row));
            IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Gender-error']"));
            string text = checkElement.GetAttribute("innerText");
            if (text == "This field is required.")
            {
                Console.WriteLine("last name check requird Done");
                //beacuse without close function its still running
                
            }
            else
            {
                throw new Exception("last name is requird");
            }
            excel.CloseExcel();
        }

        //we should check 4 cases on Email
        //1- null    2- without @   3- without domain      4- without .com
        [TestMethod]
        public void CheckRequirdEmail()
        {
            string[] emailCases = {"","dana13gmail.com","dana@.com","dana@gmail" };

            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            for(int i = 0; i<4; i++)
            { 
                  NegativeRegister(excel.ReadExcel(1, row), excel.ReadExcel(2, row),  excel.ReadExcel(3, row), emailCases[i] ,excel.ReadExcel(5, row), excel.ReadExcel(6, row));
                  IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Email-error']"));
                  string text = checkElement.GetAttribute("innerText");
                    if (text == "Email is required" || text== "Please enter a valid e-mail adress")
                    {
                      Console.WriteLine("email check null requird Done");
                      //beacuse without close function its still running
                     
                    }

                   
            
            }
            
            excel.CloseExcel();
        }

        //Not a valid phone number  &  Phone number is required
        //div/span/span[@id='Phonenumber-error'] 
        [TestMethod]
        public void CheckRequirdPhone()
        {
            string[] phoneNumber = { "", "079755568", "079755568888" };

            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            for (int i = 0; i < 3; i++)
            {
                NegativeRegister(excel.ReadExcel(1, row), excel.ReadExcel(2, row), excel.ReadExcel(3, row), excel.ReadExcel(4, row),phoneNumber[i], excel.ReadExcel(6, row));
                IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Phonenumber-error']"));
                string text = checkElement.GetAttribute("innerText");
                if (text == " Phone number is required" || text == "Not a valid phone number")
                {
                    Console.WriteLine("password check requird Done");
                    //beacuse without close function its still running

                }
                
            }
        
            excel.CloseExcel();

        }

        //Password is required  &   Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.
        // //div/span/span[@id='Password-error'] 
        //test case 1- null 2- without symbols  3- without capital letter  4- without small leter    5- without number   6- GREATE THAN 20 (@434wedSSADFDFFHH)     7- LESS THAN 6 
        [TestMethod]
        public void CheckRequirdPassword()
        {
            string[] pass = { "", "Asssss123455", "Askdklda$kA", "alma123#5", "ADANA123@9" , "@434wedSSADFDFFHH" , "A@1e" };

            Excel excel = new Excel();
            excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\Book1.xlsx", 5);
            Random rnd = new Random();
            int row = rnd.Next(2, 12); //valid requirments with null first name 
            for (int i = 0; i < 7; i++)
            {
                NegativeRegister(excel.ReadExcel(1, row), excel.ReadExcel(2, row), excel.ReadExcel(3, row), excel.ReadExcel(4, row), excel.ReadExcel(5, row),pass[i]);
                IWebElement checkElement = TestSetup.driver.FindElement(By.XPath("//div/span/span[@id='Password-error']"));
                string text = checkElement.GetAttribute("innerText");
                if (text == "Password is required" || text == "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")
                {
                    Console.WriteLine("password check requird Done");
                    //beacuse without close function its still running

                }

            }
           
            excel.CloseExcel();

        }


        public static void NegativeRegister(string fName, string lName, string gender, string email, string phone, string password)
        {
            TestSetup.NavigateToUrl(TestSetup.driver, TestSetup.url);
            System.Threading.Thread.Sleep(5000);

            IWebElement RegisterBtn = TestSetup.driver.FindElement(By.XPath("//div/a[.='Register']"));
            TestSetup.HighlightElement(TestSetup.driver, RegisterBtn);
            RegisterBtn.Click();
            System.Threading.Thread.Sleep(3000);

            IWebElement fNameInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Fname']"));
            TestSetup.HighlightElement(TestSetup.driver, fNameInput);
            fNameInput.SendKeys(fName);
            System.Threading.Thread.Sleep(1000);

            IWebElement lNameInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Lname']"));
            TestSetup.HighlightElement(TestSetup.driver, lNameInput);
            lNameInput.SendKeys(lName);
            System.Threading.Thread.Sleep(1000);

            if (gender.ToUpper() == "FEMALE")
            {
                IWebElement femaleInput = TestSetup.driver.FindElement(By.XPath("//div/label[@for='Female']"));
                TestSetup.HighlightElement(TestSetup.driver, femaleInput);
                femaleInput.Click();
                System.Threading.Thread.Sleep(1000);

            }
            else if (gender.ToUpper() == "MALE") // MALE , male , Male => MALE
            {
                IWebElement maleInput = TestSetup.driver.FindElement(By.XPath("//div/label[@for='Male']"));
                TestSetup.HighlightElement(TestSetup.driver, maleInput);
                maleInput.Click();
                System.Threading.Thread.Sleep(1000);
            }

            IWebElement emailInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Email']"));
            TestSetup.HighlightElement(TestSetup.driver, emailInput);
            emailInput.SendKeys(email);
            System.Threading.Thread.Sleep(1000);

            IWebElement phoneInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Phonenumber']"));
            TestSetup.HighlightElement(TestSetup.driver, phoneInput);
            phoneInput.SendKeys(phone);
            System.Threading.Thread.Sleep(1000);


            IWebElement passwordInput = TestSetup.driver.FindElement(By.XPath("//div/input[@id='Password']"));
            TestSetup.HighlightElement(TestSetup.driver, passwordInput);
            passwordInput.SendKeys(password);
            System.Threading.Thread.Sleep(1000);

            IWebElement Register = TestSetup.driver.FindElement(By.XPath("//div/input[@value='Register']"));
            TestSetup.HighlightElement(TestSetup.driver, Register);
            Register.Click();
            System.Threading.Thread.Sleep(1000);



        }



    }
}
