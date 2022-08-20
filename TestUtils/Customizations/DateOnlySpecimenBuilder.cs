using System;
using System.Reflection;

using AutoFixture.Kernel;

namespace TestUtils;

internal class DateOnlySpecimanBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        return !typeof(DateOnly).GetTypeInfo().IsAssignableFrom(request as Type)
            ? new NoSpecimen()
            : DateOnly.FromDateTime((DateTime)context.Resolve(typeof(DateTime)));
    }
}