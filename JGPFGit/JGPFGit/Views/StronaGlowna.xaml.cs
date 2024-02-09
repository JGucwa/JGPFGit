using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JGPFGit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StronaGlowna : TabbedPage
    {
        public StronaGlowna()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            wyswietl();
        }
        private void wyswietl()
        {
            List<Wydatek> tmp = new List<Wydatek>();
            for (int i = 0; i < App.Database.WszystkieWydatki().Result.Count; i++)
            {
                bool istnieje = false;
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (App.Database.WszystkieWydatki().Result[i].Data == tmp[j].Data)
                    {
                        istnieje = true;
                    }
                }
                if (!istnieje)
                {
                    tmp.Add(App.Database.WszystkieWydatki().Result[i]);
                }
            }
            Lista.ItemsSource = tmp;
        }
        public async void DodajWydatek(object sender, EventArgs e)
        {
            if(KwotaTxt.Text.Length > 0)
            {
                if (string.IsNullOrWhiteSpace(NazwaTxt.Text))
                {
                    await App.Database.DodajWydatek(new Wydatek() { Data = DataTxt.Date, Nazwa = "Brak tytułu", Kwota = decimal.Parse(KwotaTxt.Text) });
                }
                else
                {
                    await App.Database.DodajWydatek(new Wydatek() { Data = DataTxt.Date, Nazwa = NazwaTxt.Text, Kwota = decimal.Parse(KwotaTxt.Text) });
                }
                NazwaTxt.Text = KwotaTxt.Text = String.Empty;

                wyswietl();
            }
        }
        public async void Sczegoly(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Szczegoly((Lista.SelectedItem as Wydatek).Data));
        }
    }
}