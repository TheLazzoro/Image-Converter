using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public class CustomTooltip
    {
        private static ToolTip tt;

        public static void DisplayTooltip(string text, IWin32Window parent, int durationSeconds = 0)
        {
            if (tt != null)
            {
                tt.Dispose();
            }
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.Show(string.Empty, parent);
            tt.Show(text, parent, durationSeconds * 1000);
        }

        public static void Dispose()
        {
            tt.Dispose();
        }
    }
}
