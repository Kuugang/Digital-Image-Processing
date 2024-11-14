using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
namespace Image_Processing.WebCamLib
{
    public class Device
    {
        private const int WM_CAP = 0x400;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;

        private const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        private const int WM_CAP_SET_OVERLAY = WM_CAP + 51;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;

        private const int WM_CAP_EDIT_COPY = WM_CAP + 30;
        private const int WM_CAP_SET_SCALE = 0x435;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CAP_SEQUENCE = WM_CAP + 62;
        private const int WM_CAP_FILE_SAVEAS = WM_CAP + 23;
        private const int SWP_NOMOVE = 0x20;
        private const int SWP_NOSIZE = 1;
        private const int SWP_NOZORDER = 0x40;
        private const int HWND_BOTTOM = 1;


        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(int adress);

        [DllImport("avicap32.dll")]
        protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName,
            int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //protected static void capPreviewRate(int hwd, int rate);

        //protected static void capPreview(int hwnd, int f);


        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);

        int index;
        int deviceHandle;

        public Device()
        {
            //just a simple constructor
        }
        public Device(int index)
        {
            this.index = index;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
        /// <summary>
        /// To Initialize the device
        /// </summary>
        /// <param name="windowHeight">Height of the Window</param>
        /// <param name="windowWidth">Width of the Window</param>
        /// <param name="handle">The Control Handle to attach the device</param>
        public void Init(int windowHeight, int windowWidth, int handle)
        {
            string deviceIndex = Convert.ToString(this.index);
            deviceHandle = capCreateCaptureWindowA(ref deviceIndex, WS_VISIBLE | WS_CHILD, 0, 0, windowWidth, windowHeight, handle, 0);

            MessageBox.Show("Connecting");
            try
            {

                if (SendMessage(deviceHandle, WM_CAP_DRIVER_CONNECT, this.index, 0L) > 0)
                {
                    SendMessage(deviceHandle, WM_CAP_SET_SCALE, -1, 0L);
                    SendMessage(deviceHandle, WM_CAP_SET_PREVIEWRATE, 100, 0L);
                    SendMessage(deviceHandle, WM_CAP_SET_PREVIEW, 1, 0L);
                    SetWindowPos(deviceHandle, 1, 0, 0, windowWidth, windowHeight, 6);
                }
                else
                {
                    MessageBox.Show("ASD");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Shows the webcam preview in the control
        /// </summary>
        /// <param name="windowsControl">Control to attach the webcam preview</param>
        ///                    global::  
        public void ShowWindow(System.Windows.Forms.Control windowsControl)
        {
            Init(windowsControl.Height, windowsControl.Width, windowsControl.Handle.ToInt32());
        }

        /// <summary>
        /// Stop the webcam and destroy the handle
        /// </summary>
        public void Stop()
        {
            SendMessage(deviceHandle, WM_CAP_DRIVER_DISCONNECT, this.index, 0);
            DestroyWindow(deviceHandle);
        }
        public void Sendmessage()
        {
            SendMessage(deviceHandle, WM_CAP_EDIT_COPY, 0, 0);
        }

        public Bitmap GetFrame()
        {
            SendMessage(deviceHandle, WM_CAP_EDIT_COPY, 0, 0);
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject == null)
            {
                return null;
            }
            Bitmap bmp = (Bitmap)dataObject.GetData(DataFormats.Bitmap);
            return bmp;
        }
    }
}
