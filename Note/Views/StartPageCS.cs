using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Note
{
    public class StartPageCS : ContentPage
    {
        ListView notesList;

        public StartPageCS()
        {
            Title = "Notes";

            var toolbarItem = new ToolbarItem
            {
                Text = "Add note",
                Icon = "plus_black.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new NotePageCS
                {
                    BindingContext = new Note()
                });
            };
            ToolbarItems.Add(toolbarItem);

            notesList = new ListView
            {
                Margin = new Thickness(15),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Title");
                
                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(15, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            notesList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new NotePageCS
                    {
                        BindingContext = e.SelectedItem as Note
                    });
                }
            };

            Content = notesList;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // reset the current note 
            ((App)App.Current).ResumeToNoteId = -1;
            notesList.ItemsSource = await App.Database.GetNotesAsync();
        }
    }
}