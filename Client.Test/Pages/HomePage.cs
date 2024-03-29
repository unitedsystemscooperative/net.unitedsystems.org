using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class HomePageTests : TestContext
{
    [Fact]
    public void RendersLatinText()
    {
        var cut = RenderComponent<Home>();

        Assert.Equal("Ad astra per aspera".ToUpper(), cut.Find(".latin-text").Text());
    }
}