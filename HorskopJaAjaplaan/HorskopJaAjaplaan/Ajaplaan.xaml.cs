using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace HorskopJaAjaplaan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ajaplaan : ContentPage
    {
        StackLayout st;
        Xamarin.Forms.TimePicker TimeP;
        Label timelbl;
        public Ajaplaan()
        {
            st = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gray,
            };
            Content = st;
            TimeP = new Xamarin.Forms.TimePicker()
            {
                Time = new TimeSpan(0),
                TextColor= Color.Black,
            };
            TimeP.PropertyChanged += TimeP_PropertyChanged;
            st.Children.Add(TimeP);
            timelbl = new Label()
            {
                Text = "",
                FontSize= 20,
                BackgroundColor= Color.White,
                TextColor= Color.Black,

            };
            st.Children.Add(timelbl);

        }

        private void TimeP_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                string[] messages = { "00:00 - Minna magama", "01:00 - Minna magama", "02:00 - Minna magama", "03:00 - Minna magama", "04:00 - Varahommik", "05:00 - Varahommik", "06:00 - Varahommik", "07:00 - Hommikul", "08:00 - Hommikul", "09:00 - Hommikul", "10:00 - Hommikul", "11:00 - Hommikul", "12:00 - Hommikul",
                    "13:00 - Päevane aeg", "14:00 - Päevane aeg", "15:00 - Päevane aeg", "16:00 - Päevane aeg", "17:00 - Päevane aeg", "18:00 - Varajane õhtu", "19:00 - Varajane õhtu", "20:00 - Õhtul", "21:00 - Õhtul", "22:00 - Hilisõhtul", "23:00 - Hilisõhtul" };
                timelbl.Text = messages[TimeP.Time.Hours % 12];
            }
        }
    }
}