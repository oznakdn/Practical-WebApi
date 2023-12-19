namespace SingerSong.Application.Helpers;

public class ValidationHelpers
{
    public static bool IsGuid(string value)
    {
        if (value.Contains("-") && value.Length.Equals(36)) return true;
        if (!value.Contains("-") && value.Length.Equals(32)) return true;
        return false;
    }
}

