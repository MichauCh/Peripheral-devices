using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Limilabs.Barcode;
using System.Drawing.Printing;

namespace BarCodePrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            BaseBarcode barcode = BarcodeFactory.GetBarcode(Symbology.EAN13);
            barcode.Number = tbEan.Text;
            if (cbControlSum.Checked == true)
                barcode.ChecksumAdd = true;
            else barcode.ChecksumAdd = false;
            pbBarCode.Image = barcode.Render();
            barcode.Save("barcode.png", ImageType.Png);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintGeneratedBarcode;
            printDocument.Print();
        }

        private static void PrintGeneratedBarcode(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile("barcode.png");
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(image, loc);
        }
    }
}