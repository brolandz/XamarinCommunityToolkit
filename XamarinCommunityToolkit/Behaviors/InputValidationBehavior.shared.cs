using Xamarin.Forms;

namespace XamarinCommunityToolkit.Behaviors
{
    public abstract class InputValidationBehavior : BaseValidationBehavior<InputView, string>
    {
        public static readonly BindableProperty ShouldTrimValueProperty = BindableProperty.Create(nameof(ShouldTrimValue), typeof(bool), typeof(InputValidationBehavior), false, propertyChanged: Revalidate);

        public bool ShouldTrimValue
        {
            get => (bool)GetValue(ShouldTrimValueProperty);
            set => SetValue(ShouldTrimValueProperty, value);
        }

        protected override void OnAttachedTo(InputView bindable)
        {
            bindable.TextChanged += OnTextChanged;
            OnValueChanged(bindable.Text);
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(InputView bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        protected override string AdjustValue(string value)
        {
            if (ShouldTrimValue)
                value = value?.Trim();

            return value;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
            => OnValueChanged(e.NewTextValue);
    }
}
