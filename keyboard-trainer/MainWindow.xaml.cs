using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


namespace keyboard_trainer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        //keyPressEvent
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            bool isSetLetterCase = SetLetterCase(e.Key);
            Label currentLabel = SetBackgroundKey(e.Key, true);
            if (currentLabel != null)
            {
                var ara = block.Inlines;

            }

        }

        //keyOutEvent 
        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {

            bool isSetLetterCase = SetLetterCase(e.Key);
            Label currentLabel = SetBackgroundKey(e.Key, false);

        }

        //Нажатие на кнопку Start
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
          string generatedString = GenerateString(Convert.ToInt32(diffLabel.Content), (bool)checkBoxCaseSensivity.IsChecked);
          block.Text = generatedString;
        }

        //событие движения слайдера и записи значения в назначенный label
        private void DiffSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            diffLabel.Content = diffSlider.Value;
        }



        //метод для установки фона на нажатые клавиши
        private Label SetBackgroundKey(Key pressedKey, bool isDown)
        {
            Key[][] keys = Presets.GetKeyboardPresetKeyEng();
            for (int i = 0; i < keys.Length; i++)
            for (int j = 0; j < keys[i].Length; j++)
            {
                if (pressedKey == keys[i][j])
                {
                    StackPanel currentStackPanel = (StackPanel) KeyBoardGrid.Children[i];
                    Border currentBorder = (Border) currentStackPanel.Children[j];
                    Label currentLabel = (Label) currentBorder.Child;
                    if (isDown)
                    {
                        currentLabel.Background = new SolidColorBrush(Colors.DimGray);
                        currentLabel.Foreground = new SolidColorBrush(Colors.White);

                    }
                    else 
                    { 
                        currentLabel.Background = null;
                        currentLabel.Foreground = new SolidColorBrush(Colors.Black);
                    }

                    return currentLabel;
                }
            }
            return null;
        }

        //метод для изменения регистра символов на Shift и CapsLock
        private bool SetLetterCase(Key pressedKey)
        {
            if (pressedKey == Key.CapsLock || pressedKey == Key.LeftShift || pressedKey == Key.RightShift)
            {
                bool isCapsLockOn = Keyboard.IsKeyToggled(Key.CapsLock);
                bool isShiftOn = Keyboard.IsKeyDown(Key.RightShift) || Keyboard.IsKeyDown(Key.LeftShift);

                foreach (StackPanel currentRow in KeyBoardGrid.Children)
                foreach (Border a in currentRow.Children)
                {
                    var label = (Label)a.Child;
                    if (label.Content.ToString().Length > 1) continue;
                    if ((isCapsLockOn && !isShiftOn) || (!isCapsLockOn && isShiftOn))
                      switch (label.Content.ToString())
                            {
                                case "0": { label.Content = ")"; break; }
                                case "1": { label.Content = "!"; break; }
                                case "2": { label.Content = "@"; break; }
                                case "3": { label.Content = "#"; break; }
                                case "4": { label.Content = "$"; break; }
                                case "5": { label.Content = "%"; break; }
                                case "6": { label.Content = "^"; break; }
                                case "7": { label.Content = "&"; break; }
                                case "8": { label.Content = "*"; break; }
                                case "9": { label.Content = "("; break; }
                                case "-": { label.Content = "_"; break; }
                                case "=": { label.Content = "+"; break; }
                                case "`": { label.Content = "~"; break; }
                                case "[": { label.Content = "{"; break; }
                                case "]": { label.Content = "}"; break; }
                                case ";": { label.Content = ":"; break; }
                                case "\\":{ label.Content = "|"; break;}
                                case ",": { label.Content = "<"; break; }
                                case "'": { label.Content = "\""; break; }
                                case ".": { label.Content = ">"; break; }
                                case "/": { label.Content = "?"; break; }
                                default: { label.Content = label.Content.ToString().ToUpper(); break; }
                            }
                    else switch (label.Content.ToString())
                    {
                        case ")": { label.Content = "0"; break; }
                        case "!": { label.Content = "1"; break; }
                        case "@": { label.Content = "2"; break; }
                        case "#": { label.Content = "3"; break; }
                        case "$": { label.Content = "4"; break; }
                        case "%": { label.Content = "5"; break; }
                        case "^": { label.Content = "6"; break; }
                        case "&": { label.Content = "7"; break; }
                        case "*": { label.Content = "8"; break; }
                        case "(": { label.Content = "9"; break; }
                        case "_": { label.Content = "-"; break; }
                        case "+": { label.Content = "="; break; }
                        case "~": { label.Content = "`"; break; }
                        case "{": { label.Content = "["; break; }
                        case "}": { label.Content = "]"; break; }
                        case ":": { label.Content = ";"; break; }
                        case "|": { label.Content = "\\"; break; }
                        case "\"": { label.Content = "'"; break; }
                        case "<": { label.Content = ","; break; }
                        case ">": { label.Content = "."; break; }
                        case "?": { label.Content = "/"; break; }
                        default: { label.Content = label.Content.ToString().ToLower(); break; }
                    }
                }
                return true;
            }
            return false;
        }

        //для генерации строки
        private string GenerateString(int difficult, bool isCaseSensitive)
        {
            string generatedString = "";
            Random random = new Random();
            int countWord = random.Next(7, 20);
            for (int i = 0; i < countWord; i++)
            {
                int lenghtWord = random.Next(2, 7);
                for (int j = 0; j < lenghtWord; j++)
                {
                    char genChar = isCaseSensitive ? Convert.ToChar(97 - (32 * random.Next(0, 2)) + random.Next(0, difficult)) : Convert.ToChar(97 + random.Next(0, difficult));
                    generatedString += genChar;
                }
                generatedString += " ";
            }

            return generatedString;
        }

        //
        //private bool CheckCorrectness(string currentLabelOnKey, string currentSym)



    }
    
}
