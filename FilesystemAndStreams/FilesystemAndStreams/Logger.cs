using System.Text;

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

        public async Task<string> ReadTodaysFileAsync()
        {
            try
            {
                var currentLogFileName = "Logs_" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
                var currentLogFilePath = Path.Combine(_logsDirectory, currentLogFileName);

                using (StreamReader reader = new StreamReader(currentLogFilePath, Encoding.UTF8))
                {
                    string content = await reader.ReadToEndAsync();
                    return content;
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions like file not found or access errors
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }

        public async Task<string> ReadFileAsync(string fileName)
        {
            try
            {

                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    string content = await reader.ReadToEndAsync();
                    return content;
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions like file not found or access errors
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
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
