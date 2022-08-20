using AutoFixture;
using AutoFixture.Kernel;

namespace TestUtils.Customizations;

public class SpecimenCustomization : ICustomization
{
    private readonly ISpecimenBuilder _specimenBuilder;

    public SpecimenCustomization(ISpecimenBuilder specimenBuilder)
    {
        _specimenBuilder = specimenBuilder;
    }
    public void Customize(IFixture fixture) => fixture.Customizations.Add(_specimenBuilder);

}
