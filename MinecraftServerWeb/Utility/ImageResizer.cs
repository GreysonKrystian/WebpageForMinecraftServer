using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MinecraftServerWeb.Utility
{
    public static class ImageResizer
    {
        public static Bitmap ResizeImage(Size newSize, Image image)
        {
            Bitmap bmp = new(newSize.Width, newSize.Height);
            bmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            var destinationRectangle = new Rectangle(0, 0, newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;


                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destinationRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                }
            }
            image.Dispose();
            return bmp;
        }
    }
}
