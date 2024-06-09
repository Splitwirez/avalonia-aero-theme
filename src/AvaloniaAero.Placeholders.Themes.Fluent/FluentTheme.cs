using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace AvaloniaAero.Placeholders.Themes.Fluent
{
    internal class FluentTheme : Styles, IResourceNode
    {
        public FluentTheme(IServiceProvider? sp = null)
        {
            AvaloniaXamlLoader.Load(sp, this);
            Palettes = Resources.MergedDictionaries.OfType<ColorPaletteResourcesCollection>().FirstOrDefault()
                ?? throw new InvalidOperationException("FluentTheme was initialized with missing ColorPaletteResourcesCollection.");
        }
        
        public IDictionary<ThemeVariant, ColorPaletteResources> Palettes { get; }

        bool IResourceNode.TryGetResource(object key, ThemeVariant? theme, out object? value)
            => base.TryGetResource(key, theme, out value);
    }
}
