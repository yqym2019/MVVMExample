using Microsoft.Win32;
using MVVMExample1.Commands;
using System;

namespace MVVMExample1
{
    class MainWindowViewModel:NotificationObject
    {
        #region 绑定属性

        private double input1;
		public double Input1
		{
			get { return input1; }
			set { input1 = value; this.RaisePropertyChanged("Input1"); }
		}

		private double input2;
		public double Input2
		{
			get { return input2; }
			set { input2 = value; this.RaisePropertyChanged("Input2"); }
		}

		private double result;
		public double Result
		{
			get { return result; }
			set { result = value; this.RaisePropertyChanged("Result"); }
		}

        #endregion

        #region 绑定方法
		public DelegateCommand AddCommand { get; set; }
		public DelegateCommand SaveCommand { get; set; }
		private void Add(object parameter)
		{
			this.Result = this.Input1 + this.Input2;
		}

		private void Save(object parameter)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.ShowDialog();
		}
        #endregion

        #region 构造方法
        public MainWindowViewModel()
		{
			//关联方法
			this.AddCommand = new DelegateCommand();
			this.AddCommand.ExecuteAction = new Action<object>(this.Add);
			this.SaveCommand = new DelegateCommand();
			this.SaveCommand.ExecuteAction = new Action<object>(this.Save);
		}

        #endregion
    }
}
