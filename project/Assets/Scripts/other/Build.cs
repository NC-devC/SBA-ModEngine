public class Build
{
    public static bool mobile = false;

    public static void prepare()
    {
        #if UNITY_ANDROID
        mobile = true;
        return;
        #endif
        mobile = false;
        return;
    }
}