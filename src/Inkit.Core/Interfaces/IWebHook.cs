using System.Threading.Tasks;
using Inkit.Core.Exceptions;
using Inkit.Core.Models;

namespace Inkit.Core.Interfaces
{
	/// <summary>
	/// Interface for Inkit WebHook
	/// </summary>
	public interface IWebHook
	{
		/// <summary>
		/// Sends to the specified recipient via the WebHook
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		/// <exception cref="TemplateNotFoundException"></exception>
		Task<WebHookResponseModel> Send(IWebhookRequest request);
	}
}