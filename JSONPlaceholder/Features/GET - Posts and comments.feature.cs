﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace JSONPlaceholder.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GET - Posts and comments")]
    public partial class GET_PostsAndCommentsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GET - Posts and comments.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GET - Posts and comments", "\tAs a JSONPlaceholeder use\r\n\tI want to see posts and comments\r\n\tSo that I can che" +
                    "ck details", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get the details of posts")]
        [NUnit.Framework.TestCaseAttribute("posts", "1", "1", "1", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", null)]
        [NUnit.Framework.TestCaseAttribute("posts", "2", "1", "2", "qui est esse", null)]
        [NUnit.Framework.TestCaseAttribute("posts", "3", "1", "3", "ea molestias quasi exercitationem repellat qui ipsa sit aut", null)]
        public virtual void GetTheDetailsOfPosts(string endpoint, string parameter, string userId, string id, string title, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get the details of posts", null, exampleTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
          testRunner.Given("that I can access JSONPlaceholder \'posts\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.And("I get status code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.When(string.Format("I send a GET request to {0} with {1}", endpoint, parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
    testRunner.Then(string.Format("I get UserID as {0}", userId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
    testRunner.And(string.Format("I get ID as {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
    testRunner.And(string.Format("I get Title as {0}", title), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get the details of comments")]
        [NUnit.Framework.TestCaseAttribute("comments", "1", "1", "1", "id labore ex et quam laborum", "Eliseo@gardner.biz", null)]
        [NUnit.Framework.TestCaseAttribute("comments", "2", "1", "2", "quo vero reiciendis velit similique earum", "Jayne_Kuhic@sydney.com", null)]
        [NUnit.Framework.TestCaseAttribute("comments", "3", "1", "3", "odio adipisci rerum aut animi", "Nikita@garfield.biz", null)]
        public virtual void GetTheDetailsOfComments(string endpoint, string parameter, string postId, string id, string name, string email, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get the details of comments", null, exampleTags);
#line 23
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 25
          testRunner.Given("that I can access JSONPlaceholder \'comments\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
    testRunner.And("I get status code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
    testRunner.When(string.Format("I send a GET request to {0} with {1}", endpoint, parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
    testRunner.Then(string.Format("I get postId as {0}", postId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
    testRunner.And(string.Format("I get ID as {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
    testRunner.And(string.Format("I get name as {0}", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
    testRunner.And(string.Format("I get email as {0}", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get all comments of post 1")]
        [NUnit.Framework.TestCaseAttribute("1", "1", "id labore ex et quam laborum", null)]
        [NUnit.Framework.TestCaseAttribute("1", "2", "quo vero reiciendis velit similique earum", null)]
        [NUnit.Framework.TestCaseAttribute("1", "3", "odio adipisci rerum aut animi", null)]
        [NUnit.Framework.TestCaseAttribute("1", "4", "alias odio sit", null)]
        [NUnit.Framework.TestCaseAttribute("1", "5", "vero eaque aliquid doloribus et culpa", null)]
        public virtual void GetAllCommentsOfPost1(string postId, string id, string name, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all comments of post 1", null, exampleTags);
#line 41
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 43
          testRunner.Given("that I can access JSONPlaceholder \'comments\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
    testRunner.And("I get status code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
    testRunner.When("I send a GET request to see all the comments of post <1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
    testRunner.Then(string.Format("I get postId as {0}", postId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
    testRunner.And(string.Format("I get ID as {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
    testRunner.And(string.Format("I get name as {0}", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Comments post 1 should not contain comments of other posts")]
        public virtual void CommentsPost1ShouldNotContainCommentsOfOtherPosts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Comments post 1 should not contain comments of other posts", null, ((string[])(null)));
#line 60
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 62
          testRunner.Given("that I can access JSONPlaceholder \'comments\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
    testRunner.And("I get status code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
    testRunner.When("I send a GET request to see all the comments of post <1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
    testRunner.Then("I should not see any comments of other posts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

