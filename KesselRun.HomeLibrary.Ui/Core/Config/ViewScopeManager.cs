using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class ViewScopeManager
    {
        public static void ManageScope()
        {
            if (PresenterBinder.ApplicationState.HasItem("DatabaseContextScope"))
            {
                PresenterBinder.ApplicationState.RemoveItem<DatabaseContextScope>("DatabaseContextScope");
            }
            PresenterBinder.ApplicationState.AddItem("DatabaseContextScope", new DatabaseContextScope());
        }
    }
}
