
namespace DrawingGraf
{
    partial class DrawingGrafForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.vertexMode = new System.Windows.Forms.RadioButton();
            this.edgeMode = new System.Windows.Forms.RadioButton();
            this.myPanel1 = new DrawingGraf.MyPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.stepByStep = new System.Windows.Forms.CheckBox();
            this.edgeWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.setWeightButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fromCb = new System.Windows.Forms.ComboBox();
            this.shortestWayLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.waysListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.basicsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.edgeWeightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // vertexMode
            // 
            this.vertexMode.AutoSize = true;
            this.vertexMode.Checked = true;
            this.vertexMode.Location = new System.Drawing.Point(996, 15);
            this.vertexMode.Name = "vertexMode";
            this.vertexMode.Size = new System.Drawing.Size(91, 19);
            this.vertexMode.TabIndex = 3;
            this.vertexMode.TabStop = true;
            this.vertexMode.Text = "Vertex mode";
            this.vertexMode.UseVisualStyleBackColor = true;
            // 
            // edgeMode
            // 
            this.edgeMode.AutoSize = true;
            this.edgeMode.Location = new System.Drawing.Point(996, 40);
            this.edgeMode.Name = "edgeMode";
            this.edgeMode.Size = new System.Drawing.Size(85, 19);
            this.edgeMode.TabIndex = 4;
            this.edgeMode.Text = "Edge mode";
            this.edgeMode.UseVisualStyleBackColor = true;
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.myPanel1.Location = new System.Drawing.Point(12, 15);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(977, 530);
            this.myPanel1.TabIndex = 5;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            this.myPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseDown);
            this.myPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseMove);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(996, 90);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(176, 30);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete selected";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // stepByStep
            // 
            this.stepByStep.AutoSize = true;
            this.stepByStep.Checked = true;
            this.stepByStep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stepByStep.Location = new System.Drawing.Point(997, 65);
            this.stepByStep.Name = "stepByStep";
            this.stepByStep.Size = new System.Drawing.Size(90, 19);
            this.stepByStep.TabIndex = 7;
            this.stepByStep.Text = "Step by step";
            this.stepByStep.UseVisualStyleBackColor = true;
            // 
            // edgeWeightNumeric
            // 
            this.edgeWeightNumeric.Location = new System.Drawing.Point(1034, 279);
            this.edgeWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edgeWeightNumeric.Name = "edgeWeightNumeric";
            this.edgeWeightNumeric.Size = new System.Drawing.Size(52, 23);
            this.edgeWeightNumeric.TabIndex = 9;
            this.edgeWeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edgeWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(995, 283);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(33, 15);
            this.label.TabIndex = 10;
            this.label.Text = "Edge";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // setWeightButton
            // 
            this.setWeightButton.Location = new System.Drawing.Point(1092, 279);
            this.setWeightButton.Name = "setWeightButton";
            this.setWeightButton.Size = new System.Drawing.Size(78, 23);
            this.setWeightButton.TabIndex = 11;
            this.setWeightButton.Text = "Set";
            this.setWeightButton.UseVisualStyleBackColor = true;
            this.setWeightButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1047, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Set weights";
            // 
            // fromCb
            // 
            this.fromCb.FormattingEnabled = true;
            this.fromCb.Location = new System.Drawing.Point(1076, 342);
            this.fromCb.Name = "fromCb";
            this.fromCb.Size = new System.Drawing.Size(75, 23);
            this.fromCb.TabIndex = 13;
            // 
            // shortestWayLabel
            // 
            this.shortestWayLabel.AutoSize = true;
            this.shortestWayLabel.Location = new System.Drawing.Point(1047, 321);
            this.shortestWayLabel.Name = "shortestWayLabel";
            this.shortestWayLabel.Size = new System.Drawing.Size(81, 15);
            this.shortestWayLabel.TabIndex = 15;
            this.shortestWayLabel.Text = "Shortest Ways";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1024, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "From";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(997, 371);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(173, 30);
            this.calculateButton.TabIndex = 17;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // waysListBox
            // 
            this.waysListBox.FormattingEnabled = true;
            this.waysListBox.ItemHeight = 15;
            this.waysListBox.Location = new System.Drawing.Point(998, 406);
            this.waysListBox.Name = "waysListBox";
            this.waysListBox.Size = new System.Drawing.Size(173, 139);
            this.waysListBox.TabIndex = 0;
            this.waysListBox.SelectedIndexChanged += new System.EventHandler(this.waysListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1025, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Basic characteristics";
            // 
            // basicsListBox
            // 
            this.basicsListBox.FormattingEnabled = true;
            this.basicsListBox.ItemHeight = 15;
            this.basicsListBox.Location = new System.Drawing.Point(997, 165);
            this.basicsListBox.Name = "basicsListBox";
            this.basicsListBox.Size = new System.Drawing.Size(175, 79);
            this.basicsListBox.TabIndex = 19;
            // 
            // DrawingGrafForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.basicsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waysListBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortestWayLabel);
            this.Controls.Add(this.fromCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setWeightButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.edgeWeightNumeric);
            this.Controls.Add(this.stepByStep);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.edgeMode);
            this.Controls.Add(this.vertexMode);
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "DrawingGrafForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graf";
            ((System.ComponentModel.ISupportInitialize)(this.edgeWeightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton vertexMode;
        private System.Windows.Forms.RadioButton edgeMode;
        private MyPanel myPanel1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox stepByStep;
        private System.Windows.Forms.NumericUpDown edgeWeightNumeric;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button setWeightButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fromCb;
        private System.Windows.Forms.Label shortestWayLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.ListBox waysListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox basicsListBox;
    }
}

