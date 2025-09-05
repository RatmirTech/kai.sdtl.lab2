using System;

namespace KTPO4311.Ishgulov.Lib.LogAn
{
    /// <summary>
    /// Анализатор лог-файлов
    /// </summary>
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; private set; }

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Имя файла не может быть пустым");

            try
            {
                var mgr = ExtensionManagerFactory.Create();
                if (!mgr.IsValid(fileName))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;
        }
    }
}