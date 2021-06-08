﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookStore.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand InvoiceClick { get; set; }
        public MainViewModel()
        {
            InvoiceClick = new RelayCommand<object>((p) => { return true; }, (p) => {
                InvoiceWindow test = new InvoiceWindow();
                test.ShowDialog();
            });
        }


    }
}
