using System;

namespace HelloDI
{
    public class HelloDIRunner
    {
        private static void Main ()
        {
            IMessageWriter writer = new ConsoleMessageWriter ();
            var salutation = new Salutation (writer);
            salutation.Exclaim ();
        }
    }
}