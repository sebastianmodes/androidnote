using System;
using Xamarin.Forms;

namespace Note
{
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }

        async void OnNoteSave(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnNoteDelete(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeletNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnCancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}