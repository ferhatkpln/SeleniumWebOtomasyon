﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebOtomasyon
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Program Files (x86)\Google\Chrome\Application\chromedriver.exe");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"https://www.beymen.com/");

            try
            {
                driver.FindElement(By.LinkText("Hesabım")).Click();
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Favorilerim")).Click();
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Sepetim")).Click();
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.ClassName("o-header__logo")).Click();
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.ClassName("input-wrapper")).Click();
                driver.FindElement(By.XPath("//input[@aria-controls='3-suggestions']")).SendKeys("pantolon");
                driver.FindElement(By.XPath("//input[@aria-controls='3-suggestions']")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.XPath("//div[@class='o-productList']/div[1]/div[3]/div/div/button")).Click();

                driver.FindElement(By.LinkText("Beyaz Krep Cigarette Pantolon")).Click();
                driver.FindElement(By.CssSelector("[class='m-variation__item']")).Click();
                driver.FindElement(By.Id("addBasket")).Click();
                var ücret = driver.FindElement(By.Id("priceNew")).Text;
                Console.WriteLine("ücret {0}", ücret);
                driver.FindElement(By.XPath("//div[@class='container']/div/div[3]/div/a[3]")).Click();

                var ücret2 = driver.FindElement(By.XPath("//div[@class='row']/div[2]/div/div[2]/ul/li[4]/span[2]")).Text;
                Console.WriteLine("ücret {0}", ücret2);
                if (ücret == ücret2)
                {
                    Console.WriteLine("Ücretler aynı");
                }
                else
                {
                    Console.WriteLine("Ücretler Aynı Değil. Ürüne İndirim Uygulanmıştır.");
                }

                IWebElement element = driver.FindElement(By.Id("quantitySelect0"));
                SelectElement selected = new SelectElement(element);
                selected.SelectByValue("2");
                System.Threading.Thread.Sleep(2000);

                var yeniücret = driver.FindElement(By.CssSelector(".m-orderSummary__item.-grandTotal")).Text;
                if (yeniücret != ücret2)
                {
                    Console.WriteLine("Ürün Adeti 2 dir");
                }
                else
                {
                    Console.WriteLine("Ürün Adeti Artmamıştır");
                }
                driver.FindElement(By.Id("removeCartItemBtn0")).Click();
                System.Threading.Thread.Sleep(2000);
                var sepetboşmu = driver.FindElement(By.XPath("//div/div/div[@class='col-12']/div/div/strong")).Text.ToLower();
                System.Threading.Thread.Sleep(2000);
                if (sepetboşmu == "sepetınızde ürün bulunmamaktadır")
                {
                    Console.WriteLine("Sepetiniz Boş :{0}", sepetboşmu.ToUpper());
                }
                else
                {
                    Console.WriteLine("Sepet Boş Değil:{0}", sepetboşmu);
                }
                Console.Read();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.Read();

        }
    }
}
