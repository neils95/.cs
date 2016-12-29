//Took help from Shikha Taori
using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace lab7
{
    public partial class Form1 : Form
    {

        private byte[] desKey;
        
        //Form-----------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        //Buttons--------------------------------------------------
        private void decrypt_Click(object sender, EventArgs e)
        {
            if (this.keyvalue())
            {

                string fileName = fileTextBox.Text;
                if (!fileName.EndsWith(".des"))  
                {
                    MessageBox.Show("This file is not a .des encrypted file", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else //It is an encrypted file
                {
                    string path = fileName.Substring(0, fileName.Length - 3);
                    if (!File.Exists(path) || (MessageBox.Show("Output file exists. Overwrite?", "error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                    {
                        Cursor = Cursors.WaitCursor;
                        decrypt_data(fileName, path, this.desKey, this.desKey); //decrypt the file
                        Cursor = Cursors.Default;
                    }
                }

            }
        }
        private void encrypt_Click(object sender, EventArgs e)
        {
            if (this.keyvalue())
            {
                string filename = this.fileTextBox.Text;
                string path = filename + ".des";

                if (!File.Exists(path) || (MessageBox.Show("Output file already encrypted. overwrite?", "error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                {
                    this.Cursor = Cursors.WaitCursor;
                    encrypt_data(filename, path, this.desKey, this.desKey);
                    this.Cursor = Cursors.Default;
                }
            }

        }
        private void browse_Click(object sender, EventArgs e)
        {
            if (fileSelectionDialog.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = fileSelectionDialog.FileName;
            }
        }

        //Functions to encrypt and decrypt file---------------------
        private static void encrypt_data(string input, string output, byte[] desKey, byte[] desIV)
        {
            FileStream fileOut = null;
            FileStream fileIn = null;
           
            try
            {
                fileIn = new FileStream(input, FileMode.Open, FileAccess.Read);
                fileOut = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);
                fileOut.SetLength(0);
            }

            catch
            {
                MessageBox.Show(" Could not open source or destination file", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (fileIn != null) fileIn.Close();
                if (fileOut != null) fileOut.Close();
                return;
            }

            //Code referenced from C# documentation
            byte[] bin = new byte[100]; 
            long rdlen = 0;     
            long totallen = fileIn.Length; 
            int len; 

            DES des = new DESCryptoServiceProvider();
            CryptoStream encryptStream = new CryptoStream(fileOut, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            
            while (rdlen < totallen)
            {
                len = fileIn.Read(bin, 0, 100);
                encryptStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encryptStream.Close();
            fileIn.Close();
            fileOut.Close();
        }

        private static void decrypt_data(string input, string output, byte[] desKey, byte[] desIV)
        {
            bool flag = false;

            FileStream fileIn = null;
            FileStream fileOut = null;

            try
            {
                fileIn = new FileStream(input, FileMode.Open, FileAccess.Read);
                fileOut = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);
                fileOut.SetLength(0);
            }

            catch
            {
                MessageBox.Show("could not open source file", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (fileIn != null) fileIn.Close();
        
                if (fileOut != null) fileOut.Close();
               
                return;
            }

            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fileIn.Length;
            DES des = new DESCryptoServiceProvider();

            KeySizes[] validsize = des.LegalKeySizes;
            int blocksize = des.BlockSize;

            CryptoStream encryptStream = new CryptoStream(fileOut, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);
            try
            {
                while (rdlen < totlen)
                {
                    int count = fileIn.Read(bin, 0, 0x10);
                    encryptStream.Write(bin, 0, count);
                    rdlen = rdlen + count;
                }
                encryptStream.Close();
            }
            catch
            {
                MessageBox.Show("Bad file/key", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            fileIn.Close();
            fileOut.Close();

            if (flag)
            {
                File.Delete(output);
            }

        }

        //Function to check if key is valid
        private bool keyvalue()
        {
            if (this.key.Text == "")
            {
                MessageBox.Show("Please enter a valid key", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            desKey = new byte[8];
            int counter = 0;
            int i = 0;

            for (i = 0; i < this.key.Text.Length; i++)
            {
                desKey[counter] = (byte)(desKey[counter] + ((byte)key.Text[i]));
                counter = (counter + 1) % 8;
            }
            return true;

        }

    }
}


