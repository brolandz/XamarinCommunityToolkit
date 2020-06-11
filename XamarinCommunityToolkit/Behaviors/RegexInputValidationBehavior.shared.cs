using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace XamarinCommunityToolkit.Behaviors
{
    public class RegexInputValidationBehavior : InputValidationBehavior
    {
        public static readonly BindableProperty RegexProperty = BindableProperty.Create(nameof(Regex), typeof(Regex), typeof(RegexInputValidationBehavior), propertyChanged: Revalidate);

        public Regex Regex
        {
            get => (Regex)GetValue(RegexProperty);
            set => SetValue(RegexProperty, value);
        }

        protected override bool Validate(string value)
            => value != null && Regex != null && Regex.IsMatch(value);
    }
}
