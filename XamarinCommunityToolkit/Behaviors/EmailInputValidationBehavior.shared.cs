using System.Text.RegularExpressions;

namespace XamarinCommunityToolkit.Behaviors
{
    public class EmailInputValidationBehavior : InputValidationBehavior
    {
        static readonly Regex emailRegex
            = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

        protected override bool Validate(string value)
            => value != null && emailRegex.IsMatch(value);
    }
}
