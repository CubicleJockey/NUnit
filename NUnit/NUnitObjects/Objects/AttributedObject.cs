using System;
using System.ComponentModel;
using System.Reflection;

namespace NUnitObjects.Objects
{
    [Description("A Description")]
    public class AttributedObject : ICustomAttributeProvider
    {
        public object[] GetCustomAttributes(bool inherit) => Array.Empty<object>();
        public object[] GetCustomAttributes(Type attributeType, bool inherit) => Array.Empty<object>();
        public bool IsDefined(Type attributeType, bool inherit) => default;
    }
}