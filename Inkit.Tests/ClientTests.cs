using System.Net;
using System.Reflection;
using Common.Logging;
using Inkit.Core;
using Inkit.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Inkit.Tests
{
	[TestFixture]
	public class ClientTests
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

	
	}
}



