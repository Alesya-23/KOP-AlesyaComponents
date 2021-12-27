using ClassLibraryPluginsConfigurations.Models;

namespace ClassLibraryPluginsConfigurations.Interfaces
{
    /// <summary>
    /// Формирование сложного отчета
    /// </summary>
    public interface ICreateWordDocument : IPlugin
    {
        /// <summary>
        /// Создание/сохранение документа
        /// </summary>
        void SaveDocument();
        /// <summary>
        /// Добавление абзаца с текстом в документ
        /// </summary>
        /// <param name="config"></param>
        void AddParagraph(ParagraphConfigModel config);
        /// <summary>
        /// Добавление изображения в документ
        /// </summary>
        /// <param name="config"></param>
        void AddImage(ImageConfigModel config);
        /// <summary>
        /// Добавление таблицы в документ
        /// </summary>
        /// <param name="config"></param>
        void AddTable<T>(TableConfigModel<T> config);
        /// <summary>
        /// Добавление диаграммы в документ
        /// </summary>
        /// <param name="config"></param>
        void AddChart(ChartConfigModel config);
    }
}