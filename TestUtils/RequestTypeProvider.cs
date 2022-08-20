using System;
using System.Reflection;

namespace TestUtils;

public class RequestTypeProvider
{
    public static Type GetType(object request)
    {
        return request switch
        {
            ParameterInfo paramInfo => paramInfo.ParameterType,
            PropertyInfo propInfo => propInfo.PropertyType,
            Type type => type,
            _ => null,
        };
    }
}
