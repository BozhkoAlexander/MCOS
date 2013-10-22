using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    partial class Encrypter
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.inputFileGroupBox = new System.Windows.Forms.GroupBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.encrypterGroupBox = new System.Windows.Forms.GroupBox();
            this.generateKeyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.rComboBox = new System.Windows.Forms.ComboBox();
            this.lComboBox = new System.Windows.Forms.ComboBox();
            this.nComboBox = new System.Windows.Forms.ComboBox();
            this.blockSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.inputFileGroupBox.SuspendLayout();
            this.encrypterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(504, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 249);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(504, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // inputFileGroupBox
            // 
            this.inputFileGroupBox.Controls.Add(this.openFileButton);
            this.inputFileGroupBox.Controls.Add(this.inputFileTextBox);
            this.inputFileGroupBox.Location = new System.Drawing.Point(13, 28);
            this.inputFileGroupBox.Name = "inputFileGroupBox";
            this.inputFileGroupBox.Size = new System.Drawing.Size(479, 54);
            this.inputFileGroupBox.TabIndex = 2;
            this.inputFileGroupBox.TabStop = false;
            this.inputFileGroupBox.Text = "Input File";
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(398, 18);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Open";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(7, 20);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.ReadOnly = true;
            this.inputFileTextBox.Size = new System.Drawing.Size(385, 20);
            this.inputFileTextBox.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files|*.*";
            // 
            // encrypterGroupBox
            // 
            this.encrypterGroupBox.Controls.Add(this.generateKeyButton);
            this.encrypterGroupBox.Controls.Add(this.label5);
            this.encrypterGroupBox.Controls.Add(this.keyTextBox);
            this.encrypterGroupBox.Controls.Add(this.saveButton);
            this.encrypterGroupBox.Controls.Add(this.encryptButton);
            this.encrypterGroupBox.Controls.Add(this.rComboBox);
            this.encrypterGroupBox.Controls.Add(this.lComboBox);
            this.encrypterGroupBox.Controls.Add(this.nComboBox);
            this.encrypterGroupBox.Controls.Add(this.blockSizeComboBox);
            this.encrypterGroupBox.Controls.Add(this.label4);
            this.encrypterGroupBox.Controls.Add(this.label3);
            this.encrypterGroupBox.Controls.Add(this.label2);
            this.encrypterGroupBox.Controls.Add(this.label1);
            this.encrypterGroupBox.Enabled = false;
            this.encrypterGroupBox.Location = new System.Drawing.Point(13, 89);
            this.encrypterGroupBox.Name = "encrypterGroupBox";
            this.encrypterGroupBox.Size = new System.Drawing.Size(479, 157);
            this.encrypterGroupBox.TabIndex = 3;
            this.encrypterGroupBox.TabStop = false;
            this.encrypterGroupBox.Text = "Encrypter";
            // 
            // generateKeyButton
            // 
            this.generateKeyButton.Location = new System.Drawing.Point(398, 39);
            this.generateKeyButton.Name = "generateKeyButton";
            this.generateKeyButton.Size = new System.Drawing.Size(75, 23);
            this.generateKeyButton.TabIndex = 14;
            this.generateKeyButton.Text = "Generate";
            this.generateKeyButton.UseVisualStyleBackColor = true;
            this.generateKeyButton.Click += new System.EventHandler(this.generateKeyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Generate key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(97, 41);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(295, 20);
            this.keyTextBox.TabIndex = 12;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(398, 122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Location = new System.Drawing.Point(317, 122);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 10;
            this.encryptButton.Text = "Start";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // rComboBox
            // 
            this.rComboBox.FormattingEnabled = true;
            this.rComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.rComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.rComboBox.Location = new System.Drawing.Point(97, 124);
            this.rComboBox.Name = "rComboBox";
            this.rComboBox.Size = new System.Drawing.Size(87, 21);
            this.rComboBox.TabIndex = 9;
            // 
            // lComboBox
            // 
            this.lComboBox.FormattingEnabled = true;
            this.lComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.lComboBox.Location = new System.Drawing.Point(97, 97);
            this.lComboBox.Name = "lComboBox";
            this.lComboBox.Size = new System.Drawing.Size(87, 21);
            this.lComboBox.TabIndex = 8;
            // 
            // nComboBox
            // 
            this.nComboBox.FormattingEnabled = true;
            this.nComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.nComboBox.Location = new System.Drawing.Point(97, 70);
            this.nComboBox.Name = "nComboBox";
            this.nComboBox.Size = new System.Drawing.Size(87, 21);
            this.nComboBox.TabIndex = 7;
            // 
            // blockSizeComboBox
            // 
            this.blockSizeComboBox.FormattingEnabled = true;
            this.blockSizeComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.blockSizeComboBox.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.blockSizeComboBox.Location = new System.Drawing.Point(97, 13);
            this.blockSizeComboBox.Name = "blockSizeComboBox";
            this.blockSizeComboBox.Size = new System.Drawing.Size(87, 21);
            this.blockSizeComboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter block size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter delay r:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter delay l:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter delay n:";
            // 
            // Encrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(504, 271);
            this.Controls.Add(this.encrypterGroupBox);
            this.Controls.Add(this.inputFileGroupBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MaximumSize = new System.Drawing.Size(520, 310);
            this.MinimumSize = new System.Drawing.Size(520, 310);
            this.Name = "Encrypter";
            this.Text = "Encrypter";
            this.Load += new System.EventHandler(this.Encrypter_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.inputFileGroupBox.ResumeLayout(false);
            this.inputFileGroupBox.PerformLayout();
            this.encrypterGroupBox.ResumeLayout(false);
            this.encrypterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        Stream inputFile;
        Aes encrypter;

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox inputFileGroupBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox encrypterGroupBox;
        private System.Windows.Forms.ComboBox rComboBox;
        private System.Windows.Forms.ComboBox lComboBox;
        private System.Windows.Forms.ComboBox nComboBox;
        private System.Windows.Forms.ComboBox blockSizeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button generateKeyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox keyTextBox;
    }
}

