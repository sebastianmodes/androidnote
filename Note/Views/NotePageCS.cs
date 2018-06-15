using Xamarin.Forms;

namespace Note
{
    public class NotePageCS : ContentPage
    {
        public NotePageCS()
        {
            Title = "Note";

            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "Title");

            var contentEntry = new Entry();
            contentEntry.SetBinding(Entry.TextProperty, "Content");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var note = (Note)BindingContext;
                await App.Database.SaveNoteAsync(note);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var note = (Note)BindingContext;
                await App.Database.DeletNoteAsync(note);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };


            Content = new StackLayout
            {
                Margin = new Thickness(15),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Note" },
                    titleEntry,
                    contentEntry,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}