using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Pages.TagHelpers
{

    [HtmlTargetElement("dateTime", Attributes = "asp-showicon,asp-only")]
    public class dateTimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "small";
            if ( context.AllAttributes["asp-showicon"].Value.ToString() == "true")
            {

            }
            if (context.AllAttributes["asp-only"].Value.ToString() =="date")
            {

            }
            output.PreContent.SetHtmlContent("<abc>");
            output.PostContent.SetHtmlContent("</abc>");

            //output.PreContent.SetContent("9527");


            base.Process(context, output);
        }
    }
}
