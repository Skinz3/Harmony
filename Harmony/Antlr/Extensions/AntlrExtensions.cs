﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Antlr.Extensions
{
    static class AntlrExtensions
    {
        public static T Get<T>(this IToken token)
        {
            if (token == null)
            {
                return default;
            }
            return Get<T>(token.Text);
        }
        public static T Get<T>(this ParserRuleContext rule)
        {
            return Get<T>(rule.GetText());
        }
        public static T Get<T>(string text)
        {
            if (typeof(T) == typeof(float))
            {
                text = text.Replace(".", ",");
            }
            try
            {
                return (T)Convert.ChangeType(text, typeof(T));
            }
            catch
            {
                return default;
            }
        }
      
    }
}
