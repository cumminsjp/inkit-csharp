using Inkit.Core.Models;
using Newtonsoft.Json;

namespace Inkit.Tests
{
	public class CustomWebhookRequest : WebhookRequest
	{
		[JsonProperty("campaignTag")] public string CampaignTag { get; set; }
	}
}