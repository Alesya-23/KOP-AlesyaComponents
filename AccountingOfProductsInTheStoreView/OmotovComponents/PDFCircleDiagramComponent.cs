using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyComponentsLibrary
{
    public partial class PDFCircleDiagramComponent : Component
    {
        private const string end = ".pdf";

        public PDFCircleDiagramComponent()
        {
            InitializeComponent();
        }

        public PDFCircleDiagramComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Положение легенды
        /// </summary>
        public enum LegendAlignment { Top, Bottom, Left, Right };

        /// <summary>
        /// Создаёт PDF файл по заданному пути с заголовком и круговой диаграммой из переданных данных.
        /// </summary>
        /// <param name="path">Имя файла (включая путь до файла)</param>
        /// <param name="headerDocument">Заголовок документа</param>
        /// <param name="headerDiagram">Заголовок диаграммы</param>
        /// <param name="legendAlignment">Положение легенды</param>
        /// <param name="data">Данные, передаваемые в диаграмму: заголовок и его значением</param>
        /// <returns>Возвращает true, если сохранение прошло успешно</returns>
        [Obsolete]
        public bool CreateDocumentWithCircleDiagram(string path, string headerDocument, string headerDiagram, LegendAlignment legendAlignment, Dictionary<string, double> data)
        {
            if (path == null || path.Length == 0)
            {
                throw new Exception("Пустой путь до файла");
            }
            else if (!path.EndsWith(end))
            {
                throw new Exception("Неверный формат файла");
            }

            if (headerDocument == null || headerDocument.Length == 0)
            {
                throw new Exception("Пустой заголовок");
            }

            if (headerDiagram == null || headerDiagram.Length == 0)
            {
                throw new Exception("Пустой заголовок");
            }

            if (data == null || data.Keys.Count == 0 || data.Values.Count == 0)
            {
                throw new Exception("Не заполнены данные");
            }

            Document document = new Document();
            Section section = document.AddSection();
            section.AddParagraph().AddFormattedText(headerDocument, TextFormat.Bold);
            section.AddParagraph(headerDiagram);
            Chart chart = section.AddChart();
            chart.Type = ChartType.Pie2D;
            chart.Width = Unit.FromCentimeter(10);
            chart.Height = Unit.FromCentimeter(10);
            Series series = chart.SeriesCollection.AddSeries();
            foreach(double item in data.Values)
            {
                series.Add(item);
            }
            XSeries xseries = chart.XValues.AddXSeries();
            foreach (string item in data.Keys)
            {
                xseries.Add(item);
            }

            switch (legendAlignment)
            {
                case LegendAlignment.Top:
                    chart.TopArea.AddLegend();
                break;
                case LegendAlignment.Bottom:
                    chart.BottomArea.AddLegend();
                break;
                case LegendAlignment.Left:
                    chart.LeftArea.AddLegend();
                break;
                case LegendAlignment.Right:
                    chart.RightArea.AddLegend();
                break;
            }

            chart.DataLabel.Type = DataLabelType.Percent;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

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
