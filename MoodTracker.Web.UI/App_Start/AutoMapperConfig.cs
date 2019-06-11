using AutoMapper;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodTracker.Web.UI.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            IEnumerable<Type> autoMapperProfileTypes = AllClasses.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                        .Where(type => type != typeof(Profile) && typeof(Profile).IsAssignableFrom(type));

            var config = new MapperConfiguration(cfg => {
                foreach (var item in autoMapperProfileTypes)

                    cfg.AddMaps(item);
            });

            return config;
        }
    }
}