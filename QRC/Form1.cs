using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int gappixel = 0;
            int ygappixel = 0;
            string selectedRow;
            string selectedRack;
            int selectedSpace;
            int qrQuantity;
            
            float mmpi = 25.4f;
            int dpi = 150;
            if (validate()) { 
                selectedRow = rowCB.SelectedItem.ToString();
                selectedRack = rackCB.SelectedItem.ToString();
                selectedSpace = (int)spaceInput.Value;
                qrQuantity = 50;
                gappixel = (int)((selectedSpace * dpi) / 25.4);
                ygappixel = (int)((7 * dpi) / 25.4);
                int xpos = 0, ypos = 0;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                Bitmap A4 = new Bitmap((int)(297 / mmpi * dpi), (int)( 210 / mmpi * dpi));
                A4.SetResolution(dpi, dpi);
                Graphics g = Graphics.FromImage(A4);
                

                for (int i = 0; i < qrQuantity; i++) {
                    String currQRString = selectedRack + selectedRow + (i<10 ? "0" : "") + (i+1).ToString();
                    Bitmap qrBitmap = getQRBitmap(qrGenerator, currQRString);
                    g.DrawImage(qrBitmap, xpos, ypos);
                    if (xpos + ((qrBitmap.Width + gappixel)*2) > A4.Width)
                    {
                        if (ypos + ((qrBitmap.Height + ygappixel) * 2) > A4.Height)
                        {
                            break;
                        }
                        else
                        {
                            ypos = ypos + qrBitmap.Height + ygappixel;
                            xpos = 0;
                        }
                    }
                    else
                    {
                        xpos = xpos + qrBitmap.Width + gappixel;
                    }
                }
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
    }
}


