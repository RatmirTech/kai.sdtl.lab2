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
        /// <param name="fileName">имя файла</param>
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Имя файла не может быть пустым");

            WasLastFileNameValid =  fileName.EndsWith(".ISHGULOV", StringComparison.OrdinalIgnoreCase);
            return WasLastFileNameValid;
        }
    }
}