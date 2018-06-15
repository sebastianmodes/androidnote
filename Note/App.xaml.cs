using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Note
{
    public partial class App : Application
    {
        static NoteDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();

            MainPage = new NavigationPage(new StartPage());
        }

        public int ResumeToNoteId { get; set; }

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("NoteSQLite.db3"));
                }
                return database;
            }
        }

    }
}
