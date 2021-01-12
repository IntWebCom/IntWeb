using IntWeb.Framework.Defaults;
using System.Collections.Generic;

namespace IntWeb.Framework.Core.Translator.WebElements
{
    public class WebElement
    {
        public string TagHTML { get; set; }

        public bool IsPaired { get; protected set; } = true;

        public Dictionary<string, string> Attributes { get; private set; } = new Dictionary<string, string>();

        public WebElement()
        {
            TagHTML = TranslatorDefaults.DefaultTagHTML;
        }

        public WebElement(string tagHTML)
        {
            TagHTML = tagHTML;
        }
    }
}