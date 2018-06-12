using System;

static class Log{
    private static bool debugEnabled = true;
    public static void i(string s){

        Console.WriteLine("[I]:\t"+s);
    }
    public static void dLine(string s){
        if(debugEnabled)
            Console.WriteLine(s);
    }
    public static void d(string s){
        if(debugEnabled)
            Console.Write(s);
    }
    public static void EnableDebug(){
        debugEnabled = true;
    }
    public static void DisableDebug(){
        debugEnabled = false;
    }
}