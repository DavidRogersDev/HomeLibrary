using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public class Utilities
    {
        private readonly Dictionary<Type, Type> _viewTypesCache;

        public Utilities(Dictionary<Type, Type> viewTypesCache)
        {
            _viewTypesCache = viewTypesCache;
        }

        public Type GetViewTypeFromInterface(Type type)
        {
            Type viewType;

            if (_viewTypesCache.TryGetValue(type, out viewType))
            {
                return viewType;
            }

            var assembly = Assembly.GetExecutingAssembly();

            foreach (var exportedType in assembly.GetExportedTypes())
            {
                if (exportedType.IsAssignableFrom(exportedType))
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
