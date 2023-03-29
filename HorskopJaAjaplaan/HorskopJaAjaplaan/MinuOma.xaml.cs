using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorskopJaAjaplaan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinuOma : ContentPage
    {
        List<Label> mrglblid = new List<Label>();
        Button lisa;
        Entry mrg;
        StackLayout st;
        DatePicker dtpicker;
        Xamarin.Forms.TimePicker TimeP;
        Label title, mrgud;
        public MinuOma()
        {
            st = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gray,
            };
            Content = st;
            title = new Label()
            {
                Text = "Märkmeid",
                FontSize = 32,
                TextColor = Color.Black,
                BackgroundColor= Color.DarkGray,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            st.Children.Add(title);
            dtpicker = new DatePicker()
            {
                Format = "dd-MM-yyyy",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.Black
            };
            st.Children.Add(dtpicker);
            TimeP = new Xamarin.Forms.TimePicker()
            {
                Time = new TimeSpan(0),
                BackgroundColor = Color.DarkGray,
                TextColor = Color.Black,
            };
            st.Children.Add(TimeP);
            mrg = new Entry
            {
                BackgroundColor = Color.DarkGray,
                Text = "Sinu märge",
            };
            st.Children.Add(mrg);
            lisa = new Button()
            {
                BackgroundColor = Color.DarkGray,
                TextColor = Color.Black,
                Text = "Lisa märge",
            };
            st.Children.Add(lisa);
            lisa.Clicked += Lisa_Clicked;
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            mrgud = new Label()
            {
                Text = dtpicker.Date.ToString("dd-MM-yyyy") + " kell " + TimeP.Time.ToString() + " " + mrg.Text,
                TextColor= Color.Black,
                BackgroundColor= Color.DarkGray,
            };
            st.Children.Add(mrg);
        }
    }
}