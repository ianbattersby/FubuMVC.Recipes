namespace DownloadStreamRecipe.Controllers
{
    using System.Web;

    using FubuMVC.Core.Behaviors;

    public class PdfController
    {
        public DownloadFileModel Stream()
        {
            return new DownloadFileModel
            {
                ContentType = "application/pdf",
                LocalFileName = HttpContext.Current.Server.MapPath("~/Assets/hola.pdf")
            };
        }

        public DownloadFileModel Download()
        {
            return new DownloadFileModel
            {
                ContentType = "application/pdf",
                FileNameToDisplay = "hola.pdf",
                LocalFileName = HttpContext.Current.Server.MapPath("~/Assets/hola.pdf")
            };
        }
    }
}