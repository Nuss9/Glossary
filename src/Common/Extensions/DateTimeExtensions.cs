namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsAtLeastFiveHundredYearsOld(this DateTime birthday) =>
            birthday > DateTime.Now.AddYears(-500)
                ? false
                : true;
    }
}
