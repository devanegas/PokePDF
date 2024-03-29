﻿using System;
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

            var path = "../../../PdfFiles/";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var doc = new Document();
            var section = doc.AddSection();
            string image64;
            var nameParagraph =section.AddParagraph(pokemon.Name.ToUpper());
            nameParagraph.Format.Alignment= ParagraphAlignment.Center;
            nameParagraph.Format.Font.Size = 20;
            var imageParagraph =section.AddParagraph();
            imageParagraph.Format.Alignment = ParagraphAlignment.Center;

            image64 = getImageofPokemonSprite(pokemon.Sprites.Front_default);
            imageParagraph.AddImage(image64);
            image64 = getImageofPokemonSprite(pokemon.Sprites.Back_default);
            imageParagraph.AddImage(image64);
            image64 = getImageofPokemonSprite(pokemon.Sprites.Front_shiny);
            imageParagraph.AddImage(image64);
            image64 = getImageofPokemonSprite(pokemon.Sprites.Back_shiny);
            imageParagraph.AddImage(image64);
            imageParagraph =section.AddParagraph();
            imageParagraph.Format.Alignment = ParagraphAlignment.Center;
            if (pokemon.Sprites.Front_female != null) {
                image64 = getImageofPokemonSprite(pokemon.Sprites.Front_female);
                imageParagraph.AddImage(image64);
            }
            if (pokemon.Sprites.Back_female != null)
            {
                image64 = getImageofPokemonSprite(pokemon.Sprites.Back_female);
                imageParagraph.AddImage(image64);
            }
            if (pokemon.Sprites.Front_shiny_female != null)
            {
                image64 = getImageofPokemonSprite(pokemon.Sprites.Front_shiny_female);
                imageParagraph.AddImage(image64);
            }
            if (pokemon.Sprites.Back_shiny_female != null)
            {
                image64 = getImageofPokemonSprite(pokemon.Sprites.Back_shiny_female);
                imageParagraph.AddImage(image64);
            }

            //header.AddFormattedText("This is my pdf", TextFormat.Bold);

            var typeParagraph=section.AddParagraph();
            var temp = typeParagraph.AddFormattedText("\nType: ");
            temp.Size = 14;
            foreach(var type in pokemon.PokemonTypes)
            {
                typeParagraph.AddFormattedText(type.PokemonType.Name + " ");
            }

            var weightParagraph = section.AddParagraph();
            temp = weightParagraph.AddFormattedText("\nWeight: ");
            temp.Size = 14;
            weightParagraph.AddFormattedText(((decimal)pokemon.Weight/10).ToString()+" kg");

            var statParagraph = section.AddParagraph();
            temp = statParagraph.AddFormattedText("\nStats:\n");
            temp.Size = 14;
            foreach (var stat in pokemon.Stats)
            {
                statParagraph.AddFormattedText(stat.Stat.Name +": ");
                statParagraph.AddFormattedText(stat.Base_stat.ToString() + '\n');
            }



            var renderer = new PdfDocumentRenderer(false);
            renderer.Document = doc;
            renderer.WorkingDirectory = path;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path + "PokemonInfo.pdf");
            //Process.Start(path + "report3.pdf");
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
