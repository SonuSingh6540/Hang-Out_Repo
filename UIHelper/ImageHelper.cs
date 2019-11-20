using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace JS.UIHelper
{
    public static class ImageHelper
    {
        //public static Bitmap GetHighQualityThumbnail(Stream inputStream_, int requiredWidth_, int requiredHeight_)
        //{
        //    System.Drawing.Bitmap bmpOut = null;

        //    Bitmap existingImage = new Bitmap(inputStream_);

        //    decimal aspectRatio;
        //    int aspectRatioWidth = 0;
        //    int aspectRatioHeight = 0;

        //    //*** If the image is smaller than a thumbnail just return it
        //    if (existingImage.Width < requiredWidth_ && existingImage.Height < requiredHeight_)
        //        return existingImage;

        //    //landscape image
        //    if (existingImage.Width > existingImage.Height)
        //    {
        //        aspectRatio = (decimal)requiredWidth_ / existingImage.Width;
        //        aspectRatioWidth = requiredWidth_;
        //        decimal lnTemp = existingImage.Height * aspectRatio;
        //        aspectRatioHeight = (int)lnTemp;
        //    }
        //    else
        //    {
        //        aspectRatio = (decimal)requiredHeight_ / existingImage.Height;
        //        aspectRatioHeight = requiredHeight_;
        //        decimal lnTemp = existingImage.Width * aspectRatio;
        //        aspectRatioWidth = (int)lnTemp;
        //    }

        //    bmpOut = new Bitmap(aspectRatioWidth, aspectRatioHeight, PixelFormat.Format32bppArgb);

        //    Graphics g = Graphics.FromImage(bmpOut);
        //    g.Clear(Color.Transparent);
        //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //    g.FillRectangle(Brushes.White, 0, 0, aspectRatioWidth, aspectRatioHeight);

        //    g.DrawImage(existingImage,
        //    new Rectangle(0, 0, aspectRatioWidth, aspectRatioHeight),
        //    new Rectangle(0, 0, existingImage.Width, existingImage.Height),
        //    GraphicsUnit.Pixel);

        //    return bmpOut;
        //}

        //public static Bitmap CreateImageByDimensions(Stream inputStream_, float X_, float Y_, int width_, int height_)
        //{
        //    System.Drawing.Bitmap bmpOut = null;
        //    Bitmap existingImage = new Bitmap(inputStream_);

        //    //decimal aspectRatio;
        //    //int aspectRatioWidth = 0;
        //    //int aspectRatioHeight = 0;

        //    ////*** If the image is smaller than a thumbnail just return it
        //    //if (existingImage.Width < requiredWidth_ && existingImage.Height < requiredHeight_)
        //    //    return existingImage;

        //    ////landscape image
        //    //if (existingImage.Width > existingImage.Height)
        //    //{
        //    //    aspectRatio = (decimal)requiredWidth_ / existingImage.Width;
        //    //    aspectRatioWidth = requiredWidth_;
        //    //    decimal lnTemp = existingImage.Height * aspectRatio;
        //    //    aspectRatioHeight = (int)lnTemp;
        //    //}
        //    //else
        //    //{
        //    //    aspectRatio = (decimal)requiredHeight_ / existingImage.Height;
        //    //    aspectRatioHeight = requiredHeight_;
        //    //    decimal lnTemp = existingImage.Width * aspectRatio;
        //    //    aspectRatioWidth = (int)lnTemp;
        //    //}

        //    bmpOut = new Bitmap(width_, height_, PixelFormat.Format32bppArgb);

        //    Graphics g = Graphics.FromImage(bmpOut);
        //    g.Clear(Color.Transparent);
        //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //    g.FillRectangle(Brushes.White, 0, 0, width_, height_);

        //    g.DrawImage(existingImage,
        //    new Rectangle(0, 0, bmpOut.Width, bmpOut.Height),
        //    new Rectangle((int)X_, (int)Y_, width_, height_),
        //    GraphicsUnit.Pixel);

        //    return bmpOut;
        //}
    }
}