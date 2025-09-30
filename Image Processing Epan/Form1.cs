using Image_Processing.Libraries;
using System.Drawing.Imaging;
using WebCamLib;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap imageB, imageA;
        int imgProcessingType = 1;

        private Device[] devices;
        private Device webcam;

        public Form1()
        {
            InitializeComponent();
            pictureBox3.Visible = false;
            button1.Visible = false; ; button2.Visible = false; ; button3.Visible = false;
            this.Size = new Size(816, 358);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcam != null)
            {
                webcam.Stop();
                webcam = null;
            }

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;

            imgProcessingType = 1;

            imageManupulationToolStripMenuItem.Visible = false;
            loadToolStripMenuItem.Visible = false;
            imageToolStripMenuItem.Visible = false;



            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            button1.Visible = false; ; button2.Visible = false; ; button3.Visible = false;
            this.Size = new Size(423, 450);


            devices = DeviceManager.GetAllDevices();

            if (devices.Length > 0)
            {
                webcam = devices[0];
                webcam.ShowWindow(pictureBox1);

                pictureBox1.Refresh();
            }
            else
            {
                MessageBox.Show("No webcam found.");
            }
        }

        private void imageManipulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcam != null)
            {
                webcam.Stop();
                webcam = null;
            }

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;

            imgProcessingType = 1;

            imageManupulationToolStripMenuItem.Visible = true;
            loadToolStripMenuItem.Visible = true;
            imageToolStripMenuItem.Visible = true;


            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            button1.Visible = false; ; button2.Visible = false; ; button3.Visible = false;
            this.Size = new Size(816, 358);
        }

        private void imageSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcam != null)
            {
                webcam.Stop();
                webcam = null;
            }
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;

            imgProcessingType = 2;

            imageManupulationToolStripMenuItem.Visible = false;
            loadToolStripMenuItem.Visible = false;
            imageToolStripMenuItem.Visible = true;

            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            button1.Visible = true; ; button2.Visible = true; ; button3.Visible = true;
            this.Size = new Size(1210, 489);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(pictureBox1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgProcessingType == 1)
            {
                if (pictureBox2.Image == null)
                {
                    MessageBox.Show("No image to save.");
                    return;
                }
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    sfd.Title = "Save an Image File";
                    sfd.FileName = "image";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                        switch (sfd.FilterIndex)
                        {
                            case 1:
                                format = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case 2:
                                format = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case 3:
                                format = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                        }
                        pictureBox2.Image.Save(sfd.FileName, format);
                    }
                }
            }
            else if (imgProcessingType == 2)
            {
                if (pictureBox3.Image == null)
                {
                    MessageBox.Show("No image to save.");
                    return;
                }
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    sfd.Title = "Save an Image File";
                    sfd.FileName = "image";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                        switch (sfd.FilterIndex)
                        {
                            case 1:
                                format = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case 2:
                                format = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case 3:
                                format = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                        }
                        pictureBox3.Image.Save(sfd.FileName, format);
                    }
                }
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            else
                pictureBox2.Image = new Bitmap(pictureBox1.Image);
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Bitmap grayBitmap = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < grayBitmap.Height; y++)
            {
                for (int x = 0; x < grayBitmap.Width; x++)
                {
                    Color c = grayBitmap.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    grayBitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = grayBitmap;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Bitmap grayBitmap = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < grayBitmap.Height; y++)
            {
                for (int x = 0; x < grayBitmap.Width; x++)
                {
                    Color c = grayBitmap.GetPixel(x, y);
                    // gray = (c.R + c.G + c.B) / 3;
                    Color newColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    grayBitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = grayBitmap;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Bitmap grayBitmap = new Bitmap(pictureBox1.Image);
            int[] histogram = new int[256];

            for (int y = 0; y < grayBitmap.Height; y++)
            {
                for (int x = 0; x < grayBitmap.Width; x++)
                {
                    Color c = grayBitmap.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    histogram[gray]++;
                }
            }
            int histHeight = pictureBox2.Height;
            int histWidth = pictureBox2.Width;
            Bitmap histBitmap = new Bitmap(histWidth, histHeight);
            int max = histogram.Max();
            for (int i = 0; i < histogram.Length; i++)
            {
                int histValue = (int)((histogram[i] / (float)max) * histHeight);
                for (int j = histHeight - 1; j >= histHeight - histValue; j--)
                {
                    if (i < histWidth)
                    {
                        histBitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }
            pictureBox2.Image = histBitmap;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Bitmap grayBitmap = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < grayBitmap.Height; y++)
            {
                for (int x = 0; x < grayBitmap.Width; x++)
                {
                    Color c = grayBitmap.GetPixel(x, y);
                    // gray = (c.R + c.G + c.B) / 3;

                    int Red = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int Green = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int Blue = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    Red = (Red > 255) ? 255 : Red;
                    Green = (Green > 255) ? 255 : Green;
                    Blue = (Blue > 255) ? 255 : Blue;


                    Color newColor = Color.FromArgb(Red, Green, Blue);
                    grayBitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = grayBitmap;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageB = LoadImagee(pictureBox1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            imageA = LoadImagee(pictureBox2);
        }

        private void LoadImage(PictureBox p)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                p.Image = new Bitmap(ofd.FileName);
            }
        }
        private Bitmap LoadImagee(PictureBox p)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                p.Image = new Bitmap(ofd.FileName);
                return new Bitmap(p.Image);
            }
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || pictureBox2.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Color mygreen = Color.FromArgb(0, 255, 0);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 30;

            int width = Math.Min(imageA.Width, imageB.Width);
            int height = Math.Min(imageA.Height, imageB.Height);
            Bitmap resultImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);

                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if (subtractvalue < threshold && pixel.G > pixel.R && pixel.G > pixel.B)
                        resultImage.SetPixel(x, y, backpixel);
                    else
                        resultImage.SetPixel(x, y, pixel);
                }
            }
            pictureBox3.Image = resultImage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gaussianBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap processed = new Bitmap(bitmap);

            ConvMatrix m = new ConvMatrix();
            m.setMatrix(1, 2, 1,
                        2, 4, 2,
                        1, 2, 1,
                        16);
            BitmapFilter.Conv3x3(processed, m);

            pictureBox2.Image = processed;
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap processed = new Bitmap(bitmap);

            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = 1;
            m.Factor = 1 + 8;
            BitmapFilter.Conv3x3(processed, m);

            pictureBox2.Image = processed;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap processed = new Bitmap(bitmap);

            ConvMatrix m = new ConvMatrix();
            m.setMatrix(0, -2, 0,
                        -2, 11, -2,
                        0, -2, 0,
                        3);
            BitmapFilter.Conv3x3(processed, m);

            pictureBox2.Image = processed;
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap processed = new Bitmap(bitmap);

            ConvMatrix m = new ConvMatrix();
            m.setMatrix(-1, -1, -1,
                        -1, 9, -1,
                        -1, -1, -1,
                        1);
            BitmapFilter.Conv3x3(processed, m);

            pictureBox2.Image = processed;
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap processed = new Bitmap(bitmap);

            ConvMatrix m = new ConvMatrix();
            m.setMatrix(-1, 0, -1,
                        0, 4, 0,
                        -1, 0, -1,
                        1, 127);
            BitmapFilter.Conv3x3(processed, m);

            pictureBox2.Image = processed;
        }

        private void imageManupulationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void horzVertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap processed = new Bitmap(bitmap);

                ConvMatrix m = new ConvMatrix();
                m.setMatrix(0, -1, 0,
                        -1, 4, -1,
                        0, -1, 0,
                        1, 127);
                BitmapFilter.Conv3x3(processed, m);

                pictureBox2.Image = processed;
            }
        }

        private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap processed = new Bitmap(bitmap);

                ConvMatrix m = new ConvMatrix();
                m.setMatrix(-1, -1, -1,
                        -1, 8, -1,
                        -1, -1, -1,
                        1, 127);
                BitmapFilter.Conv3x3(processed, m);

                pictureBox2.Image = processed;
            }
        }

        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap processed = new Bitmap(bitmap);

                ConvMatrix m = new ConvMatrix();
                m.setMatrix(1, -2, 1,
                        -2, 4, -2,
                        -2, 1, -2,
                        1, 128);
                BitmapFilter.Conv3x3(processed, m);

                pictureBox2.Image = processed;
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap processed = new Bitmap(bitmap);

                ConvMatrix m = new ConvMatrix();
                m.setMatrix(0, 0, 0,
                        -1, 2, -1,
                        0, 0, 0,
                        1, 127);
                BitmapFilter.Conv3x3(processed, m);

                pictureBox2.Image = processed;
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap processed = new Bitmap(bitmap);

                ConvMatrix m = new ConvMatrix();
                m.setMatrix(0, -1, 0,
                        0, 0, 0,
                        0, 1, 0,
                        1, 127);
                BitmapFilter.Conv3x3(processed, m);

                pictureBox2.Image = processed;
            }
        }
    }
}
