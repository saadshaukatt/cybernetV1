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
        By jobtitle = By.Id("MainContent_ddlJobTitleSearch");
        By appSS = By.Id("MainContent_ddlApplicantSourceSearch");

        By jobSS = By.Id("MainContent_ddlJobStatusSearch");
        By namesearch = By.Id("MainContent_txtApplicantNameSearch");
        By contactsearh = By.Id("MainContent_txtContactNoSearch");
        By cnicsearch = By.Id("MainContent_txtCNICNoSearch");
        By personalemailsearch = By.Id("MainContent_txtPersonalEmailSearch");
        By maincontentsearch = By.Name("ctl00$MainContent$btnSearch");

        By editbtn = By.XPath("/html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]");
        By txtappname = By.Id("MainContent_txtApplicantNameAdd");
        By cntnoadd = By.Id("MainContent_txtContactNoAdd");
        By cnicadd = By.Id("MainContent_txtcnicadd");
        By emailadd = By.Id("MainContent_txtPersonalEmailAdd");
        By linedinid = By.Id("MainContent_txtLinkedInUrl");
        By jobstatus = By.Id("MainContent_ddlJobStatus");
        By hearabtus = By.Id("MainContent_ddlHowHearAboutUS");
        By rmrk = By.Id("MainContent_txtRemark");
        By jobtitleadd = By.Id("MainContent_ddlJobTitleAdd");
        By savebtn = By.Id("MainContent_btnSave");
        By confirmbtn = By.ClassName("confirm");
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


        public void Login(string id, string pw)
        {
            dr.FindElement(login).SendKeys(id);
            Console.WriteLine("String Constraint Passed: login");

            dr.FindElement(password).SendKeys(pw);
            Console.WriteLine("String Constraint Passed:password");

            dr.FindElement(loginclick).Click();
        }



        public void closepopup()
        {
            //dr.SwitchTo().Frame("modal inmodal in").Close();
            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement().FindElement(closepopup1).Click();




        }



        public void Applcantlist(string ID, int company, int job, int source, int status, string name, string cellno, string cnic, string email)
        {

            dr.FindElement(applist).Click();

            dr.FindElement(appID).SendKeys(ID);
            Console.WriteLine("String Constraint Passed: ID");



            var selectcompnay = dr.FindElement(companyid);
            // selected / Cyber Internet Services (Pvt.) Limited / Lakson Business Solutions Limited 
            //  Fulcrum - Third Party / Sybrid - Third Party / NayaPay (Pvt.) Limited
            var dropdowncompany = new SelectElement(selectcompnay);
            dropdowncompany.SelectByIndex(company);
            Console.WriteLine("String Constraint Passed: company selection");

            Thread.Sleep(6000);

            var selectjob = dr.FindElement(jobtitle);// selected
            var dropdownjob = new SelectElement(selectjob);
            Console.WriteLine("String Constraint Passed: job selection");

            dropdownjob.SelectByIndex(job);



            var selectsource = dr.FindElement(appSS);//Website / HR / Referral / Fourth
            var dropdownsource = new SelectElement(selectsource);
            Console.WriteLine("String Constraint Passed: soure selection");

            dropdownsource.SelectByIndex(source);



            var selectstatus = dr.FindElement(jobSS);
            //selected / Relevant (second priority) / Route to another active job 
            //Park for future job  / Viewed / Finalized
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownstatus.SelectByIndex(status);
            Console.WriteLine("String Constraint Passed: select status");




            dr.FindElement(namesearch).SendKeys(name);
            Console.WriteLine("String Constraint Passed:name passed");

            dr.FindElement(contactsearh).SendKeys(cellno);
            Console.WriteLine("String Constraint Passed: cellno passed");

            dr.FindElement(cnicsearch).SendKeys(cnic);
            Console.WriteLine("String Constraint Passed: cnic passed");

            dr.FindElement(personalemailsearch).SendKeys(email);
            Console.WriteLine("String Constraint Passed: email passed");


            dr.FindElement(maincontentsearch).Click();
            //dr.FindElement(By.Id("MainContent_btnSearch")).Click();


        }


        public void Editsearch(int jobtitle, string name, string number, string cnic,
            string email, string linkedin, int status, int abtus, string rmks, string upload1, string upload2)
        {
            Thread.Sleep(5000);
            //html/body/form/div[3]/div/div[2]/div[3]/div[2]/div/div/div/div[2]/div[2]/div/div/table/tbody/tr/td[8]/input[1]
            var edit = dr.FindElement(editbtn);
            // IWebElement edit = dr.FindElement(By.Name("ctl00$MainContent$rpt$ctl00$lbEdit"));//ctl00$MainContent$rpt$ctl00$lbEdit 

            bool isElementDisplayed = dr.FindElement(editbtn).Displayed;

            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;

            if (isElementDisplayed == true)
            {
                Console.WriteLine("FOUND FOUND");

            }
            Thread.Sleep(2000);

            js.ExecuteScript("arguments[0].scrollIntoView();", edit);
            edit.Click();

            Thread.Sleep(3000);
            dr.SwitchTo().ActiveElement();

            //Thread.Sleep(2000);
            var selectjobtitle = dr.FindElement(jobtitleadd);// selected
            var dropdownjobtitle = new SelectElement(selectjobtitle);
            dropdownjobtitle.SelectByIndex(jobtitle - 1);
            dropdownjobtitle.SelectByIndex(jobtitle);


            /*  if(dr.FindElement(By.Id("MainContent_RequiredFieldValidator6")).Displayed)
              {
                  MessageBox.Show("Job Title has no input");
              }*/


            dr.FindElement(txtappname).Clear();
            dr.FindElement(txtappname).SendKeys(name);
            Console.WriteLine("String Constraint Passed: edited name passed");


            //

            dr.FindElement(cntnoadd).Clear();
            dr.FindElement(cntnoadd).SendKeys(number);
            Console.WriteLine("String Constraint Passed:edited num passed");



            //

            dr.FindElement(cnicadd).Clear();
            dr.FindElement(cnicadd).SendKeys(cnic);
            Console.WriteLine("String Constraint Passed:edited cncn passed");



            //

            dr.FindElement(emailadd).Clear();
            dr.FindElement(emailadd).SendKeys(email);
            Console.WriteLine("String Constraint Passed:edited email passed");


            //

            dr.FindElement(linedinid).Clear();
            dr.FindElement(linedinid).SendKeys(linkedin);
            Console.WriteLine("String Constraint Passed:edited linkedin passed");


            var selectstatus = dr.FindElement(jobstatus);// selected
            var dropdownstatus = new SelectElement(selectstatus);
            dropdownstatus.SelectByIndex(status);
            Console.WriteLine("String Constraint Passed: edited status picked");


            var selectabtus = dr.FindElement(hearabtus);// selected
            var dropdownabtus = new SelectElement(selectabtus);
            dropdownabtus.SelectByIndex(abtus);
            Console.WriteLine("String Constraint Passed: edited about us passed");

            dr.FindElement(rmrk).Clear();
            dr.FindElement(rmrk).SendKeys(rmks);
            Console.WriteLine("String Constraint Passed: edited remarks passed");

            Uploadfile(upload1, upload2);
            Console.WriteLine("String Constraint Passed: file uploaded");


            dr.FindElement(savebtn).Click();
            Console.WriteLine("String Constraint Passed: edits saved");
            string success = dr.FindElement(By.CssSelector("html>body>div:nth-of-type(3)>p")).Text;
            string act_h = "Application updated successfully.";

            Assert.That(act_h, Is.EqualTo(success));
            //dr.SwitchTo().ActiveElement();
            dr.FindElement(confirmbtn).Click();


            //File.WriteAllText("log.txt", displayMessage); 
            // Assert.That(act_title, Is.EqualTo(exp_title));// save asertion 


        }



        public void ClickAppraisalPeriod()
        {
            dr.FindElement(By.CssSelector("ul#side-menu>li:nth-of-type(8)>a")).Click();

            Thread.Sleep(2000);
            dr.FindElement(By.LinkText("Period")).Click();
        }

        #region Period
        public void PeriodAddstartdate(string pname, string date)
        {
            dr.FindElement(By.LinkText("Add")).Click();
            dr.SwitchTo().ActiveElement();
            dr.FindElement(By.Id("MainContent_txtNameAdd")).SendKeys(pname);

            //FIND DATE
            dr.FindElement(By.Id("MainContent_txtPeriodStartDate")).Click();
            //String defaultdate = dr.FindElement(By.XPath("//th[text()='July 2021']")).Text;
            string defaultdate = dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Text;

            //
            string month = defaultdate.Substring(0, defaultdate.IndexOf(" "));
            string year = defaultdate.Substring(defaultdate.IndexOf(" ") + 1);
            Console.WriteLine(month + "|" + year);
            //

            string indate = date.Substring(0, 2);
            string inmonth = date.Substring(date.IndexOf("/") + 1, date.LastIndexOf("/") - 3);
            string inyear = date.Substring(date.LastIndexOf("/") + 1);
            Console.WriteLine(indate + "|" + inmonth + "|" + inyear);
            string threeletterinmonth = inmonth.Substring(0, 3);
            Console.WriteLine(indate + "|" + threeletterinmonth + "|" + inyear);

            //


            // year input
            if (int.Parse(inyear) == int.Parse(year))
            {

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();
            }

            if (int.Parse(inyear) > int.Parse(year) | int.Parse(inyear) < int.Parse(year))
            {
                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[2]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + inyear + "']")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();

            }


        }



        public void Periodaddenddate(string date)
        {

            dr.FindElement(By.Id("MainContent_txtPeriodEndDate")).Click();

            string defaultdate = dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Text;

            string month = defaultdate.Substring(0, defaultdate.IndexOf(" "));
            string year = defaultdate.Substring(defaultdate.IndexOf(" ") + 1);
            Console.WriteLine(month + "|" + year);

            string indate = date.Substring(0, 2);
            string inmonth = date.Substring(date.IndexOf("/") + 1, date.LastIndexOf("/") - 3);
            string inyear = date.Substring(date.LastIndexOf("/") + 1);
            Console.WriteLine(indate + "|" + inmonth + "|" + inyear);
            string threeletterinmonth = inmonth.Substring(0, 3);
            Console.WriteLine(indate + "|" + threeletterinmonth + "|" + inyear);


            // year input
            if (int.Parse(inyear) == int.Parse(year))
            {

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();
            }

            if (int.Parse(inyear) > int.Parse(year) | int.Parse(inyear) < int.Parse(year))
            {
                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[2]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + inyear + "']")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();

            }

        }


        public void Deadlinedate(string date)
        {

            dr.FindElement(By.Id("MainContent_txtDeadline")).Click();

            string defaultdate = dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Text;

            string month = defaultdate.Substring(0, defaultdate.IndexOf(" "));
            string year = defaultdate.Substring(defaultdate.IndexOf(" ") + 1);
            Console.WriteLine(month + "|" + year);

            string indate = date.Substring(0, 2);
            string inmonth = date.Substring(date.IndexOf("/") + 1, date.LastIndexOf("/") - 3);
            string inyear = date.Substring(date.LastIndexOf("/") + 1);
            Console.WriteLine(indate + "|" + inmonth + "|" + inyear);
            string threeletterinmonth = inmonth.Substring(0, 3);
            Console.WriteLine(indate + "|" + threeletterinmonth + "|" + inyear);


            // year input
            if (int.Parse(inyear) == int.Parse(year))
            {

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();
            }

            if (int.Parse(inyear) > int.Parse(year) | int.Parse(inyear) < int.Parse(year))
            {
                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[2]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + inyear + "']")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();

            }

        }

        public void Maxjoindate(string date)
        {

            dr.FindElement(By.Id("MainContent_txtMaxJoiningDate")).Click();

            string defaultdate = dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Text;

            string month = defaultdate.Substring(0, defaultdate.IndexOf(" "));
            string year = defaultdate.Substring(defaultdate.IndexOf(" ") + 1);
            Console.WriteLine(month + "|" + year);

            string indate = date.Substring(0, 2);
            string inmonth = date.Substring(date.IndexOf("/") + 1, date.LastIndexOf("/") - 3);
            string inyear = date.Substring(date.LastIndexOf("/") + 1);
            Console.WriteLine(indate + "|" + inmonth + "|" + inyear);
            string threeletterinmonth = inmonth.Substring(0, 3);
            Console.WriteLine(indate + "|" + threeletterinmonth + "|" + inyear);


            // year input
            if (int.Parse(inyear) == int.Parse(year))
            {

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();
            }

            if (int.Parse(inyear) > int.Parse(year) | int.Parse(inyear) < int.Parse(year))
            {
                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[1]")).Click();

                dr.FindElement(By.XPath("(//th[@class='datepicker-switch'])[2]")).Click();

                dr.FindElement(By.XPath("//span[text()='" + inyear + "']")).Click();

                dr.FindElement(By.XPath("//span[text()='" + threeletterinmonth + "']")).Click();

                dr.FindElement(By.XPath("//td[text()='" + indate + "']")).Click();

            }

        }

        public void Periodsave_close (bool save)
        {
            if (save == true)
            {
                dr.FindElement(By.Id("MainContent_btnAdd")).Click();
            }
            else
            {
                dr.FindElement(By.XPath("(//span[text()='×'])[1]")).Click();
            }
        }

        #endregion Period





        #region Appraisals

        public void ClickAppraisalTraintscompetencies()
        {
            dr.FindElement(By.CssSelector("ul#side-menu>li:nth-of-type(8)>a")).Click();

            Thread.Sleep(2000);
            dr.FindElement(By.XPath("//a[@href='/Pages/Appraisal/Setup/SetupKPI.aspx']")).Click();

        }
        public void TnCsearch(string search)
        {
            dr.FindElement(By.Id("MainContent_txtSearch")).SendKeys(search);
            dr.FindElement(By.Id("MainContent_btnSearch")).Click();

        }
        public void TnCEdit(string TnC, string desc, string click)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;

            var edit = dr.FindElement(By.Id("MainContent_rpt_lbEdit_0"));

            js.ExecuteScript("arguments[0].scrollIntoView();", edit);

            edit.Click();

            dr.SwitchTo().ActiveElement();
            Thread.Sleep(2000);

            dr.FindElement(By.Id("MainContent_txtKpi")).Clear();
            dr.FindElement(By.Id("MainContent_txtKpi")).SendKeys(TnC);

            dr.FindElement(By.Id("MainContent_txtKpiDesc")).Clear();
            dr.FindElement(By.Id("MainContent_txtKpiDesc")).SendKeys(desc);

            if (click == "A")
            {
                dr.FindElement(By.Id("MainContent_chkCategory_0")).Click();

            }

            if (click == "B")
            {
                dr.FindElement(By.Id("MainContent_chkCategory_1")).Click();

            }
           

        }

        public void TnCsave_close(bool save)
        {
            if (save == true)
            {
                dr.FindElement(By.Id("MainContent_btnAdd")).Click();
            }
            else
            {
                dr.FindElement(By.XPath("(//span[text()='×'])[1]")).Click();
            }
        }


        #endregion




        public void ClickAppraisalEML()
        {
            dr.FindElement(By.CssSelector("ul#side-menu>li:nth-of-type(8)>a")).Click();

            Thread.Sleep(2000);
            dr.FindElement(By.LinkText("Employee Mapping List")).Click();
        }

        public void EMLsearch(string name)
        {
            dr.FindElement(By.Id("MainContent_txtEmployeeName")).SendKeys(name);
            dr.FindElement(By.Id("MainContent_btnSearch")).Click();
        }

        public void EMLedit(int company,int division,int department,int designation ,
            int jobtitle, string ename,string ecode, int search)
        {
            dr.FindElement(By.Id("MainContent_rpt_lbEdit_0")).Click();


           // var ctlMainContentddlCompany = dr.FindElement(By.Id("MainContent_ddlCompany"));
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlCompany"))).SelectByIndex(company);
            Thread.Sleep(5000);
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlBusinessUnit"))).SelectByIndex(division);
            Thread.Sleep(1000);
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlDepartment"))).SelectByIndex(department);
            Thread.Sleep(1000);
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlJobCategory"))).SelectByIndex(jobtitle);
            Thread.Sleep(1000);
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlDesignation"))).SelectByIndex(designation);
            Thread.Sleep(1000);
            dr.FindElement(By.Id("MainContent_txtEmployeeName")).SendKeys(ename);
            dr.FindElement(By.Id("MainContent_txtEmployeeCode")).SendKeys(ecode);
            new SelectElement(dr.FindElement(By.Id("MainContent_ddlSearchFor"))).SelectByIndex(search);
            Thread.Sleep(1000);
            dr.FindElement(By.Id("MainContent_btnSearch")).Click();

        }



    }
}
