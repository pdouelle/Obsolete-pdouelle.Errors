using System.Reflection;
using Ardalis.GuardClauses;

namespace pdouelle.Errors
{
    public class ResourceAlreadyExists : ErrorObject
    {
        public ResourceAlreadyExists(MemberInfo type, string propertyName, string value)
        {
            Title = $"Another resource with the specified {propertyName} already exists.";
            Detail = $"Another resource of type '{type.Name}' with {propertyName} '{value}' already exists.";
        }
        
        public ResourceAlreadyExists(MemberInfo type, string propertyName, object value) : this(type, propertyName, value?.ToString())
        {
        }

        public static implicit operator string(ResourceAlreadyExists resourceAlreadyExists)
        {
            Guard.Against.Null(resourceAlreadyExists, nameof(resourceAlreadyExists));
            
            return resourceAlreadyExists.ToString();
        }

    }
}