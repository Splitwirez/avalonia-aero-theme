using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

namespace AeroAvalonia.Demo
{
    public sealed class AeroThemeInfo
    {
        public readonly int TotalControlsToStyleCount;
        public readonly IEnumerable<string> CurrentlyStyledControls;
        public AeroThemeInfo(AeroTheme aero)
        {
            CurrentlyStyledControls = GetControlNames();
            var fluent = aero.OfType<FluentTheme>().First();

            TotalControlsToStyleCount = GetStyledCount(fluent.OfType<Styles>().Last());
        }


        static int GetStyledCount(Styles controls)
        {
            var stylesCount = controls.Count;
            var mergedResCount = controls.Resources.Keys.OfType<Type>().Count();
            return stylesCount + mergedResCount;
        }

        const string _MATCH_PREFIX = "ControlStyles/";
        static readonly int _MATCH_PREFIX_LENGTH = _MATCH_PREFIX.Length;




        static readonly Assembly _AERO_ASSEMBLY = typeof(AeroThemeInfo).Assembly;
        static readonly IReadOnlyDictionary<string, string> _SWAP_NAME = new Dictionary<string, string>()
        {
            ["Menu"] = null,
            ["HeaderedContentControl"] = "HeaderedContentControl (GroupBox)",
            ["Window"] = "Window (managed chrome NYI)",
        };
        static IEnumerable<string> GetControlNames()
        {
            List<string> ret = new();
            
            var resNames = _AERO_ASSEMBLY.GetManifestResourceNames();
            foreach (var resName in resNames)
            {
                if (!resName.StartsWith(_MATCH_PREFIX))
                    continue;
                
                
                string axamlName = resName.Substring(_MATCH_PREFIX_LENGTH);

                if (axamlName.Contains("_"))
                    ret.AddRange(axamlName.Split('_'));
                else
                    ret.Add(axamlName);
            }
            foreach (var unfinished in _SWAP_NAME)
            {
                string replaceWhat = unfinished.Key;
                if (!ret.Contains(replaceWhat))
                    continue;

                int index = ret.IndexOf(replaceWhat);
                ret.Remove(replaceWhat);

                string replaceWith = unfinished.Value;
                if (!string.IsNullOrWhiteSpace(replaceWith))
                    ret.Insert(index, replaceWith);
            }
            ret.Sort();
            return ret;
        }
    }
}