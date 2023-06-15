using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_ButtonTracker : MonoBehaviour
{
    public Text OutputText;
    public Text ButtonPress;
    //public Dictionary<string, int> allButtons;
    private string newEntry;
    private string lastEntry;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString!="")
        {
            lastEntry = Input.inputString;
        }

        if (Input.anyKeyDown)
        {

            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                newEntry = "Backspace";
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                newEntry = "Delete";
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                newEntry = "Tab";
            }

            if (Input.GetKeyDown(KeyCode.Clear))
            {
                newEntry = "Clear";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                newEntry = "Return";
            }

            if (Input.GetKeyDown(KeyCode.Pause))
            {
                newEntry = "Pause";
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                newEntry = "Escape";
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                newEntry = "Space";
            }

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                newEntry = "Keypad0";
            }

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                newEntry = "Keypad1";
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                newEntry = "Keypad2";
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                newEntry = "Keypad3";
            }

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                newEntry = "Keypad4";
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                newEntry = "Keypad5";
            }

            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                newEntry = "Keypad6";
            }

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                newEntry = "Keypad7";
            }

            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                newEntry = "Keypad8";
            }

            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                newEntry = "Keypad9";
            }

            if (Input.GetKeyDown(KeyCode.KeypadPeriod))
            {
                newEntry = "KeypadPeriod";
            }
            if (Input.GetKeyDown(KeyCode.KeypadDivide))
            {
                newEntry = "KeypadDivide";
            }
            if (Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                newEntry = "KeypadMultiply";
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                newEntry = "KeypadMinus";
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                newEntry = "KeypadPlus";
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                newEntry = "KeypadEnter";
            }
            if (Input.GetKeyDown(KeyCode.KeypadEquals))
            {
                newEntry = "KeypadEquals";
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                newEntry = "UpArrow";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                newEntry = "DownArrow";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                newEntry = "RightArrow";
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                newEntry = "LeftArrow";
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                newEntry = "Insert";
            }
            if (Input.GetKeyDown(KeyCode.Home))
            {
                newEntry = "Home";
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                newEntry = "End";
            }
            if (Input.GetKeyDown(KeyCode.PageUp))
            {
                newEntry = "PageUp";
            }
            if (Input.GetKeyDown(KeyCode.PageDown))
            {
                newEntry = "PageDown";
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                newEntry = "F1";
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                newEntry = "F2";
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                newEntry = "F3";
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                newEntry = "F4";
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                newEntry = "F5";
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                newEntry = "F6";
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                newEntry = "F7";
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                newEntry = "F8";
            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                newEntry = "F9";
            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                newEntry = "F10";
            }
            if (Input.GetKeyDown(KeyCode.F11))
            {
                newEntry = "F11";
            }
            if (Input.GetKeyDown(KeyCode.F12))
            {
                newEntry = "F12";
            }
            if (Input.GetKeyDown(KeyCode.F13))
            {
                newEntry = "F13";
            }
            if (Input.GetKeyDown(KeyCode.F14))
            {
                newEntry = "F14";
            }
            if (Input.GetKeyDown(KeyCode.F15))
            {
                newEntry = "F15";
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                newEntry = "Alpha0";
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                newEntry = "Alpha1";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                newEntry = "Alpha2";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                newEntry = "Alpha3";
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                newEntry = "Alpha4";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                newEntry = "Alpha5";
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                newEntry = "Alpha6";
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                newEntry = "Alpha7";
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                newEntry = "Alpha8";
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                newEntry = "Alpha9";
            }
            if (Input.GetKeyDown(KeyCode.Exclaim))
            {
                newEntry = "Exclaim";
            }
            if (Input.GetKeyDown(KeyCode.DoubleQuote))
            {
                newEntry = "DoubleQuote";
            }
            if (Input.GetKeyDown(KeyCode.Hash))
            {
                newEntry = "Hash";
            }
            if (Input.GetKeyDown(KeyCode.Dollar))
            {
                newEntry = "Dollar";
            }
            if (Input.GetKeyDown(KeyCode.Percent))
            {
                newEntry = "Percent";
            }
            if (Input.GetKeyDown(KeyCode.Ampersand))
            {
                newEntry = "Ampersand";
            }
            if (Input.GetKeyDown(KeyCode.Quote))
            {
                newEntry = "Quote";
            }
            if (Input.GetKeyDown(KeyCode.LeftParen))
            {
                newEntry = "LeftParen";
            }
            if (Input.GetKeyDown(KeyCode.RightParen))
            {
                newEntry = "RightParen";
            }
            if (Input.GetKeyDown(KeyCode.Asterisk))
            {
                newEntry = "Asterisk";
            }
            if (Input.GetKeyDown(KeyCode.Plus))
            {
                newEntry = "Plus";
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                newEntry = "Comma";
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                newEntry = "Minus";
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                newEntry = "Period";
            }
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                newEntry = "Slash";
            }
            if (Input.GetKeyDown(KeyCode.Colon))
            {
                newEntry = "Colon";
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                newEntry = "Semicolon";
            }
            if (Input.GetKeyDown(KeyCode.Less))
            {
                newEntry = "Less";
            }
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                newEntry = "Equals";
            }
            if (Input.GetKeyDown(KeyCode.Greater))
            {
                newEntry = "Greater";
            }
            if (Input.GetKeyDown(KeyCode.Question))
            {
                newEntry = "Question";
            }
            if (Input.GetKeyDown(KeyCode.At))
            {
                newEntry = "At";
            }
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                newEntry = "LeftBracket";
            }
            if (Input.GetKeyDown(KeyCode.Backslash))
            {
                newEntry = "Backslash";
            }
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                newEntry = "RightBracket";
            }
            if (Input.GetKeyDown(KeyCode.Caret))
            {
                newEntry = "Caret";
            }
            if (Input.GetKeyDown(KeyCode.Underscore))
            {
                newEntry = "Underscore";
            }
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                newEntry = "BackQuote";
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                newEntry = "A";
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                newEntry = "B";
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                newEntry = "C";
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                newEntry = "D";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                newEntry = "E";
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                newEntry = "F";
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                newEntry = "G";
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                newEntry = "H";
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                newEntry = "I";
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                newEntry = "J";
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                newEntry = "K";
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                newEntry = "L";
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                newEntry = "M";
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                newEntry = "N";
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                newEntry = "O";
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                newEntry = "P";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                newEntry = "Q";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                newEntry = "R";
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                newEntry = "S";
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                newEntry = "T";
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                newEntry = "U";
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                newEntry = "V";
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                newEntry = "W";
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                newEntry = "X";
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                newEntry = "Y";
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                newEntry = "Z";
            }
            if (Input.GetKeyDown(KeyCode.LeftCurlyBracket))
            {
                newEntry = "LeftCurlyBracket";
            }
            if (Input.GetKeyDown(KeyCode.Pipe))
            {
                newEntry = "Pipe";
            }
            if (Input.GetKeyDown(KeyCode.RightCurlyBracket))
            {
                newEntry = "RightCurlyBracket";
            }
            if (Input.GetKeyDown(KeyCode.Numlock))
            {
                newEntry = "Numlock";
            }
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                newEntry = "";
            }
            if (Input.GetKeyDown(KeyCode.ScrollLock))
            {
                newEntry = "CapsLock";
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                newEntry = "RightShift";
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                newEntry = "LeftShift";
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                newEntry = "RightControl";
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                newEntry = "LeftControl";
            }
            if (Input.GetKeyDown(KeyCode.RightAlt))
            {
                newEntry = "RightAlt";
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                newEntry = "LeftAlt";
            }
            if (Input.GetKeyDown(KeyCode.LeftMeta))
            {
                newEntry = "LeftMeta";
            }
            if (Input.GetKeyDown(KeyCode.LeftCommand))
            {
                newEntry = "LeftCommand";
            }
            if (Input.GetKeyDown(KeyCode.LeftApple))
            {
                newEntry = "LeftApple";
            }
            if (Input.GetKeyDown(KeyCode.LeftWindows))
            {
                newEntry = "LeftWindows";
            }
            if (Input.GetKeyDown(KeyCode.RightMeta))
            {
                newEntry = "RightMeta";
            }
            if (Input.GetKeyDown(KeyCode.RightCommand))
            {
                newEntry = "RightCommand";
            }
            if (Input.GetKeyDown(KeyCode.RightApple))
            {
                newEntry = "RightApple";
            }
            if (Input.GetKeyDown(KeyCode.RightWindows))
            {
                newEntry = "RightWindows";
            }
            if (Input.GetKeyDown(KeyCode.AltGr))
            {
                newEntry = "AltGr";
            }
            if (Input.GetKeyDown(KeyCode.Help))
            {
                newEntry = "Help";
            }
            if (Input.GetKeyDown(KeyCode.Print))
            {
                newEntry = "Print";
            }
            if (Input.GetKeyDown(KeyCode.SysReq))
            {
                newEntry = "SysReq";
            }
            if (Input.GetKeyDown(KeyCode.Break))
            {
                newEntry = "Break";
            }
            if (Input.GetKeyDown(KeyCode.Menu))
            {
                newEntry = "Menu";
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                newEntry = "Mouse0";
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                newEntry = "Mouse1";
            }
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                newEntry = "Mouse2";
            }
            if (Input.GetKeyDown(KeyCode.Mouse3))
            {
                newEntry = "Mouse3";
            }
            if (Input.GetKeyDown(KeyCode.Mouse4))
            {
                newEntry = "Mouse4";
            }
            if (Input.GetKeyDown(KeyCode.Mouse5))
            {
                newEntry = "Mouse5";
            }
            if (Input.GetKeyDown(KeyCode.Mouse6))
            {
                newEntry = "Mouse6";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                newEntry = "JoystickButton0";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                newEntry = "JoystickButton1";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                newEntry = "JoystickButton2";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                newEntry = "JoystickButton3";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton4))
            {
                newEntry = "JoystickButton4";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                newEntry = "JoystickButton5";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton6))
            {
                newEntry = "JoystickButton6";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                newEntry = "JoystickButton7";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton8))
            {
                newEntry = "JoystickButton8";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton9))
            {
                newEntry = "JoystickButton9";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton10))
            {
                newEntry = "JoystickButton10";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton11))
            {
                newEntry = "JoystickButton11";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton12))
            {
                newEntry = "JoystickButton12";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton13))
            {
                newEntry = "JoystickButton13";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton14))
            {
                newEntry = "JoystickButton14";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton15))
            {
                newEntry = "JoystickButton15";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton16))
            {
                newEntry = "JoystickButton16";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton17))
            {
                newEntry = "JoystickButton17";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton18))
            {
                newEntry = "JoystickButton18";
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton19))
            {
                newEntry = "JoystickButton19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                newEntry = "JoystickButton20";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                newEntry = "Joystick1Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                newEntry = "Joystick1Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                newEntry = "Joystick1Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                newEntry = "Joystick1Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                newEntry = "Joystick1Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                newEntry = "Joystick1Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                newEntry = "Joystick1Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button8))
            {
                newEntry = "Joystick1Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                newEntry = "Joystick1Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button10))
            {
                newEntry = "Joystick1Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button11))
            {
                newEntry = "Joystick1Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button12))
            {
                newEntry = "Joystick1Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button13))
            {
                newEntry = "Joystick1Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button14))
            {
                newEntry = "Joystick1Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button15))
            {
                newEntry = "Joystick1Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button16))
            {
                newEntry = "Joystick1Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button17))
            {
                newEntry = "Joystick1Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button18))
            {
                newEntry = "Joystick1Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button19))
            {
                newEntry = "Joystick1Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                newEntry = "Joystick2Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                newEntry = "Joystick2Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                newEntry = "Joystick2Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                newEntry = "Joystick2Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button4))
            {
                newEntry = "Joystick2Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button5))
            {
                newEntry = "Joystick2Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button6))
            {
                newEntry = "Joystick2Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                newEntry = "Joystick2Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button8))
            {
                newEntry = "Joystick2Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button9))
            {
                newEntry = "Joystick2Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button10))
            {
                newEntry = "Joystick2Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button11))
            {
                newEntry = "Joystick2Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button12))
            {
                newEntry = "Joystick2Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button13))
            {
                newEntry = "Joystick2Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button14))
            {
                newEntry = "Joystick2Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button15))
            {
                newEntry = "Joystick2Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button16))
            {
                newEntry = "Joystick2Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button17))
            {
                newEntry = "Joystick2Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button18))
            {
                newEntry = "Joystick2Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button19))
            {
                newEntry = "Joystick2Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                newEntry = "Joystick3Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                newEntry = "Joystick3Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button2))
            {
                newEntry = "Joystick3Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button3))
            {
                newEntry = "Joystick3Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button4))
            {
                newEntry = "Joystick3Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button5))
            {
                newEntry = "Joystick3Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button6))
            {
                newEntry = "Joystick3Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button7))
            {
                newEntry = "Joystick3Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button8))
            {
                newEntry = "Joystick3Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button9))
            {
                newEntry = "Joystick3Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button10))
            {
                newEntry = "Joystick3Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button11))
            {
                newEntry = "Joystick3Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button12))
            {
                newEntry = "Joystick3Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button13))
            {
                newEntry = "Joystick3Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button14))
            {
                newEntry = "Joystick3Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button15))
            {
                newEntry = "Joystick3Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button16))
            {
                newEntry = "Joystick3Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button17))
            {
                newEntry = "Joystick3Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button18))
            {
                newEntry = "Joystick3Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button19))
            {
                newEntry = "Joystick3Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                newEntry = "Joystick4Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                newEntry = "Joystick4Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button2))
            {
                newEntry = "Joystick4Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button3))
            {
                newEntry = "Joystick4Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button4))
            {
                newEntry = "Joystick4Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button5))
            {
                newEntry = "Joystick4Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button6))
            {
                newEntry = "Joystick4Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button7))
            {
                newEntry = "Joystick4Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button8))
            {
                newEntry = "Joystick4Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button9))
            {
                newEntry = "Joystick4Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button10))
            {
                newEntry = "Joystick4Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button11))
            {
                newEntry = "Joystick4Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button12))
            {
                newEntry = "Joystick4Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button13))
            {
                newEntry = "Joystick4Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button14))
            {
                newEntry = "Joystick4Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button15))
            {
                newEntry = "Joystick4Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button16))
            {
                newEntry = "Joystick4Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button17))
            {
                newEntry = "Joystick4Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button18))
            {
                newEntry = "Joystick4Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button19))
            {
                newEntry = "Joystick4Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button0))
            {
                newEntry = "Joystick5Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button1))
            {
                newEntry = "Joystick5Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button2))
            {
                newEntry = "Joystick5Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button3))
            {
                newEntry = "Joystick5Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button4))
            {
                newEntry = "Joystick5Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button5))
            {
                newEntry = "Joystick5Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button6))
            {
                newEntry = "Joystick5Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button7))
            {
                newEntry = "Joystick5Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button8))
            {
                newEntry = "Joystick5Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button9))
            {
                newEntry = "Joystick5Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button10))
            {
                newEntry = "Joystick5Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button11))
            {
                newEntry = "Joystick5Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button12))
            {
                newEntry = "Joystick5Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button13))
            {
                newEntry = "Joystick5Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button14))
            {
                newEntry = "Joystick5Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button15))
            {
                newEntry = "Joystick5Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button16))
            {
                newEntry = "Joystick5Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button17))
            {
                newEntry = "Joystick5Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button18))
            {
                newEntry = "Joystick5Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button19))
            {
                newEntry = "Joystick5Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button0))
            {
                newEntry = "Joystick6Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button1))
            {
                newEntry = "Joystick6Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button2))
            {
                newEntry = "Joystick6Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button3))
            {
                newEntry = "Joystick6Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button4))
            {
                newEntry = "Joystick6Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button5))
            {
                newEntry = "Joystick6Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button6))
            {
                newEntry = "Joystick6Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button7))
            {
                newEntry = "Joystick6Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button8))
            {
                newEntry = "Joystick6Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button9))
            {
                newEntry = "Joystick6Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button10))
            {
                newEntry = "Joystick6Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button11))
            {
                newEntry = "Joystick6Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button12))
            {
                newEntry = "Joystick6Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button13))
            {
                newEntry = "Joystick6Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button14))
            {
                newEntry = "Joystick6Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button15))
            {
                newEntry = "Joystick6Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button16))
            {
                newEntry = "Joystick6Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button17))
            {
                newEntry = "Joystick6Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button18))
            {
                newEntry = "Joystick6Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button19))
            {
                newEntry = "Joystick6Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button0))
            {
                newEntry = "Joystick7Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button1))
            {
                newEntry = "Joystick7Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button2))
            {
                newEntry = "Joystick7Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button3))
            {
                newEntry = "Joystick7Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button4))
            {
                newEntry = "Joystick7Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button5))
            {
                newEntry = "Joystick7Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button6))
            {
                newEntry = "Joystick7Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button7))
            {
                newEntry = "Joystick7Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button8))
            {
                newEntry = "Joystick7Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button9))
            {
                newEntry = "Joystick7Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button10))
            {
                newEntry = "Joystick7Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button11))
            {
                newEntry = "Joystick7Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button12))
            {
                newEntry = "Joystick7Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button13))
            {
                newEntry = "Joystick7Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button14))
            {
                newEntry = "Joystick7Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button15))
            {
                newEntry = "Joystick7Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button16))
            {
                newEntry = "Joystick7Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button17))
            {
                newEntry = "Joystick7Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button18))
            {
                newEntry = "Joystick7Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick7Button19))
            {
                newEntry = "Joystick7Button19";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button0))
            {
                newEntry = "Joystick8Button0";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button1))
            {
                newEntry = "Joystick8Button1";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button2))
            {
                newEntry = "Joystick8Button2";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button3))
            {
                newEntry = "Joystick8Button3";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button4))
            {
                newEntry = "Joystick8Button4";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button5))
            {
                newEntry = "Joystick8Button5";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button6))
            {
                newEntry = "Joystick8Button6";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button7))
            {
                newEntry = "Joystick8Button7";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button8))
            {
                newEntry = "Joystick8Button8";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button9))
            {
                newEntry = "Joystick8Button9";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button10))
            {
                newEntry = "Joystick8Button10";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button11))
            {
                newEntry = "Joystick8Button11";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button12))
            {
                newEntry = "Joystick8Button12";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button13))
            {
                newEntry = "Joystick8Button13";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button14))
            {
                newEntry = "Joystick8Button14";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button15))
            {
                newEntry = "Joystick8Button15";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button16))
            {
                newEntry = "Joystick8Button16";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button17))
            {
                newEntry = "Joystick8Button17";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button18))
            {
                newEntry = "Joystick8Button18";
            }
            if (Input.GetKeyDown(KeyCode.Joystick8Button19))
            {
                newEntry = "Joystick8Button19";
            }

        }

        OutputText.text = "Last key pressed: " + lastEntry;
        ButtonPress.text = "last Button: " + newEntry;
    }
}
