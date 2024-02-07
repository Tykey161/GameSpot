using FluentValidation;
using GameSpot.Models;

namespace GameSpot.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Genre).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PublisherId).NotEmpty().GreaterThan(0);
        }
    }
}
