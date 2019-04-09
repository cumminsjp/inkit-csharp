using System;
using System.Reflection;
using Common.Logging;

// ReSharper disable once CheckNamespace
namespace Inkit.Core
{
	/// <summary>
	/// Inkit Settings
	/// </summary>
	/// <seealso cref="Inkit.Core.SettingsBase" />
	public class Settings : SettingsBase
	{
		/// <summary>
		///     The Log (Common.Logging)
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		
		/// <summary>
		/// Gets the web hook API token.
		/// </summary>
		/// <value>
		/// The web hook API token.
		/// </value>
		public static string WebHookApiToken
		{
			get
			{
				var token = Environment.GetEnvironmentVariable("INKIT_WEBHOOK_API_TOKEN");

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit WebHook API token obtained from environment variable.");
					return token;
				}

				token = Get<string>("Inkit:WEBHOOK_API_TOKEN",true,string.Empty);

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit WebHook API token obtained from App Settings.");
					return token;
				}


				return token;
			}
		}

		/// <summary>
		/// Gets the public API authorization token.
		/// </summary>
		/// <value>
		/// The public API authorization token.
		/// </value>
		public static string PublicApiAuthorizationToken
		{
			get
			{
				var token = Get<string>("Inkit:API_AUTH_TOKEN",true,String.Empty);

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API Authorization Token obtained from App Settings.");
					return token;
				}
				
				token = Environment.GetEnvironmentVariable("INKIT_API_AUTH_TOKEN");

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API Authorization Token obtained from environment variable.");
					return token;
				}

				return token;
			}
		}
		
		/// <summary>
		/// Gets the web hook URL.
		/// </summary>
		/// <value>
		/// The web hook URL.
		/// </value>
		public static string WebHookUrl
		{
			get
			{
				var token = Environment.GetEnvironmentVariable("INKIT_WEBHOOK_URL");

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Webhook URL obtained from environment variable.");
					return token;
				}

				token = Get<string>("Inkit:WEBHOOK_URL",true,string.Empty);

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Webhook URL obtained from App Settings.");
					return token;
				}

				token = "https://internal.inkit.io/integrations/iterable/webhook";
				Log.Debug($"Inkit Webhook URL obtained from Internal Default.");

				return token;
			}
		}

		/// <summary>
		/// Gets the public API URL (e.g. http://api.inkit.io)
		///  <see href="https://docs.inkit.com/#inkit-public-api">https://docs.inkit.com/#inkit-public-api</see> 
		/// </summary>
		/// <value>
		/// The public API URL.
		/// </value>
		public static string PublicApiUrl
		{
			get
			{
				var token = Environment.GetEnvironmentVariable("INKIT_PUBLICAPI_URL");

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API URL obtained from environment variable.");
					return token;
				}

				token = Get("Inkit:PUBLICAPI_URL",true,string.Empty);

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API URL obtained from App Settings.");
					return token;
				}

				token = "http://api.next.inkit.io";
				Log.Debug($"Inkit Public API URL obtained from Internal Default.");

				return token;
			}
		}

		/// <summary>
		/// Gets the public API version.
		/// </summary>
		/// <value>
		/// The public API version.
		/// </value>
		public static string PublicApiVersion
		{
			get
			{
				var token = Environment.GetEnvironmentVariable("INKIT_PUBLICAPI_VERSION");

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API Version obtained from environment variable.");
					return token;
				}

				token = Get("Inkit:PUBLICAPI_VERSION",true,string.Empty);

				if (!string.IsNullOrWhiteSpace(token))
				{
					Log.Debug($"Inkit Public API Version obtained from App Settings.");
					return token;
				}

				token = "1";
				Log.Debug($"Inkit Public API Version obtained from Internal Default.");

				return token;
			}
		}
	}
}
