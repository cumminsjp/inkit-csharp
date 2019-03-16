using System.Collections.Generic;
using System.Reflection;
using Common.Logging;
using Inkit.Core;
using Inkit.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Inkit.Tests
{
	[TestFixture]
	public class ModelTests
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
		public void Serialize_Recipient_Test()
		{
			Log.Debug("Enter");

			var actual = Settings.WebHookApiToken;
			Log.Debug($"actual={actual}");

			var model = new Recipient()
			{
				Address = "4704 TAMEO CT",
				City = "Glen Allen",
				State = "VA",
				PostalCode = "23060",
				Country = "USA",
				FirstName = "Jay",
				LastName = "Cummins",
				TemplateId = "12c5618c96184a419257f0744b9d9c76",
				ApiToken = Settings.PublicApiAuthorizationToken
			};
			
			var json = JsonConvert.SerializeObject(model, Formatting.Indented);

			Assert.IsNotEmpty(json);
		}
	}
}
 


