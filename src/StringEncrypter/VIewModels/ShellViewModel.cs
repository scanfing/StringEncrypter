using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using StringEncrypter.Controls;
using StringEncrypter.Encrypters;
using StringEncrypter.Services;

namespace StringEncrypter.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Fields

        private EncrypterService _encyptService;
        private IEncrypter _selectedEncrypter;
        private string _title = "字符串加密工具";

        private string _txtDst;
        private string _txtSrc = "hello";

        #endregion Fields

        #region Constructors

        public ShellViewModel()
        {
            Encrypters = new ObservableCollection<IEncrypter>();

            _encyptService = new EncrypterService();

            CommandEncode = new DelegateCommand(OnEncode, CanEncode);
            CommandDecode = new DelegateCommand(OnDecode, CanDecode);
        }

        #endregion Constructors

        #region Properties

        public DelegateCommand CommandDecode { get; private set; }

        public ICommand CommandEncode { get; private set; }

        public ObservableCollection<IEncrypter> Encrypters { get; private set; }

        public IEncrypter SelectedEncrypter
        {
            get => _selectedEncrypter;

            set
            {
                if (SetProperty(ref _selectedEncrypter, value))
                    CommandDecode?.RaiseCanExecuteChanged();
            }
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string TxtInput
        {
            get => _txtSrc;
            set => SetProperty(ref _txtSrc, value);
        }

        public string TxtOutput
        {
            get => _txtDst;
            set => SetProperty(ref _txtDst, value);
        }

        #endregion Properties

        #region Methods

        public async void OnViewLoaded()
        {
            var workDir = Path.GetDirectoryName(GetType().Assembly.Location);
            var encrypters = await _encyptService.LoadEncrypterFromDir(workDir);
            foreach (var en in encrypters)
                Encrypters.Add(en);
        }

        private bool CanDecode()
        {
            return SelectedEncrypter?.CanDecrypt ?? false;
        }

        private bool CanEncode()
        {
            return true;
        }

        private void OnDecode()
        {
            var encrypter = SelectedEncrypter;

            if (!encrypter.CanDecrypt)
                return;

            try
            {
                TxtOutput = encrypter.Decrypt(TxtInput);
            }
            catch (Exception ex)
            {
                TxtOutput = ex.Message;
            }
        }

        private void OnEncode()
        {
            var encrypter = SelectedEncrypter;
            if (encrypter is null)
                return;
            try
            {
                TxtOutput = encrypter.Encrypt(TxtInput);
            }
            catch (Exception ex)
            {
                TxtOutput = ex.Message;
            }
        }

        #endregion Methods
    }
}