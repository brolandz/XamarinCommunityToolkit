using Xamarin.Forms;

namespace XamarinCommunityToolkit.Behaviors
{
    public class LengthInputValidationBehavior : InputValidationBehavior
    {
        public static readonly BindableProperty MinimumLengthProperty = BindableProperty.Create(nameof(MinimumLength), typeof(int), typeof(LengthInputValidationBehavior), 0, propertyChanged: Revalidate);

        public static readonly BindableProperty MaximumLengthProperty = BindableProperty.Create(nameof(MaximumLength), typeof(int), typeof(LengthInputValidationBehavior), int.MaxValue, propertyChanged: Revalidate);

        public int MinimumLength
        {
            get => (int)GetValue(MinimumLengthProperty);
            set => SetValue(MinimumLengthProperty, value);
        }

        public int MaximumLength
        {
            get => (int)GetValue(MaximumLengthProperty);
            set => SetValue(MaximumLengthProperty, value);
        }

        protected override bool Validate(string value)
        {
            value ??= string.Empty;
            var length = value.Length;
            return length >= MinimumLength && length <= MaximumLength;
        }
    }
}
