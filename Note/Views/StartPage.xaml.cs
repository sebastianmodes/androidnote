using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Note
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeToNoteId = -1;
            notesList.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage
            {
                BindingContext = new Note()
            });
        }

        async void OnNoteSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NotePage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}