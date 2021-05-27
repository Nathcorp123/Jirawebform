using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jirawebform.Pages
{
    public class Homepage
    {
        public static string detail = ("//*[@id=\"details-button\"]");
        public static string proceed = ("//*[@id=\"proceed-link\"]");
        public static string selectproject = ("//select[@id='ddlProjectName']");
        public static string projectclick = ("//*[@id=\"ddlProjectName\"]/option[2]");
        public static string pin = ("//input[@id='pin']");
        public static string verify = ("//input[@id='btnVerify']");
        public static string TestType = ("//select[@id='CFTestType']");
        public static string TestTypedrpvalue = ("//*[@id=\"CFTestType\"]/option[2]");
        public static string smoketest = ("//select[@id='SmokeTest']");
        public static string smoketestvalue = ("//*[@id=\"SmokeTest\"]/option[2]");
        public static string issuetype = ("//select[@id='IssueType']");
        public static string issuetypevalue = ("//*[@id=\"IssueType\"]/option[2]");
        public static string businessprocess = ("//input[@id='txtSummary']");
        public static string almsetname = ("//input[@id='txtALMTestID']");
        public static string operatingsystem = ("//div[@id='js-bodyWrapper']//div[@class='col-md-8 form-group']//div[2]//div[1][1]//input[1]");
        public static string owingteam = ("//select[@id='ddlteamName']");
        public static string owingteamvalue = ("//*[@id=\"ddlteamName\"]/option[9]");
        public static string description = ("//textarea[@id='txtAreaDescription']");
        public static string dataparameter = ("//input[@id='txtDataParameter']");
        public static string createissue = ("//input[@value='Create Issue']");





    }
}
