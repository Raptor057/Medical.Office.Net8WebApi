namespace Medical.Office.App.Methods
{
    public class ConvertToClass
    {
        private static int? ConvertBoolToInt(bool? value)
        {
            return value.HasValue ? (value.Value ? 1 : 0) : (int?)null;
        }

    }
}
