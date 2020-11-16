using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace EmployeePayrollRestSharpTest
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public double Salary { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:5000");
        }
        [TestMethod]
        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }
        /// <summary>
        /// UC1 Test method to verify if employee list is retrieved or not
        /// </summary>
        [TestMethod]
        public void onCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(11, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine("id: " + item.id + "Name: " + item.name + "Salary: " + item.Salary);
            }
        }

        /// <summary>
        /// UC2 Test method to verify an employee is added or not
        /// </summary>
        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("name", "Mihir");
            jObjectbody.Add("Salary", "15000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Mihir", dataResponse.name);
            Assert.AreEqual(15000, dataResponse.Salary);
        }
        /// <summary>
        /// UC3 Test method to verify multiple employees are added to the json server
        /// </summary>
        [TestMethod]
        public void AfterAddingMultipleEmployees_onCallingGETApi_ReturnEmployeesCount()
        {
            //arrange
            List<Employee> empList = new List<Employee>();
            Employee employee1 = new Employee { name = "Manish", Salary = 15000 };
            Employee employee2 = new Employee { name = "Prakash", Salary = 25000 };
            empList.Add(employee1);
            empList.Add(employee2);
            foreach (Employee employee in empList)
            {
                //act
                RestRequest request = new RestRequest("/employees/create", Method.POST);
                JObject jObject = new JObject();
                jObject.Add("name", employee.name);
                jObject.Add("salary", employee.Salary);
                request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                //Assert
                Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
                Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(employee.name, dataResponse.name);
                Assert.AreEqual(employee.Salary, dataResponse.Salary);
                List<Employee> dataResponse2 = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
                Assert.AreEqual(13, dataResponse2.Count);
            }
        }
        /// <summary>
        /// UC4 Test method to verify if salary is updated or not
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnUpdate_ShouldReturnUpdatedEmployee()
        {
            //arrange 
            RestRequest request = new RestRequest("/employees/10", Method.PUT);
            JObject jObjectBody = new JObject();
            jObjectBody.Add("name", "Manish");
            jObjectBody.Add("Salary", "16000");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Manish", dataResponse.name);
            Assert.AreEqual(16000, dataResponse.Salary);
            Console.WriteLine(response.Content);
        }
    }
}
