using System;
using Newtonsoft.Json;

namespace Inkit.Models
{
	/// <summary>
	///     Inkit Recipient
	/// </summary>
	public class Recipient
	{
		/// <summary>
		/// The country abbreviation
		/// </summary>
		private string _country;

		[JsonProperty("first_name")] public string FirstName { get; set; }

		[JsonProperty("last_name")] public string LastName { get; set; }

		[JsonProperty("address")] public string Address { get; set; }

		[JsonProperty("address2")] public string Address2 { get; set; }

		[JsonProperty("city")] public string City { get; set; }

		[JsonProperty("state")] public string State { get; set; }

		[JsonProperty("zip")] public string PostalCode { get; set; }

		[JsonProperty("country")]
		public string Country
		{
			get => _country;
			set
			{
				if (value.Length > 2)
				{// ReSharper disable once NotResolvedInText
					throw new ArgumentOutOfRangeException(@"Country", value, "Length must be between 2 and 2.");
				}

				_country = value;
			}
		}

		[JsonProperty("template_id")] public string TemplateId { get; set; }

		[JsonProperty("api_token")] public string ApiToken { get; set; }
	}
}