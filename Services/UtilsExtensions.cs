using System.Reflection;
using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public static class UtilsExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T>? list) => list is null || list.Count() == 0;

        public static int ToInt(this string? text) => int.TryParse(text, out int i) ? i : 0;
        public static int? ToNullableInt(this string? text) => int.TryParse(text, out int i) && i != 0 ? i : null;

        public static decimal ToDecimal(this string? text) => decimal.TryParse(text, out decimal i) ? i : 0;
        public static decimal? ToNullableDecimal(this string? text) => decimal.TryParse(text, out decimal i) && i != 0 ? i : null;

        public static double ToDouble(this string? text) => double.TryParse(text, out double i) ? i : 0;
        public static double? ToNullableDouble(this string? text) => double.TryParse(text, out double i) && i != 0 ? i : null;

        public static void AddAuditInfo(this object objecto, int userId, bool newRow = false)
        {
            if (objecto.GetType().GetProperties().Any(x => x.Name == nameof(Audit.Modified)))
            {
                PropertyInfo? modified = objecto.GetType()?.GetProperty(nameof(Audit.Modified));
                modified?.SetValue(objecto, DateTime.Now);
            }
            if (objecto.GetType().GetProperties().Any(x => x.Name == nameof(Audit.ModifiedId)))
            {
                PropertyInfo? modified = objecto.GetType()?.GetProperty(nameof(Audit.ModifiedId));
                modified?.SetValue(objecto, userId);
            }
            if (newRow == true)
            {
                if (objecto.GetType().GetProperties().Any(x => x.Name == nameof(Audit.Created)))
                {
                    PropertyInfo? modified = objecto.GetType()?.GetProperty(nameof(Audit.Created));
                    modified?.SetValue(objecto, DateTime.Now);
                }
                if (objecto.GetType().GetProperties().Any(x => x.Name == nameof(Audit.CreatedId)))
                {
                    PropertyInfo? modified = objecto.GetType()?.GetProperty(nameof(Audit.CreatedId));
                    modified?.SetValue(objecto, userId);
                }
            }
        }
        public static string GetColumnLetter(this int columnNumber)
        {
            string column = string.Empty;
            while (columnNumber > 0)
            {
                int mod = (columnNumber - 1) % 26;
                column = (char)(65 + mod) + column;
                columnNumber = (columnNumber - mod) / 26;
            }
            return column;
        }
    }
}
