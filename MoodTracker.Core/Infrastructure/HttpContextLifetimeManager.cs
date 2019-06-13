using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoodTracker.Core.Infrastructure
{
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current.Items.Contains(typeof(T).AssemblyQualifiedName))
                HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
            else
                HttpContext.Current.Items.Add(typeof(T).AssemblyQualifiedName, newValue);
        }

        public override void RemoveValue()
        {
            var value = GetValue();
            IDisposable disposableValue = value as IDisposable;

            if (disposableValue != null)
            {
                disposableValue.Dispose();
            }
            HttpContext.Current.Items.Remove(value);
        }

        public void Dispose()
        {
            RemoveValue();
        }
    }
}
