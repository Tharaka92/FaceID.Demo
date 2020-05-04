using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceID.Demo.Windows.Azure
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice device;
        Bitmap bitmap;
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        bool isAuthorized = false;
        string displayName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusLbl.ForeColor = Color.Red;
            statusLbl.Text = "UNAUTHORIZED.";

            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filter)
                deviceCmb.Items.Add(device.Name);
            deviceCmb.SelectedIndex = 0;

            device = new VideoCaptureDevice();

            device = new VideoCaptureDevice(filter[deviceCmb.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                bitmap = (Bitmap)eventArgs.Frame.Clone();
                //var localBitmap = (Bitmap)eventArgs.Frame.Clone();
                //pic.Image = bitmap;

                if (isAuthorized)
                {
                    DrawRectangle(Color.Green, string.Empty);
                }
                else
                {
                    DrawRectangle(Color.Red, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.", "Error");
            }
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            statusLbl.ForeColor = Color.Blue;
            statusLbl.Text = "Processing....";
            try
            {
                await FaceService.CreatePersonAsync(nameTxt.Text, string.Empty, GetImage(bitmap));
                statusLbl.ForeColor = Color.Green;
                statusLbl.Text = "Registered";
                MessageBox.Show("Registration Successful.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.", "Error");
            }
        }

        private byte[] GetImage(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                device.Stop();
        }

        private async void loginbtn_Click(object sender, EventArgs e)
        {
            statusLbl.ForeColor = Color.Blue;
            statusLbl.Text = "Processing....";
            try
            {
                var reconizedUsers = await FaceService.RecognizeAsync(GetImage(bitmap));
                if (reconizedUsers.Count > 0)
                {
                    isAuthorized = true;
                    statusLbl.ForeColor = Color.Green;
                    statusLbl.Text = "AUTHORIZED - " + reconizedUsers[0].Name;
                }
                else
                {
                    isAuthorized = false;
                    statusLbl.ForeColor = Color.Red;
                    statusLbl.Text =  "UNAUTHORIZED.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.", "Error");
            }
        }

        private void DrawRectangle(Color color, string name)
        {
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(color, 3))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        using (Font font = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                        {
                            Point point1 = new Point(30, 10);
                            graphics.DrawString(name, font, Brushes.Green, point1);
                        }
                    }
                }
            }
            pic.Image = bitmap;
        }

        private void deviceCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(filter[deviceCmb.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }
    }
}
