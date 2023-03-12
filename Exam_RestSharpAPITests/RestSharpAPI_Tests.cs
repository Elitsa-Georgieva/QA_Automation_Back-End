using RestSharp;
using System.Net;
using System.Numerics;
using System.Text.Json;
using System.Xml.Linq;

namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {
        private RestClient client;
        private const string baseUrl = "https://contactbook.itsageorgieva.repl.co/api";

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(baseUrl);
        }

        [Test]
        public void Test_GetContacts_CheckFirstAndLastNameOfFirstContact()
        {
            //Arrange
            var request = new RestRequest("contacts", Method.Get);

            //Act
            var response = this.client.Execute(request);

            //Assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var contacts = JsonSerializer.Deserialize<List<Contact>>(response.Content);

            Assert.That(contacts[0].firstName, Is.EqualTo("Steve"));
            Assert.That(contacts[0].lastName, Is.EqualTo("Jobs"));
        }

        [Test]
        public void Test_SearchByKeyWord_ValidResult()
        {
            //Arrange
            var request = new RestRequest("contacts/search/albert", Method.Get);

            //Act
            var response = this.client.Execute(request);

            //Assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var contacts = JsonSerializer.Deserialize<List<Contact>>(response.Content);

            Assert.That(contacts[0].firstName, Is.EqualTo("Albert"));
            Assert.That(contacts[0].lastName, Is.EqualTo("Einstein"));
        }

        [Test]
        public void Test_SearchByKeyWord_InvalidResult()
        {
            //Arrange
            var request = new RestRequest("contacts/search/missing" + DateTime.Now.Ticks, Method.Get);

            //Act
            var response = this.client.Execute(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(response.Content, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_CreateTaskWithInvalidData()
        {
            //Arrange
            var request = new RestRequest("contacts", Method.Post);
            var reqBody = new
            {
                lastName = "Curie",
                email = "marie67@gmail.com",
                phone = "+1 800 200 300",
                comments = "Old friend"
            };


        request.AddBody(reqBody);

            //Act
            var response = this.client.Execute(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"First name cannot be empty!\"}"));
        }

        [Test]
        public void Test_CreateTaskWithValidData()
        {
            //Arrange
            var request = new RestRequest("contacts", Method.Post);
            var reqBody = new
            {
                firstName = "Marie",
                lastName = "Curie",
                email = "marie67@gmail.com",
                phone = "+1 800 200 300",
                comments = "Old friend"
            };


            request.AddBody(reqBody);

            //Act
            var response = this.client.Execute(request);

            var contactObject = JsonSerializer.Deserialize<contactObject>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(contactObject.msg, Is.EqualTo("Contact added."));
            Assert.That(contactObject.contact.id, Is.GreaterThan(0));
            Assert.That(contactObject.contact.firstName, Is.EqualTo(reqBody.firstName));
            Assert.That(contactObject.contact.lastName, Is.EqualTo(reqBody.lastName));
            Assert.That(contactObject.contact.email, Is.EqualTo(reqBody.email));
            Assert.That(contactObject.contact.phone, Is.EqualTo(reqBody.phone));
            Assert.That(contactObject.contact.dateCreated, Is.Not.Empty);
            Assert.That(contactObject.contact.comments, Is.EqualTo(reqBody.comments));


        }



    }
}