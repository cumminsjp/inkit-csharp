namespace Inkit.Core.Interfaces
{
	/// <summary>
	/// Inkit Address Interface
	/// </summary>
	public interface IAddress
	{
		/// <summary>
		///     Gets or sets the street (excluding unit) of a mailing address
		/// </summary>
		/// <value>
		///     The street.
		/// </value>
		string Street { get; set; }

		/// <summary>
		///     Gets or sets the unit portion of a mailing address
		/// </summary>
		/// <value>
		///     The unit.
		/// </value>
		string Unit { get; set; }

		/// <summary>
		///     Gets or sets the city for a mailing address
		/// </summary>
		/// <value>
		///     The city.
		/// </value>
		string City { get; set; }

		/// <summary>
		///     Gets or sets the state 2-character abbreviation for a mailing address (e.g. for California, use CA).
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		string State { get; set; }

		/// <summary>
		///     Gets or sets the ZIP Code
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
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		string ToString();
	}
}