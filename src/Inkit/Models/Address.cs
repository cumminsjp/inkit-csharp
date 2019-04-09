using System.Text;
using Newtonsoft.Json;

namespace Inkit.Models
{
	/// <summary>
	///     An Inkit.io Address record
	/// </summary>
	public class Address
	{
		/// <summary>
		///     Gets or sets the street (excluding unit) of a mailing address
		/// </summary>
		/// <value>
		///     The street.
		/// </value>
		[JsonProperty("street")]
		public string Street { get; set; }

		/// <summary>
		///     Gets or sets the unit portion of a mailing address
		/// </summary>
		/// <value>
		///     The unit.
		/// </value>
		[JsonProperty("unit")]
		public string Unit { get; set; }

		/// <summary>
		///     Gets or sets the city for a mailing address
		/// </summary>
		/// <value>
		///     The city.
		/// </value>
		[JsonProperty("city")]
		public string City { get; set; }

		/// <summary>
		///     Gets or sets the state 2-character abbreviation for a mailing address (e.g. for California, use CA).
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		[JsonProperty("state")]
		public string State { get; set; }

		/// <summary>
		///     Gets or sets the ZIP Code
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
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{Street}");

			if (!string.IsNullOrWhiteSpace(Unit) && sb.Length > 0)
			{
				sb.Append($", {Unit}");
			}

			if (!string.IsNullOrWhiteSpace(City) && sb.Length > 0)
			{
				sb.Append($", {City}");
			}

			if (!string.IsNullOrWhiteSpace(State) && sb.Length > 0)
			{
				sb.Append($", {State}");
			}

			if (!string.IsNullOrWhiteSpace(Zip) && sb.Length > 0)
			{
				sb.Append($" {Zip}");
			}	
			
			if (!string.IsNullOrWhiteSpace(Country) && sb.Length > 0)
			{
				sb.Append($" {Country}");
			}

			return sb.ToString();
		}
	}
}