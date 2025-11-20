using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;

namespace AeroAvalonia
{
    public class HeaderGapClipper
        : Decorator
    {
        public static readonly StyledProperty<Layoutable> HeaderElementProperty
            = AvaloniaProperty.Register<HeaderGapClipper, Layoutable>(nameof(HeaderElement));
        public Layoutable HeaderElement
        {
            get => GetValue(HeaderElementProperty);
            set => SetValue(HeaderElementProperty, value);
        }




        static HeaderGapClipper()
        {
            HeaderGapClipper.ClipToBoundsProperty.OverrideDefaultValue<HeaderGapClipper>(true);
        }




        public HeaderGapClipper()
            : base()
        {
        }




        StreamGeometry CreateClipGeometry()
        {
            var headerEl = HeaderElement;
            if (headerEl == null)
                return null;
            var hElBounds = headerEl.Bounds;
            var hElTl = headerEl.TranslatePoint(hElBounds.TopLeft, this).Value;
            var hElBr = headerEl.TranslatePoint(hElBounds.BottomRight, this).Value;
            StreamGeometry clipGeom = new();
            var bounds = Bounds;
            var l = bounds.X;
            var t = bounds.Y;
            var r = bounds.Right;
            var b = bounds.Bottom;
            using (var ctx = clipGeom.Open())
            {
                ctx.BeginFigure(new(l, t), true);
                ctx.LineTo(new(hElTl.X, t));
                ctx.LineTo(new(hElTl.X, hElBr.Y));
                ctx.LineTo(new(hElBr.X, hElBr.Y));
                ctx.LineTo(new(hElBr.X, t));
                ctx.LineTo(new(r, t));
                ctx.LineTo(new(r, b));
                ctx.LineTo(new(l, b));
                ctx.EndFigure(true);
            }
            return clipGeom;
        }


        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            RefreshClipGeometry();
        }
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            DelayedRefreshClipGeometry();
        }


        void DelayedRefreshClipGeometry()
            => Dispatcher.UIThread.Post(RefreshClipGeometry);
        void RefreshClipGeometry()
        {
            Clip = CreateClipGeometry();
        }
    }
}