using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        async void OnAddedButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            book.Lent = false;
            await App.Database.AddBookInfoAsync(book);
            int MaxBookID = await App.Database.GetMaxBookID();
            await DisplayAlert("添加成功", string.Format("图书ID是 {0}", MaxBookID), "OK");
            await Navigation.PopAsync();
        }
    }
}
