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

namespace MCOS
{
    public partial class Encrypter : Form
    {
        public Encrypter()
        {
            InitializeComponent();
        }

		public byte[] XOR(byte[] buffer1, byte[] buffer2)
		{
			for(int i = 0; i < buffer1.Length; i++)
				buffer1[i] ^= buffer2[i];
			return buffer1;
		}

        static byte[] EncryptStringToBytes_Aes(byte[] inputBytes, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (inputBytes == null || inputBytes.Length <= 0)
                throw new ArgumentNullException("inputBytes");
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
                            swEncrypt.Write(inputBytes);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static byte[] DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.None;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            byte[] result = Convert.FromBase64String(plaintext);

            return result;

        }

        private void Encrypter_Load(object sender, EventArgs e)
        {
            blockSizeComboBox.SelectedIndex = 0;
            nComboBox.SelectedIndex = 0;
            lComboBox.SelectedIndex = 0;
            rComboBox.SelectedIndex = 0;
            DBlockSizeComboBox.SelectedIndex = 0;
            DDelayLComboBox.SelectedIndex = 0;
            DDelayNComboBox.SelectedIndex = 0;
            DDelayRComboBox.SelectedIndex = 0;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Stream inputFileStream;
            //if open input file
            if (sender == this.openFileButton)
            {
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
            //if open encrypt file
            else if (sender == this.OpenEcnFileButton)
            {
                this.openFileDialog.Filter = "Encrypted files|*.enc";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((inputFileStream = openFileDialog.OpenFile()) != null)
                        {
                            using (inputFileStream)
                            {
                                statusLabel.Text = "The encrypted file successfully opened.";
                                this.EncFileTextBox.Text = openFileDialog.FileName;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            //if open keys file
            else if (sender == this.OpenKeysFileButton)
            {
                this.openFileDialog.Filter = "Key files|*.key";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((inputFileStream = openFileDialog.OpenFile()) != null)
                        {
                            using (inputFileStream)
                            {
                                statusLabel.Text = "The key file successfully opened.";
                                this.KeysFileTextBox.Text = openFileDialog.FileName;                          
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            if (this.EncFileTextBox.Text.Length != 0 && this.KeysFileTextBox.Text.Length != 0)
            {
                this.DecrypterGroupBox.Enabled = true;
            }
            else
            {
                this.DecrypterGroupBox.Enabled = false;
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
            string path = "ecrypt" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            StreamWriter sw = new StreamWriter(path + ".enc");
            try
            {
				int delayN = Convert.ToInt32(nComboBox.SelectedItem);
                int delayR = Convert.ToInt32(rComboBox.SelectedItem);
                int delayL = Convert.ToInt32(lComboBox.SelectedItem);
				int counterN = 0;
				int counterR = 0;
				int counterL = 0;
				byte[] bufferN = null;// = new byte[blockSize*delayN];
				byte[] bufferR = null;// = new byte[blockSize*delayR];
				byte[] bufferL = null;// = new byte[blockSize*delayL];
				MemoryStream streamN = new MemoryStream();
				MemoryStream streamR = new MemoryStream();
				MemoryStream streamL = new MemoryStream();
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to 10.'
                    int n = inputFileStream.Read(bytes, 0, blockSize);
                    // The end of the file is reached.
                    if (n == 0)
                    {
                        break;
                    }
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes_Aes(bytes, encryptkey, encryptIV);
                    //actions with block

					//delayL N blocks
					if (counterN < delayN)
					{
						streamN.Write(encrypted, 0, encrypted.Length);
						counterN++;
					}
					else 
					{
						counterN = 0;
						bufferN = streamN.ToArray();
						streamN.Dispose();
						streamN = new MemoryStream();
						//decrypt n
						bufferN = EncryptStringToBytes_Aes(bufferN, encryptkey, encryptIV);
						/*********/

						// xor buffers
						if (bufferR!=null)
						{
							bufferN = XOR(bufferN, bufferR);
							bufferR = null;
						}
						//encrypt n
						//bufferN = EncryptStringToBytes_Aes(bufferN, encryptkey, encryptIV);
						/*********/

						//delay l blocks
						if (counterL < delayL)
						{
							streamL.Write(bufferN, 0, bufferN.Length);
							counterL++;
						}
						else
						{
							counterL = 0;
							bufferL = streamL.ToArray();
							streamL.Dispose();
							streamL = new MemoryStream();
						}
						//xor buffers
						if (bufferL != null) 
						{
							encrypted = XOR(encrypted, bufferL);
							bufferL = null;
						}
						//delay r blocks
						if (counterR < delayR)
						{
							streamR.Write(encrypted, 0, encrypted.Length);
							counterR++;
						}
						else
						{
							counterR = 0;
							bufferR = streamR.ToArray();
							streamR.Dispose();
							streamR = new MemoryStream();
							//decrypt r
							//bufferR = EncryptStringToBytes_Aes(bufferR, encryptkey, encryptIV);
							/*********/
						}
					}
					//outputFileStream.Write(encrypted, numBytesRead, blockSize);
					sw.Write(Convert.ToBase64String(encrypted));
					numBytesRead += n;
					numBytesToRead -= n;
                    /******************/
                }
                sw.Close();
                //save key
                StreamWriter keyWriter = new StreamWriter(path + ".key");
                keyWriter.WriteLine(Convert.ToBase64String(encryptkey));
                keyWriter.WriteLine(Convert.ToBase64String(encryptIV));
                keyWriter.Close();
                //change interface
                statusLabel.Text = "Encryption is completed.";
                MessageBox.Show("Encryption is completed.");
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Encrypt error.";
                MessageBox.Show("Encrypt error: " + ex.Message + " Length input: " + inputFileStream.Length + ", current position: " + numBytesRead + ", block size: " + blockSize + ".");
            }
        }

        private void generateKeyButton_Click(object sender, EventArgs e)
        {
            // This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                keyTextBox.Text = Convert.ToBase64String(myAes.Key);
                encryptkey = myAes.Key;
                encryptIV = myAes.IV;

                encryptButton.Enabled = true;
            }
        }

        private void encrypterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == this.encrypterToolStripMenuItem)
            {
                this.decrypterToolStripMenuItem.Checked = false;
                this.encrypterToolStripMenuItem.Checked = true;
                this.inputFileGroupBox.Visible = true;
                this.DecrypterFileGroupBox.Visible = false;
                this.encrypterGroupBox.Visible = true;
                this.DecrypterGroupBox.Visible = false;
            }
            else
            {
                this.decrypterToolStripMenuItem.Checked = true;
                this.encrypterToolStripMenuItem.Checked = false;
                this.inputFileGroupBox.Visible = false;
                this.DecrypterFileGroupBox.Visible = true;
                this.encrypterGroupBox.Visible = false;
                this.DecrypterGroupBox.Visible = true;
            }
        }

        private void DecryptStartButton_Click(object sender, EventArgs e)
        {
            // Now read s into a byte buffer.
            int blockSize = (int)Math.Pow(Convert.ToDouble(2), Convert.ToDouble(4 + this.DBlockSizeComboBox.SelectedIndex));
            openFileDialog.FileName = EncFileTextBox.Text;
            Stream inputFileStream = openFileDialog.OpenFile();

            StreamReader keyReader = new StreamReader(KeysFileTextBox.Text);
            String aesKeyString = keyReader.ReadLine();
            byte[] aesKey = Convert.FromBase64String(aesKeyString);
            String aesIVString = keyReader.ReadLine();
            byte[] aesIV = Convert.FromBase64String(aesIVString);
            keyReader.Close();

            byte[] bytes = new byte[blockSize];
            int numBytesToRead = (int)inputFileStream.Length;
            int numBytesRead = 0;
            string path = "decrypt" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            StreamWriter sw = new StreamWriter(path + ".dec");
            try
            {
                int delayN = Convert.ToInt32(DDelayNComboBox.SelectedItem);
                int delayR = Convert.ToInt32(DDelayRComboBox.SelectedItem);
                int delayL = Convert.ToInt32(DDelayLComboBox.SelectedItem);
                int counterN = 0;
                int counterR = 0;
                int counterL = 0;
                byte[] bufferN = null;// = new byte[blockSize*delayN];
                byte[] bufferR = null;// = new byte[blockSize*delayR];
                byte[] bufferL = null;// = new byte[blockSize*delayL];
                MemoryStream streamN = new MemoryStream();
                MemoryStream streamR = new MemoryStream();
                MemoryStream streamL = new MemoryStream();
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to 10.'
                    int n = inputFileStream.Read(bytes, 0, blockSize);
                    // The end of the file is reached.
                    if (n == 0)
                    {
                        break;
                    }
                    // Encrypt the string to an array of bytes.
                    byte[] decrypted = DecryptStringFromBytes_Aes(bytes, aesKey, aesIV);
                    //actions with block

                    //delayL N blocks
                    if (counterN < delayN)
                    {
                        streamN.Write(decrypted, 0, decrypted.Length);
                        counterN++;
                    }
                    else
                    {
                        counterN = 0;
                        bufferN = streamN.ToArray();
                        streamN.Dispose();
                        streamN = new MemoryStream();
                        //decrypt n
                        bufferN = DecryptStringFromBytes_Aes(bufferN, aesKey, aesIV);
                        /*********/

                        // xor buffers
                        if (bufferR != null)
                        {
                            bufferN = XOR(bufferN, bufferR);
                            bufferR = null;
                        }
                        //encrypt n
                        //bufferN = EncryptStringToBytes_Aes(bufferN, encryptkey, encryptIV);
                        /*********/

                        //delay l blocks
                        if (counterL < delayL)
                        {
                            streamL.Write(bufferN, 0, bufferN.Length);
                            counterL++;
                        }
                        else
                        {
                            counterL = 0;
                            bufferL = streamL.ToArray();
                            streamL.Dispose();
                            streamL = new MemoryStream();
                        }
                        //xor buffers
                        if (bufferL != null)
                        {
                            decrypted = XOR(decrypted, bufferL);
                            bufferL = null;
                        }
                        //delay r blocks
                        if (counterR < delayR)
                        {
                            streamR.Write(decrypted, 0, decrypted.Length);
                            counterR++;
                        }
                        else
                        {
                            counterR = 0;
                            bufferR = streamR.ToArray();
                            streamR.Dispose();
                            streamR = new MemoryStream();
                            //decrypt r
                            //bufferR = EncryptStringToBytes_Aes(bufferR, encryptkey, encryptIV);
                            /*********/
                        }
                    }
                    //outputFileStream.Write(encrypted, numBytesRead, blockSize);
                    sw.Write(Convert.ToBase64String(decrypted));
                    numBytesRead += n;
                    numBytesToRead -= n;
                    /******************/
                }
                sw.Close();
                //change interface
                statusLabel.Text = "Decryption is completed.";
                MessageBox.Show("Decryption is completed.");
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Decrypt error.";
                MessageBox.Show("Decrypt error: " + ex.Message + " Length input: " + inputFileStream.Length + ", current position: " + numBytesRead + ", block size: " + blockSize + ".");
            }
        }

    }
}
