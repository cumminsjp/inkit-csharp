using FluentValidation;
using Inkit.Core.Interfaces;
using Inkit.Core.Models;

namespace Inkit.Core.Validation
{
	/// <summary>
	///     Validates data for a Webhook Request
	/// </summary>
	/// <seealso cref="WebhookRequest" />
	public class WebhookRequestValidator : AbstractValidator<IWebhookRequest>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="WebhookRequestValidator" /> class.
		/// </summary>
		public WebhookRequestValidator()
		{
			RuleFor(r => r.FirstName).NotNull();

			RuleFor(r => r.LastName).NotNull().MaximumLength(39);

			RuleFor(r => r.Street).NotNull();
			RuleFor(r => r.Zip).NotNull();
			RuleFor(r => r.City).NotNull();
			RuleFor(r => r.State).NotNull().Length(2);
			RuleFor(r => r.TemplateId).NotNull();
			RuleFor(r => r.ApiToken).NotNull();
			RuleFor(r => r.Country).NotNull().Length(2);
		}
	}
}