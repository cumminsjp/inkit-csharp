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
		[JsonProperty("api_token")] public string ApiToken { get; set; }
		[JsonProperty("template_id")] public string TemplateId { get; set; }
		/// <summary>
		/// Gets or sets the first name. This data is required.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		[JsonProperty("first_name")] public string FirstName { get; set; }
		/// <summary>
		/// Gets or sets the last name. This data is required.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		[JsonProperty("last_name")] public string LastName { get; set; }
		[JsonProperty("email")] public string Email { get; set; }
		[JsonProperty("street")] public string Street { get; set; }
		[JsonProperty("unit")] public string Unit { get; set; }
		[JsonProperty("state")] public string State { get; set; }
		[JsonProperty("city")] public string City { get; set; }
		[JsonProperty("zip")] public string Zip { get; set; }
		[JsonProperty("country")] public string Country { get; set; }
	}
}