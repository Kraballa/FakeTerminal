using System;

namespace FakeTerminal
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Controller())
                game.Run();
        }
    }
}
