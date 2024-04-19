using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitmapLib
{
    public class InputManager
    {
        List<IClickEventReceiver> clickReceivers;

        private static InputManager instance;
        public static InputManager GetInstance()
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }

        public InputManager()
        {
            clickReceivers = new();
        }

        public void AddClickEventReceiver(IClickEventReceiver clickReceiver)
        {
            clickReceivers.Add(clickReceiver);
        }

        public void NotifyClickReceiversOf(MouseEventArgs e)
        {
            clickReceivers.ForEach(x => { x.Receive(e); });
        }
    }
}
