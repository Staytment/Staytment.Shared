using Windows.Devices.Geolocation;

namespace Staytment.Shared.Demo.ViewModels
{
    internal class PostDataModel : ViewModel
    {
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
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