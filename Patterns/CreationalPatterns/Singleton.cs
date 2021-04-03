// Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует,
// что для определенного класса будет создан только один объект,
// а также предоставит к этому объекту точку доступа.
// Синглтон позволяет создать объект только при его необходимости.
// Если объект не нужен, то он не будет создан. В этом отличие синглтона от глобальных переменных.

using System;

namespace Patterns
{
    /// <summary>
    /// Thread unsafe implementation
    /// </summary>
    public class Singleton
    {
        private static Singleton instance;
        public string Name { get; private set; }
        protected Singleton(string name) 
        {
            Name = name;
        }

        public static Singleton GetSingleton(string name)
        {
            if (instance == null)
                instance = new Singleton(name);
            return instance;
        }
    }

    #region Singleton Example
    public class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.GetOS(osName);
        }
    }

    public class OS
    {
        private static OS instance;
        public string Name { get; private set; }
        private static object locker = new object();

        private OS(string name)
        {
            Name = name;
        }
        public static OS GetOS(string name)
        {
            if(instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }
    #endregion

    /// <summary>
    /// Thread Safe Implementation of the Singleton with lock
    /// </summary>
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe instance;
        private static object locker = new object();
        public string Name { get; private set; }
        private SingletonThreadSafe(string name)
        {
            Name = name;
        }

        public SingletonThreadSafe GetSingleton(string name)
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new SingletonThreadSafe(name);
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Thread Safe Singleton Without using Lock
    /// </summary>
    public class ThreadSafeSingletonWithoutLock
    {
        private static ThreadSafeSingletonWithoutLock instance = new ThreadSafeSingletonWithoutLock();
        public string Date { get; set; }
        private ThreadSafeSingletonWithoutLock() => Date = DateTime.Now.TimeOfDay.ToString();
        public static ThreadSafeSingletonWithoutLock GetSingleton() => instance;
    }

    /// <summary>
    /// This implementation of the class is convenient when there are static data fields 
    /// that the calling code refers to. In this case, the creation of an instance of the class 
    /// is not required.
    /// </summary>
    public class SingletonWithLazyLoading
    {
        public static double PI = 3.14; // To this field the calling code refers to 
        public string Name { get; set; }
        private SingletonWithLazyLoading()
        {
            Console.WriteLine($"Creation time: {DateTime.Now.TimeOfDay.ToString()}");
        }

        public static SingletonWithLazyLoading GetSingleton(string name)
        {
            Console.WriteLine($"Get time: {DateTime.Now.TimeOfDay.ToString()}");
            Nested.instance.Name = name;
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() {}
            internal static readonly SingletonWithLazyLoading instance = new SingletonWithLazyLoading();
        }

    }
}
