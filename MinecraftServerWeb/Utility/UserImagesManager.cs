using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Utility
{
    public static class UserImagesManager
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

        public static Image ConvertIFormFileToImage(IFormFile file)
        {
            if (file.Length == 0)
            {
                throw new ArgumentException("file is empty");
            }

            using (MemoryStream memoryStream = new())
            {
                file.CopyToAsync(memoryStream);
                return Image.FromStream(memoryStream);
            }
        }

        public static void SaveBitmapToFile(Bitmap bmp, string path)
        {
            Image img = bmp;

            img.Save(path, ImageFormat.Png);
        }

        public static string GetUserImagePath(User user)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory() + Paths.UserImagesPath, user.Email + ".png");
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "default.png");
            }
        }

    }
}
