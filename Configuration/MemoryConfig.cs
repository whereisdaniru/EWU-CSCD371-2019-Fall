using System;
using System.Collections.Generic;

namespace Configuration
{
    public class MemoryConfig
    {
        Dictionary<string, object?> InternalCollection { get; } =
            new Dictionary<string, object?>();

        Dictionary<Type, System.Collections.IDictionary> InternalValueTypeCollection =
            new Dictionary<Type, System.Collections.IDictionary>();

        public void SetValue<TValue>(string name, TValue value)
        {
            if(typeof(TValue).IsValueType)
            {
                System.Collections.IDictionary collection;
                if (InternalValueTypeCollection.TryGetValue(typeof(TValue), 
                    out collection))
                {
                    ((IDictionary<string, TValue>)collection)[name] = value;
                }
                else
                {
                    collection = new Dictionary<string, TValue>();
                    collection.Add(name, value);
                    InternalValueTypeCollection.Add(typeof(TValue), collection);
                }
            }
            else
            {
                InternalCollection[name] = value;
            }
        }

        public TValue GetValue<TValue>(string name)
        {
            if (typeof(TValue).IsValueType)
            {
                return ((IDictionary<string, TValue>)InternalValueTypeCollection[typeof(TValue)])[name];
            }
            else
            {
                // Discuss use of null forgive operator.
                return (TValue)InternalCollection[name]!;
            }
        }
    }
}