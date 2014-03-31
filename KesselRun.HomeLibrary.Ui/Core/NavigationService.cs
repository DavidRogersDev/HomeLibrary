using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public class NavigationService
    {
        private readonly Dictionary<Type, Type> _viewTypesCache;
        private Stack<MvpUserControl> _controlStatck = new Stack<MvpUserControl>();
        public Control NavigationRootControl { get; set; }

        public NavigationService()
        {
            _viewTypesCache = new Dictionary<Type, Type>();
        }

        private class NavigationServiceSingletonCreator
        {
            static NavigationServiceSingletonCreator()
            {

                
            }

            // Private object instantiated with private constructor
            internal static readonly NavigationService UniqueInstance = new NavigationService();
        }

        public static NavigationService SingleNavigationService
        {
            get
            {
                return NavigationServiceSingletonCreator.UniqueInstance;
            }
        }

        public void NavigateTo(Type view, Control containerControl)
        {
            var typeOfControl = GetViewTypeFromInterface(view);
            var constructors = typeOfControl.GetConstructors();
            var destinationView = constructors[0].Invoke(new object[] { });
            containerControl.Controls.Add((MvpUserControl)destinationView);
        }

        public Type GetViewTypeFromInterface(Type type)
        {
            Type viewType;

            if (_viewTypesCache.TryGetValue(type, out viewType))
            {
                return viewType;
            }

            var assembly = Assembly.GetExecutingAssembly();

            foreach (var exportedType in assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(Control))))
            {
                if (type.IsAssignableFrom(exportedType))
                {
                    viewType = exportedType;
                    break;
                }
            }
            
            _viewTypesCache.Add(type, viewType);

            return viewType;
        }
    }
}
