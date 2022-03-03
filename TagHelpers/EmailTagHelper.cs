using Microsoft.AspNetCore.Razor.TagHelpers;

namespace fiapweb2022.TagHelpers
{
    public class EmailTagHelper :TagHelper
    {
        public string Email { get; set; }
        const string Domain = "fiap.com.br";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{Email}@{Domain}";

            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
            
        }
    }



    public class AutoCompleteTagHelper : TagHelper
    {
        public string Tipo { get; set; }
        const string Domain = "fiap.com.br";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            var autoCompleteUrl = $"https://api.com.br/{Tipo}";

            output.Attributes.SetAttribute("class", "auto-complete");
            output.Attributes.SetAttribute("data-auto-complete-url", autoCompleteUrl);

        }
    }
}
