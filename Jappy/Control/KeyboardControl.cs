using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Jappy.Control
{
    class KeyboardControl
    {
        private Keys? keyStack;
        private bool isReleased;

        internal void PushKey(Keys keyCode)
        {
            keyStack = keyCode;
            isReleased = false;
        }
        internal void ReleaseKey(KeyEventArgs key)
        {
            if (keyStack == key.KeyCode)
            {
                isReleased = true;
                if (key.Shift) keyStack = null;
            }
        }
        internal Keys? PullStack()
        {
            Keys? ret = keyStack;
            if (isReleased
                || keyStack == Keys.Space) keyStack = null;
            return ret;
        }
    }
}
