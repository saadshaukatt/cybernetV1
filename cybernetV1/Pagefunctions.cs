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




        #region

        By logintitle = By.ClassName("login-title");
        By upload1 = By.Id("MainContent_flResume");
        By upload22 = By.Id("MainContent_flCoverLetter");
        By login = By.Id("txtUserName");
        By password = By.Id("txtPassword");
        By loginclick = By.Id("btnLogin");
        By closepopup1 = By.XPath("//div[@id='divTaskList']/div[1]/div[1]/div[1]/button[1]/span[1]");
        By applist = By.XPath("//span[text()='Applicant List']");
        By appID = By.Id("MainContent_txtApplicantID");
        By companyid = By.Id("MainContent_ddlcompanySearch");
        By jobtitle= By.Id("MainContent_ddlJobTitleSearch");
        By appSS= By.Id("MainContent_ddlApplicantSourceSearch");

        By jobSS = By.Id("MainContent_ddlJobStatusSearch");
        By namesearch = By.Id("MainContent_txtApplicantNameSearch");
        By contactsearh = By.Id("MainContent_txtContactNoSearch");
        By cnicsearch = By.Id("MainContent_txtCNICNoSearch");
        By personalemailsearch = By.Id("MainContent_txtPersonalEmailSearch");
        By maincontentsearch = By.Name("ctl00$MainContent$btnSearch");

        By editbtn = By.XPath("/html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]");
        By txtappname = By.Id("MainContent_txtApplicantNameAdd");
        By cntnoadd= By.Id("MainContent_txtContactNoAdd");
        By cnicadd = By.Id("MainContent_txtcnicadd");
        By emailadd = By.Id("MainContent_txtPersonalEmailAdd");
        By linedinid = By.Id("MainContent_txtLinkedInUrl");
        By jobstatus= By.Id("MainContent_ddlJobStatus");
        By hearabtus = By.Id("MainContent_ddlHowHearAboutUS");
        By rmrk = By.Id("MainContent_txtRemark");
        By jobtitleadd = By.Id("MainContent_ddlJobTitleAdd");
        By savebtn = By.Id("MainContent_btnSave");

        #endregion



        public void Gotourl(string url)
        {
            dr.Url = url;
            //dr.Manage().Window.Maximize();
            // string exp_title = "https://staging.cyber.net.pk/Pages/Login.aspx";
            string act_title = dr.FindElement(logintitle).Text;
            string exp_title = "PEOPLE HUB";


            Console.WriteLine("The site title is " + act_title);
            Assert.That(act_title, Is.EqualTo(exp_title));


            Console.WriteLine("String Constraint Test Passed");

        }


        public void Uploadfile(string cv, string letter)
        {
            IWebElement upload = dr.FindElement(upload1);// dr.FindElement(By.XPath("(//input[@class='form-control fileinput-controls'])[1]"));
            ((RemoteWebElement)upload).SendKeys(cv);
            IWebElement upload2 = dr.FindElement(upload22);
            ((RemoteWebElement)upload2).SendKeys(letter);
            Thread.Sleep(3000);

        }


        public void Login(string id, string pw )
        {
            dr.FindElement(login).SendKeys(id);       
            dr.FindElement(password).SendKeys(pw);
            dr.FindElement(loginclick).Click();
        }



        public void closepopup()
        {
            //dr.SwitchTo().Frame("modal inmodal in").Close();
            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement().FindElement(closepopup1).Click();




        }



        public void Applcantlist(string ID, int company ,int job, int source, int status , string name , string cellno, string cnic, string email)
        {

            dr.FindElement(applist).Click();

            dr.FindElement(appID).SendKeys(ID);


            var selectcompnay = dr.FindElement(companyid);
            // selected / Cyber Internet Services (Pvt.) Limited / Lakson Business Solutions Limited 
            //  Fulcrum - Third Party / Sybrid - Third Party / NayaPay (Pvt.) Limited
            var dropdowncompany = new SelectElement(selectcompnay);
            dropdowncompany.SelectByIndex(company);
            Thread.Sleep(6000);

            var selectjob = dr.FindElement(jobtitle);// selected
            var dropdownjob = new SelectElement(selectjob);
            dropdownjob.SelectByIndex(job);



            var selectsource = dr.FindElement(appSS);//Website / HR / Referral / Fourth
            var dropdownsource = new SelectElement(selectsource);
            dropdownsource.SelectByIndex(source);



            var selectstatus = dr.FindElement(jobSS);
            //selected / Relevant (second priority) / Route to another active job 
            //Park for future job  / Viewed / Finalized
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownstatus.SelectByIndex(status);



            dr.FindElement(namesearch).SendKeys(name);

            dr.FindElement(contactsearh).SendKeys(cellno);

            dr.FindElement(cnicsearch).SendKeys(cnic);

            dr.FindElement(personalemailsearch).SendKeys(email);

            dr.FindElement(maincontentsearch).Click();
            //dr.FindElement(By.Id("MainContent_btnSearch")).Click();


        }


        public void Editsearch(int jobtitle,string name , string number,string cnic,
            string email , string linkedin , int status, int abtus, string rmks, string upload1, string upload2)
        {
            Thread.Sleep(5000);
            //html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]
           var edit= dr.FindElement(editbtn);
           // IWebElement edit = dr.FindElement(By.Name("ctl00$MainContent$rpt$ctl00$lbEdit"));//ctl00$MainContent$rpt$ctl00$lbEdit 
               
            bool isElementDisplayed = dr.FindElement(editbtn).Displayed;

            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;

            if (isElementDisplayed==true)
            {
                Console.WriteLine("FOUND FOUND");

            }
            
            js.ExecuteScript("arguments[0].scrollIntoView();", edit);
            edit.Click();

            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement();

            Thread.Sleep(2000);
            var selectjobtitle = dr.FindElement(jobtitleadd);// selected
            var dropdownjobtitle = new SelectElement(selectjobtitle);
            dropdownjobtitle.SelectByIndex(jobtitle);


            dr.FindElement(txtappname).Clear();
            dr.FindElement(txtappname).SendKeys(name);

            //

            dr.FindElement(cntnoadd).Clear();
            dr.FindElement(cntnoadd).SendKeys(number);



            //

            dr.FindElement(cntnoadd).Clear();
            dr.FindElement(cnicadd).SendKeys(cnic);



            //

            dr.FindElement(emailadd).Clear();
            dr.FindElement(emailadd).SendKeys(email);


            //

            dr.FindElement(linedinid).Clear();
            dr.FindElement(linedinid).SendKeys(linkedin);


            var selectstatus = dr.FindElement(jobstatus);// selected
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownjobtitle.SelectByIndex(status);


            var selectabtus = dr.FindElement(hearabtus);// selected
            var dropdownabtus = new SelectElement(selectabtus);
            dropdownjobtitle.SelectByIndex(abtus);

            dr.FindElement(rmrk).Clear();
            dr.FindElement(rmrk).SendKeys(rmks);

            Uploadfile(upload1, upload2);
            

            dr.FindElement(savebtn).Click();


        }

    }
}
