using System.Reflection;
using Newtonsoft.Json;

namespace pdouelle.Errors
{
    public class RelationshipNotFound : ErrorObject
    {
        public RelationshipNotFound(MemberInfo type, object value)
        {
            Title = $"The requested relationship does not exist.";
            Detail = $"Resource of type '{type}' does not contain a relationship with these properties '{JsonConvert.SerializeObject(value)}'.";
        }
    }
}