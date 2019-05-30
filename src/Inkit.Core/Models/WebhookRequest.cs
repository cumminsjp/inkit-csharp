using Inkit.Core.Interfaces;
using Newtonsoft.Json;

namespace Inkit.Core.Models
{
	/// <summary>
	///     Model for Webhook Request
	///     <see cref="http://support.inkit.io/integrations/generic-inkit-webhook-integration" />
	/// </summary>
	public class WebhookRequest : IWebhookRequest
	{
		/// <summary>
		///     Gets or sets the API token.  The InkitClient will use config setting: Inkit:API_AUTH_TOKEN or Env var:
		///     INKIT_API_AUTH_TOKEN if they exist
		/// </summary>
		/// <value>
		///     The API token.
		/// </value>
		[JsonProperty("api_token")]
		public string ApiToken { get; set; }

		/// <summary>
		///     Gets or sets the template identifier.
		/// </summary>
		/// <value>
		///     The template identifier.
		/// </value>
		[JsonProperty("template_id")]
		public string TemplateId { get; set; }

		/// <summary>
		///     Gets or sets the first name. This data is required.
		/// </summary>
		/// <value>
		///     The first name.
		/// </value>
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		/// <summary>
		///     Gets or sets the last name. This data is required.
		/// </summary>
		/// <value>
		///     The last name.
		/// </value>
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		[JsonProperty("email")]
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the street.
		/// </summary>
		/// <value>
		///     The street.
		/// </value>
		[JsonProperty("street")]
		public string Street { get; set; }

		/// <summary>
		///     Gets or sets the unit value [optional]
		/// </summary>
		/// <value>
		///     The unit.
		/// </value>
		[JsonProperty("unit")]
		public string Unit { get; set; }

		/// <summary>
		///     Gets or sets the state.
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		[JsonProperty("state")]
		public string State { get; set; }

		/// <summary>
		///     Gets or sets the city.
		/// </summary>
		/// <value>
		///     The city.
		/// </value>
		[JsonProperty("city")]
		public string City { get; set; }

		/// <summary>
		///     Gets or sets the zip.
		/// </summary>
		/// <value>
		///     The zip.
		/// </value>
		[JsonProperty("zip")]
		public string Zip { get; set; }

		/// <summary>
		///     Gets or sets the country.
		/// </summary>
		/// <value>
		///     The country.
		/// </value>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the company or c/o value
		/// </summary>
		/// <value>
		/// The company.
		/// </value>
		public string Company { get; set; }
	}
}