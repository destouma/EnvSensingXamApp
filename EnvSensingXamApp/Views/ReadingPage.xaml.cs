using System;
using System.Collections.Generic;
using EnvSensingXamApp.ViewModels;
using Xamarin.Forms;

namespace EnvSensingXamApp.Views
{
    public partial class ReadingPage : ContentPage
    {
        ReadingViewModel viewModel;

        public ReadingPage(object sensor)
        {
            InitializeComponent();

            BindingContext = viewModel = new ReadingViewModel();

            viewModel.LoadItemsCommand.Execute(sensor);

        }
    }
}
