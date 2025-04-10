using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        try
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            driver.Manage().Window.Maximize();

            IWebElement firstNameField = driver.FindElement(By.Id("fname"));
            firstNameField.Clear();
            firstNameField.SendKeys("Tharun");
            Thread.Sleep(10000);

            IWebElement genderMale = driver.FindElement(By.Id("male"));
            genderMale.Click();
            Thread.Sleep(10000);

            IWebElement countryDropdown = driver.FindElement(By.Id("state"));
            SelectElement selectCountry = new SelectElement(countryDropdown);
            selectCountry.SelectByText("India");
            Thread.Sleep(10000);

            if (firstNameField.GetAttribute("value") == "Tharun")
            {
                Console.WriteLine("First Name input verified.");
            }
            else
            {
                Console.WriteLine("First Name verification failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
