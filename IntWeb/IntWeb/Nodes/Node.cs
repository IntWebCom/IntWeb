using IntWeb.Framework.Collections;
using IntWeb.Framework.Core.Translator;
using IntWeb.Framework.Core.Translator.WebElements;
using IntWeb.Framework.Defaults;
using System.Collections.Generic;
using System.Linq;

namespace IntWeb.Framework.Nodes
{
    public abstract class Node
    {
        public NodesCollection Nodes { get; private set; } = new NodesCollection();

        public long Identifier { get; private set; } = GenerateNewIdentifier();

        public string ContentText { get; private set; } = string.Empty;

        protected WebElement LinkedWebElement { get; set; } = new WebElement();

        public Node()
        {
            SetupIdentifierAttribute();
        }

        public string GetIdentifierLabel()
        {
            return NodeDefaults.IdentifierLabelPrefix + Identifier;
        }

        public void AppendClass(string targetClass)
        {
            string attribute = NodeDefaults.ClassAttribute;
            bool isAttributeExists = LinkedWebElement.Attributes.ContainsKey(attribute);

            if(isAttributeExists)
            {
                LinkedWebElement.Attributes[attribute] += ' ' + targetClass;
            }
            else
            {
                LinkedWebElement.Attributes[attribute] = targetClass;
            }
        }

        public void ExcludeClass(string targetClass)
        {
            if(HasClass(targetClass))
            {
                List<string> classes = GetClasses();
                classes.Remove(targetClass);
                SetClasses(classes);
            }
        }

        public bool HasClass(string targetClass)
        {
            string attributeValue = GetAttribute(NodeDefaults.ClassAttribute);

            if(attributeValue == null)
            {
                return false;
            }

            return attributeValue.Contains(targetClass);
        }

        public List<string> GetClasses()
        {
            string attributeValue = GetAttribute(NodeDefaults.ClassAttribute);

            if (attributeValue == null)
            {
                return new List<string>();
            }

            return attributeValue.Trim().Split(' ').ToList();
        }

        public void SetClasses(List<string> classes)
        {
            string strClasses = string.Join(' ', classes);
            SetAttribute(NodeDefaults.ClassAttribute, strClasses);
        }

        public string GetAttribute(string attribute)
        {
            if(!HasAttribute(attribute))
            {
                return null;
            }

            string value = LinkedWebElement.Attributes[attribute.ToLower()];
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public bool HasAttribute(string attribute)
        {
            return LinkedWebElement.Attributes.ContainsKey(attribute.ToLower());
        }

        public void SetAttribute(string attribute, string value = null)
        {
            LinkedWebElement.Attributes[attribute.ToLower()] = value;
        }

        public void UnsetAttribute(string attribute)
        {
            LinkedWebElement.Attributes.Remove(attribute.ToLower());
        }

        private static long GenerateNewIdentifier()
        {
            return ApplicationNodesCounter.NextValue();
        }

        private void SetupIdentifierAttribute()
        {
            LinkedWebElement.Attributes[NodeDefaults.IdentifierAttribute] = GetIdentifierLabel();
        }
    }
}
