using CarListApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsViewModel : ViewModelBase, IQueryAttributable
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private Car _car;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(query[nameof(Id)]);
            Car = App.CarService.GetById(Id);
        }
    }
}
