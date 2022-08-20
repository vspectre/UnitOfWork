using AutoFixture.Xunit2;

namespace TestUtils.Customizations;

public class InlineAutoDomainAttribute : InlineAutoDataAttribute
{
    public InlineAutoDomainAttribute(params object[] values)
        : base(new DomainCustomizationAttribute(), values)
    { }
}
