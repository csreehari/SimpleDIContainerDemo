using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleDIDemo
{
    public class DIContainer
    {
        private Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

        public void Register<TInterface, TType>()
        {
            if (_types.ContainsKey(typeof(TInterface)))
            {
                throw new Exception("Type already registered");
            }
            _types.Add(typeof(TInterface), typeof(TType));
        }

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)GetImplementation(typeof(TInterface));
        }

        public object GetImplementation(Type type)
        {
            // We are assuming types have been already registerd - incase they are not then we throw and exception
            if (!_types.ContainsKey(type))
            {
                throw new Exception("Type does not exist");
            }
            //Get the value of the class/type registered with the interface, ignore warning as we are dont get nulls due the previous statements - throwing exception
            Type implementation = _types.GetValueOrDefault(type); 
            // Assuming we are only dealing with one constructor alone, we are getting the constructor info
            ConstructorInfo constructorInfo = implementation.GetConstructors()[0];
            // Get Constructor parameters, these contain just the abstractions/interfaces
            var constructorParamTypes = constructorInfo.GetParameters();
            //What we actually need is the concrete implementation and those implementations reside in the dictionary
            List<object> constructorParamImplementations = new List<object>();
            // we are recursively calling the current method to get the implementation of each constructor param type/interface
            foreach (var param in constructorParamTypes)
            {
                constructorParamImplementations.Add(GetImplementation(param.ParameterType));
            }

            return constructorInfo.Invoke(constructorParamImplementations.ToArray());
        }

    }
}

