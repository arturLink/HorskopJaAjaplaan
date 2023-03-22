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
    public partial class Horoskop : ContentPage
    {
        DatePicker dtpicker;
        StackLayout st;
        Label hrlbl;
        Image img = new Image();
        public Horoskop()
        {
            st = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gray,
            };
            Content = st;

            dtpicker = new DatePicker()
            {
                Format = "dd-MM-yyyy",
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            dtpicker.DateSelected += Dtpicker_DateSelected;
            st.Children.Add(dtpicker);

            hrlbl = new Label()
            {
                Text = "Palun vali sinu sünnipäev ja vaata oma Tähtkuju märg!",
                FontSize = 20,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            st.Children.Add(hrlbl);

            img.Source = ImageSource.FromFile("QuestionMark.jpg");
            st.Children.Add(img);

            Button TagasiBtn = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.White,
                TextColor = Color.Black,
            };
            TagasiBtn.Clicked += TagasiBtn_Clicked;
            st.Children.Add(TagasiBtn);
        }

        private async void TagasiBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Dtpicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var kuu = e.NewDate.Month;
            var paev = e.NewDate.Day;
            //string[] margid = {"Kaljukits", "Veevalaja", "Kalad", "Jäär", "Sõnn", "Kaksikud",
            //                "Vähk", "Lõvi", "Neitsi", "Kaalud", "Skorpion", "Ambur"};
            string[] pildid = { "kaljukits.PNG", "veevalaja.PNG", "kalad.PNG", "jaar.PNG", "sonn.PNG", "kaksikud.PNG", "vahk.PNG", "lovi.PNG", "neitsi.PNG",
                                "kaalud.PNG", "skorpion.PNG", "ambur.PNG" };
            string[] kirjeldus = {
                "Kaljukits on zodiaki kümnendas tähemärgis ja seda sümboliseerib mägiveis. Selle märgi all sündinud inimesed on tuntud oma ambitsioonikuse, distsipliini ja praktilisuse poolest.",
                "Veevalaja on zodiaki üheteistkümnes tähemärk ja seda sümboliseerib veekandja. Selle märgi all sündinud inimesed on tuntud oma iseseisvuse, eksentrilisuse ja humanitaarteaduste poolest.",
                "Kalad on zodiaki kaheteistkümnes tähemärk ja seda sümboliseerib kala. Selle märgi all sündinud inimesed on tuntud oma loovuse, empaatiavõime ja intuitsiooni poolest.",
                "Jäär on zodiaki esimene tähemärk ja seda sümboliseerib tallekas. Selle märgi all sündinud inimesed on tuntud oma julguse, spontaansuse ja enesekindluse poolest.",
                "Sõnn on zodiaki teine tähemärk ja seda sümboliseerib pull. Selle märgi all sündinud inimesed on tuntud oma kindlameelsuse, püsivuse ja praktilisuse poolest.",
                "Kaksikud on zodiaki kolmas tähemärk ja seda sümboliseerivad kaksikud. Selle märgi all sündinud inimesed on tuntud oma vaimukuse, kohanemisvõime ja suhtlemisoskuse poolest.",
                "Vähk on zodiaki neljas tähemärk ja seda sümboliseerib vähk. Selle märgi all sündinud inimesed on tuntud oma tundlikkuse, hoolivuse ja pereväärtuste poolest.",
                "Lõvi on zodiaki viies tähemärk ja seda sümboliseerib lõvi. Selle märgi all sündinud inimesed on tuntud oma enesekindluse, loovuse ja helduse poolest.",
                "Neitsi on zodiaki kuues tähemärk ja seda sümboliseerib neitsi. Selle märgi all sündinud inimesed on tuntud oma täpsuse, korralikkuse ja analüüsivõime poolest.",
                "Kaalud on zodiaki seitsmes tähemärk ja seda sümboliseerivad kaalud. Selle märgi all sündinud inimesed on tuntud oma rahulikkuse, diplomaatia ja koostöövõime poolest.",
                "Skorpion on zodiaki kaheksas tähemärk ja seda sümboliseerib skorpion. Selle märgi all sündinud inimesed on tuntud oma intensiivsuse, kirglikkuse ja sügava tundlikkuse poolest.",
                "Ambur on zodiaki üheksas tähemärk ja seda sümboliseerib ambur. Selle märgi all sündinud inimesed on tuntud oma avatuse, optimistlikkuse ja seiklushimu poolest."};
            int[] loige = { 20, 19, 20, 20, 21, 21, 22, 23, 23, 23, 22, 21 };
            int index = (paev <= loige[kuu - 1]) ? kuu - 1 : (kuu + 10) % 12;

            img.Source = ImageSource.FromFile(pildid[index]);
            hrlbl.Text = kirjeldus[index];
        }
    }
}