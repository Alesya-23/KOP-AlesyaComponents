using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnvisualComponentsAlesa.HelperModels;

namespace UnvisualComponentsAlesa
{
    /*Не визуальный компонент для создания документа с таблицей, у которой шапкой является первая строка и первый столбец.
	 * У компонента должен быть публичный метод, который должен принимать на вход имя файла (включая путь до файла),
	 * название документа (заголовок в документе), информацию по ширине каждого столбца и высоте каждой строки
	 * (по строке задается для шапки и для остальных строк), заголовки для шапки и данные для таблицы. 
	 * Строки и столбцы таблицы считать с 0 позиции. Данные должны передаваться в виде набора объектов какого-то класса.
	 * 
	 * 
	 * Таблица должна заполнятся по принципу: каждая строка – это запись класса из набора, ячейка строки заполняется из 
	 * свойства/поля объекта класса (в настройках указывать для какого столбца какое свойство/поле соответствует) 
	 * Первая ячейка строки (относящаяся к шапке) заполняется также из записи класса из набора.
	 * 
	 * Должна быть проверка на заполненность входных данных значениями. +
	 * 
	 * 
	 * Должна быть проверка, что все ячейки шапки заполнены и для каждого столбца известно свойство/поле класса из которого для него следует брать значение.*/
    public partial class WordTableTwo : Component
    {
        public WordTableTwo()
        {
            InitializeComponent();
        }

        public WordTableTwo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SaveData<T>(string filename, string title, List<TableColumnHelper> columns,
            TableRowHelper[] rows, List<T> product)
        {
            IsTableEmpty(product);
            IsColumnEmpty(columns);
            Table table = CreateTable(columns, rows, product);
            FileStream fs = new FileStream(filename, FileMode.Create);
            Document document = new Document();
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (title, new
                WordTextProperties {Bold = true, Size = "28", } ) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));
                document.AddChild(new Paragraph(filename));
                document.AddChild(table);
                wordDocument.MainDocumentPart.Document.Save();
                fs.Close();
            }
        }

        private Table CreateTable<T>(List<TableColumnHelper> columns,
            TableRowHelper[] rows, List<T> product)
        {
            Table table = new Table();  
            //Здесь получаем массив ширины колонок для таблицы и проверяем заполненность ширины 
            float[] widths = new float[columns.Count];
            bool widthsExist = true;
            foreach (TableColumnHelper column in columns)
            {
                if (column.Width == null)
                {
                    widthsExist = false;
                }
            }
            if (widthsExist)
            {
                int index = 0;
                int sum = 0;
                foreach (TableColumnHelper column in columns)
                {
                    widths[index] = (float)column.Width;
                    sum += (int)column.Width;
                    index++;
                }
            }

            //Здесь мы проверяем наличие данных о высоте колонок
            bool heightsExist;
            heightsExist = rows.Length == 2 ? true : false;
            foreach (TableRowHelper row in rows)
            {
                if (row.Height == null)
                {
                    heightsExist = false;
                }
            }

            //Если есть ширина, то добавляем параметры
            if (widthsExist)
            {
             //   table.
            }
            TableProperties props = new TableProperties(
                       new TableBorders(
                       new TopBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       },
                       new BottomBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       },
                       new LeftBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       },
                       new RightBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       },
                       new InsideHorizontalBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       },
                       new InsideVerticalBorder
                       {
                           Val = new EnumValue<BorderValues>(BorderValues.Single),
                           Size = 6
                       }));

            table.AppendChild<TableProperties>(props);

            // TableProperties

            //Добавляем столбцы по данным
            foreach (TableColumnHelper column in columns)
            {
                TableCell cell = new TableCell();
                if (heightsExist)
                {
                   // cell.Append(new TableCellProperties(
              //  new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = rows[1]. }));
                }
                table.AddChild(cell);
            }

           // Добавляем ячейки по данным
            foreach (T produc in product)
            {
                foreach (TableColumnHelper column in columns)
                {
                    TableRow row = new TableRow();
                    TableRowHeight trh = row.OfType<TableRowHeight>().FirstOrDefault();
                    trh.Val = 100;
                    row.Append(trh);
                    PropertyInfo propertyInfo = produc.GetType().GetProperty(column.PropertyName);
                    string value = propertyInfo.GetValue(produc).ToString();
                    TableCell cell = new TableCell();
                    cell.Append(new Paragraph(new Run(new Text(value))));
                    if (heightsExist)
                    {
                        //cell.Append(new TableCellProperties(
                 //   new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = columns[1].Width }));
                       // cell.MinimumHeight = (float)rows[1].Height;
                    }
                    table.AddChild(cell);
                }
            }

            //foreach (var row in table)
            //{
               
            //}

            return table;
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
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Задание форматирования для абзаца
        /// </summary>
        /// <param name="paragraphProperties"></param>
        /// <returns></returns>
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties
       paragraphProperties)
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

        private bool IsTableEmpty<T>(List<T> product)
        {
            if (product.Count == 0) throw new Exception("list is empty");
            return false;
        }
        private bool IsColumnEmpty(List<TableColumnHelper> columnHelpers)
        {
            foreach (TableColumnHelper column in columnHelpers)
            {
                if (column.Name == null || column.PropertyName == null)
                {
                    throw new Exception("fullfill the columnHelpers");
                }
            }
            return false;
        }
    }
}
