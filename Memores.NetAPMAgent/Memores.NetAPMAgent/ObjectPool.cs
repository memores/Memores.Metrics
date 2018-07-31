using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;


namespace Memores.NetAPMAgent {
    /// <summary>
    /// Object pool can improve application performance in situations where you require multiple instances of a class and the class is expensive to create or destroy
    /// </summary>
    /// <see>
    ///     <cref>https://docs.microsoft.com/ru-ru/dotnet/standard/collections/thread-safe/how-to-create-an-object-pool</cref>
    /// </see>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> {
        ConcurrentBag<T> _objects;
        Func<T> _objectGenerator;


        public ObjectPool(Func<T> objectGenerator) {
            _objects = new ConcurrentBag<T>();
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        }


        public T GetObject() {
            T item;
            if (_objects.TryTake(out item))
                return item;
            return _objectGenerator();
        }


        public void PutObject(T item) {
            _objects.Add(item);
        }
    }
}
