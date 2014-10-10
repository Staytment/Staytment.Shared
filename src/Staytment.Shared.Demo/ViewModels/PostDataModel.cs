using Windows.Devices.Geolocation;

namespace Staytment.Shared.Demo.ViewModels
{
    internal class PostDataModel : ViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        private Geopoint _location;
        public Geopoint Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}