using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using System.Diagnostics;

namespace PerlinNoise
{
    public partial class GeneratePerlin : Form
    {
        public GeneratePerlin()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void GeneratePerlin_Load(object sender, EventArgs e)
        {
            generateImageInPictureBox(canvas);
        }

        private void GeneratePerlin_Resize(object sender, EventArgs e)
        {
            generateImageInPictureBox(canvas);
        }

        private void generatePerlinButton_Click(object sender, EventArgs e)
        {
            generateImageInPictureBox(canvas);
        }

        private void generateImageInPictureBox(PictureBox pictureBox)
        {
            generateImage(pictureBox.Width, pictureBox.Height, pictureBox);
        }

        private void generateImage(int width, int height, PictureBox pictureBox)
        {
            int[,] pixels = new int[height, width];
            for (int y = 0; y < pixels.GetLength(0); y++)
            {
                for (int x = 0; x < pixels.GetLength(1); x++)
                {
                    pixels[y, x] = 255 * ((y + x) % 2);
                }
            }

            drawImage(pixels, pictureBox);
        }

        private void drawImage(int[,] pixels, PictureBox pictureBox)
        {
            using (var image = new Image<L8>(pixels.GetLength(1), pixels.GetLength(0)))
            {
                for (int y = 0; y < pixels.GetLength(0); y++)
                {
                    Span<L8> pixelRowSpan = image.GetPixelRowSpan(y);
                    for (int x = 0; x < pixels.GetLength(1); x++)
                    {
                        pixelRowSpan[x] = new L8((byte)pixels[y, x]);
                    }
                }

                var stream = new System.IO.MemoryStream();
                image.SaveAsBmp(stream);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                pictureBox.Image?.Dispose();
                pictureBox.Image = img;
            }
        }
    }
}
