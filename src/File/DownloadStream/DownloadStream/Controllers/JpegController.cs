namespace DownloadStream.Controllers
{
    using System.Web;
    using FubuMVC.Core.Behaviors;

    public class JpegController
    {
        public DownloadFileModel Stream()
        {
            return new DownloadFileModel
            {
                ContentType = "image/jpeg",
                LocalFileName = HttpContext.Current.Server.MapPath("~/Assets/desert.jpg")
            };
        }
    }
}