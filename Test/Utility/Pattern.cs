using System.Collections.Generic;


namespace Test.Utility
{
    public class Pattern
    {
        
        public Dictionary<string, string> PatternCheck()
        {
            Dictionary<string, string> pattern = new Dictionary<string, string>(){ {"email", @"^[^@\s]+@[^@\s]+\.[^@\s]+$" },
                                                                                     { "passwd", "[^a-zA-Z0-9]"} }; ;
            return pattern;
        }
      
    }
}
