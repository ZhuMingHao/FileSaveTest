﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
namespace TestApp
{
    public class ViewModel
    {
        private readonly  IFileSaver _fileSaver;
        public ViewModel(IFileSaver fileSaver)
        {
            _fileSaver = fileSaver;
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand {
            get
            {if (_clickCommand == null)
                {
                    _clickCommand = new Command(ExcuteClickCommand);
                }
                return _clickCommand;
            }
           
        }
        private async void ExcuteClickCommand()
        {var cancellationToken = new CancellationToken();
            using var stream = new MemoryStream(Encoding.Default.GetBytes("Hello from the Community Toolkit!"));
            var fileSaverResult = await _fileSaver.SaveAsync("test.txt", stream, cancellationToken);
            fileSaverResult.EnsureSuccess();
            await Toast.Make($"File is saved: {fileSaverResult.FilePath}").Show(cancellationToken);
           await App.Current.MainPage.DisplayAlert("hello","ok", "canviewmodelcel");
        }

    }
}