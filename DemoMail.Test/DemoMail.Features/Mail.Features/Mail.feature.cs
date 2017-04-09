﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DemoMail.Features.Mail_Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Mail")]
    public partial class MailFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Mail.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Mail", "\tIn order to save draft version of the email\r\n\tAs a registered user\r\n\tI want to c" +
                    "reate and save simple email", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("I am on the mail site with Chrome browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using parameterization method input")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        public virtual void SuccsesfulLoginToMailSiteUsingParameterizationMethodInput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using parameterization method input", new string[] {
                        "positive",
                        "login"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 11
 testRunner.Given("I enter a mailbox login JohnDoe1990", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
  testRunner.And("I enter a mailbox domain @list.ru", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And("I enter a mailbox password INeedSomePassword", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I should see my e-mail address JohnDoe1990@list.ru in the header of site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using resources")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        public virtual void SuccsesfulLoginToMailSiteUsingResources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using resources", new string[] {
                        "positive",
                        "login"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 20
 testRunner.Given("I enter a correct mailbox login", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
  testRunner.And("I enter a correct mailbox domain", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("I enter a correct mailbox password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("I should see my e-mail address JohnDoe1990@list.ru in the header of site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using resources and ScenarioContext (not thread saf" +
            "e) to share data between steps")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        [NUnit.Framework.CategoryAttribute("not_thread_safe")]
        public virtual void SuccsesfulLoginToMailSiteUsingResourcesAndScenarioContextNotThreadSafeToShareDataBetweenSteps()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using resources and ScenarioContext (not thread saf" +
                    "e) to share data between steps", new string[] {
                        "positive",
                        "login",
                        "not_thread_safe"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 29
 testRunner.Given("I enter a correct mailbox login with saving into ScenarioContext", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
  testRunner.And("I enter a correct mailbox domain with saving into ScenarioContext", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.And("I enter a correct mailbox password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("I should see my correct e-mail address in the header of site, using ScenarioConte" +
                    "xt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using resources and ScenarioContext (thread safe) t" +
            "o share data between steps")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        [NUnit.Framework.CategoryAttribute("thread_safe")]
        public virtual void SuccsesfulLoginToMailSiteUsingResourcesAndScenarioContextThreadSafeToShareDataBetweenSteps()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using resources and ScenarioContext (thread safe) t" +
                    "o share data between steps", new string[] {
                        "positive",
                        "login",
                        "thread_safe"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 38
 testRunner.Given("I enter a correct mailbox login with saving into ScenarioContext", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
  testRunner.And("I enter a correct mailbox domain with saving into ScenarioContext", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("I enter a correct mailbox password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("I should see my correct e-mail address in the header of site, using ScenarioConte" +
                    "xt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using weakly-typed step data table")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        public virtual void SuccsesfulLoginToMailSiteUsingWeakly_TypedStepDataTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using weakly-typed step data table", new string[] {
                        "positive",
                        "login"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table1.AddRow(new string[] {
                        "login",
                        "JohnDoe1990"});
            table1.AddRow(new string[] {
                        "domain",
                        "@list.ru"});
            table1.AddRow(new string[] {
                        "password",
                        "INeedSomePassword"});
#line 47
 testRunner.Given("I enter following parameters on Login page (weak)", ((string)(null)), table1, "Given ");
#line 52
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("I should see my e-mail address JohnDoe1990@list.ru in the header of site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using strongly-typed step data table")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        public virtual void SuccsesfulLoginToMailSiteUsingStrongly_TypedStepDataTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using strongly-typed step data table", new string[] {
                        "positive",
                        "login"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table2.AddRow(new string[] {
                        "login",
                        "JohnDoe1990"});
            table2.AddRow(new string[] {
                        "domain",
                        "@list.ru"});
            table2.AddRow(new string[] {
                        "password",
                        "INeedSomePassword"});
#line 58
 testRunner.Given("I enter following parameters on Login page (strong)", ((string)(null)), table2, "Given ");
#line 63
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("I should see my e-mail address JohnDoe1990@list.ru in the header of site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succsesful login to mail site using dynamic step data table")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("login")]
        public virtual void SuccsesfulLoginToMailSiteUsingDynamicStepDataTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsesful login to mail site using dynamic step data table", new string[] {
                        "positive",
                        "login"});
#line 68
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table3.AddRow(new string[] {
                        "login",
                        "JohnDoe1990"});
            table3.AddRow(new string[] {
                        "domain",
                        "@list.ru"});
            table3.AddRow(new string[] {
                        "password",
                        "INeedSomePassword"});
#line 69
 testRunner.Given("I enter following parameters on Login page (dynamic)", ((string)(null)), table3, "Given ");
#line 74
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("I should see my e-mail address JohnDoe1990@list.ru in the header of site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Login to mail site with incorrect password")]
        [NUnit.Framework.CategoryAttribute("negative")]
        [NUnit.Framework.CategoryAttribute("login")]
        [NUnit.Framework.CategoryAttribute("invalid_login_or_password")]
        [NUnit.Framework.TestCaseAttribute("INeedSomePassword1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("NeedSomePassword", new string[0])]
        [NUnit.Framework.TestCaseAttribute("I_Need_Some_Password", new string[0])]
        public virtual void LoginToMailSiteWithIncorrectPassword(string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "negative",
                    "login",
                    "invalid_login_or_password"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to mail site with incorrect password", @__tags);
#line 79
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 80
 testRunner.Given("I enter a correct mailbox login", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
  testRunner.And("I enter a correct mailbox domain", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
  testRunner.And(string.Format("I enter a incorrect mailbox {0} password", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And("I select that I have not authentication remembering", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I submit my login data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.Then("I should see error message Неверное имя пользователя или пароль. Проверьте правил" +
                    "ьность введенных данных. about invalid login or password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Succesful saving draft e-mail")]
        [NUnit.Framework.CategoryAttribute("positive")]
        [NUnit.Framework.CategoryAttribute("draft")]
        public virtual void SuccesfulSavingDraftE_Mail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succesful saving draft e-mail", new string[] {
                        "positive",
                        "draft"});
#line 94
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 95
 testRunner.Given("I succesfully login to mail site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
  testRunner.And("I select a new e-mail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.And("I enter a whom of the message johndoe1990@list.ru", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("I enter a theme of the message Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
  testRunner.And("I enter a body of the message Hello, Mail World!", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.When("I submit saving my message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("I should see a confirmation of saving", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
