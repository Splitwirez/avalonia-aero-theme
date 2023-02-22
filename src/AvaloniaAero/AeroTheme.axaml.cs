using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

#if VARIANT_NOPE
#nullable enable
#endif

namespace AvaloniaAero
{
#if VARIANT_NOPE
    public enum AeroVariant
    {
        Light,
        Dark,
    }
#endif
    /// <summary>
    /// Includes the aero theme in an application.
    /// </summary>
    public partial class AeroTheme : Styles
    {
#if VARIANT_NOPE
        private IResourceProvider _prevVariant = null;
        private StyleInclude _prevStyles = null;
        
        private readonly StyleInclude _darkStyles;
        private readonly StyleInclude _lightStyles;
        //private readonly IResourceProvider _darkVariant;
        //private readonly IResourceProvider _lightVariant;
#endif
        /// <summary>
        /// Initializes a new instance of the <see cref="AeroTheme"/> class.
        /// </summary>
        public AeroTheme()
        {
            AvaloniaXamlLoader.Load(this);
#if VARIANT_NOPE
            _darkStyles = GetAndRemove<StyleInclude>("DarkStyles");
            _lightStyles = GetAndRemove<StyleInclude>("LightStyles");
            
            string variantPlaceholder = "%VARIANT%";
            string variantUriBase = $"avares://AvaloniaAero/Variant/{variantPlaceholder}Styles.axaml";
            
            /*var includes = Resources.MergedDictionaries.OfType<ResourceInclude>().ToList();
            _darkVariant = includes.First(x => x.Source.AbsolutePath.EndsWith("/Dark.axaml"));
            Resources.MergedDictionaries.Remove(_darkVariant);
            /*new ResourceInclude()
            {
                Source = new Uri(variantUriBase.Replace(variantPlaceholder, "Dark"))
            };* /
            //GetAndRemove<IResourceProvider>("DarkVariant");
            _lightVariant = includes.First(x => x.Source.AbsolutePath.EndsWith("/Light.axaml"));
            //Resources.MergedDictionaries[3];
            Resources.MergedDictionaries.Remove(_lightVariant);
            //new ResourceInclude(new Uri(variantUriBase.Replace(variantPlaceholder, "Light")));
            //GetAndRemove<IResourceProvider>("LightVariant");
            */
            
            EnsureThemeVariants();
#endif
        }

#if VARIANT_NOPE
        T GetAndRemove<T>(string key)
            => TryGetRes<T>(key, true, out T value)
                ? value
                : default(T)
            ;
        
        bool TryGetRes<T>(object key, out T value)
            => TryGetRes<T>(key, false, out value);
        bool TryGetRes<T>(object key, bool remove, out T value)
        {
            value = default(T);
            
            if (!Resources.ContainsKey(key))
                return false;

            var resVal = Resources[key];
            if (resVal is T tVal)
            {
                value = tVal;
                Resources.Remove(key);
                return true;
            }
            return false;
        }

        public static readonly StyledProperty<AeroVariant> VariantProperty =
            AvaloniaProperty.Register<AeroTheme, AeroVariant>(nameof(Variant));

        /// <summary>
        /// Gets or sets the <see cref="AeroVariant">Variant</see> of the aero theme (<see cref="AeroVariant.Light"/>, <see cref="AeroVariant.Dark"/>).
        /// </summary>
        public AeroVariant Variant
        {
            get => GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            
            if (change.Property == VariantProperty)
                EnsureThemeVariants();
        }

        private void EnsureThemeVariants()
        {
            bool dark = Variant == AeroVariant.Dark;
            /*var variant = dark
                ? _darkVariant
                : _lightVariant*/
            ;
            var styles = dark
                ? _darkStyles
                : _lightStyles
            ;

            /*if (_prevVariant == null)
            {
                Resources.MergedDictionaries.Add(variant);
            }
            else
            {
                var index = Resources.MergedDictionaries.IndexOf(_prevVariant);
                Resources.MergedDictionaries.Insert(index, variant);
                Resources.MergedDictionaries.Remove(_prevVariant);
            }*/

            if (_prevStyles == null)
            {
                Insert(0, styles);
            }
            else
            {
                var index = IndexOf(_prevStyles);
                Insert(index, styles);
                Remove(_prevStyles);
            }

            //_prevVariant = variant;
            _prevStyles = styles;
        }
#endif
    }
}