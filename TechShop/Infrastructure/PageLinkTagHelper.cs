using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TechShop.Models;
using System.Collections.Generic;

namespace TechShop.Infrastructure {

    [HtmlTargetElement("nav", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory) {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
            = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context,
                TagHelperOutput output) {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("nav");
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination justify-content-center");
            for (int i = 1; i <= PageModel.TotalPages; i++) {
                TagBuilder li = new TagBuilder("li");
                TagBuilder tag;
                if (i == PageModel.CurrentPage)
                {
                    tag = new TagBuilder("span");
                }
                else
                {
                    tag = new TagBuilder("a");
                }
                
                PageUrlValues["productPage"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                if (PageClassesEnabled) {
                    tag.AddCssClass("page-link");
                    li.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                li.InnerHtml.AppendHtml(tag);
                ul.InnerHtml.AppendHtml(li);
            }
            result.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
