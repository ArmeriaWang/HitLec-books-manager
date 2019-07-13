using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class DetailedRecordPage : ContentPage
    {
        public DetailedRecordPage()
        {
            InitializeComponent();
        }

        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            var record = (RecordInfo)BindingContext;
            if (record.Returned == true)
            {
                await DisplayAlert("提示", "此书已归还", "OK");
            }
            else
            {
                await App.Database.ReturnBookAsync(record);
                await DisplayAlert("提示", "归还成功", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
