using SQLiteDemo.MVVM.Views;

namespace SQLiteDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ItemPage();
        }
    }
}
