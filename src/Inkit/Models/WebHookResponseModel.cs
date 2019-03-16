using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Permissions;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Inkit.Models
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
		public JObject Data { get; set; }
		
	}
}
