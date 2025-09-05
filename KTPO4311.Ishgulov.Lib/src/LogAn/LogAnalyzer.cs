using System;

namespace KTPO4311.Ishgulov.Lib.LogAn
{
    /// <summary>
    /// Анализатор лог-файлов
    /// </summary>
    public class LogAnalyzer
    {   
        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager manager = new FileExtensionManager();
            return manager.IsValid(fileName);
        }
    }
}