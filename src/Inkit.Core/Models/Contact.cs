using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inkit.Core.Models
{
	/// <summary>
	///     Model for Inkit Contacts
	///     <see href="https://docs.inkit.com/#contacts">https://docs.inkit.com/#contacts</see>
	/// </summary>
	public class Contact
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     Gets or sets the TimeStamp when the contact was created
		/// </summary>
		/// <value>
		///     The created at.
		/// </value>
		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }

		/// <summary>
		///     Gets or sets the TimeStamp when the contact last modified
		/// </summary>
		/// <value>
		///     The updated at.
		/// </value>
		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }

		/// <summary>
		///     Gets or sets the source.
		/// </summary>
		/// <value>
		///     The source.
		/// </value>
		[JsonProperty("source")]
		public string Source { get; set; }

		/// <summary>
		///     Gets or sets the first name.
		/// </summary>
		/// <value>
		///     The first name.
		/// </value>
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		/// <summary>
		///     Gets or sets the last name.
		/// </summary>
		/// <value>
		///     The last name.
		/// </value>
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		/// <summary>
		///     Gets or sets the company.
		/// </summary>
		/// <value>
		///     The company.
		/// </value>
		[JsonProperty("company")]
		public string Company { get; set; }

		/// <summary>
		///     Gets or sets the mailing address.
		/// </summary>
		/// <value>
		///     The address.
		/// </value>
		[JsonProperty("address")]
		public Address Address { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		[JsonProperty("email")]
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the tags.
		/// </summary>
		/// <value>
		///     The tags.
		/// </value>
		[JsonProperty("tags")]
		public JArray Tags { get; set; }

		/// <summary>
		///     Gets or sets the custom data.
		/// </summary>
		/// <value>
		///     The custom data.
		/// </value>
		[JsonProperty("custom_data")]
		public JObject CustomData { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{LastName}, {FirstName}");

			if (Address != null)
				sb.Append($", {Address}");

			return sb.ToString();
		}
	}
}