using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeTerminal
{
    /// <summary>
    /// Text Input class that handles key input and an input string and cursor. Loosely based on the 'Commands' class from Monocle
    /// </summary>
    public class TextController
    {
        public string Text { get; private set; }

        private int[] held = new int[254];

        private static int heldPause = 25;

        public int Cursor = 0;

        public TextController()
        {
            Text = "";
        }


        public void Update()
        {
            for (int i = 0; i < 254; i++)
            {
                if (KeyboardInput.Check((Keys)i))
                {
                    HandleKey((Keys)i);
                }
                else
                {
                    held[i] = 0;
                }
            }
        }


        public void HandleKey(Keys key)
        {
            KeyboardState currentState = KeyboardInput.current;


            if (held[(int)key] < heldPause && held[(int)key] != 0)
            {
                held[(int)key]++;
                return;
            }
            else
            {
                held[(int)key]++;
                if (held[(int)key] % 2 != 1)
                {
                    return;
                }
            }


            switch (key)
            {
                default:
                    if (key.ToString().Length == 1)
                    {
                        if (KeyboardInput.current.CapsLock)
                        {
                            if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                                PlaceString(key.ToString().ToLower());
                            else
                                PlaceString(key.ToString());
                        }
                        else
                        {
                            if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                                PlaceString(key.ToString());
                            else
                                PlaceString(key.ToString().ToLower());
                        }


                    }
                    break;

                case (Keys.D1):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("!");
                    else
                        PlaceString("1");
                    break;
                case (Keys.D2):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("@");
                    else
                        PlaceString("2");
                    break;
                case (Keys.D3):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("#");
                    else
                        PlaceString("3");
                    break;
                case (Keys.D4):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("$");
                    else
                        PlaceString("4");
                    break;
                case (Keys.D5):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("%");
                    else
                        PlaceString("5");
                    break;
                case (Keys.D6):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("^");
                    else
                        PlaceString("6");
                    break;
                case (Keys.D7):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("&");
                    else
                        PlaceString("7");
                    break;
                case (Keys.D8):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("*");
                    else
                        PlaceString("8");
                    break;
                case (Keys.D9):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("(");
                    else
                        PlaceString("9");
                    break;
                case (Keys.D0):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString(")");
                    else
                        PlaceString("0");
                    break;
                case (Keys.OemComma):
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("<");
                    else
                        PlaceString(",");
                    break;
                case Keys.OemPeriod:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString(">");
                    else
                        PlaceString(".");
                    break;
                case Keys.OemQuestion:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("?");
                    else
                        PlaceString("/");
                    break;
                case Keys.OemSemicolon:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString(":");
                    else
                        PlaceString(";");
                    break;
                case Keys.OemQuotes:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("'");
                    else
                        PlaceString("\"");
                    break;
                case Keys.OemBackslash:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("|");
                    else
                        PlaceString("\\");
                    break;
                case Keys.OemOpenBrackets:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("{");
                    else
                        PlaceString("[");
                    break;
                case Keys.OemCloseBrackets:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("}");
                    else
                        PlaceString("]");
                    break;
                case Keys.OemMinus:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("_");
                    else
                        PlaceString("-");
                    break;
                case Keys.OemPlus:
                    if (currentState[Keys.LeftShift] == KeyState.Down || currentState[Keys.RightShift] == KeyState.Down)
                        PlaceString("+");
                    else
                        PlaceString("=");
                    break;

                case Keys.Space:
                    PlaceString(" ");
                    break;
                case Keys.Back:
                    if (currentState[Keys.LeftControl] == KeyState.Down || currentState[Keys.RightControl] == KeyState.Down)
                    {
                        if (Text.Length > 0)
                        {
                            Text = Text.Substring(0, Cursor - 1) + Text.Substring(Cursor);
                            Cursor--;
                        }
                    }
                    else
                    {
                        if (Text.Length > 0)
                        {
                            Text = Text.Substring(0, Cursor - 1) + Text.Substring(Cursor);
                            Cursor--;
                        }
                    }
                    break;
                case Keys.Delete:
                    if (Cursor < Text.Length)
                    {
                        Text = Text.Substring(0, Cursor) + Text.Substring(Cursor + 1);
                    }
                    break;

                case Keys.Up:

                    break;
                case Keys.Down:

                    break;
                case Keys.Left:
                    if (Cursor > 0)
                        Cursor--;
                    break;
                case Keys.Right:
                    if (Cursor < Text.Length)
                        Cursor++;
                    break;
                case Keys.Tab:
                    PlaceString("    ");
                    break;

                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                    ExecuteFunctionKeyAction((int)(key - Keys.F1));
                    break;

                case Keys.Enter:
                    Controller.Instance.SendText(Text);
                    Text = "";
                    Cursor = 0;
                    break;
                case Keys.Escape:
                    Cursor = 0;
                    Text = "";
                    break;
            }
        }

        private void PlaceString(string c)
        {
            if (Cursor == Text.Length)
                Text += c;
            else
            {
                Text = Text.Substring(0, Cursor) + c + Text.Substring(Cursor);
            }
            Cursor += c.Length;
        }

        private void ExecuteFunctionKeyAction(int key)
        {
            throw new NotImplementedException();
        }
    }
}
