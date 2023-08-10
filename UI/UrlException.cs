using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace MarketParsApp.UI
{
    internal class UrlException
    {
        internal void ExceptionConf()
        {
            var settings = new ExceptionSettings
            {
                Format = ExceptionFormats.Default | ExceptionFormats.ShowLinks,
                Style = new ExceptionStyle
                {
                    Exception = new Style().Foreground(Color.Grey),
                    Message = new Style().Foreground(Color.White),
                    NonEmphasized = new Style().Foreground(Color.Cornsilk1),
                    Parenthesis = new Style().Foreground(Color.Cornsilk1),
                    Method = new Style().Foreground(Color.Red),
                    ParameterName = new Style().Foreground(Color.Cornsilk1),
                    ParameterType = new Style().Foreground(Color.Red),
                    Path = new Style().Foreground(Color.Red),
                    LineNumber = new Style().Foreground(Color.Cornsilk1),
                }

            };

        }
    }
}
