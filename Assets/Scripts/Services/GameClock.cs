public static class GameClock
{
    public static string FormatSeconds(int totalSeconds)
    {
        if (totalSeconds < 0)
        {
            totalSeconds = 0;
        }

        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
