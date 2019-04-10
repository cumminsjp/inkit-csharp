using Common.Logging;
using Inkit.Core;
using Inkit.Exceptions;
using Inkit.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inkit
{
	/// <summary>
	/// Inkit API Client
	/// https://docs.inkit.com
	/// 
	/// </summary>
	public class InkitClient
	{
		/// <summary>
		///     The Log (Common.Logging)
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private HttpClient _apiClient;

		/// <summary>
		///     Gets or sets the API client to Inkit's public API
		///     https://docs.inkit.com/#authentication
		/// </summary>
		/// <value>
		///     The API client.
		/// </value>
		private HttpClient ApiClient
		{
			get => _apiClient ?? (_apiClient = CreateApiClient());

			set => _apiClient = value;
		}

		/// <summary>
		///     Gets the public API URL, including the version.
		/// </summary>
		/// <value>
		///     The public API URL.
		/// </value>
		public string PublicApiUrl => $"{Settings.PublicApiUrl}/v{Settings.PublicApiVersion}";

		/// <summary>
		///     Sends the specified recipient via the WebHook
		/// </summary>
		/// <param name="recipient">The recipient.</param>
		/// <exception cref="TemplateNotFoundException"></exception>
		public async Task<WebHookResponseModel> Send(Recipient recipient)
		{
			// TODO: Implement validation
			var url = Settings.WebHookUrl;

			var response = new WebHookResponseModel();

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
						Log.Warn($"Something took {stopwatch.ElapsedMilliseconds}ms but expected to take <1000ms");

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
					Log.Error($"recipient={JsonConvert.SerializeObject(recipient, Formatting.Indented)}");

					throw;
				}
			}
		}

		/// <summary>
		///     Creates the API client.
		///     https://docs.inkit.com/#authentication
		/// </summary>
		/// <returns></returns>
		private HttpClient CreateApiClient()
		{
			var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Inkit", Settings.PublicApiAuthorizationToken);
			// client.DefaultRequestHeaders.Add("Authorization", $"Inkit {Settings.PublicApiAuthorizationToken}");
			client.DefaultRequestHeaders.Add("Accept", "application/json");

			return client;
		}

		/// <summary>
		///     Gets the contacts.
		/// </summary>
		/// <returns></returns>
		public async Task<JArray> GetContacts()
		{
			var url = $"{PublicApiUrl}/contacts/";

			var result = await ApiClient.GetStringAsync(url);

			var responseObject = JObject.Parse(result);

			// responseObject["response"];

			return (JArray)responseObject["body"];
		}

		/// <summary>
		/// Gets the contact by the Inkit {contact_id}
		/// </summary>
		/// <param name="contactId">The contact identifier.</param>
		/// <returns></returns>
		public async Task<Contact> GetContact(string contactId)
		{
			if (string.IsNullOrWhiteSpace(contactId))
				throw new ArgumentNullException(nameof(contactId));

			var url = $"{PublicApiUrl}/contacts/{contactId}";

			var result = await ApiClient.GetStringAsync(url);

			return await DeserializeBody<Contact>(result);
		}

		/// <summary>
		///     Creates the contact.
		///     <see cref="Https://docs.inkit.com/#post-v1-contacts">https://docs.inkit.com/#post-v1-contacts</see>
		/// </summary>
		/// <param name="contact">The contact.</param>
		/// <returns></returns>
		public async Task<Contact> CreateContact(Contact contact)
		{
			var url = $"{PublicApiUrl}/contacts/";

			var json = JsonConvert.SerializeObject(contact, Formatting.None, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			});

			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await ApiClient.PostAsync(url, content);

			if (response.StatusCode == HttpStatusCode.Created)
			{
				// Yes!

				var addedContact = await DeserializeBody<Contact>(response);

				return addedContact;
			}

			return null;
		}

		/// <summary>
		/// Creates the tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <returns></returns>
		public async Task<Tag> CreateTag(Tag tag)
		{
			return await PostItem("tags", tag);
		}

		/// <summary>
		/// Gets all tags from inkit
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Tag>> GetTags()
		{
			var url = $"{PublicApiUrl}/tags/";

			var result = await ApiClient.GetStringAsync(url);

			Log.Debug($"HTTP GET: {url} result: {result}");

			return await DeserializeBody<Tag[]>(result);
		}

		/// <summary>
		///     Deserializes the body of the Inkit.io response into a model T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="response">The response.</param>
		/// <returns></returns>
		private async Task<T> DeserializeBody<T>(HttpResponseMessage response)
		{
			var responseContent = await response.Content.ReadAsStringAsync();

			return await DeserializeBody<T>(responseContent);
		}

		/// <summary>
		/// Deserializes a JSON string into a model T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="json">The json.</param>
		/// <returns></returns>
		private async Task<T> DeserializeBody<T>(string json)
		{
			var responseJson = JObject.Parse(json);

			return responseJson["body"].ToObject<T>();
		}

		/// <summary>
		///     Deletes the contact from Inkit
		/// </summary>
		/// <param name="added">The added.</param>
		/// <returns></returns>
		public async Task DeleteContact(Contact added)
		{
			await DeleteContact(added.Id);
		}

		/// <summary>
		///     Deletes the contact from Inkit
		/// </summary>
		/// <param name="contactId">The contact identifier.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task DeleteContact(string contactId)
		{
			if (string.IsNullOrWhiteSpace(contactId))
				throw new ArgumentNullException(nameof(contactId));

			var resourceName = "contacts";

			await DeleteItem(resourceName, contactId);
		}

		/// <summary>
		/// Deletes the tag.
		/// </summary>
		/// <param name="tagId">The tag identifier.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">tagId</exception>
		public async Task DeleteTag(string tagId)
		{
			if (string.IsNullOrWhiteSpace(tagId))
				throw new ArgumentNullException(nameof(tagId));

			var resourceName = "tags";

			await DeleteItem(resourceName, tagId);
		}

		/// <summary>
		/// Deletes the item from Inkit 
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">
		/// id
		/// or
		/// resourceName
		/// </exception>
		/// <exception cref="ApiException"></exception>
		private async Task DeleteItem(string resourceName, string id)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentNullException(nameof(id));

			if (string.IsNullOrWhiteSpace(resourceName))
				throw new ArgumentNullException(nameof(resourceName));


			var url = $"{PublicApiUrl}/{resourceName}/{id}";

			var result = await ApiClient.DeleteAsync(url);

			if (result.StatusCode == HttpStatusCode.NoContent)
			{
				Log.Debug($"{resourceName} ID: {id} successfully deleted.");
			}
			else
			{
				var errorMessage =
					$"Received Status Code: {result.StatusCode} when attempting to delete {resourceName} ID: {id} ({url}).";
				Log.Error(errorMessage);

				throw new ApiException(result.StatusCode, errorMessage);
			}
		}

		/// <summary>
		/// HTTP POST the item to Inkit (creates an  item in Inkit).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">
		/// item
		/// or
		/// resourceName
		/// </exception>
		/// <exception cref="ApiException"></exception>
		private async Task<T> PostItem<T>(string resourceName, T item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			if (string.IsNullOrWhiteSpace(resourceName))
				throw new ArgumentNullException(nameof(resourceName));

			var url = $"{PublicApiUrl}/{resourceName}/";

			var json = JsonConvert.SerializeObject(item, Formatting.None, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			});

			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await ApiClient.PostAsync(url, content);
			
			if (response.StatusCode == HttpStatusCode.Created)
			{
				var added = await DeserializeBody<T>(response);

				return added;

			}

			var errorMessage =
				$"Received Status Code: {response.StatusCode} when attempting to create {resourceName}: ({url}) {json}.";
			Log.Error(errorMessage);

			throw new ApiException(response.StatusCode, errorMessage);

		}

	}
}