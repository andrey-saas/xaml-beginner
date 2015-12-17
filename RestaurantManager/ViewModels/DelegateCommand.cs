using System;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public interface IUpdatableCommand : ICommand
    {
        void UpdateState();
    }

    public class DelegateCommand : IUpdatableCommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action action)
            : this(action, () => true)
        {
        }

        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action();
                UpdateState();
            }
        }

        public void UpdateState()
        {
            RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            var eventHandler = CanExecuteChanged;
            if (eventHandler != null)
                eventHandler(this, EventArgs.Empty);
        }

    }
}
