using UnityEngine;

public static class LogManager 
{
    public static Logger levelLogger = new Logger(Debug.unityLogger.logHandler);
    public static Logger playerLogger = new Logger(Debug.unityLogger.logHandler);
    public static Logger addLogger = new Logger(Debug.unityLogger.logHandler);
    public static Logger analyticsLogger = new Logger(Debug.unityLogger.logHandler);
    public static Logger parallaxLogger = new Logger(Debug.unityLogger.logHandler);
    public static Logger gameLogger = new Logger(Debug.unityLogger.logHandler);

    public static void Initiliaze()
    {
        // Call this function when the game starts
        //levelLogger.logEnabled = true;
        //playerLogger.logEnabled = true;
        //addLogger.logEnabled = true;
        //analyticsLogger.logEnabled = true;
        //parallaxLogger.logEnabled = true;
        //gameLogger.logEnabled = true;
    }
}
