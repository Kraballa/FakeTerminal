using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeTerminal.Display
{
    public class TextEntity : DisplayEntity
    {
        public string Text { get; set; }

        public TextEntity(string text)
        {
            Text = text;
        }

        public void Render(int x, int y, int width)
        {
            int charsPerLine = (int)(Text.Length * Draw.CharWidth / width);



            Draw.Text(Text, new Vector2(x, y), Color.White);
        }

        public void Render(int x, int y, int width, int height)
        {
            Draw.Text(Text, new Vector2(x, y), Color.White);
        }

        public int GetHeight(int width)
        {
            Vector2 size = Draw.Font.MeasureString(Text);
            return (int)(Math.Ceiling(size.X / width) * size.Y);
        }
    }
}
