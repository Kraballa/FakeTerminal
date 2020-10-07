using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeTerminal.Display
{
    public class LinearDisplay : IDisplay
    {
        private Queue<DisplayEntity> Entities = new Queue<DisplayEntity>();

        private TextEntity Input = new TextEntity("");

        public string GetAllText()
        {
            throw new NotImplementedException();
        }

        public string GetText(int fromLine, int toLine)
        {
            throw new NotImplementedException();
        }

        public void SendText(string text)
        {
            Entities.Enqueue(new TextEntity(text));
        }

        public void Render()
        {
            int pos = 4;
            foreach (DisplayEntity ent in Entities)
            {
                ent.Render(4, pos, Controller.Width);
                pos += ent.GetHeight(Controller.Width);
            }
            Input.Text = Controller.Instance.TextController.Text;
            Input.Render(4, pos, Controller.Width);
            float xPos = Controller.Instance.TextController.Cursor;
            xPos *= Draw.CharWidth;
            Draw.Line(new Vector2(xPos + 4, pos), new Vector2(xPos + 4, pos + Draw.CharHeight), Color.White);
        }

        public void Update()
        {

        }
    }
}
