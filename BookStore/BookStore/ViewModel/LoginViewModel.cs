﻿using BookStore.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStore.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public bool IsLogin { get; set; }
        public TextBlock ErrorLogin { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PassWordChangedCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand UserNameChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { doLogin(p); });
            PassWordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; ErrorLogin.Visibility = Visibility.Hidden; });
            LoadedCommand = new RelayCommand<TextBlock>((p) => { return true; }, (p) => { ErrorLogin = (TextBlock)p; });
            UserNameChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { ErrorLogin.Visibility = Visibility.Hidden; });
        }

        private void doLogin(Window p)
        {
            var count = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == UserName && x.MatKhau == Password).Count();
            if (count > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                ErrorLogin.Visibility = Visibility.Visible;
                IsLogin = false;
            }

        }
    }
}
