using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace QuizzGUI.Controls
{
    public class SVGImage : ContentView
    {
        private readonly SKCanvasView canvasView = new SKCanvasView();

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            propertyName: nameof(Source),
            returnType: typeof(string),
            defaultValue: default(string),
            declaringType: typeof(SVGImage),
            propertyChanged: RedrawCanvas

            );

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public SVGImage()
         {
            Padding = new Thickness(0);
            BackgroundColor = Color.Transparent;
            Content = canvasView;
            canvasView.PaintSurface += CanvasView_PaintSurface;

         }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas sKCanvas = e.Surface.Canvas;
            sKCanvas.Clear();
            if(string.IsNullOrEmpty(Source))
            {
                return;
            }

            var assembly = typeof(SVGImage).GetTypeInfo().Assembly.GetName();

            using (Stream stream = typeof(SVGImage).GetTypeInfo().Assembly.GetManifestResourceStream(assembly.Name + ".OnboardingImages." + Source))
            {
                SkiaSharp.Extended.Svg.SKSvg sKSvg = new SkiaSharp.Extended.Svg.SKSvg();
                sKSvg.Load(stream);
                SKImageInfo imageInfo= e.Info;
                sKCanvas.Translate(imageInfo.Width / 2f, imageInfo.Height / 2f);
                SKRect rectBounds = sKSvg.ViewBox;
                float xRatio = imageInfo.Width / rectBounds.Width;
                float yRatio = imageInfo.Height / rectBounds.Height;
                float minRatio = Math.Min(xRatio, yRatio);
                sKCanvas.Scale(minRatio);
                sKCanvas.Translate(-rectBounds.MidX, -rectBounds.MidY);
                sKCanvas.DrawPicture(sKSvg.Picture);
            }
        }

        private static void RedrawCanvas(BindableObject bindable, object oldValue, object newValue)
        {
            SVGImage sVGImage = bindable as SVGImage;
            sVGImage?.canvasView.InvalidateSurface();
        }
    }
}
