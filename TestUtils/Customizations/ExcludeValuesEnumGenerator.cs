using System;
using System.Linq;

using AutoFixture;
using AutoFixture.Kernel;

namespace TestUtils.Customizations;

public class ExcludeValuesEnumGenerator<TEnum> : ISpecimenBuilder
{
    private readonly EnumGenerator _enumGenerator = new();
    private readonly Type _enumType;
    private readonly TEnum[] _excluded;

    public ExcludeValuesEnumGenerator(params TEnum[] excluded)
    {
        _enumType = typeof(TEnum);
        _excluded = excluded;
    }

    public object Create(object request, ISpecimenContext context)
    {
        var requestType = RequestTypeProvider.GetType(request);
        if (requestType != _enumType)
        {
            return new NoSpecimen();
        }

        var namesEnumerator = Enum.GetNames(_enumType).GetEnumerator();
        while (namesEnumerator.MoveNext())
        {
            var specimen = _enumGenerator.Create(requestType, context);
            if (specimen is not TEnum value || !_excluded.Contains(value))
            {
                return specimen;
            }
        }

        throw new ObjectCreationException(
            $"AutoFixture was unable to create a value for {_enumType.FullName}" +
            " since it is an enum containing either no values or " +
            $"ignored values only {string.Join(", ", _excluded)}. " +
            "Please add at least one valid value to the enum.");
    }
}
