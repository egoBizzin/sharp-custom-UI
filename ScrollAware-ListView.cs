using System;
using System.Windows.Forms;

namespace CustomUI
{
    class ScrollAwareListView : ListView
    {
        public event ScrollEventHandler Scroll;
        protected virtual void OnScroll(ScrollEventArgs e)
        {
            ScrollEventHandler handler = this.Scroll;
            if (handler != null) handler(this, e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x115:
                    OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), 0));
                    break;
                default:
                    break;
            }//switch
        }//WndProc
    }//ScrollAwareListView
}//CustomUI