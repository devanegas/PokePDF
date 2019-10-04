using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PokePDF.Models;

namespace PokePDF.Services
{
    public class PrintingService
    {
        public void Print(Pokemon pokemon)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var doc = new Document();
            var section = doc.AddSection();
            string image64;
            section.AddParagraph("This is some text");

            image64 = getImageofPokemonSprite(pokemon.Sprites.Front_default);

            section.AddImage(image64);
            //header.AddFormattedText("This is my pdf", TextFormat.Bold);
            var path = "../../../PdfFiles/";




            var renderer = new PdfDocumentRenderer(false);
            renderer.Document = doc;
            renderer.WorkingDirectory = path;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path + "report4.pdf");
            Process.Start(path + "report3.pdf");
        }

        private string getImageofPokemonSprite(string urlToPokemonImage)
        {
            byte[] byteImage;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlToPokemonImage);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            string image64 = String.Empty;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var bmp = Image.FromStream(res.GetResponseStream(), true, true);
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, bmp.RawFormat);
                    byteImage = ms.ToArray();
                }
                //XImage image = XImage.FromGdiPlusImage(bmp);
                image64 = "base64:" + Convert.ToBase64String(byteImage);
            }

            return image64;
        }
    }
}
