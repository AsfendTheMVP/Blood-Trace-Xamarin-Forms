using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodTrace.Models;
using BloodTrace.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodTrace.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonarsListPage : ContentPage
    {
        public ObservableCollection<BloodUser> BloodUsers;
        private string _bloodGroup;
        private string _country;
        public DonarsListPage(string country, string bloodType)
        {
            InitializeComponent();
            BloodUsers = new ObservableCollection<BloodUser>();
            _bloodGroup = bloodType;
            _country = country;
            FindBloodDonars();
        }

        private async void FindBloodDonars()
        {
            ApiServices apiServices = new ApiServices();
            var bloodUsers = await apiServices.FindBlood(_country, _bloodGroup);
            foreach (var bloodUser in bloodUsers)
            {
                BloodUsers.Add(bloodUser);
            }

            LvBloodDonars.ItemsSource = BloodUsers;
        }

        private void LvBloodDonars_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedDonar = e.SelectedItem as BloodUser;
            if (selectedDonar != null)
            {
                Navigation.PushAsync(new DonarProfilePage(selectedDonar));

            }

            ((ListView)sender).SelectedItem = null;

        }
    }
}