using System;
using System.Collections.Generic;
using System.Text;

namespace FakeTerminal.Display
{
    public interface IDisplay
    {
        public void Render();
        public void Update();
        public string GetAllText();
        public string GetText(int fromLine, int toLine);
        public void SendText(string text);
    }
}
