namespace DownloadStream.Controllers
{
    using HtmlTags;

    public class HomeController
    {
        public HtmlDocument Index()
        {
            var document = new HtmlDocument
                { Title = "How to use DownloadFileModel class to stream and download assets" };

            document.Body.Add("h1").Text("Using DownloadFileModel class to stream and download assets");

            LinkTag streamPdf = new LinkTag("Stream PDF to browser", "pdf/stream");
            LinkTag downloadPdf = new LinkTag("Force browser to open dialog for download PDF", "pdf/download");
            LinkTag streamJpeg = new LinkTag("Stream JPEG to browser", "jpeg/stream");

            document.Body.Append(streamPdf).Add("br");
            document.Body.Append(downloadPdf).Add("br");
            document.Body.Append(streamJpeg).Add("br");
                    
            return document;
        }
    }
}