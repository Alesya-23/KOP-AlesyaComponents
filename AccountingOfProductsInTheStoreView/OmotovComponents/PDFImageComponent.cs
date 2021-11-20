using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyComponentsLibrary
{
    public partial class PDFImageComponent : Component
    {
        private const string end = ".pdf";

        public PDFImageComponent()
        {
            InitializeComponent();
        }

        public PDFImageComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Создаёт PDF файл по заданному пути с заголовком и картинками (не менее 2).
        /// </summary>
        /// <param name="path">Имя файла (включая путь до файла)</param>
        /// <param name="header">Заголовок</param>
        /// <param name="images">Массив путей до изображений (более одного изображения)</param>
        [Obsolete]
        public bool CreateDocumentWithImages(string path, string header, List<string> images)
        {
            if(path.Length == 0)
            {
                throw new Exception("Пустой путь до файла");
            }
            else if (!path.EndsWith(end))
            {
                throw new Exception("Неверный формат файла");
            }

            if (header.Length == 0)
            {
                throw new Exception("Пустой заголовок");
            }

            if (images.Count < 2)
            {
                throw new Exception("Менее 2 картинок");
            }

            Document document = new Document();
            document.AddSection().AddParagraph(header);
            Section sectionImages = document.AddSection();
            foreach(string imgPath in images)
            {
                sectionImages.AddImage(imgPath);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            return true;
        }
    }
}
