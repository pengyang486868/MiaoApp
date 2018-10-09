using System;
using System.Windows.Input;

namespace MiaoCore
{
    public class MiaoCommand : ICommand
    {
        public delegate void RunDelegate();
        public delegate bool CanRunDelegate();
        public MiaoCommand(RunDelegate run,CanRunDelegate canRun)
        {
            _running = run;
            _canRun = canRun;
        }

        public MiaoCommand(RunDelegate run)
        {
            _running = run;
            _canRun = () => true;
        }

        private readonly RunDelegate _running;
        private readonly CanRunDelegate _canRun;

        public bool CanExecute(object parameter)
        {
            return _canRun();
        }

        public void Execute(object parameter)
        {
            _running();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
