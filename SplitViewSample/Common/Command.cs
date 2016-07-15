using System;
using System.Windows.Input;

namespace SplitViewSample.Common
{
    /// <summary>
    /// Представляет команду.
    /// </summary>
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public Command(Action execute, Func<bool> canexecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            this.execute = execute;
            canExecute = canexecute ?? (() => true);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object o)
        {
            return canExecute();
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
                return;
            execute();
        }
    }

    /// <summary>
    /// Представляет команду с параметром.
    /// </summary>
    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public Command(Action execute, Func<bool> canexecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            this.execute = execute;
            canExecute = canexecute ?? (() => true);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object o)
        {
            return canExecute();
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
                return;
            execute();
        }
    }
}