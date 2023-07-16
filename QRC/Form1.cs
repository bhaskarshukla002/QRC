using QRCoder;
using System;

using System.Drawing;

using System.Windows.Forms;

namespace QRC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeRackComboBox();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float borderGap = 5.6f;  // qr border gap;
            int gappixel = 0;   // x - axis error gap in mm 
            int ygappixel = 23; // y -axis gap enter here in mm
            int flag = 0;
            string selectedRow; // selected Row Item
            string selectedRack;// selected Rack Item
            int selectedSpace;  // selected Space or gap in  mm
            int qrQuantity;     // selected qr Quanity
            //
            // dpi , resolution setting
            float mmpi = 25.4f;
            int dpi = 150;
            
            if (validate()) {   // function to validate selected values
                //
                // getting selected values
                selectedRow = rowCB.SelectedItem.ToString(); 
                selectedRack = rackCB.SelectedItem.ToString();
                selectedSpace = (int)spaceInput.Value;
                //
                //
                qrQuantity = 50;
                //
                // converting mm into pixel acc to dpi
                borderGap = (int)((borderGap * dpi) / 25.4);
                gappixel = (int)((selectedSpace * dpi) / 25.4);
                gappixel = gappixel + (int)borderGap;
                ygappixel = (int)((ygappixel * dpi) / 25.4);
                //
                // qr position variavles
                int xpos = 8, ypos = 0;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                //
                // a4 size bitmap
                Bitmap A4 = new Bitmap((int)(297 / mmpi * dpi), (int)( 210 / mmpi * dpi));
                A4.SetResolution(dpi, dpi);
                Graphics g = Graphics.FromImage(A4);
                //
                // for string under QR
                Font font = new Font(FontFamily.GenericMonospace.Name, 10);
                Brush brush = Brushes.Black;
                //
                // loop to generate and aad qr to bitmap
                for (int i = 1; i <=qrQuantity; i++) {
                    String currQRString = selectedRack + selectedRow + (i).ToString("D2");
                    Bitmap currQRBitmap = getQRBitmap(qrGenerator, currQRString);
                    //
                    // Draw QR on a4 size bitmap 
                    g.DrawImage(currQRBitmap, xpos, ypos);
                    //
                    // Draw the text on the bitmap
                    int textX = xpos + (currQRBitmap.Width) / 2 ;
                    int textY = ypos + currQRBitmap.Height + (int)borderGap + 8;
                    g.DrawString((i).ToString("D2"), font, brush, textX, textY);

                    if (xpos+currQRBitmap.Width + gappixel + currQRBitmap.Width > A4.Width )
                    {
                        if (ypos + currQRBitmap.Height + ygappixel + currQRBitmap.Height > A4.Height)
                        {
                            break;
                        }
                        else
                        {
                            flag = 1;
                            
                            ypos = ypos + currQRBitmap.Height + ygappixel;
                            g.DrawString("Rack : " + selectedRack + ", Row : " + selectedRow, new Font(FontFamily.GenericMonospace.Name, 10), brush, xpos / 2, textY+(ygappixel / 4));

                            xpos = 8;
                        }
                    }else if ( (i) % 10 == 0 && flag==0)
                    {
                        if (ypos + currQRBitmap.Height + ygappixel + currQRBitmap.Height > A4.Height)
                        {
                            break;
                        }
                        else
                        {
                            
                            ypos = ypos + currQRBitmap.Height + ygappixel;
                            g.DrawString("Rack : " + selectedRack + ", Row : " + selectedRow, new Font(FontFamily.GenericMonospace.Name, 10), brush, xpos / 2, textY+(ygappixel/4));
                            xpos = 8;
                        }

                    }
                    else
                    {
                        xpos = xpos + currQRBitmap.Width + gappixel;
                    }
                }
                g.DrawString("#Rack : "+ selectedRack + ", Row : " + selectedRow  , new Font(FontFamily.GenericMonospace.Name, 14), brush, 8, 1200);
                pictureBox1.Image = A4;
                //QRCodeGenerator qrGenerator = new QRCodeGenerator();
                //QRCodeData qrCodeData = qrGenerator.CreateQrCode("A001.", QRCodeGenerator.ECCLevel.Q);
                //QRCode qrCode = new QRCode(qrCodeData);

                //QRCodeData qrCodeData2 = qrGenerator.CreateQrCode("A002", QRCodeGenerator.ECCLevel.Q);
                //QRCode qrCode2 = new QRCode(qrCodeData);

                //Bitmap qr1 = qrCode.GetGraphic(2);
                //Bitmap qr2 = qrCode2.GetGraphic(2);


                //Bitmap bitmap = new Bitmap(qr1.Width * 20, qr1.Height);

                //        using (Graphics g = Graphics.FromImage(bitmap))
                //          {
                //            g.DrawImage(qr1, 0, 0);
                //              g.DrawImage(qr2, qr1.Width + gappixel, 0);

                //                pictureBox1.Image = bitmap;
                //}

            }
            


        }

        private Bitmap getQRBitmap(QRCodeGenerator qrGenerator,String qrCodeString) 
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrBitmap = qrCode.GetGraphic(2);
            return qrBitmap;
        }

        private Boolean validate()
        {
            if (rackCB.SelectedItem != null && rowCB.SelectedItem != null)
            { 
                return true;
            }
            else
            {
                MessageBox.Show("Please select all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2Clicked(object sender, EventArgs e)
        {
            // Save the image in the PictureBox as a PNG file
            if (pictureBox1.Image != null)
            {
                // SaveFileDialog for selecting the save location
                float mmpi = 25.4f;
                int dpi = 150 ;
                Bitmap bitmap = new Bitmap((int)(297 / mmpi * dpi), (int)(210 / mmpi * dpi));
                bitmap.SetResolution(dpi, dpi);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);

                    // Draw the PictureBox image onto the Bitmap
                    graphics.DrawImage(pictureBox1.Image, 0, 0);
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png";
                    saveFileDialog.Title = "Save Image";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                    saveFileDialog.FileName = rackCB.SelectedItem.ToString() + rowCB.SelectedItem.ToString() + ".png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Save the image as a PNG file
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                        MessageBox.Show("Image Saved Successfully.","Message", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Can not find /n enviroment variable for download Folder.", "Error", MessageBoxButtons.RetryCancel);
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to save.","Error",MessageBoxButtons.OK);
            }
        }
    }
}


