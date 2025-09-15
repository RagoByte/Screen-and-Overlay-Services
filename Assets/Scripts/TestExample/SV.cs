using System;
using System.Collections.Generic;

namespace TestExample
{
    public static class SV
    {
        private static readonly Dictionary<string, object> Services = new();
        public static bool IsRegistered<T>() => Services.ContainsKey(typeof(T).Name);

        public static T Get<T>()
        {
            var key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                throw new Exception($"[ServiceError] {key} not registered");
            }

            return (T)Services[key];
        }

        public static void Register<T>(T service)
        {
            var key = typeof(T).Name;
            if (Services.ContainsKey(key))
            {
                throw new Exception($"Attempted to register service of type {key} which is already registered");
            }

            Services.Add(key, service);
        }

        public static void Unregister<T>(T service)
        {
            var key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                throw new Exception($"Attempted to UNregister service of type {key} which is not contains");
            }

            Services.Remove(key);
        }
    }
}