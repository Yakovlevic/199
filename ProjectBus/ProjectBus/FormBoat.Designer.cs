namespace ProjectBoat
{
    partial class FormBoat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoat));
            pictureBoxBoat = new PictureBox();
            button1 = new Button();
            buttonUp = new Button();
            buttonDown = new Button();
            buttonRight = new Button();
            buttonLeft = new Button();
            comboBoxStrategy = new ComboBox();
            buttonCretaeBoat = new Button();
            buttonStrategyStep = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoat).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBoat
            // 
            pictureBoxBoat.Dock = DockStyle.Fill;
            pictureBoxBoat.Location = new Point(0, 0);
            pictureBoxBoat.Margin = new Padding(3, 2, 3, 2);
            pictureBoxBoat.Name = "pictureBoxBoat";
            pictureBoxBoat.Size = new Size(700, 338);
            pictureBoxBoat.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxBoat.TabIndex = 0;
            pictureBoxBoat.TabStop = false;
            pictureBoxBoat.Click += pictureBoxBoat_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(10, 307);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(186, 22);
            button1.TabIndex = 1;
            button1.Text = "создать катер";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonCreateBoat_Click;
            // 
            // buttonUp
            // 
            buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUp.BackgroundImage = (Image)resources.GetObject("buttonUp.BackgroundImage");
            buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
            buttonUp.Location = new Point(632, 280);
            buttonUp.Margin = new Padding(3, 2, 3, 2);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(26, 22);
            buttonUp.TabIndex = 2;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += ButtonMove_Click;
            // 
            // buttonDown
            // 
            buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDown.BackgroundImage = (Image)resources.GetObject("buttonDown.BackgroundImage");
            buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
            buttonDown.Location = new Point(632, 307);
            buttonDown.Margin = new Padding(3, 2, 3, 2);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(26, 22);
            buttonDown.TabIndex = 3;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += ButtonMove_Click;
            // 
            // buttonRight
            // 
            buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRight.BackgroundImage = (Image)resources.GetObject("buttonRight.BackgroundImage");
            buttonRight.BackgroundImageLayout = ImageLayout.Zoom;
            buttonRight.Location = new Point(663, 307);
            buttonRight.Margin = new Padding(3, 2, 3, 2);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(26, 22);
            buttonRight.TabIndex = 4;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += ButtonMove_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLeft.BackgroundImage = (Image)resources.GetObject("buttonLeft.BackgroundImage");
            buttonLeft.BackgroundImageLayout = ImageLayout.Zoom;
            buttonLeft.Location = new Point(600, 307);
            buttonLeft.Margin = new Padding(3, 2, 3, 2);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(26, 22);
            buttonLeft.TabIndex = 5;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += ButtonMove_Click;
            // 
            // comboBoxStrategy
            // 
            comboBoxStrategy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxStrategy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStrategy.FormattingEnabled = true;
            comboBoxStrategy.Items.AddRange(new object[] { "к центру", "к краю" });
            comboBoxStrategy.Location = new Point(557, 9);
            comboBoxStrategy.Margin = new Padding(3, 2, 3, 2);
            comboBoxStrategy.Name = "comboBoxStrategy";
            comboBoxStrategy.Size = new Size(133, 23);
            comboBoxStrategy.TabIndex = 6;
            // 
            // buttonCretaeBoat
            // 
            buttonCretaeBoat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCretaeBoat.Location = new Point(210, 308);
            buttonCretaeBoat.Margin = new Padding(3, 2, 3, 2);
            buttonCretaeBoat.Name = "buttonCretaeBoat";
            buttonCretaeBoat.Size = new Size(186, 22);
            buttonCretaeBoat.TabIndex = 7;
            buttonCretaeBoat.Text = "создать лодку";
            buttonCretaeBoat.UseVisualStyleBackColor = true;
            buttonCretaeBoat.Click += buttonCretaeBoat_Click;
            // 
            // buttonStrategyStep
            // 
            buttonStrategyStep.Location = new Point(607, 34);
            buttonStrategyStep.Margin = new Padding(3, 2, 3, 2);
            buttonStrategyStep.Name = "buttonStrategyStep";
            buttonStrategyStep.Size = new Size(82, 22);
            buttonStrategyStep.TabIndex = 8;
            buttonStrategyStep.Text = "шаг";
            buttonStrategyStep.UseVisualStyleBackColor = true;
            buttonStrategyStep.Click += ButtonStrategyStep_Click;
            // 
            // FormBoat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(buttonStrategyStep);
            Controls.Add(buttonCretaeBoat);
            Controls.Add(comboBoxStrategy);
            Controls.Add(buttonLeft);
            Controls.Add(buttonRight);
            Controls.Add(buttonDown);
            Controls.Add(buttonUp);
            Controls.Add(button1);
            Controls.Add(pictureBoxBoat);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormBoat";
            Text = "FormBoat";
            Load += FormBoat_Load;
            Click += ButtonMove_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBoat;
        private Button button1;
        private Button buttonUp;
        private Button buttonDown;
        private Button buttonRight;
        private Button buttonLeft;
        private ComboBox comboBoxStrategy;
        private Button buttonCretaeBoat;
        private Button buttonStrategyStep;
    }
}