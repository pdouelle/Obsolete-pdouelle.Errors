using System;
using System.Reflection;
using Ardalis.GuardClauses;
using Newtonsoft.Json;

namespace pdouelle.Errors
{
    public class ResourceNotFound : ErrorObject
    {
        public ResourceNotFound(MemberInfo type, string propertyName, string value)
        {
            Title = "The requested resource does not exist.";
            Detail = $"Resource of type '{type.Name}' with {propertyName} '{value}' does not exist.";
        }

        public ResourceNotFound(MemberInfo type, string propertyName, Guid? value) : this(type, propertyName, value?.ToString())
        {
        }

        public ResourceNotFound(MemberInfo type, string propertyName, object value) : this(type, propertyName, value?.ToString())
        {
        }

        public ResourceNotFound(MemberInfo type, object value) : this(type, "multiple properties", JsonConvert.SerializeObject(value))
        {
        }

        public static implicit operator string(ResourceNotFound resourceNotFound)
        {
            Guard.Against.Null(resourceNotFound, nameof(resourceNotFound));

            return resourceNotFound.ToString();
        }
    }
}