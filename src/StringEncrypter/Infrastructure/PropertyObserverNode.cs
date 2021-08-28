using System;
using System.ComponentModel;
using System.Reflection;

namespace Prism.Commands
{
    /// <summary>
    /// Represents each node of nested properties expression and takes care of
    /// subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class PropertyObserverNode
    {
        #region Fields

        private readonly Action _action;
        private INotifyPropertyChanged _inpcObject;

        #endregion Fields

        #region Constructors

        public PropertyObserverNode(PropertyInfo propertyInfo, Action action)
        {
            PropertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
            _action = () =>
            {
                action?.Invoke();
                if (Next == null) return;
                Next.UnsubscribeListener();
                GenerateNextNode();
            };
        }

        #endregion Constructors

        #region Properties

        public PropertyObserverNode Next { get; set; }
        public PropertyInfo PropertyInfo { get; }

        #endregion Properties

        #region Methods

        public void SubscribeListenerFor(INotifyPropertyChanged inpcObject)
        {
            _inpcObject = inpcObject;
            _inpcObject.PropertyChanged += OnPropertyChanged;

            if (Next != null) GenerateNextNode();
        }

        private void GenerateNextNode()
        {
            var nextProperty = PropertyInfo.GetValue(_inpcObject);
            if (nextProperty == null) return;
            if (!(nextProperty is INotifyPropertyChanged nextInpcObject))
                throw new InvalidOperationException("Trying to subscribe PropertyChanged listener in object that " +
                                                    $"owns '{Next.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.");

            Next.SubscribeListenerFor(nextInpcObject);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e?.PropertyName == PropertyInfo.Name || string.IsNullOrEmpty(e?.PropertyName))
            {
                _action?.Invoke();
            }
        }

        private void UnsubscribeListener()
        {
            if (_inpcObject != null)
                _inpcObject.PropertyChanged -= OnPropertyChanged;

            Next?.UnsubscribeListener();
        }

        #endregion Methods
    }
}