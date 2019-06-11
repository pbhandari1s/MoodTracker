using MoodTracker.Core.Initialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Helper
{
    public class TypeLoader
    {
        public static IEnumerable<Type> GetTypes(Type type)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            return types;
        }

        public static void InitializeConfiguration<T, TU>(object value)
        {
            try
            {
                var unityContainer = GetTypes(typeof(T));
                foreach (var type in unityContainer)
                {
                    var container = Activator.CreateInstance(type) as IConfigRegistration<TU>;

                    container?.Register((TU)value);
                }
            }
            catch
            {
                return;
            }
        }
    }
}
