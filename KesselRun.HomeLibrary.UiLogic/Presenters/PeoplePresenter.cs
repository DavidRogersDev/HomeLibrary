using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.Service;
using KesselRun.HomeLibrary.UiLogic.Enums;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class PeoplePresenter : Presenter<IPersonView>, IDisposable
    {
        private readonly IHomeLibraryService _homeLibraryService;
        private bool disposed = false;

        public PeoplePresenter(IPersonView view, IHomeLibraryService homeLibraryService)
            : base(view)
        {
            View.ViewClosing += view_ViewClosing;
            View.Load += View_Load;
            _homeLibraryService = homeLibraryService;
        }

        void View_Load(object sender, EventArgs e)
        {
            var people = _homeLibraryService.GetAllPeople();

            var vm = new PersonViewModel
            {
                People = people,
                SearchFilter = FilterType.ByLastName
            };
            

            View.ViewModel = vm;
        }

        private void view_ViewClosing(object sender, System.EventArgs e)
        {
            View.ReleasePresenter(this);
        }


        public void Dispose()
        {
            CleanUp(true);
            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ((IDisposable)_homeLibraryService).Dispose();
                }
            }
            disposed = true;
        }

    }
}
