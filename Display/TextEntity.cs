using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            int lineLength = (int)(width / Draw.CharWidth);
            string renderText = Regex.Replace(Text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
            Draw.Text(renderText, new Vector2(x, y), Color.White);
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
