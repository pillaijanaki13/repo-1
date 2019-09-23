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
    class TestDataSchemas
    {
        private static string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\json\\JSONPlaceholder\\Test_Data\\";
        //private static string filePath = "C:\\Users\\BalachandranJ\\json\\JSONPlaceholder\\JSONPlaceholder\\Test_Data\\";
        private static string baseurl = "https://jsonplaceholder.typicode.com/";

        //Method to execute post requests
        public void ExecutePostRequest(Table table)
        {  
            //Getting table data from feature file and parameterizing in horizontal format
            IEnumerable <dynamic> tableData = table.CreateDynamicSet();
            //Creating oblect,reading and parsing sample json
            StreamReader r = new StreamReader(filePath + "post_request.json");
            var json = r.ReadToEnd();
            dynamic objPostJsonTest = JObject.Parse(json);

            foreach (var row in tableData)
            {
                string currentApiName = string.Empty;
                string newJsonText = string.Empty;               
                currentApiName = row.endPoint;
                //overriding sample json with table data
                if (currentApiName.ToLower() == "posts")
                {
                    if (row.referenceData == "") Assert.Fail("requires referenceData value from feature file for e.g. Test");
 
                    objPostJsonTest.userid = row.referenceData.Split(',')[0].Split(':')[1];
                    objPostJsonTest.title = row.referenceData.Split(',')[1].Split(':')[1];
                    objPostJsonTest.body = row.referenceData.Split(',')[2].Split(':')[1];
                }

                else if (currentApiName.ToLower() == "comments")
                {
                    if (row.referenceData == "") Assert.Fail("requires referenceData value from feature file for e.g. Test");

                    int postid = ScenarioContext.Current[row.referenceData.Split(',')[0].Split(':')[1] + "_postid"];
                    objPostJsonTest.postid = postid;
                    objPostJsonTest.name = row.referenceData.Split(',')[1].Split(':')[1];
                    objPostJsonTest.email = row.referenceData.Split(',')[2].Split(':')[1];
                    objPostJsonTest.body = row.referenceData.Split(',')[3].Split(':')[1];
                }

                newJsonText = objPostJsonTest.ToString();
                string url = baseurl + currentApiName;
                //sending POST request
                var postRequestResponse = HttpHelpers.PostJson(JsonConvert.DeserializeObject(newJsonText), url).Result;
                // Checking the request is successful
                if (ScenarioContext.Current.Get<HttpResponseMessage>().IsSuccessStatusCode && postRequestResponse != "")
                {
                    //Getting and storing response
                    var dataResponse = JToken.Parse(postRequestResponse);
                    ScenarioContext.Current["CurrentPostResponse"] = JToken.Parse(postRequestResponse);

                    //setting scenario context
                    if (currentApiName.ToLower() == "posts")
                    {
                        string postid = "_postid";
                        var id = objPostJsonTest.title.ToString() + postid;
                        ScenarioContext.Current[id] = dataResponse["id"];
                    }
                    else if (currentApiName.ToLower() == "comments")
                    {
                        string commentid = "_commentid";
                        var id = objPostJsonTest.name.ToString() + commentid;
                        ScenarioContext.Current[id] = dataResponse["id"];
                    }

                }                
                else if (currentApiName.ToLower() == "posts")
                {
                    Assert.Fail("Create posts unsuccessful");
                }
                else if (currentApiName.ToLower() == "comments")
                {
                    Assert.Fail("Create comments unsuccessful");
                }
            }
        }
        //Method to execute PUT requests
        public void ExecutePutRequest(Table table)
        {
            //Getting table data from feature file and parameterizing in horizontal format
            IEnumerable<dynamic> tableData = table.CreateDynamicSet();
            //Creating oblect,reading and parsing sample json
            StreamReader r = new StreamReader(filePath + "put_request.json");
            var json = r.ReadToEnd();
            dynamic objPutJsonTest = JObject.Parse(json);

            foreach (var row in tableData)
            {
                string currentApiName = string.Empty;
                string newJsonText = string.Empty;
                string parameterString = string.Empty;
                currentApiName = row.endPoint;

                //overriding sample json with table data
                if (currentApiName.ToLower() == "posts")
                {
                    if (row.referenceData == "") Assert.Fail("requires referenceData value from feature file for e.g. Test");

                    parameterString = ScenarioContext.Current[row.referenceData.Split(',')[0] + "_postid"];
                    objPutJsonTest.userid = row.referenceData.Split(',')[1].Split(':')[1];
                    objPutJsonTest.title = row.referenceData.Split(',')[2].Split(':')[1];
                    objPutJsonTest.body = row.referenceData.Split(',')[3].Split(':')[1];
                }

                else if (currentApiName.ToLower() == "comments")
                {
                    if (row.referenceData == "") Assert.Fail("requires referenceData value from feature file for e.g. Test");

                    parameterString = ScenarioContext.Current[row.referenceData.Split(',')[0] + "_commentid"];
                    //objPutJsonTest.postid = row.referenceData.Split(',')[1].Split(':')[1];
                    //objPutJsonTest.name = row.referenceData.Split(',')[2].Split(':')[1];
                    //objPutJsonTest.email = row.referenceData.Split(',')[3].Split(':')[1];
                    objPutJsonTest.body = row.referenceData.Split(',')[1].Split(':')[1];
                }

                newJsonText = objPutJsonTest.ToString();
                string apiName = row.endPoint + "/" + parameterString;
                string url = baseurl + apiName ;
                //sending POST request
                var postRequestResponse = HttpHelpers.PostJson(JsonConvert.DeserializeObject(newJsonText), url).Result;
                // Checking the request is successful
                if (ScenarioContext.Current.Get<HttpResponseMessage>().IsSuccessStatusCode && postRequestResponse != "")
                {
                    //Getting and storing response
                    var dataResponse = JToken.Parse(postRequestResponse);
                    ScenarioContext.Current["CurrentPostResponse"] = JToken.Parse(postRequestResponse);

                    //setting scenario context
                    if (currentApiName.ToLower() == "posts")
                    {
                        string postid = "_postid";
                        string updatedPostTitle = "_updatedPostTitle";
                        string updatedPostbody = "_updatedPostbody";
                        var title = ScenarioContext.Current[row.referenceData.Split(',')[0]] + updatedPostTitle;
                        var body = ScenarioContext.Current[row.referenceData.Split(',')[0]] + updatedPostbody;
                        ScenarioContext.Current[title] = dataResponse["title"];
                        ScenarioContext.Current[body] = dataResponse["body"];
                    }
                    else if (currentApiName.ToLower() == "comments")
                    {
                        string updatedCommentBody = "_updatedCommentBody";
                        var body = ScenarioContext.Current[row.referenceData.Split(',')[0]] + updatedCommentBody;
                        ScenarioContext.Current[body] = dataResponse["body"];
                    }
                }
                else if (currentApiName.ToLower() == "posts")
                {
                    Assert.Fail("Update posts unsuccessful");
                }
                else if (currentApiName.ToLower() == "comments")
                {
                    Assert.Fail("Update comments unsuccessful");
                }                
            }
        }
        //Method to execute GET requests
        public void ExecuteGetRequest(string parameterString)
        {
            string url = baseurl + parameterString;
            var response = HttpHelpers.GetAsync(url).Result;
            ScenarioContext.Current.Set(response);            
        }
    }
}
