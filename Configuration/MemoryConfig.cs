using System;
using System.Collections.Generic;

namespace Configuration
{
    public class MemoryConfig
    {
        Dictionary<string, object?> InternalCollection { get; } =
            new Dictionary<string, object?>();

        Dictionary<Type, System.Collections.IDictionary> InternalValueTypeCollection { get; } =
            new Dictionary<Type, System.Collections.IDictionary>();

        public void SetValue<TValue>(string name, TValue value)
            // where TValue: IComparable<TValue>
        {
            if(typeof(TValue).IsValueType)
            {
                SetValueTypeConfig<TValue>(name, value);
            }
            else
            {
                InternalCollection[name] = value;
            }
        }

        private void SetValueTypeConfig<TValue>(string name, TValue value)
            // Does not work because we don't know at the caller whethe the type is a stuct or not.
            // where TValue: struct  
        {
            if (InternalValueTypeCollection.TryGetValue(typeof(TValue),
                out System.Collections.IDictionary collection))
            {
                ((IDictionary<string, TValue>)collection)[name] = value;
            }
            else
            {
                collection = new Dictionary<string, TValue>
                    {
                        { name, value }
                    };
                InternalValueTypeCollection.Add(typeof(TValue), collection);
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
                return (TValue)InternalCollection[name]!;
            }
        }
    }
}