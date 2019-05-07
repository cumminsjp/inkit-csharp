using System.Net;
using Newtonsoft.Json.Linq;

namespace Inkit.Core.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class WebHookResponseModel
	{
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public HttpStatusCode? Status { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public string Data { get; set; }
		
	}
}
