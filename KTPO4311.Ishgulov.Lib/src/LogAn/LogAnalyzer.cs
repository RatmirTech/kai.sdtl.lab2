using System;

namespace KTPO4311.Ishgulov.Lib.LogAn
{
    /// <summary>
    /// Анализатор лог-файлов
    /// </summary>
    public class LogAnalyzer
    {
        private readonly IExtensionManager _extensionManager;
        public bool WasLastFileNameValid { get; private set; }

        /// <summary>
        /// Конструктор с внедрением зависимости
        /// </summary>
        /// <param name="extensionManager">Менеджер расширений</param>
        public LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager ?? throw new ArgumentNullException(nameof(extensionManager));
        }

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
                if (!_extensionManager.IsValid(fileName))
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