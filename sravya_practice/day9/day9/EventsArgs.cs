using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day9
{
    public class ButtonClickedEventArgs : EventArgs
    {
        public string ClickBy { get; }
        public ButtonClickedEventArgs(string ClickBy)
        {
            this.ClickBy = ClickBy;
        }
    }

    public class Button
    {
        public event EventHandler<ButtonClickedEventArgs> ButtonClicked;

        public void Click(string user)
        {
            Console.WriteLine("Event Raised");
            OnButtonClicked(new ButtonClickedEventArgs(user));
        }
        protected virtual void OnButtonClicked(ButtonClickedEventArgs e)
        {
            ButtonClicked.Invoke(this, e);
        }
    }
    class EventsArgs
    {
        public static void Button_ButtonClicked(object sender, ButtonClickedEventArgs e)

        {
            Console.WriteLine($"Button was clicked by :{e.ClickBy}");
        }

        static void Main(string[] args)
        {
            Button button = new Button();
            button.ButtonClicked += Button_ButtonClicked;

            button.Click("Bob");
            button.Click("SRI");
            Console.Read();
        }
    }
}
