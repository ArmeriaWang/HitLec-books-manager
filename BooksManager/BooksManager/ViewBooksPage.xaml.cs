using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class ViewBooksPage : ContentPage
    {
        public ViewBooksPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetBooksInfoAsync();
        }

        async void OnKeywordChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = e.NewTextValue;

            base.OnAppearing();

            listView.ItemsSource = await App.Database.SearchBookInfoAsync(keyword);
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailedBookPage
                {
                    BindingContext = e.SelectedItem as BookInfo
                });
            }
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage
            {
                BindingContext = new BookInfo()
            });
        }

        async void OnViewRecordsButtonClicked(object sender, EventArgs e)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
            await Navigation.PushAsync(new RecordsViewPage());
        }
    }
}
