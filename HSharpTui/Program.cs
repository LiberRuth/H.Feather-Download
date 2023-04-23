using Terminal.Gui;

namespace HSharpTui.hitomi
{
    internal class Program
    {

        public static TextView editor { get; set; }

        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            var win = new Window("H.Feather-Download")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(win);

            var label = new Label(" 로그 ")
            {
                X = 2,
                Y = 1,
            };
            win.Add(label);

            editor = new TextView()
            {
                X = 2,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 7, 
                ReadOnly = true,
            };
            win.Add(editor);
 
            var gap1 = new Label("")
            {
                X = 0,
                Y = Pos.Bottom(editor),
            };
            win.Add(gap1);
 
            var nameLabel = new Label("번호 입력")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(gap1) + 1, 
            };
            win.Add(nameLabel);

            var gap2 = new Label("")
            {
                X = 0,
                Y = Pos.Bottom(nameLabel),
            };
            win.Add(gap2);
  
            var textField = new TextField("")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(gap2) + 1, 
                Width = 50,
            };
            win.Add(textField);

            var gap3 = new Label("")
            {
                X = 0,
                Y = Pos.Bottom(textField),
            };
            win.Add(gap3);
     
            var button = new Button(" OK ")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(gap3) + 1,
            };
            win.Add(button);
            
            button.Clicked += async () => {
                string inputStr = $"{textField.Text}";
                bool isNumber = int.TryParse(inputStr, out _);
                if (isNumber == false) {
                    MessageBox.Query("실패", $" {textField.Text} 이것은 문자열입니다.\n 숫자를 입력하세요.", "OK");
                    return;
                }  
                // editor.Text += $"{textField.Text}\n";
                int numberText = Convert.ToInt32(textField.Text);
                await HitomiWebp.HitomiDownload(numberText);
            };

            Application.Run();

        }
    }
}