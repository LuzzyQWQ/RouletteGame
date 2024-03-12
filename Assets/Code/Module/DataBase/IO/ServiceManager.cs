using Argali.Module.Singleton;
using System;
using System.Collections.Generic;

namespace Argali.Module.DataBase.IO
{
	/// <summary>
	/// Service用于保存各种数据
	/// </summary>
    public class ServiceManager: Singleton<ServiceManager>
    {
        private static readonly List<ServiceBase> ServiceList = new();

        public static T GetService<T>() where T: ServiceBase
        {
            ServiceBase service = null;
            foreach (ServiceBase s in ServiceList)
            {
                if (s is T)
                {
                    service = s;
                }
            }

            if (service == null)
            {
                var newService = (T) Activator.CreateInstance(typeof(T));
                ServiceList.Add(newService);
                return newService;
            }
            else
            {
                return (T)service;
            }
        }

        public static void Sync()
        {
            foreach (ServiceBase service in ServiceList)
            {
                service.Sync();
            }
        }
    }
}

