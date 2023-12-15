using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JGPFGit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Szczegoly : ContentPage
    {
        public Szczegoly(DateTime data)
        {
            InitializeComponent();

            decimal WydatkiDnia = 0;
            List<Wydatek> tmp = new List<Wydatek>();
            for(int i = 0; i < App.Database.WszystkieWydatki().Result.Count; i++)
            {
                if (App.Database.WszystkieWydatki().Result[i].Data == data)
                {
                    tmp.Add(App.Database.WszystkieWydatki().Result[i]);
                    WydatkiDnia += App.Database.WszystkieWydatki().Result[i].Kwota;
                }
            }
            WydatkiDniaTxt.Text = data.ToString("yyyy-MM-dd") + " Łacznie wydano " + WydatkiDnia.ToString() + " zł";
            Lista.ItemsSource = tmp;

        }
    }
}