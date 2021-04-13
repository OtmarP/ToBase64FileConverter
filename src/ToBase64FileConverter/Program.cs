using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToBase64FileConverter
{
    class Program
    {
        // ****************************
        // Di.13.04.2021 12:22:57 -op- to GitHub, mit bool dispOpenFileDialog
        // Do.08.04.2021 18:58:00 -op- mit args als File-Input-Parameter
        // Do.08.04.2021 18:08:00 -op- Created (FW45)
        // ****************************

        [STAThread]
        static void Main(string[] args)
        {
            string fileName = "";

            bool dispOpenFileDialog = true;
            if (args.Length > 0)
            {
                string file = args[0];
                if (File.Exists(file))
                {
                    fileName = file;
                    dispOpenFileDialog = false;
                }
            }

            if (dispOpenFileDialog) {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }
            }

            if (fileName != "")
            {
                try
                {
                    DumpBase64(fileName, fileName + ".txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                }
            }
        }

        private static void DumpBase64(string binaryFile, string base64DumpFile)
        {
            byte[] asBytes = File.ReadAllBytes(binaryFile);
            string asBase64String = Convert.ToBase64String(asBytes);

            byte[] asBase64Bytes = new byte[asBase64String.Length];
            for (int i = 0; i < asBase64String.Length; i++)
            {
                asBase64Bytes[i] = (byte)asBase64String[i];
                Console.Write(asBase64Bytes[i]);
            }

            File.WriteAllBytes(base64DumpFile, asBase64Bytes);
        }
    }
}
