using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyBooks.TagHelpers
{
    public class WelcomeMessageTagHelper: TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "WelcomeMessageTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<span>Hi! {0} Welcome to my book store.</span>", this.Name);

            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
