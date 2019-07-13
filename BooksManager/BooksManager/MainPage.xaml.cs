using System;
using System.IO;
using Xamarin.Forms;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            // NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // (sender as Button).Text = "登录中...";
            var user = (UserInfo)BindingContext;
            user.ID = int.Parse(user.strID);
            bool LoginState = App.Database.TryLogin(user.ID, user.Password);
            if (LoginState == true)
            {
                App.CurrentUser = await App.Database.GetUserInfoAsync(user.ID);
                await DisplayAlert("登录成功", "您太强了！", "OK");
                await Navigation.PushAsync(new ViewBooksPage());
            }
            else
            {
                await DisplayAlert("登录失败", "请检查用户ID和密码", "OK");
            }
            
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage
            {
                BindingContext = new UserInfo()
            });
        }
    }
}