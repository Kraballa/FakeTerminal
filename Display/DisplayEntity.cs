using System;
using System.Collections.Generic;
using System.Text;

namespace FakeTerminal.Display
{
    public interface DisplayEntity
    {
        public void Render(int x, int y, int width);
        public void Render(int x, int y, int width, int height);
        public int GetHeight(int width);
    }
}
