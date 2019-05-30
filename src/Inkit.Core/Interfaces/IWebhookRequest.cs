namespace Inkit.Core.Interfaces
{
	/// <summary>
	///     Webhook Request Interface
	/// </summary>
	public interface IWebhookRequest
	{
		/// <summary>
		///     Gets or sets the API token.  The InkitClient will use config setting: Inkit:API_AUTH_TOKEN or Env var:
		///     INKIT_API_AUTH_TOKEN if they exist
		/// </summary>
		/// <value>
		///     The API token.
		/// </value>
		string ApiToken { get; set; }

		/// <summary>
		///     Gets or sets the template id (Template ID from Inkit’s end)
		/// </summary>
		/// <value>
		///     The template identifier.
		/// </value>
		string TemplateId { get; set; }

		/// <summary>
		///     Gets or sets the first name.
		/// </summary>
		/// <value>
		///     The first name.
		/// </value>
		string FirstName { get; set; }

		/// <summary>
		///     Gets or sets the last name.
		/// </summary>
		/// <value>
		///     The last name.
		/// </value>
		string LastName { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		string Email { get; set; }

		/// <summary>
		///     Gets or sets the street.
		/// </summary>
		/// <value>
		///     The street.
		/// </value>
		string Street { get; set; }

		/// <summary>
		///     Gets or sets the unit [optional]
		/// </summary>
		/// <value>
		///     The unit.
		/// </value>
		string Unit { get; set; }

		/// <summary>
		///     Gets or sets the state (must be a 2 character code, e.g. CA)
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		string State { get; set; }

		/// <summary>
		///     Gets or sets the city.
		/// </summary>
		/// <value>
		///     The city.
		/// </value>
		string City { get; set; }

		/// <summary>
		///     Gets or sets the zip.
		/// </summary>
		/// <value>
		///     The zip.
		/// </value>
		string Zip { get; set; }

		/// <summary>
		///     Gets or sets the country.
		/// </summary>
		/// <value>
		///     The country.
		/// </value>
		string Country { get; set; }

		/// <summary>
		/// Gets or sets the company or c/o value
		/// </summary>
		/// <value>
		/// The company.
		/// </value>
		string Company { get; set; }
	}
}