using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace WebScrape_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://revenue.stlouisco.com/IAS/";
            string locator = "07J140191";
            Random NewRnd = new Random();
            int waitTime = NewRnd.Next(3, 12) * 1000;

            try
            {
                using (IWebDriver driver = new FirefoxDriver())
                {
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    Thread.Sleep(waitTime);
                    driver.SwitchTo().Frame("SearchInput");
                    IWebElement parcelBox = driver.FindElement(By.CssSelector("#tboxLocatorNum"));
                    parcelBox.SendKeys(locator);
                    Thread.Sleep(waitTime);
                    IWebElement findBtn = driver.FindElement(By.CssSelector("#butFind"));
                    findBtn.Click();
                    Thread.Sleep((waitTime));
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(driver.FindElement(By.XPath("/html/frameset/frameset/frame[2]")));
                    IWebElement resultRow = driver.FindElement(By.CssSelector("#tableData > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(3)"));
                    resultRow.Click();
                    Thread.Sleep(waitTime);
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame("body");
                    string locatorNum = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labLocatorNum")).Text.ToString();
                    string taxYr = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labTaxYear")).Text.ToString();
                    string taxDist = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labTaxDistrict")).Text.ToString();
                    string cityCode = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labCityCode")).Text.ToString();
                    string siteCode = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labSiteCode")).Text.ToString();
                    string destinationCode = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labDestCode")).Text.ToString();
                    string owner = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labOwnerName")).Text.ToString();
                    string taxAddress = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labTaxAddr")).Text.ToString();
                    string careOfNm = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labCareOfName")).Text.ToString();
                    string mailingAdd = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labMailAddr")).Text.ToString();
                    string subDivBkPg = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labSubdivBookPage")).Text.ToString();
                    string assessBkPg = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labAsrBookPage")).Text.ToString();
                    string cityNm = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labCityName")).Text.ToString();
                    string subDivNm = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labSubdivisionName")).Text.ToString();
                    string legalDesc = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labLegalDesc")).Text.ToString();
                    string lotNum = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labLotNum")).Text.ToString();
                    string blockNum = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labBlockNum")).Text.ToString();
                    string lotDim = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labLotDimensions")).Text.ToString();
                    string totalAcres = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labAcres")).Text.ToString();
                    string taxCode = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labTaxCode")).Text.ToString();
                    string landUseCode = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labLandUseCode")).Text.ToString();
                    string deedDocNum = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labRecordersDateDaily")).Text.ToString();
                    string deedType = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labDeedType")).Text.ToString();
                    string deedBkPg = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labDeedBookPage")).Text.ToString();
                    string trashDist = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labTrashDistrict")).Text.ToString();
                    string schoolDist = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labSchoolDistrict")).Text.ToString();
                    string cityCouDist = driver.FindElement(By.CssSelector("#ctl00_MainContent_OwnLeg_labCoCouncilDistrict")).Text.ToString();

                    Console.WriteLine("Locator Number: " + locatorNum + "\n" + "Tax Year: " + taxYr + "\n" + "Tax District: " + taxDist + "\n"
                        + "City Code: " + cityCode + "\n" + "Site Code: " + siteCode + "\n" + "Destination Code: " + destinationCode + "\n"
                        + "Owner(s): " + owner + "\n" + "Tax Address: " + taxAddress + "\n" + "Care Of Name: " + careOfNm + "\n" + "Mailing Address:"
                        + mailingAdd + "\n" + "Subdivision Book/Page: " + subDivBkPg + "\n" + "Assessor Book/Page: " + assessBkPg + "\n" + "City Name: "
                        + cityNm + "\n" + "Subdivision Name: " + subDivNm + "\n" + "Legal Description: " + legalDesc + "\n" + "Lot Number: " + lotNum
                        + "\n" + "Block Number: " + blockNum + "\n" + "Lot Dimensions: " + lotDim + "\n" + "Total Acres: " + totalAcres + "\n"
                        + "Tax Code: " + taxCode + "\n" + "Land Use Code: " + landUseCode + "\n" + "Deed Document Number: " + deedDocNum + "\n"
                        + "Deed Type: " + deedType + "\n" + "Deed Book/Page: " + deedBkPg + "\n" + "Trash District: " + trashDist + "\n"
                        + "School District: " + schoolDist + "\n" + "City Council District: " + cityCouDist);
                    Console.ReadKey();
                    driver.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
