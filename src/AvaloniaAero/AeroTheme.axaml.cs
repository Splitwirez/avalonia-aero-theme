using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

#nullable enable

namespace AvaloniaAero
{
    public enum AeroVariant
    {
        Light,
        Dark,
    }
    /// <summary>
    /// Includes the aero theme in an application.
    /// </summary>
    #if !YE_OLDE_AEROTHEME
    public partial class AeroTheme : Styles
    {
        private IResourceProvider _prevVariant = null;
        private StyleInclude _prevStyles = null;
        
        private readonly StyleInclude _darkStyles;
        private readonly StyleInclude _lightStyles;
        private readonly IResourceProvider _darkVariant;
        private readonly IResourceProvider _lightVariant;

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroTheme"/> class.
        /// </summary>
        public AeroTheme()
        {
            AvaloniaXamlLoader.Load(this);
            
            _darkStyles = GetAndRemove<StyleInclude>("DarkStyles");
            _lightStyles = GetAndRemove<StyleInclude>("LightStyles");
            _darkVariant = GetAndRemove<IResourceProvider>("DarkVariant");
            _lightVariant = GetAndRemove<IResourceProvider>("LightVariant");
            
            EnsureThemeVariants();

            T GetAndRemove<T>(string key)
            {
                /*var val = Resources[key]
                          ?? throw new KeyNotFoundException($"Key {key} was not found in the resources");
                Resources.Remove(key);
                return val;*/
                if (Resources.TryGetResource(key, out object rawVal) && (rawVal is T retVal))
                    return retVal;
                throw new KeyNotFoundException($"Key {key} was not found in the resources");
            }
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
            var variant = dark
                ? _darkVariant
                : _lightVariant
            ;
            var styles = dark
                ? _darkStyles
                : _lightStyles
            ;

            if (_prevVariant == null)
            {
                Resources.MergedDictionaries.Add(variant);
            }
            else
            {
                var index = Resources.MergedDictionaries.IndexOf(_prevVariant);
                Resources.MergedDictionaries.Insert(index, variant);
                Resources.MergedDictionaries.Remove(_prevVariant);
            }

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

            _prevVariant = variant;
            _prevStyles = styles;
        }
    }
    #else
    public class AeroTheme : IStyle, IResourceProvider
    {
        private static readonly string _URI_PREFIX = $"avares://{nameof(AvaloniaAero)}";
        private readonly Uri _baseUri;
        private IStyle[]? _loaded;
        private bool _isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroTheme"/> class.
        /// </summary>
        /// <param name="baseUri">The base URL for the XAML context.</param>
        public AeroTheme(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroTheme"/> class.
        /// </summary>
        /// <param name="serviceProvider">The XAML service provider.</param>
        public AeroTheme(IServiceProvider serviceProvider)
        {
            _baseUri = ((IUriContext)serviceProvider.GetService(typeof(IUriContext))).BaseUri;
        }

        /// <summary>
        /// Gets or sets the variant of the aero theme (light, dark).
        /// </summary>
        
        AeroThemeVariant _variant = AeroThemeVariant.Light;
        public AeroThemeVariant Variant
        {
            get => _variant;
            set
            {
                var prev = _variant;
                
                _variant = value;
                if (_variant != prev)
                {
                    _isLoading = true;
                    _loaded = GetStyles();
                    _isLoading = false;
                }
            }
        }

        public IResourceHost? Owner => (Loaded as IResourceProvider)?.Owner;

        private static readonly Uri _THEME_URI = new Uri($"{_URI_PREFIX}/AeroBase.axaml", UriKind.Absolute);
        /// <summary>
        /// Gets the loaded style.
        /// </summary>
        public IStyle Loaded
        {
            get
            {
                if (_loaded == null)
                {
                    _isLoading = true;
                    _loaded = GetStyles();
                    _isLoading = false;
                }

                return _loaded?[0]!;
            }
        }

        IStyle[] GetStyles()
        {
            
            var themeBase = (Styles)AvaloniaXamlLoader.Load(_THEME_URI, _baseUri);
            var variantStyles = (IStyle)AvaloniaXamlLoader.Load(GetVariantStylesUri(), _baseUri);
            var variantResources = new ResourceInclude()
            {
                Source = GetVariantResourceUri()
            };
            //(ResourceDictionary)AvaloniaXamlLoader.Load(_THEME_URI, GetVariantResourceUri());
            themeBase.Resources.MergedDictionaries.Add(variantResources);
            return new IStyle[]
            {
                themeBase,
                //variantStyles,
            };
        }

        bool IResourceNode.HasResources => (Loaded as IResourceProvider)?.HasResources ?? false;

        IReadOnlyList<IStyle> IStyle.Children => _loaded ?? Array.Empty<IStyle>();

        public event EventHandler OwnerChanged
        {
            add
            {
                if (Loaded is IResourceProvider rp)
                {
                    rp.OwnerChanged += value;
                }
            }
            remove
            {
                if (Loaded is IResourceProvider rp)
                {
                    rp.OwnerChanged -= value;
                }
            }
        }

        public SelectorMatchResult TryAttach(IStyleable target, IStyleHost? host) => Loaded.TryAttach(target, host);

        public bool TryGetResource(object key, out object? value)
        {
            if (!_isLoading && Loaded is IResourceProvider p)
            {
                return p.TryGetResource(key, out value);
            }

            value = null;
            return false;
        }

        void IResourceProvider.AddOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.AddOwner(owner);
        void IResourceProvider.RemoveOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.RemoveOwner(owner);

        private static readonly Uri _DARK_RES_URI = new Uri($"{_URI_PREFIX}/Variant/Dark.axaml", UriKind.Absolute);
        private static readonly Uri _LIGHT_RES_URI = new Uri($"{_URI_PREFIX}/Variant/Light.axaml", UriKind.Absolute);
        private Uri GetVariantResourceUri() => Variant switch
        {
            AeroThemeVariant.Dark => _DARK_RES_URI,
            _ => _LIGHT_RES_URI,
        };

        private static readonly Uri _DARK_STYLES_URI = new Uri($"{_URI_PREFIX}/Variant/DarkStyles.axaml", UriKind.Absolute);
        private static readonly Uri _LIGHT_STYLES_URI = new Uri($"{_URI_PREFIX}/Variant/LightStyles.axaml", UriKind.Absolute);
        private Uri GetVariantStylesUri() => Variant switch
        {
            AeroThemeVariant.Dark => _DARK_STYLES_URI,
            _ => _LIGHT_STYLES_URI,
        };
    }
    #endif
}