using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ClassLibraryPluginsConfiguration.Interfaces;
using ClassLibraryPluginsConfiguration.Models;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using PageSize = DocumentFormat.OpenXml.Wordprocessing.PageSize;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace PluginWordReport
{
    [Export(typeof(IPlugin))]
    public class WordDocument : ICreateWordDocument
    {
        private string FileName;
        private string Title;
        private List<(string Title, string Path)> ImagePaths = new List<(string Title, string Path)>();

        Document document = new Document();

        public string PluginName => "Отчет word";

        public void AddParagraph(ParagraphConfigModel config)
        {
            Body docBody = document.AppendChild(new Body());
            docBody.AppendChild(CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (config.Text, new WordTextProperties { Bold = config.Bold, Size = config.FontSize.ToString() }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationValues = JustificationValues.Center
                }
            }));
            docBody.AppendChild(CreateSectionProperties());
        }

        public void AddTable<T>(TableConfigModel<T> config)
        {
            Body docBody = document.AppendChild(new Body());
            docBody.AppendChild(CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (config.Title, new WordTextProperties { Bold = true, Size = "48" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationValues = JustificationValues.Center
                }
            }));

            Table table = new Table();

            TableProperties tblProp = new TableProperties(
                new TableBorders(new TopBorder()
                { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 },
                    new BottomBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 },
                    new LeftBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 },
                    new RightBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 },
                    new InsideHorizontalBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 },
                    new InsideVerticalBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 12 })
            );

            table.Append(tblProp);

            TableRow titleRow = new TableRow();

            foreach (var columnInfo in config.ColumnInfo)
            {
                TableCell tableCell = new TableCell();

                tableCell.Append(
                    new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = columnInfo.Width.ToString() }),
                    new Paragraph(new Run(new Text(columnInfo.Title)))
                    );

                titleRow.Append(tableCell);
            }

            table.Append(titleRow);

            foreach (T obj in config.Objects)
            {
                TableRow tableRow = new TableRow();

                foreach (var columnInfo in config.ColumnInfo)
                {
                    TableCell tableCell = new TableCell();

                    foreach (PropertyInfo property in typeof(T).GetProperties())
                    {
                        if (property.Name.Equals(columnInfo.PropertyName))
                        {
                            tableCell.Append(
                                new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = columnInfo.Width.ToString() }),
                                new Paragraph(new Run(new Text(property.GetValue(obj).ToString())))
                                );
                            break;
                        }
                    }
                    tableRow.Append(tableCell);
                }
                table.Append(tableRow);
            }

            docBody.Append(table);
        }

        public void AddImage(ImageConfigModel config)
        {
            ImagePaths.Add((config.Title, config.Path));
        }

        public void AddChart(ChartConfigModel config)
        {
            Syncfusion.DocIO.DLS.WordDocument wordDocument = new Syncfusion.DocIO.DLS.WordDocument();
            IWSection section = wordDocument.AddSection();

            IWParagraph paragraph = section.AddParagraph();

            WChart chart = paragraph.AppendChart(500, 300);
            chart.ChartType = OfficeChartType.Line;

            chart.IsSeriesInRows = false;

            chart.ChartTitle = config.ChartTitle;

            for (int i = 0; i < config.ChartData.Count; i++)
            {
                IOfficeChartSerie series = chart.Series.Add(config.ChartData[i].SeriesName);
                series.Values = chart.ChartData[1, i + 1, config.ChartData[i].Data.Length + 1, i + 1];
                series.SerieType = OfficeChartType.Line;
                series.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
            }

            for (int i = 0; i < config.ChartData.Count; i++)
            {
                for (int j = 0; j < config.ChartData[i].Data.Length; j++)
                {
                    chart.ChartData.SetValue(j + 1, i + 1, config.ChartData[i].Data[j]);
                }
            }

            chart.HasLegend = true;

            switch (config.LegendPosition)
            {
                case LegendPosition.Top:
                    chart.Legend.Position = OfficeLegendPosition.Top;
                    break;
                case LegendPosition.Bottom:
                    chart.Legend.Position = OfficeLegendPosition.Bottom;
                    break;
                case LegendPosition.Left:
                    chart.Legend.Position = OfficeLegendPosition.Left;
                    break;
                case LegendPosition.Right:
                    chart.Legend.Position = OfficeLegendPosition.Right;
                    break;
            }

            wordDocument.Save("C:\\Users\\aleca\\Desktop\\123.docx");
            wordDocument.Close();
        }

        public void Execute(AbstractModel abstractModel)
        {
            FileName = abstractModel.WordInfoConfigModel.FileName;
            Title = abstractModel.WordInfoConfigModel.Title;

            Body docBody = document.AppendChild(new Body());
            docBody.AppendChild(CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (Title, new WordTextProperties { Bold = true, Size = "48", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationValues = JustificationValues.Center
                }
            }));

            docBody.AppendChild(CreateSectionProperties());
        }

        public void SaveDocument()
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = document;
                Body docBody = mainPart.Document.AppendChild(new Body());

                foreach (var image in ImagePaths)
                {
                    docBody.AppendChild(CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { (image.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationValues = JustificationValues.Center
                        }
                    }));

                    ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                    using (FileStream stream = new FileStream(image.Path, FileMode.Open))
                    {
                        imagePart.FeedData(stream);
                    }

                    AddImageToBody(wordDocument, mainPart.GetIdOfPart(imagePart));
                }

                docBody.AppendChild(CreateSectionProperties());
                wordDocument.MainDocumentPart.Document.Save();
            }
        }

        private static SectionProperties CreateSectionProperties()
        {
            SectionProperties properties = new SectionProperties();
            PageSize pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }

        private static Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                Paragraph docParagraph = new Paragraph();

                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    Run docRun = new Run();
                    RunProperties properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space =
                   SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }

            return null;
        }

        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                ParagraphProperties properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = paragraphProperties.JustificationValues
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                ParagraphMarkRunProperties paragraphMarkRunProperties = new
               ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val =
                   paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 990000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }
    }
}
