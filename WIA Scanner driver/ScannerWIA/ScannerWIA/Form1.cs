using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScannerWIA
{
    public partial class Form1 : Form
    {
        WIA.ICommonDialog commonDialog;
        WIA.Device scanner;
        List<string> devices;
        WIA.ImageFile scannedImage;
        Byte[] imageBytes;
        Image image;
        WIA.DeviceManager manager;
        /*private const int WIA_DPS_DOCUMENT_HANDLING_SELECT_FEEDER = 1;
        private const int WIA_DPS_DOCUMENT_HANDLING_SELECT_FLATBED = 2;
        private const int WIA_DPS_DOCUMENT_HANDLING_STATUS_FEED_READY = 1;

        private const int WIA_DIP_FIRST = 2;
        private const int WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_IPA_FIRST = WIA_DPS_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_IPC_FIRST = WIA_IPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_IPS_FIRST = WIA_IPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;

        private const int WIA_IPS_PAGES = 3096;
        private const int WIA_RESERVED_FOR_NEW_PROPS = 1024;

        private const int WIA_DPS_PAGE_SIZE = WIA_DPS_FIRST + 23;
        private const int WIA_DPS_PAGE_WIDTH = WIA_DPS_FIRST + 24;
        private const int WIA_DPS_PAGE_HEIGHT = WIA_DPS_FIRST + 25;

        private const int WIA_IPS_ORIENTATION = WIA_IPS_FIRST + 10;
        private const int WIA_IPS_XPOS = WIA_IPS_FIRST + 3;
        private const int WIA_IPS_YPOS = WIA_IPS_FIRST + 4;
        private const int WIA_IPS_XEXTENT = WIA_IPS_FIRST + 5;
        private const int WIA_IPS_YEXTENT = WIA_IPS_FIRST + 6;

        private const int WIA_PAGE_A4 = 0;
        private const int WIA_PAGE_LETTER = 1;
        private const int WIA_PAGE_CUSTOM = 2;

        private const int WIA_PROPERTIES_WIA_RESERVED_FOR_NEW_PROPS = 1024;
        private const int WIA_PROPERTIES_WIA_DIP_FIRST = 2;
        private const int WIA_PROPERTIES_WIA_DPA_FIRST = WIA_PROPERTIES_WIA_DIP_FIRST + WIA_PROPERTIES_WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_PROPERTIES_WIA_DPC_FIRST = WIA_PROPERTIES_WIA_DPA_FIRST + WIA_PROPERTIES_WIA_RESERVED_FOR_NEW_PROPS;

        private const int WIA_PROPERTIES_WIA_DPS_FIRST = WIA_PROPERTIES_WIA_DPC_FIRST + WIA_PROPERTIES_WIA_RESERVED_FOR_NEW_PROPS;
        private const int WIA_PROPERTIES_WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_PROPERTIES_WIA_DPS_FIRST + 13;
        private const int WIA_PROPERTIES_WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_PROPERTIES_WIA_DPS_FIRST + 14;
        private const string WIA_DPS_DOCUMENT_HANDLING_STATUS_STR = "Document Handling Status";
 
        private const double WIA_ERRORS_BASE_VAL_WIA_ERROR = 2149646336;
        private const double WIA_ERRORS_WIA_ERROR_PAPER_EMPTY = WIA_ERRORS_BASE_VAL_WIA_ERROR + 3;

        private const int WIA_IPS_CUR_INTENT = 6146;
        private const int WIA_IPS_XRES = 6147;
        private const int WIA_IPS_YRES = 6148;

        private const int WIA_INTENT_NONE = 0x00000000;
        private const int WIA_INTENT_IMAGE_TYPE_COLOR = 0x00000001;
        private const int WIA_INTENT_IMAGE_TYPE_GRAYSCALE = 0x00000002;
        private const int WIA_INTENT_IMAGE_TYPE_TEXT = 0x00000004;
        private const int WIA_INTENT_IMAGE_TYPE_MASK = 0x0000000F;
        private const int WIA_INTENT_MINIMIZE_SIZE = 0x00010000;
        private const int WIA_INTENT_MAXIMIZE_QUALITY = 0x00020000;
        private const int WIA_INTENT_BEST_PREVIEW = 0x00040000;
        private const int WIA_INTENT_SIZE_MASK = 0x000F0000;
        private const int FEED_READY = 0x01; */

        private const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        private const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        public Form1()
        {
            InitializeComponent();
        }

        private void searchDevices()
        {
            devices = new List<string>();
            manager = new WIA.DeviceManager();
            foreach (WIA.DeviceInfo devInfo in manager.DeviceInfos)
                devices.Add(devInfo.DeviceID);
        }

        private void buttonSearchDev_Click(object sender, EventArgs e)
        {
            searchDevices();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (scanner != null)
                scan(scanner.DeviceID);
            else throw new Exception("Select scanner!");
        }

        private void buttonChooseScanner_Click(object sender, EventArgs e)
        {
            commonDialog = new WIA.CommonDialog();
            scanner = commonDialog.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, true, false);
        }

        void scan(string scannerId)
        {
            scanner = null;
            foreach (WIA.DeviceInfo devInfo in manager.DeviceInfos)
                if (devInfo.DeviceID == scannerId)
                    scanner = devInfo.Connect();
            if (scanner == null) throw new Exception("Selected scanner is unavailable!");

            WIA.Item item = scanner.Items[1];

            try
            {
                commonDialog = null;
                commonDialog = new WIA.CommonDialog();
                scanInit();
                scannedImage = (WIA.ImageFile)commonDialog.ShowTransfer(item, wiaFormatBMP, false);
                imageBytes = (byte[])scannedImage.FileData.get_BinaryData();
                MemoryStream ms = new MemoryStream(imageBytes);
                image = Image.FromStream(ms);
                pbScannedImage.Image = image;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Marshal.ReleaseComObject(scannedImage);
            }
        }

        private void scanInit()
        {
            Object Object1 = null;
            Object Object2 = null;
            Int32 DPI = Convert.ToInt32(textBoxDpi.Text);
            Int32 C = Convert.ToInt32(trackBarContrast.Value);
            Int32 B = Convert.ToInt32(trackBarBrightness.Value);
            try
            {
                Object1 = (Object)WIA_IPS_CUR_INTENT.ToString();// "6146";

                if (radioButtonColor.Checked)
                    Object2 = (Object)WIA_INTENT_IMAGE_TYPE_COLOR;
                else
                    Object2 = (Object)WIA_INTENT_IMAGE_TYPE_GRAYSCALE;
                scanner.Items[1].Properties.get_Item(ref Object1).set_Value(ref Object2);

                Object1 = (Object)"6147";
                Object2 = (Object)DPI;
                scanner.Items[1].Properties.get_Item(ref Object1).set_Value(ref Object2);

                Object1 = (Object)"6148";
                Object2 = (Object)DPI;
                scanner.Items[1].Properties.get_Item(ref Object1).set_Value(ref Object2);

                Object1 = (Object)(WIA_IPS_FIRST + 9).ToString();
                Object2 = (Object)C;
                scanner.Items[1].Properties.get_Item(ref Object1).set_Value(ref Object2);

                Object1 = (Object)(WIA_IPS_FIRST + 8).ToString();
                Object2 = (Object)B;
                scanner.Items[1].Properties.get_Item(ref Object1).set_Value(ref Object2);
            }
            catch
            {
                MessageBox.Show("Skaner nie jest gotowy lub nie obsługuje tej funkcji.\r\n\r\n Przywrócono ustawienia domyślne.", "Inicjalizacja",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Object1 = null;
            Object2 = null;
        }

        private void radioButtonColor_Checked(object sender, EventArgs e)
        {
            if (radioButtonColor.Checked == true)
            {
                radioButtonColor.CheckedChanged -= new
                         EventHandler(this.radioButtonColor_Checked);
                radioButtonGrayscale.CheckedChanged -= new
                        EventHandler(this.radSelCols_Checked);
                radioButtonColor.Checked = false;
                radioButtonGrayscale.Checked = true;
                radioButtonColor.CheckedChanged += new
                         EventHandler(this.radioButtonColor_Checked);
                radioButtonGrayscale.CheckedChanged += new
                        EventHandler(this.radSelCols_Checked);
            }
        }

        private void radSelCols_Checked(object sender, EventArgs e)
        {
            if (radioButtonGrayscale.Checked == true)
            {
                radioButtonColor.CheckedChanged -= new
                         EventHandler(this.radioButtonColor_Checked);
                radioButtonGrayscale.CheckedChanged -= new
                        EventHandler(this.radSelCols_Checked);
                radioButtonGrayscale.Checked = false;
                radioButtonColor.Checked = true;
                radioButtonColor.CheckedChanged += new
                         EventHandler(this.radioButtonColor_Checked);
                radioButtonGrayscale.CheckedChanged += new
                        EventHandler(this.radSelCols_Checked);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pbScannedImage.Image != null)
            {
                Bitmap image = (Bitmap) pbScannedImage.Image;
                saveFileDialog.Filter = "Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();
                System.IO.FileStream fs = (System.IO.FileStream) saveFileDialog.OpenFile();
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                fs.Close();
                MessageBox.Show("Saved!");
            }
        }
    }
}
