using BlazorWebAssembly.Web.Client.Pages;
using Bunit;
using Xunit;

namespace BlazaorWebAssembly.Test.Web
{
    public class DemoTest
    {
        [Fact]
        public void CounterShouldIncrementWhenSelected()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Current count: 1");
        }
    }
}