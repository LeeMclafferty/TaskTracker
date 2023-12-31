
using TaskTracker.Views;

namespace TaskTracker.Navigation
{
    public static class ViewNavigation
    {
        public static async Task NavigateToPageAsync(string pageName, Dictionary<string, string> parameters = null)
        {
            var navigationUri = $"{pageName}";

            if (parameters != null && parameters.Count > 0)
            {
                var queryString = string.Join("&", parameters.Select(kv => $"{kv.Key}={kv.Value}"));
                navigationUri += $"?{queryString}";
            }

            await Shell.Current.GoToAsync(navigationUri);
        }

    }
}
