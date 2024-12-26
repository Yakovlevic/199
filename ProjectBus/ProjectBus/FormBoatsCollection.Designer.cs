namespace ProjectBoat
{
    partial class FormBoatsCollection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxTools = new GroupBox();
            maskedTextBoxPosision = new MaskedTextBox();
            buttonRefresh = new Button();
            buttonGetToTest = new Button();
            ButtonRemoveBoat = new Button();
            ButtonAddMBoat = new Button();
            ButtonAddBoat = new Button();
            comboBoxSelectorCompany = new ComboBox();
            pictureBoxBoat = new PictureBox();
            groupBoxTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoat).BeginInit();
            SuspendLayout();
            // 
            // groupBoxTools
            // 
            groupBoxTools.Controls.Add(maskedTextBoxPosision);
            groupBoxTools.Controls.Add(buttonRefresh);
            groupBoxTools.Controls.Add(buttonGetToTest);
            groupBoxTools.Controls.Add(ButtonRemoveBoat);
            groupBoxTools.Controls.Add(ButtonAddMBoat);
            groupBoxTools.Controls.Add(ButtonAddBoat);
            groupBoxTools.Controls.Add(comboBoxSelectorCompany);
            groupBoxTools.Dock = DockStyle.Right;
            groupBoxTools.Location = new Point(596, 0);
            groupBoxTools.Name = "groupBoxTools";
            groupBoxTools.Size = new Size(222, 574);
            groupBoxTools.TabIndex = 0;
            groupBoxTools.TabStop = false;
            groupBoxTools.Text = "инструменты";
            // 
            // maskedTextBoxPosision
            // 
            maskedTextBoxPosision.Location = new Point(20, 229);
            maskedTextBoxPosision.Mask = "00";
            maskedTextBoxPosision.Name = "maskedTextBoxPosision";
            maskedTextBoxPosision.Size = new Size(186, 27);
            maskedTextBoxPosision.TabIndex = 2;
            maskedTextBoxPosision.ValidatingType = typeof(int);
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRefresh.Location = new Point(20, 479);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(186, 40);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // buttonGetToTest
            // 
            buttonGetToTest.Anchor = AnchorStyles.Right;
            buttonGetToTest.Location = new Point(20, 366);
            buttonGetToTest.Name = "buttonGetToTest";
            buttonGetToTest.Size = new Size(186, 40);
            buttonGetToTest.TabIndex = 4;
            buttonGetToTest.Text = "передать на тесты";
            buttonGetToTest.UseVisualStyleBackColor = true;
            buttonGetToTest.Click += ButtonGetToTest_Click;
            // 
            // ButtonRemoveBoat
            // 
            ButtonRemoveBoat.Anchor = AnchorStyles.Right;
            ButtonRemoveBoat.Location = new Point(20, 271);
            ButtonRemoveBoat.Name = "ButtonRemoveBoat";
            ButtonRemoveBoat.Size = new Size(186, 40);
            ButtonRemoveBoat.TabIndex = 3;
            ButtonRemoveBoat.Text = "удалить крейсер";
            ButtonRemoveBoat.UseVisualStyleBackColor = true;
            ButtonRemoveBoat.Click += ButtonRemoveBoat_Click;
            // 
            // ButtonAddMBoat
            // 
            ButtonAddMBoat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ButtonAddMBoat.Location = new Point(20, 152);
            ButtonAddMBoat.Name = "ButtonAddMBoat";
            ButtonAddMBoat.Size = new Size(186, 50);
            ButtonAddMBoat.TabIndex = 2;
            ButtonAddMBoat.Text = "добваление военного крейсера";
            ButtonAddMBoat.UseVisualStyleBackColor = true;
            ButtonAddMBoat.Click += ButtonAddMBoat_Click;
            // 
            // ButtonAddBoat
            // 
            ButtonAddBoat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ButtonAddBoat.BackgroundImageLayout = ImageLayout.Center;
            ButtonAddBoat.Location = new Point(20, 106);
            ButtonAddBoat.Name = "ButtonAddBoat";
            ButtonAddBoat.Size = new Size(186, 40);
            ButtonAddBoat.TabIndex = 1;
            ButtonAddBoat.Text = "добваление крейсера";
            ButtonAddBoat.UseVisualStyleBackColor = true;
            ButtonAddBoat.Click += ButtonAddBoat_Click;
            // 
            // comboBoxSelectorCompany
            // 
            comboBoxSelectorCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectorCompany.FormattingEnabled = true;
            comboBoxSelectorCompany.Items.AddRange(new object[] { "хранилище" });
            comboBoxSelectorCompany.Location = new Point(20, 26);
            comboBoxSelectorCompany.Name = "comboBoxSelectorCompany";
            comboBoxSelectorCompany.Size = new Size(186, 28);
            comboBoxSelectorCompany.TabIndex = 0;
            comboBoxSelectorCompany.SelectedIndexChanged += comboBoxSelectorCompany_SelectedIndexChanged_1;
            // 
            // pictureBoxBoat
            // 
            pictureBoxBoat.Dock = DockStyle.Fill;
            pictureBoxBoat.Location = new Point(0, 0);
            pictureBoxBoat.Name = "pictureBoxBoat";
            pictureBoxBoat.Size = new Size(596, 574);
            pictureBoxBoat.TabIndex = 1;
            pictureBoxBoat.TabStop = false;
            // 
            // FormBoatsCollection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 574);
            Controls.Add(pictureBoxBoat);
            Controls.Add(groupBoxTools);
            Name = "FormBoatsCollection";
            Text = "FormBoatsCollection";
            groupBoxTools.ResumeLayout(false);
            groupBoxTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxTools;
        private ComboBox comboBoxSelectorCompany;
        private Button ButtonAddMBoat;
        private Button ButtonAddBoat;
        private Button ButtonRemoveBoat;
        private Button buttonRefresh;
        private Button buttonGetToTest;
        private PictureBox pictureBoxBoat;
        private MaskedTextBox maskedTextBoxPosision;
    }
}