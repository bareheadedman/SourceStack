using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Pages.TagHelpers
{
    [HtmlTargetElement("paged",Attributes ="path,pagedIndex")]
    public class PagedTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            Object path = context.AllAttributes["path"].Value;

            output.Attributes.RemoveAll("path");
            output.Attributes.RemoveAll("pagedIndex");


            object pagedIndex = context.AllAttributes["pagedIndex"].Value;

            output.Attributes.Add("href",$"{path}/paged-{pagedIndex}");

            base.Process(context, output);
        }
    }
}
