using Xamarin.Forms;

namespace XamarinCommunityToolkit.Behaviors
{
    public abstract class BaseValidationBehavior<TView, TValue> : Behavior<TView> where TView: BindableObject
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(BaseValidationBehavior<TView, TValue>), true, BindingMode.OneWayToSource);

        public static readonly BindableProperty ShouldValidateProperty = BindableProperty.Create(nameof(ShouldValidate), typeof(bool), typeof(BaseValidationBehavior<TView, TValue>), true, propertyChanged: Revalidate);

        protected TValue previousValue;

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public bool ShouldValidate
        {
            get => (bool)GetValue(ShouldValidateProperty);
            set => SetValue(ShouldValidateProperty, value);
        }

        protected void OnValueChanged(TValue value)
        {
            previousValue = value;

            if (!ShouldValidate)
                return;

            IsValid = Validate(AdjustValue(value));
        }

        protected virtual TValue AdjustValue(TValue value) => value;

        protected abstract bool Validate(TValue value);

        protected static void Revalidate(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (BaseValidationBehavior<TView, TValue>)bindable;
            behavior.OnValueChanged(behavior.previousValue);
        }
    }
}
