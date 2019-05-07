using System;
using Newtonsoft.Json.Linq;

namespace Inkit.Core.Exceptions
{
	/// <summary>
	/// Exception when template is not found
	/// </summary>
	/// <seealso cref="NotFoundException" />
	public class TemplateNotFoundException : NotFoundException
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="TemplateNotFoundException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="description">The description.</param>
		public TemplateNotFoundException(string message, string description) : base(message)
		{
			Description = description;
		}

		public TemplateNotFoundException(string message, string description, Exception innerException) : base(message,
			innerException)
		{
			Description = description;
		}

		public TemplateNotFoundException(JObject responseData) : base(responseData.Value<string>("title"))
		{
			Description = responseData.Value<string>("description");
		}
		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		/// <value>
		///     The description.
		/// </value>
		public string Description { get; set; }
	}
}