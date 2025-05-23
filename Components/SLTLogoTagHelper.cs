/*
   @Date                 : 23.05.2025
   @Author               : Stein Lundbeck
   @Description          : null
   @Version              : 1.0.0.1
   @Latest               : 23.05.2025
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SteinLundbeck.Components.Extensions;
using SteinLundbeck.Components.TagHelper;
using SteinLundbeck.Components.TagHelper.Options;

namespace SLT.Home.Spirit.Components
{
    /// <summary>
    /// The SLT Logo
    /// </summary>
    [HtmlTargetElement(tag: "slt:logo", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SLTLogoTagHelper(IHttpContextAccessor httpContext) : TagHelperBase(httpContext)
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilderCustom mainWrap = new("div");
            TagBuilderCustom innerWrap = new("div");
            TagBuilderCustom logo = new("img", new TagBuilderCustomOptions() { RenderMode = TagRenderMode.SelfClosing });
            TagBuilderCustom sltName = new("h1");
            TagBuilderCustom slName = new("h2");
            mainWrap.AddAttribute("id", "SLTechLogo");
            innerWrap.AddCssClass("content-wrap");
            logo.AddAttribute("src", "https://assets.sltech.no/shared/image//logo/sltech.png");
            logo.AddCssClass("logo");
            sltName.InnerHtml.Append("SL Tech");
            sltName.AddCssClass("slt-name");
            slName.InnerHtml.Append("Stein Lundbeck");
            slName.AddCssClass("sl-name");

            innerWrap.AddContent(
                logo,
                sltName,
                slName);

            mainWrap.AddContent(innerWrap);

            AddContent(mainWrap);

            await base.ProcessAsync(context, output);
        }
    }
}
