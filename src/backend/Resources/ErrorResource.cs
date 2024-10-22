using Microsoft.Extensions.Localization;

namespace Resources
{
    public class ErrorResource
    {
        protected readonly IStringLocalizer<ErrorResource> _localizer;

        public ErrorResource(IStringLocalizer<ErrorResource> commonResource)
        {
            _localizer = commonResource;
        }

        public string InvalidUserPassword { get { return GetString(nameof(InvalidUserPassword)); } }
        public string WrongFormat { get { return GetString(nameof(WrongFormat)); } }
        public string Unauthorized { get { return GetString(nameof(Unauthorized)); } }
        public string errorCreateProfile { get { return GetString(nameof(errorCreateProfile)); } }

        protected string GetString(string name) =>
            _localizer.GetString(name);
    }
}
