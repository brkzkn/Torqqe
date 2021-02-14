using System;

namespace Torqqe.ShopmonkeyApi.Helper
{
    public static class DatetimeExtension
    {
        public static string GetXDate(this DateTime date)
        {
            var ts = date - new DateTime(1970, 1, 1);
            return ts.TotalMilliseconds.ToString();
        }
    }
}
