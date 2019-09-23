using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JSONPlaceholder
{
    [Binding]
    public class GET_PostsAndCommentsSteps
    {
        private TestDataSchemas jsonSchemas = new TestDataSchemas();
        
        [When(@"I send a GET request to (.*) with (.*)")]
        public void WhenISendAGETRequestToWith(string endPoint, int parameterString)
        {
            string url = endPoint + "/" + parameterString;
            jsonSchemas.ExecuteGetRequest(url);
        }        
        
        [Then(@"I get UserID as (.*)")]
        public void ThenIGetUserIDAs(int userId)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            int expectedUserId = userId;
            int currentUserId = actualJson.userId;

            Assert.AreEqual(expectedUserId, currentUserId);
        }
        
        [Then(@"I get ID as (.*)")]
        public void ThenIGetIDAs(int id)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            int expectedId = id;
            int currentId = actualJson.id;

            Assert.AreEqual(expectedId, currentId);
        }

        [Then(@"I get Title as (.*)")]
        public void ThenIGetTitleAs(string title)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            string expectedTitle = title;
            string currentTitle = actualJson.title;

            Assert.AreEqual(expectedTitle, currentTitle);
        }

        [Then(@"I get Body as (.*)")]
        public void ThenIGetBodyAs(string body)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            string expectedBody = body;
            string currentBody = actualJson.body;

            Assert.AreEqual(expectedBody, currentBody);
        }

        [Then(@"I get postId as (.*)")]
        public void ThenIGetPostIdAs(int postId)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            int expectedpostId = postId;
            int currentpostId = actualJson.postId;

            Assert.AreEqual(expectedpostId, currentpostId);
        }

        [Then(@"I get name as (.*)")]
        public void ThenIGetNameAs(string name)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            string expectedName = name;
            string currentName = actualJson.name;

            Assert.AreEqual(expectedName, currentName);
        }

        [Then(@"I get email as (.*)")]
        public void ThenIGetEmailAs(string email)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            string expectedEmail = email;
            string currentEmail = actualJson.email;

            Assert.AreEqual(expectedEmail, currentEmail);
        }

        [When(@"I send a GET request to see all the comments of post (.*)")]
        public void WhenISendAGETRequestToSeeAllTheCommentsOfPost(int postId)
        {
            ScenarioContext.Current["postId"] = postId;
            string url = "posts" + postId +"comments";
            jsonSchemas.ExecuteGetRequest(url);           
        }

        [Then(@"I should not see any comments of other posts")]
        public void ThenIShouldNotSeeAnyCommentsOfOtherPosts()
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            bool flag = false;
            int arrayLength = actualJson.id.count;

            for(int i = 0; i < arrayLength; i++)
            {
                if(ScenarioContext.Current["postId"] != actualJson[i].PostId)
                {
                    flag = true;                   
                }
                break;
            }

            Assert.AreEqual(false, flag);
        }

    }
}
