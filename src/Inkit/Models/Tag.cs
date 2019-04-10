using System;
using System.Text;
using Newtonsoft.Json;

namespace Inkit.Models
{
	/// <summary>
	///     Inkit Tag Model
	///     <see cref="https://docs.inkit.com/#get-v1-tags-or-get-v1-tags-tag_id" />
	/// </summary>
	public class Tag
	{
		/// <summary>
		///     Gets or sets the tag id.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     Gets or sets the timestamp when the tag was created
		/// </summary>
		/// <value>
		///     The created at.
		/// </value>
		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }

		/// <summary>
		///     Gets or sets the timestamp when the tag was last modified
		/// </summary>
		/// <value>
		///     The updated at.
		/// </value>
		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }

		/// <summary>
		///     Gets or sets the tag name.
		/// </summary>
		/// <value>
		///     The name.
		/// </value>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{Name} - {Id}");

			return sb.ToString();
		}
	}
}