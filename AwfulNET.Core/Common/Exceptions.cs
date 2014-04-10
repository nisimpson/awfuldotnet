using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
   public sealed class BannedAccountException : Exception
   {
       public BannedAccountException(string message) : base(message) { }
       public BannedAccountException(Exception inner) : base("This account has been banned.", inner) { }
   }

   public sealed class SpecialMessageException : Exception
   {
       public SpecialMessageException(HtmlDocument doc) : base(GetMessage(doc)) { }

       private static string GetMessage(HtmlDocument doc)
       {
           var innerNode = doc.DocumentNode.Descendants("div")
               .Where(n => n.GetAttributeValue("class", string.Empty).Equals("inner"))
               .FirstOrDefault();

           if (innerNode != null)
           {
               StringBuilder builder = new StringBuilder();
               var message = GetMessage(innerNode.FirstChild, builder).ToString();
               message = message.Replace("  ", " ");
               message = message.Replace("\n\n\n", "\n");
               return message;
           }

           return string.Empty;
       }

       private static StringBuilder GetMessage(HtmlNode node, StringBuilder builder)
       {
            // base: null node
           if (node == null)
               return builder;

           else
           {
               // if node is text, add text to builder, then mine children
               if (node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText))
               {
                   var text = node.InnerText.Trim();
                   text = text.Replace("\n", "");
                   text = text.Replace("\r", "");
                   text = text.Replace("\t", "");
                   builder.Append(text + " ");
               }

               else if (node.Name.Equals("br"))
                   builder.AppendLine("\n");

               GetMessage(node.FirstChild, builder);
               return GetMessage(node.NextSibling, builder);
           }
       }
   }
}