
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Logging;
using Inkit.Core;
using Inkit.Helpers;
using Inkit.Models;
using Inkit.Tests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Inkit.Tests
{
	[TestFixture]
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
		public void GetContacts_Test()
		{
			Log.Debug("Enter");


			var client = new InkitClient();

			var result = client.GetContacts().Result;

			var contacts = result.ToObject<Contact[]>();

			Assert.IsNotNull(contacts);

			Console.WriteLine(contacts.Select(x => x.ToString()).ToCharacterSeparatedValueString(Environment.NewLine));
		}


		[Test]
		public void Contact_Lifecycle_Test()
		{
			Log.Debug("Enter");


			var client = new InkitClient();

			var data = TestHelper.GetTestFileData("new-contact-1.json");

			Assert.IsNotNull(data);
			Assert.IsNotEmpty(data);

			var contact = JsonConvert.DeserializeObject<Contact>(data);

			var added = client.CreateContact(contact).Result;

			Assert.IsNotNull(added);

			// Assert.False(string.IsNullOrWhiteSpace(added.Id));
			// Assert.False(string.IsNullOrWhiteSpace(added.Source));
			


			// var result = client.GetContacts().Result;
			// Console.WriteLine(JsonConvert.SerializeObject(result));
			// Assert.IsNotNull(result);
		}


	}
}



