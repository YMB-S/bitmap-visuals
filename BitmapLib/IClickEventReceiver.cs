﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitmapLib
{
    public interface IClickEventReceiver
    {
        public void Receive(Vector2 clickPosition, MouseEventArgs e);
    }
}