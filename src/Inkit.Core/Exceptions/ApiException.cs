using System;
using System.Net;

namespace Inkit.Core.Exceptions
{
	/// <summary>
	///     Generic API Exception with HTTP Status Code
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class ApiException : Exception
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ApiException" /> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <param name="message">The message.</param>
		/// <param name="ex">The ex.</param>
		public ApiException(HttpStatusCode statusCode, string message, Exception ex)
			: base(message, ex)
		{
			StatusCode = statusCode;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="ApiException" /> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <param name="message">The message.</param>
		public ApiException(HttpStatusCode statusCode, string message)
			: base(message)
		{
			StatusCode = statusCode;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="ApiException" /> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		public ApiException(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}

		/// <summary>
		///     Gets the status code.
		/// </summary>
		/// <value>
		///     The status code.
		/// </value>
		public HttpStatusCode StatusCode { get; }
	}
}
