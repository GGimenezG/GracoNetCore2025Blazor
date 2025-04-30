using Newtonsoft.Json.Linq;

namespace BlazorApp1.Components
{
    public class TokenContainer
    {
        public string? token { get; private set; } = string.Empty;

        public void AsignarToken(string newToken)
        {
            token = newToken;
            NotifyStateChanged();
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Clear()
        {
            token = null;
            NotifyStateChanged();

        }
    }
}
