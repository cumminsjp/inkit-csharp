namespace Inkit.Core.Interfaces
{
	/// <summary>
	/// Webhook Request Interface
	/// </summary>
	public interface IWebhookRequest
	{
		/// <summary>
		/// Gets or sets the API token.  The InkitClient will use config setting: Inkit:API_AUTH_TOKEN or Env var: INKIT_API_AUTH_TOKEN if they exist
		/// </summary>
		/// <value>
		/// The API token.
		/// </value>
		string ApiToken { get; set; }
		string TemplateId { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string Email { get; set; }
		string Street { get; set; }
		string Unit { get; set; }
		string State { get; set; }
		string City { get; set; }
		string Zip { get; set; }
		string Country { get; set; }
	}
}