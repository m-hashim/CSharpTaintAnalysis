using System;
using System.Collections;
using System.Linq;
public static class StringUntainter
{
    private static string [] TabBadStrings = { "select", "drop", ";", "--", "insert", "delete", 
    "xp_", "%", "&", 	"'", "(", ")", "/", "\\", ":", ";", "<", ">", "=", "[", "]", "?", "`", "|" };

    public static bool IsFreeOfSQLInjectionUntainter(string target)
    {
        string taintedStringLower = target.ToLower();

        return !TabBadStrings.Any( s => taintedStringLower.Contains(s) );
    }

    public static bool NOPUntainter(string target)
    {
        return true;
    }
}