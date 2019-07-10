using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class RecordsViewPage : ContentPage
    {
        public RecordsViewPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetRecordsInfoAsync(App.CurrentUser.ID, false);
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailedRecordPage
                {
                    BindingContext = e.SelectedItem as RecordInfo
                });
            }
        }

        async void OnDisplayUnreturnButtonClicked(object sender, EventArgs e)
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetRecordsInfoAsync(App.CurrentUser.ID, true);
        }

        async void OnDisplayAllButtonClicked(object sender, EventArgs e)
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetRecordsInfoAsync(App.CurrentUser.ID, false);
        }
    }
}
