using System.Linq;

using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace TestUtils.Customizations;

public class DomainCustomization : CompositeCustomization
{
    private static readonly ICustomization[] _commonCustomizations =
    {
            new AutoNSubstituteCustomization(),
            new OmitRecursionCustomization(),
            new SpecimenCustomization(new DateOnlySpecimanBuilder())
        };

    public DomainCustomization() : base(_commonCustomizations)
    { }

    public DomainCustomization(params ICustomization[] customizations)
        : base(_commonCustomizations.Union(customizations))
    { }
}
