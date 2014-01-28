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
        internal void ReleaseKey(Keys keyCode)
        {
            if (keyStack == keyCode)
            {
                isReleased = true;
            }
        }
        internal Keys? PullStack()
        {
            Keys? ret = keyStack;
            if (isReleased) keyStack = null;
            return ret;
        }
    }
}
