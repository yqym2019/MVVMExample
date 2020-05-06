using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace MVVMExample1.Commands
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// 无返回值 委托
        /// </summary>
        public Action<object> ExecuteAction { get; set; }

        /// <summary>
        /// 有返回值 委托 最后一个类型就是返回值类型
        /// </summary>
        public Func<object,bool> CanExecuteFunc { get; set; }

        /// <summary>
        /// 检测是否可执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if(this.CanExecuteFunc==null)           
                return true;           

            return this.CanExecuteFunc(parameter);
        }

        /// <summary>
        /// 当可执行时 执行的内容
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if(this.ExecuteAction == null)
                return;

            this.ExecuteAction(parameter);
        }
    }
}
