using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace Harmony.IDE.Avalon
{
    public class AvalonUtils
    {
        public static void ApplySyntaxRules(string definitionPath, TextEditor textEditor)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream s = new FileStream(definitionPath, FileMode.Open))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }
    }
}
