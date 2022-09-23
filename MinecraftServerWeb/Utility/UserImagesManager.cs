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


        public static string GetUserImageSavePath(string email, IWebHostEnvironment webHostEnvironment, string size)
        {
            if (size != "100" && size != "300" && size != "600")
            {
                throw new InvalidOperationException("Wrong photo size. Available sizes are 100, 300 and 600");
            }
            return Path.Combine(webHostEnvironment.WebRootPath + Paths.UserImagesPath, email + "." + size + ".png");
        }


        public static string GetUserImagePath(string email, IWebHostEnvironment webHostEnvironment, string size)
        {
            if (size != "100" && size != "300" && size != "600")
            {
                throw new InvalidOperationException("Wrong photo size. Available sizes are 100, 300 and 600");
            }
            string path = Path.Combine(webHostEnvironment.WebRootPath + Paths.UserImagesPath, email + "." + size + ".png");
            if (File.Exists(path))
            {
                return Path.Combine("~" + Paths.UserImagesPath, email + "." + size + ".png");
            }
            else
            {
                return Path.Combine("~" + Paths.UserImagesPath, "default." + size + ".png");
            }
        }

    }
}
