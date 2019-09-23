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
    public class PostsSteps
    {
        private TestDataSchemas jsonSchemas = new TestDataSchemas();

        [Given(@"that I can access JSONPlaceholder '(.*)' endpoint")]
        public void GivenThatICanAccessJSONPlaceholderEndpoint(string parameterString)
        {
            jsonSchemas.ExecuteGetRequest(parameterString);                       
        }

        [Given(@"I get status code '(.*)'")]
        public void GivenIGetStatusCode(int expectedStatusCode)
        {
            string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
            var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

            var currentStatusCode = (int)ScenarioContext.Current.Get<HttpResponseMessage>().StatusCode;

            Assert.AreEqual(expectedStatusCode, currentStatusCode);
        }

        [When(@"I send a POST request to the below end point :")]
        public void WhenISendAPOSTRequestToTheBelowEndPoint(Table table)
        {
            jsonSchemas.ExecutePostRequest(table);
        }

        [Then(@"new '(.*)' are created")]
        public void ThenNewAreCreated(string parameter, Table table)
        {
            IEnumerable<dynamic> tableData = table.CreateDynamicSet();

            if(parameter == "posts")
            {
                foreach (var row in tableData)
                {
                    jsonSchemas.ExecuteGetRequest(parameter + "/" + ScenarioContext.Current[row.title + "_postid"]);
                    string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
                    var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

                    Assert.AreEqual(row.title, actualJson.title);
                }
            }

            if (parameter == "comments")
            {
                foreach (var row in tableData)
                {
                    jsonSchemas.ExecuteGetRequest(parameter + "/" + ScenarioContext.Current[row.title + "_commentid"]);
                    string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
                    var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

                    Assert.AreEqual(row.name, actualJson.name);
                }
            }

        }

        [When(@"I send a PUT request to the below end point :")]
        public void WhenISendAPUTRequestToTheBelowEndPoint(Table table)
        {
            jsonSchemas.ExecutePutRequest(table);
        }
        [Then(@"'(.*)' are updated")]
        public void ThenAreUpdated(string parameter, Table table)
        {
            IEnumerable<dynamic> tableData = table.CreateDynamicSet();

            if (parameter == "posts")
            {
                foreach (var row in tableData)
                {
                    jsonSchemas.ExecuteGetRequest(parameter + "/" + ScenarioContext.Current[row.post + "_postid"]);
                    string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
                    var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

                    Assert.AreEqual(row.title, actualJson.title);
                    Assert.AreEqual(row.body, actualJson.body);
                }
            }
            if (parameter == "comments")
            {
                foreach (var row in tableData)
                {
                    jsonSchemas.ExecuteGetRequest(parameter + "/" + ScenarioContext.Current[row.comments + "_commentid"]);
                    string actualRawJsonText = ScenarioContext.Current.Get<HttpResponseMessage>().Content.ReadAsStringAsync().Result.ToString();
                    var actualJson = JsonConvert.DeserializeObject<dynamic>(actualRawJsonText);

                    Assert.AreEqual(row.body, actualJson.body);                    
                }
            }
        }

    }
}
