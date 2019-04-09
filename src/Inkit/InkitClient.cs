﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Inkit.Core;
using Inkit.Exceptions;
using Inkit.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inkit
{
	public class InkitClient
	{
		/// <summary>
		///     The Log (Common.Logging)
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private HttpClient _apiClient;

		/// <summary>
		/// Sends the specified recipient via the WebHook
		/// </summary>
		/// <param name="recipient">The recipient.</param>
		/// <exception cref="TemplateNotFoundException"></exception>
		public async Task<WebHookResponseModel> Send(Recipient recipient)
		{
			// TODO: Implement validation
			var url = Settings.WebHookUrl;

			WebHookResponseModel response = new WebHookResponseModel();

			var jo = JObject.FromObject(recipient);
			var dict = jo.ToObject<Dictionary<string, string>>();

			response.Data = jo;
			
			using (var client = new HttpClient())
			{
				
				client.DefaultRequestHeaders.Add("Authorization", Settings.PublicApiAuthorizationToken);
				var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };

				var stopwatch = Stopwatch.StartNew();
				try
				{
					var res = await client.SendAsync(req);
					
					stopwatch.Stop();
					Log.Debug($"Something took {stopwatch.ElapsedMilliseconds}ms.");

					if (stopwatch.ElapsedMilliseconds > 1000)
					{
						Log.Warn($"Something took {stopwatch.ElapsedMilliseconds}ms but expected to take <1000ms");
					}
					
					Log.Debug($"HTTP Post To: {url} status: {res.StatusCode}");

					response.Status = res.StatusCode;
					var contentData = await res.Content.ReadAsStringAsync();
					var responseJsonObject = JObject.Parse(contentData);

					switch (res.StatusCode)
					{
						case HttpStatusCode.NotFound:
							throw new TemplateNotFoundException(responseJsonObject);
						case HttpStatusCode.Accepted:
							response.Data = responseJsonObject;
							break;
						case HttpStatusCode.AlreadyReported:
							break;
						case HttpStatusCode.Ambiguous:
							break;
						case HttpStatusCode.BadGateway:
							break;
						case HttpStatusCode.BadRequest:
							break;
						case HttpStatusCode.Conflict:
							break;
						case HttpStatusCode.Continue:
							break;
						case HttpStatusCode.Created:
							break;
						case HttpStatusCode.EarlyHints:
							break;
						case HttpStatusCode.ExpectationFailed:
							break;
						case HttpStatusCode.FailedDependency:
							break;
						case HttpStatusCode.Forbidden:
							break;
						case HttpStatusCode.Found:
							break;
						case HttpStatusCode.GatewayTimeout:
							break;
						case HttpStatusCode.Gone:
							break;
						case HttpStatusCode.HttpVersionNotSupported:
							break;
						case HttpStatusCode.IMUsed:
							break;
						case HttpStatusCode.InsufficientStorage:
							break;
						case HttpStatusCode.InternalServerError:
							break;
						case HttpStatusCode.LengthRequired:
							break;
						case HttpStatusCode.Locked:
							break;
						case HttpStatusCode.LoopDetected:
							break;
						case HttpStatusCode.MethodNotAllowed:
							break;
						case HttpStatusCode.MisdirectedRequest:
							break;
						case HttpStatusCode.Moved:
							break;
						case HttpStatusCode.MultiStatus:
							break;
						case HttpStatusCode.NetworkAuthenticationRequired:
							break;
						case HttpStatusCode.NoContent:
							break;
						case HttpStatusCode.NonAuthoritativeInformation:
							break;
						case HttpStatusCode.NotAcceptable:
							break;
						case HttpStatusCode.NotExtended:
							break;

						case HttpStatusCode.NotImplemented:
							break;
						case HttpStatusCode.NotModified:
							break;
						case HttpStatusCode.OK:
							break;
						case HttpStatusCode.PartialContent:
							break;
						case HttpStatusCode.PaymentRequired:
							break;
						case HttpStatusCode.PermanentRedirect:
							break;
						case HttpStatusCode.PreconditionFailed:
							break;
						case HttpStatusCode.PreconditionRequired:
							break;
						case HttpStatusCode.Processing:
							break;
						case HttpStatusCode.ProxyAuthenticationRequired:
							break;
						case HttpStatusCode.RedirectKeepVerb:
							break;
						case HttpStatusCode.RedirectMethod:
							break;
						case HttpStatusCode.RequestedRangeNotSatisfiable:
							break;
						case HttpStatusCode.RequestEntityTooLarge:
							break;
						case HttpStatusCode.RequestHeaderFieldsTooLarge:
							break;
						case HttpStatusCode.RequestTimeout:
							break;
						case HttpStatusCode.RequestUriTooLong:
							break;
						case HttpStatusCode.ResetContent:
							break;
						case HttpStatusCode.ServiceUnavailable:
							break;
						case HttpStatusCode.SwitchingProtocols:
							break;
						case HttpStatusCode.TooManyRequests:
							break;
						case HttpStatusCode.Unauthorized:
							break;
						case HttpStatusCode.UnavailableForLegalReasons:
							break;
						case HttpStatusCode.UnprocessableEntity:
							break;
						case HttpStatusCode.UnsupportedMediaType:
							break;
						case HttpStatusCode.Unused:
							break;
						case HttpStatusCode.UpgradeRequired:
							break;
						case HttpStatusCode.UseProxy:
							break;
						case HttpStatusCode.VariantAlsoNegotiates:
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}



					return response;
				}
				catch (Exception ex)
				{
					Log.Error(ex);
					Log.Error($"url={url}");
					Log.Error($"recipient={JsonConvert.SerializeObject(recipient,Formatting.Indented)}");

					throw;
				}
				
			}
		}

		/// <summary>
		/// Gets or sets the API client to Inkit's public API
		/// https://docs.inkit.com/#authentication 
		/// </summary>
		/// <value>
		/// The API client.
		/// </value>
		private HttpClient ApiClient
		{
			get => _apiClient ?? (_apiClient = CreateApiClient());

			set => _apiClient = value;
		}


		/// <summary>
		/// Creates the API client.
		/// https://docs.inkit.com/#authentication
		/// </summary>
		/// <returns></returns>
		private HttpClient CreateApiClient()
		{
			var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Inkit", Settings.PublicApiAuthorizationToken);
			// client.DefaultRequestHeaders.Add("Authorization", $"Inkit {Settings.PublicApiAuthorizationToken}");
			client.DefaultRequestHeaders.Add("Accept", "application/json");

			return client;
		}

		/// <summary>
		/// Gets the contacts.
		/// </summary>
		/// <returns></returns>
		public async Task<JArray> GetContacts()
		{
			string url = $"{PublicApiUrl}/contacts/";
			
			var result = await ApiClient.GetStringAsync(url);

			var  responseObject = JObject.Parse(result);
			
			// responseObject["response"];

			return (JArray)responseObject["body"];
		}

		 

		/// <summary>
		/// Gets the public API URL, including the version.
		/// </summary>
		/// <value>
		/// The public API URL.
		/// </value>
		public string PublicApiUrl => $"{Settings.PublicApiUrl}/v{Settings.PublicApiVersion}";


		/// <summary>
		/// Creates the contact.
		/// <see cref="Https://docs.inkit.com/#post-v1-contacts">https://docs.inkit.com/#post-v1-contacts</see>
		/// </summary>
		/// <param name="contact">The contact.</param>
		/// <returns></returns>
		public async Task<Contact>   CreateContact(Contact contact)
		{
			string url = $"{PublicApiUrl}/contacts/";

			var json = JsonConvert.SerializeObject(contact);

			var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");

			var response = await ApiClient.PostAsync(url, content);

			var body = response.Content.ReadAsStringAsync();

			Console.WriteLine(body);

			return null;
		}
	}

	


}
