using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BooksManager.Models;

namespace BooksManager
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = (UserInfo)BindingContext;
            await App.Database.CreateNewUser(user);
            int MaxUserID = await App.Database.GetMaxUserID();
            await DisplayAlert("注册成功", string.Format("你的用户ID是 {0}", MaxUserID), "OK");
            await Navigation.PopAsync();
        }

    }

}
 