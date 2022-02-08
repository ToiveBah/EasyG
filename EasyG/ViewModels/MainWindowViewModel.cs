using EasyG.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyG.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        private string _Title = "EasyG";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
           get => _Title;
           // set 
           // {
              //  if(Equals(_Title, value)) return;
              //  _Title = value;
              //  OnPropertyChanged();
            // }
            set => Set(ref _Title, value);
        }
        #endregion
    }
}
