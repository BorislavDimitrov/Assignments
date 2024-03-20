namespace FilesystemAndStreams
{
    public interface ILogger
    {
        void LogSuccess(string methodName, string date, string outcome);
        void LogError(string methodName, string date, string outcome, string error);

        Task<string> ReadTodaysFileAsync();
        Task<string> ReadFileAsync(string fileName);
    }
}
