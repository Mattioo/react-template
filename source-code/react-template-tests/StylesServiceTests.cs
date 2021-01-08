using react_template.IoC.Scoped;
using react_template.Services;
using react_template_tests.Stubs;

namespace react_template_tests
{
    public class StylesServiceTests
    {
        private readonly IStylesService _sut;

        public StylesServiceTests()
        {
            _sut = new StylesService(new StylesRepositoryStub());
        }
    }
}
