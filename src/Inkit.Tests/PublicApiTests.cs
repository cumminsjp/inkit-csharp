using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Logging;
using Inkit.Core;
using Inkit.Core.Helpers;
using Inkit.Core.Models;
using Inkit.Tests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Inkit.Tests
{
	/// <summary>
	///     Some tests to use during development.  These are not unit tests.
	/// </summary>
	[TestFixture]
	[Ignore("These aren't unit tests. Just tests for isolating API issues.  ")]
	public class PublicApiTests
	{
		[SetUp]
		public void DerivedSetUp()
		{
			Log.Debug("Enter");
		}

		[TearDown]
		public void DerivedTearDown()
		{
			Log.Debug("Enter");
		}

		/// <summary>
		///     The Log (Common.Logging)
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		[OneTimeSetUp]
		public void RunBeforeAnyTests()
		{
			Log.Debug("Enter");
		}

		[OneTimeTearDown]
		public void RunAfterAnyTests()
		{
			Log.Debug("Enter");
		}


		[Test]
		public void Contact_Lifecycle_Test()
		{
			Log.Debug("Enter");


			var client = new InkitClient();

			var data = TestHelper.GetTestFileData("new-contact-2.json");

			Assert.IsNotNull(data);
			Assert.IsNotEmpty(data);

			var contact = JsonConvert.DeserializeObject<Contact>(data);

			var added = client.CreateContact(contact).Result;

			Assert.IsNotNull(added);
			Assert.False(string.IsNullOrWhiteSpace(added.Id));

			client.DeleteContact(added.Id).Wait();

			Assert.IsNotNull(added);

			// Assert.False(string.IsNullOrWhiteSpace(added.Id));
			// Assert.False(string.IsNullOrWhiteSpace(added.Source));


			// var result = client.GetContacts().Result;
			// Console.WriteLine(JsonConvert.SerializeObject(result));
			// Assert.IsNotNull(result);
		}

		[Test]
		public void GetContact_ById_Test()
		{
			Log.Debug("Enter");

			var client = new InkitClient();

			var result = client.GetContacts().Result;

			var contactId = result.First().Value<string>("id");

			var contact = client.GetContact(contactId).Result;

			Assert.IsNotNull(contact);
		}

		[Test]
		public void GetContacts_Test()
		{
			Log.Debug("Enter");


			var client = new InkitClient();

			var result = client.GetContacts().Result;

			var contacts = result.ToObject<Contact[]>();

			Assert.IsNotNull(contacts);

			Console.WriteLine(contacts.Select(x => x.ToString()).ToCharacterSeparatedValueString(Environment.NewLine));

			foreach (var contact in contacts)
				Console.WriteLine($"{contact.Id} : {contact.LastName}, {contact.FirstName}");
		}

		[Test]
		public void GetTags_Test()
		{
			Log.Debug("Enter");

			var client = new InkitClient();

			var result = client.GetTags().Result;

			Console.WriteLine(result.Select(x => x.ToString()).ToCharacterSeparatedValueString(Environment.NewLine));
		}


		// client.DeleteTag("9a0c73af96844ede9f17330c052792d8").Wait();


		[Test]
		public void Tag_Delete_Test()
		{
			Log.Debug("Enter");

			var tagIds = new List<string>
			{
				"9a0c73af96844ede9f17330c052792d8"
			};

			var client = new InkitClient();

			foreach (var id in tagIds)
				try
				{
					client.DeleteTag(id).Wait();
				}
				catch
				{
					// throw;
				}
		}

		[Test]
		public void Tag_Lifecycle_Test()
		{
			Log.Debug("Enter");


			var client = new InkitClient();


			var tag = new Tag
			{
				Name = "testtag3"
			};


			var added = client.CreateTag(tag).Result;


			Assert.IsNotNull(added);
			Assert.IsNotEmpty(added.Id);
			Assert.IsNotEmpty(added.Name);

			Console.WriteLine($"Test Tag: {added} added.");

			client.DeleteTag(added.Id).Wait();

			Console.WriteLine($"Test Tag: {added} deleted.");


			// Assert.False(string.IsNullOrWhiteSpace(added.Id));
			// Assert.False(string.IsNullOrWhiteSpace(added.Source));


			// var result = client.GetContacts().Result;
			// Console.WriteLine(JsonConvert.SerializeObject(result));
			// Assert.IsNotNull(result);
		}
	}
}