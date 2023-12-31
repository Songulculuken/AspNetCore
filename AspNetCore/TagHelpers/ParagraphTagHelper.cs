﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore.TagHelpers
{
    [HtmlTargetElement("paragraph")]
    public class ParagraphTagHelper : TagHelper
    {
        public string ShortDescription { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<b>Custom Tag Helper works {ShortDescription} </b>"); //Parametre ile atama
            base.Process(context, output);
        }
    }
}
