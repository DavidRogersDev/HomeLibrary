using System.ComponentModel;
using System.Runtime.CompilerServices;
using KesselRun.HomeLibrary.UiModel.Annotations;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class LendingGridItem : Lending, INotifyPropertyChanged
    {
        public string Authors { get; set; }
        public string Borrower { get; set; }
        public string Email { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
