using Image_Converter.Forms;
using Image_Converter.IO;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class MainNew : Form
    {
        Color colorActiveButton = Color.FromArgb(255, 124, 10);
        UserControl currentChildControl;
        Button currentMenuButton;
        UserControl importControl;
        UserControl fileListControl;
        UserControl filterControl;
        UserControl exportControl;

        public MainNew()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Text = string.Empty;
            this.ControlBox = false;

            // Default Control
            importControl = new ImportControl();
            currentChildControl = importControl;
            importControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top));
            importControl.AutoSize = false;
            importControl.Size = new Size(panelImport.Width, panelImport.Height);
            panelImport.Controls.Add(importControl);
            importControl.Show();

            fileListControl = new FileListControl();
            currentChildControl = fileListControl;
            fileListControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
            fileListControl.AutoSize = false;
            fileListControl.Size = new Size(panelFileList.Width, panelFileList.Height);
            panelFileList.Controls.Add(fileListControl);
            importControl.Show();

            filterControl = new FilterControl();
            splitContainer.Panel1.Controls.Add(filterControl);
            filterControl.Hide();

            exportControl = new ExportControl();
            panelChildForm.Controls.Add(exportControl);
            exportControl.Hide();

            currentMenuButton = btnImport;
            currentMenuButton.BackColor = colorActiveButton;
            currentMenuButton.FlatAppearance.MouseOverBackColor = colorActiveButton;
        }

        // ------- CUSTOM RESIZE ------- //

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }


        // Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void iconMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void panelTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void UpdateMenuButtonColor(Button button)
        {
            if (currentMenuButton != null)
            {
                currentMenuButton.BackColor = Color.Transparent;
                currentMenuButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            }
            currentMenuButton = button;
            button.BackColor = colorActiveButton;
            button.FlatAppearance.MouseOverBackColor = colorActiveButton;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            panelFileList.Controls.Add(fileListControl); // move file list from export view to import view
            splitContainer.Show();
            panelImport.Show();
            panelFileList.Show();
            exportControl.Hide();
            filterControl.Hide();
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            splitContainer.Show();
            filterControl.Show();
            exportControl.Hide();
            panelImport.Hide();
            panelFileList.Hide();
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportControl.Controls.Add(fileListControl); // move file list from import view to export view
            importControl.Show();
            splitContainer.Hide();
            exportControl.Show();
            UpdateMenuButtonColor((Button)sender);
        }

        ImportControl.OnButtonClickSingle += new EventHandler(UserControl_ButtonClick);

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
        }
    }
}
