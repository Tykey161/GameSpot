using FluentValidation;
using GameSpot.Models;

namespace GameSpot.Validators
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Headquarters).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Website).NotEmpty().MaximumLength(100);
        }
    }
}
