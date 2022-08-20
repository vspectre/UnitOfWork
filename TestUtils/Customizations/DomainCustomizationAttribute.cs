using System;
using System.Linq;

using AutoFixture;
using AutoFixture.Xunit2;

namespace TestUtils.Customizations;
public class DomainCustomizationAttribute : AutoDataAttribute
{
    public DomainCustomizationAttribute()
        : base(() => new Fixture().Customize(new DomainCustomization()))
    { }

    public DomainCustomizationAttribute(params Type[] customizations)
        : base(() => new Fixture().Customize(new DomainCustomization(customizations.Select(x => (ICustomization)Activator.CreateInstance(x)).ToArray())))
    { }
}
