using react_template.IoC.Singletons;
using react_template.Services;
using react_template_tests.Stubs;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace react_template_tests
{
    public class StylesServiceTests
    {
        private readonly IStylesService _sut;

        public StylesServiceTests()
        {
            _sut = new StylesService(new StylesRepositoryStub());
        }

        [Fact]
        public async Task GetDefault_Should_Return_Default_Style()
        {
            var styles = await _sut.GetDefault(CancellationToken.None);

            Assert.NotNull(styles);

            Assert.True(styles.Active);
            Assert.True(styles.Default);
        }
    }
}
