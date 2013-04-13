
using System;
using System.Reflection;
namespace ChartLibrary.Utils
{
    public class Singleton<T> where T : class
    {
        private static T instance;
        private static object singletonLock = new object();

        public static T GetSingleton()
        {
            if (instance == null)
                lock (singletonLock)
                {
                    if (instance == null)
                    {
                        Type t = typeof(T);

                        // Confere se não tem construtores publicos...
                        ConstructorInfo[] ctors = t.GetConstructors();
                        if (ctors.Length > 0)
                            instance = (T)Activator.CreateInstance(t, true);

                    }
                }

            return instance;
        }
    }
}
