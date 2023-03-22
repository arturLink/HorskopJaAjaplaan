using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HorskopJaAjaplaan
{
    public partial class MainPage : ContentPage
    {
        List<ContentPage> cntPages = new List<ContentPage>() { new Horoskop(), new Ajaplaan(), new MinuOma() };
        List<string> tekstid = new List<string> { "Horoskoop", "Aiaplaan", "Minu Oma" };
        public MainPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gray,
            };
            for (int i = 0; i < cntPages.Count; i++)
            {
                Button btn = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.White,
                    TextColor = Color.Black,
                };
                btn.Clicked += NavigFunkt;
                st.Children.Add(btn);
            }
            Content = st;
        }

        private async void NavigFunkt(object sender, EventArgs e)
        {
            Button bSender = (Button)sender;
            await Navigation.PushAsync(cntPages[bSender.TabIndex]);
        }
    }
}
