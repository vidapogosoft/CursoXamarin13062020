using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Menu_Tab_Maps.Model;

namespace Menu_Tab_Maps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public List<Tiendas> Alltiendas;
        public Home()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Alltiendas = new List<Tiendas>()
            {
                new Tiendas
                {
                    Name = "Wallmart",
                    ImageUrl = "http://18.218.178.167/imagesemail/walmart.jpg"
                },

                new Tiendas
                {
                    Name = "Target",
                    ImageUrl = "http://18.218.178.167/imagesemail/target.jpg"
                },

                new Tiendas
                {
                    Name = "Ferreteri",
                    ImageUrl = "http://18.218.178.167/imagesemail/ferre1.jpg"
                }
            };

            this.CLTiendas.ItemsSource = Alltiendas;

        }

        private void CLTiendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                CLTiendas.SelectedItem = null;

                DisplayAlert("Colletion view", "Selecion", "Cerrar");

            }
        }
    }
}