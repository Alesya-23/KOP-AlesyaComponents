using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MyComponentsLibrary.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MyComponentsLibrary
{
    public partial class PDFTableComponent : Component
    {
        private const string end = ".pdf";
        public PDFTableComponent()
        {
            InitializeComponent();
        }

        public PDFTableComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Создаёт PDF файл по заданному пути с заголовком и таблицей из переданных объектов.
        /// </summary>
        /// <typeparam name="T">Тип объекта данных</typeparam>
        /// <param name="path">Имя файла (включая путь до файла)</param>
        /// <param name="header">Заголовок</param>
        /// <param name="data">Массив данных объектов</param>
        /// <param name="headersRows">Массив заголовков</param>
        /// <param name="mergedRows">Массив номеров строк которые будут слиты</param>
        /// <param name="heightRows">Словарь размеров высоты строк</param>
        /// <returns>Возвращает true, если сохранение прошло успешно</returns>
        [Obsolete]
        public bool CreateDocumentWithObjects<T>(string path, string header, List<T> data, List<string> headersRows, List<int> mergedRows, Dictionary<int, string> heightRows) 
        {
            if (path == null || path.Length == 0)
            {
                throw new Exception("Пустой путь до файла");
            }
            else if (!path.EndsWith(end))
            {
                throw new Exception("Неверный формат файла");
            }

            if (header == null || header.Length == 0)
            {
                throw new Exception("Пустой заголовок");
            }

            if (data == null || data.Count == 0)
            {
                throw new Exception("Пустой массив данных");
            }

            if (headersRows == null || headersRows.Count == 0)
            {
                throw new Exception("Пустой массив заголовков");
            }

            if (mergedRows == null || mergedRows.Count == 0)
            {
                throw new Exception("Пустой массив слияний строк");
            }

            List<List<string>> table = new List<List<string>>();

            Type type = typeof(T);
            foreach (string item in headersRows)
            {
                table.Add(new List<string> { item, item });
                PropertyInfo info = type.GetProperty(item);
                if (info != null)
                {
                    foreach (T obj in data)
                    {
                        string value = info.GetValue(obj).ToString();
                        table[table.Count - 1].Add(value);
                    }
                }
                else
                {
                    throw new Exception("Найден неверный заголовок (" + item + ")");
                }
            }

            Document document = new Document();
            Section section = document.AddSection();
            section.AddParagraph(header);
            Table tablePDF = section.AddTable();
            tablePDF.AddColumn("4cm");
            tablePDF.AddColumn("4cm");
            foreach (T _ in data)
            {
                tablePDF.AddColumn("2cm");
            }


            foreach (List<string> row in table) { 
                CreateRow(new PdfRowParameters
                {
                    Table = tablePDF,
                    Texts = row,
                    Style = "NormalTitle",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
            }

            int pointer = 0;
            int startPoint = -1;

            for (int i = 0; i < table.Count; i++)
            {
                if (mergedRows.Contains(i))
                {
                    if(startPoint != -1)
                    {
                        pointer++;
                        if (i == table.Count - 1)
                        {
                            tablePDF.Rows[startPoint].Cells[0].MergeDown = pointer;
                        }
                    }
                    else
                    {
                        startPoint = i;
                        if (i == table.Count - 1)
                        {
                            tablePDF.Rows[i].Cells[0].MergeRight = 1;
                        }
                    }
                }
                else
                {
                    if(startPoint != -1 && pointer != 0)
                    {
                        tablePDF.Rows[startPoint].Cells[0].MergeDown = pointer;
                        pointer = 0;
                        startPoint = -1;
                        i--;
                    }
                    else
                    {
                        tablePDF.Rows[i].Cells[0].MergeRight = 1;
                    }
                }

                if(heightRows != null && heightRows.Count != 0 && heightRows.ContainsKey(i))
                {
                    tablePDF.Rows[i].Height = heightRows[i];
                }
            }

            foreach (Row row in tablePDF.Rows)
            {
                if(row.Cells[0].Elements.Count == 0 || row.Cells[1].Elements.Count == 0)
                {
                    throw new Exception("Не все ячейки шапки заполнены");
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            return true;
        }

        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }

        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
