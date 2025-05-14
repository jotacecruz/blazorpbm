namespace BlazorPBM.Services
{
    public class ErrorService
    {
        public event Action<string>? OnError;

        public void ReportError(Exception ex)
        {
            OnError?.Invoke(ex.Message);
        }
    }
}
