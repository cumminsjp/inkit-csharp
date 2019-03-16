using System.Reflection;
using Common.Logging;
using Inkit.Core;
using NUnit.Framework;

namespace Inkit.Tests
{
	[TestFixture]
	public class TestClass
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
		public void Get_WebHookApiToken_Test()
		{
			Log.Debug("Enter");

			var actual = Settings.WebHookApiToken;
			Log.Debug($"actual={actual}");

			Assert.IsNotNull(actual);
		}
	}
}