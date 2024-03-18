namespace FilesystemAndStreams
{
    public class Logger : ILogger
    {
        private string _logsDirectory;

        public Logger()
        {
            _logsDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.ToString() + "\\Logs";
        }

        public void LogSuccess(string methodName, string date, string outcome)
        {
            var logMessage = $"Method name: {methodName} Time of invoke: {date} Outcome of invoking: {outcome}";
            WriteInFileAsync(logMessage);
        }

        public void LogError(string methodName, string date, string outcome, string error)
        {
            var errorLog = $"Method name: {methodName} Time of invoke: {date} Outcome of invoking: {outcome} Error: {error}";
            WriteInFileAsync(errorLog);
        }

        private async void WriteInFileAsync(string line)
        {
            var currentLogFileName = "Logs_" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
            var currentLogFilePath = Path.Combine(_logsDirectory, currentLogFileName);

            EnsureCreateLogsDirectory();

            try
            {
                using (StreamWriter writer = new StreamWriter(currentLogFilePath, append: true))
                {
                    await writer.WriteLineAsync(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void EnsureCreateLogsDirectory()
        {
            if (File.Exists(_logsDirectory) == false)
            {
                Directory.CreateDirectory(_logsDirectory);
            }
        }
    }
}
