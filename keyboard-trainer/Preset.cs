
using System.Windows.Input;

namespace keyboard_trainer
{

    struct Presets
    {
        public static Key[][] GetKeyboardPresetKeyEng()
        {
            const int rows = 5;
            Key[][] buttonContentsEng = new Key[rows][];
            buttonContentsEng[0] = new Key[] { Key.Oem3, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.D0, Key.OemMinus, Key.OemPlus, Key.Back };
            buttonContentsEng[1] = new Key[] { Key.Tab, Key.Q, Key.W, Key.E, Key.R, Key.T, Key.Y, Key.U, Key.I, Key.O, Key.P, Key.OemOpenBrackets, Key.Oem6, Key.Oem3 };
            buttonContentsEng[2] = new Key[] { Key.CapsLock, Key.A, Key.S, Key.D, Key.F, Key.G, Key.H, Key.J, Key.K, Key.L, Key.Oem1, Key.OemQuotes, Key.Enter };
            buttonContentsEng[3] = new Key[] { Key.LeftShift, Key.Z, Key.X, Key.C, Key.V, Key.B, Key.N, Key.M, Key.OemComma, Key.OemPeriod, Key.OemQuestion, Key.RightShift };
            buttonContentsEng[4] = new Key[] { Key.LeftCtrl, Key.LWin, Key.LeftAlt, Key.Space, Key.RightAlt, Key.RWin, Key.RightCtrl };
            return buttonContentsEng;
        }
    }
}
