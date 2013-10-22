using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Encrypter : Form
    {
        public Encrypter()
        {
            InitializeComponent();
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        private void Encrypter_Load(object sender, EventArgs e)
        {
            blockSizeComboBox.SelectedIndex = 0;
            nComboBox.SelectedIndex = 0;
            lComboBox.SelectedIndex = 0;
            rComboBox.SelectedIndex = 0;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Stream inputFileStream;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFileStream = openFileDialog.OpenFile()) != null)
                    {
                        using (inputFileStream)
                        {
                            statusLabel.Text = "The file successfully opened.";
                            inputFileTextBox.Text = openFileDialog.FileName;
                            encrypterGroupBox.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            // Now read s into a byte buffer.
            int blockSize = (int)Math.Pow(Convert.ToDouble(2), Convert.ToDouble(4 + blockSizeComboBox.SelectedIndex));
            Stream inputFileStream = openFileDialog.OpenFile();
            byte[] bytes = new byte[blockSize];
            int numBytesToRead = (int)inputFileStream.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to 10.
                int n = inputFileStream.Read(bytes, numBytesRead, blockSize);
                // The end of the file is reached.
                if (n == 0)
                {
                    break;
                }
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes("sss", encrypter.Key, encrypter.IV);
                numBytesRead += n;
                numBytesToRead -= n;
            }
        }

        private void generateKeyButton_Click(object sender, EventArgs e)
        {
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                keyTextBox.Text = Convert.ToBase64String(myAes.Key);
                encrypter = myAes;

                encryptButton.Enabled = true;
            }
        }
    }
}
