using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class DetailedBookPage : ContentPage
    {
        public DetailedBookPage()
        {
            InitializeComponent();
        }

        async void OnBorrowButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            if (book.Lent == true)
            {
                await DisplayAlert("提示", "本书已被借出，无法借阅", "OK");
            }
            else
            {
                book.Lent = true;
                await App.Database.BorrowBookAsync(book);
                await DisplayAlert("提示", "借阅成功", "OK");
                await Navigation.PopAsync();
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            await App.Database.SaveBookInfoAsync(book);
            await DisplayAlert("提示", "修改成功", "OK");
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            if (book.Lent == true)
            {
                await DisplayAlert("提示", "本书正被借出，无法删除", "OK");
            }
            else
            {
                await App.Database.DeleteBookInfoAsync(book);
                await DisplayAlert("提示", "删除成功", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
