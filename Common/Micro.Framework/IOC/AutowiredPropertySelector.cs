using Autofac.Core;
using System.Reflection;

namespace Micro.Framework
{
    /// <summary>
    ///                                                 
    /// </summary>
    public class AutowiredPropertySelector : IPropertySelector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.CustomAttributes.Any(it => it.AttributeType == typeof(AutowiredAttribute));
        }
    }
}