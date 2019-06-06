using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultPlatProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAuthorPage : ContentPage
    {
        public NewAuthorPage()
        {
            InitializeComponent();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Handle_RequestFailed(object sender, ErrorResponse e)
        {
            DisplayAlert("Erro", e.Message, "ok");
        }

        private void NewAuthorViewModel_AuthorAdded(object sender, EventArgs e)
        {
            ToolbarItem_Clicked(sender, e);
        }
    }
}