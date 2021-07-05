using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace cybernetV1
{
    class Pagefunctions : BaseClass
    {
        public void Gotourl(string url)
        {
            dr.Url = url;
            dr.Manage().Window.Maximize();
            // string exp_title = "https://staging.cyber.net.pk/Pages/Login.aspx";
            string act_title = dr.FindElement(By.ClassName("login-title")).Text;
            string exp_title = "PEOPLE HUB";


            Console.WriteLine("The site title is " + act_title);
            Assert.That(act_title, Is.EqualTo(exp_title));


            Console.WriteLine("String Constraint Test Passed");

        }


        public void Uploadfile(string cv, string letter)
        {
            IWebElement upload = dr.FindElement(By.Id("MainContent_flResume"));// dr.FindElement(By.XPath("(//input[@class='form-control fileinput-controls'])[1]"));
            ((RemoteWebElement)upload).SendKeys(cv);
            IWebElement upload2 = dr.FindElement(By.Id("MainContent_flCoverLetter"));
            ((RemoteWebElement)upload2).SendKeys(letter);
            Thread.Sleep(3000);

        }


        public void Login(string id, string pw )
        {
            dr.FindElement(By.Id("txtUserName")).SendKeys(id);       
            dr.FindElement(By.Id("txtPassword")).SendKeys(pw);
            dr.FindElement(By.Id("btnLogin")).Click();
        }



        public void closepopup()
        {
            //dr.SwitchTo().Frame("modal inmodal in").Close();
            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement().FindElement(By.XPath("//div[@id='divTaskList']/div[1]/div[1]/div[1]/button[1]/span[1]")).Click();




        }



        public void Applcantlist(string ID, int company ,int job, int source, int status , string name , string cellno, string cnic, string email)
        {

            dr.FindElement(By.XPath("//span[text()='Applicant List']")).Click();

            dr.FindElement(By.Id("MainContent_txtApplicantID")).SendKeys(ID);


            var selectcompnay = dr.FindElement(By.Id("MainContent_ddlcompanySearch"));
            // selected / Cyber Internet Services (Pvt.) Limited / Lakson Business Solutions Limited 
            //  Fulcrum - Third Party / Sybrid - Third Party / NayaPay (Pvt.) Limited
            var dropdowncompany = new SelectElement(selectcompnay);
            dropdowncompany.SelectByIndex(company);
            Thread.Sleep(6000);

            var selectjob = dr.FindElement(By.Id("MainContent_ddlJobTitleSearch"));// selected
            var dropdownjob = new SelectElement(selectjob);
            dropdownjob.SelectByIndex(job);



            var selectsource = dr.FindElement(By.Id("MainContent_ddlApplicantSourceSearch"));//Website / HR / Referral / Fourth
            var dropdownsource = new SelectElement(selectsource);
            dropdownsource.SelectByIndex(source);



            var selectstatus = dr.FindElement(By.Id("MainContent_ddlJobStatusSearch"));
            //selected / Relevant (second priority) / Route to another active job 
            //Park for future job  / Viewed / Finalized
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownstatus.SelectByIndex(status);



            dr.FindElement(By.Id("MainContent_txtApplicantNameSearch")).SendKeys(name);

            dr.FindElement(By.Id("MainContent_txtContactNoSearch")).SendKeys(cellno);

            dr.FindElement(By.Id("MainContent_txtCNICNoSearch")).SendKeys(cnic);

            dr.FindElement(By.Id("MainContent_txtPersonalEmailSearch")).SendKeys(email);

            dr.FindElement(By.Name("ctl00$MainContent$btnSearch")).Click();
            //dr.FindElement(By.Id("MainContent_btnSearch")).Click();


        }


        public void Editsearch(int jobtitle,string name , string number,string cnic, string email , string linkedin , int status, int abtus, string rmks)
        {
            Thread.Sleep(5000);
            //html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]
           var edit= dr.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]"));
           // IWebElement edit = dr.FindElement(By.Name("ctl00$MainContent$rpt$ctl00$lbEdit"));//ctl00$MainContent$rpt$ctl00$lbEdit 
               
            bool isElementDisplayed = dr.FindElement(By.Name("ctl00$MainContent$rpt$ctl00$lbEdit")).Displayed;
            if(isElementDisplayed==true)
            {
                Console.WriteLine("FOUND FOUND");

            }
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
            js.ExecuteScript("arguments[0].scrollIntoView();", edit);
            edit.Click();

            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement();

            Thread.Sleep(2000);
            var selectjobtitle = dr.FindElement(By.Id("MainContent_ddlJobTitleAdd"));// selected
            var dropdownjobtitle = new SelectElement(selectjobtitle);
            dropdownjobtitle.SelectByIndex(jobtitle);


            dr.FindElement(By.Id("MainContent_txtApplicantNameAdd")).Clear();
            dr.FindElement(By.Id("MainContent_txtApplicantNameAdd")).SendKeys(name);

            //

            dr.FindElement(By.Id("MainContent_txtContactNoAdd")).Clear();
            dr.FindElement(By.Id("MainContent_txtContactNoAdd")).SendKeys(number);



            //

            dr.FindElement(By.Id("MainContent_txtcnicadd")).Clear();
            dr.FindElement(By.Id("MainContent_txtcnicadd")).SendKeys(cnic);



            //

            dr.FindElement(By.Id("MainContent_txtPersonalEmailAdd")).Clear();
            dr.FindElement(By.Id("MainContent_txtPersonalEmailAdd")).SendKeys(email);


            //

            dr.FindElement(By.Id("MainContent_txtLinkedInUrl")).Clear();
            dr.FindElement(By.Id("MainContent_txtLinkedInUrl")).SendKeys(linkedin);


            var selectstatus = dr.FindElement(By.Id("MainContent_ddlJobStatus"));// selected
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownjobtitle.SelectByIndex(status);


            var selectabtus = dr.FindElement(By.Id("MainContent_ddlHowHearAboutUS"));// selected
            var dropdownabtus = new SelectElement(selectabtus);
            dropdownjobtitle.SelectByIndex(abtus);

            dr.FindElement(By.Id("MainContent_txtRemark")).Clear();

            dr.FindElement(By.Id("MainContent_txtRemark")).SendKeys(rmks);

            Uploadfile("C:\\NOOQI - Share Meal Plan to folks (ver 1.0).pdf", "C:\\try1.docx");
            



            dr.FindElement(By.Id("MainContent_btnSave")).Click();

        }

    }
}
