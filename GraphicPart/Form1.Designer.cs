namespace GraphicPart
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.knownGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.inputXbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputYbox = new System.Windows.Forms.TextBox();
            this.addInputBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.xMin = new System.Windows.Forms.TextBox();
            this.xMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rebuildBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.methodPicker = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.foundYbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.findXbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.operationBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.polyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knownGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Newton";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            legend2.Name = "Spline";
            legend2.Position.Auto = false;
            legend2.Position.Height = 6.629834F;
            legend2.Position.Width = 19.61415F;
            legend2.Position.X = 70.64631F;
            legend2.Position.Y = 11F;
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chart.Legends.Add(legend1);
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            this.chart.Size = new System.Drawing.Size(623, 363);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // knownGridView
            // 
            this.knownGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knownGridView.Location = new System.Drawing.Point(644, 25);
            this.knownGridView.Name = "knownGridView";
            this.knownGridView.Size = new System.Drawing.Size(232, 140);
            this.knownGridView.TabIndex = 1;
            this.knownGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.knownGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Базові точки:";
            // 
            // inputXbox
            // 
            this.inputXbox.Location = new System.Drawing.Point(668, 188);
            this.inputXbox.Name = "inputXbox";
            this.inputXbox.Size = new System.Drawing.Size(89, 20);
            this.inputXbox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(763, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y:";
            // 
            // inputYbox
            // 
            this.inputYbox.Location = new System.Drawing.Point(786, 188);
            this.inputYbox.Name = "inputYbox";
            this.inputYbox.Size = new System.Drawing.Size(90, 20);
            this.inputYbox.TabIndex = 6;
            // 
            // addInputBtn
            // 
            this.addInputBtn.Location = new System.Drawing.Point(801, 214);
            this.addInputBtn.Name = "addInputBtn";
            this.addInputBtn.Size = new System.Drawing.Size(75, 23);
            this.addInputBtn.TabIndex = 8;
            this.addInputBtn.Text = "Додати";
            this.addInputBtn.UseVisualStyleBackColor = true;
            this.addInputBtn.Click += new System.EventHandler(this.addInputBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Область визначення ф-ції:  Хmin:";
            // 
            // xMin
            // 
            this.xMin.Location = new System.Drawing.Point(187, 385);
            this.xMin.Name = "xMin";
            this.xMin.Size = new System.Drawing.Size(56, 20);
            this.xMin.TabIndex = 10;
            // 
            // xMax
            // 
            this.xMax.Location = new System.Drawing.Point(288, 385);
            this.xMax.Name = "xMax";
            this.xMax.Size = new System.Drawing.Size(56, 20);
            this.xMax.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Xmax:";
            // 
            // rebuildBtn
            // 
            this.rebuildBtn.Location = new System.Drawing.Point(350, 383);
            this.rebuildBtn.Name = "rebuildBtn";
            this.rebuildBtn.Size = new System.Drawing.Size(90, 23);
            this.rebuildBtn.TabIndex = 13;
            this.rebuildBtn.Text = "Перебудувати";
            this.rebuildBtn.UseVisualStyleBackColor = true;
            this.rebuildBtn.Click += new System.EventHandler(this.rebuildBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(644, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Додати/Видилити точку:";
            // 
            // methodPicker
            // 
            this.methodPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodPicker.Items.AddRange(new object[] {
            "Метод Ньютона",
            "Метод Кубічних сплайнів"});
            this.methodPicker.Location = new System.Drawing.Point(755, 248);
            this.methodPicker.Name = "methodPicker";
            this.methodPicker.Size = new System.Drawing.Size(121, 21);
            this.methodPicker.TabIndex = 15;
            this.methodPicker.SelectedIndexChanged += new System.EventHandler(this.findYEvent);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(644, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Знайти Y методом:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(763, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Y:";
            // 
            // foundYbox
            // 
            this.foundYbox.Enabled = false;
            this.foundYbox.Location = new System.Drawing.Point(786, 279);
            this.foundYbox.Name = "foundYbox";
            this.foundYbox.Size = new System.Drawing.Size(90, 20);
            this.foundYbox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(645, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "X:";
            // 
            // findXbox
            // 
            this.findXbox.Location = new System.Drawing.Point(668, 279);
            this.findXbox.Name = "findXbox";
            this.findXbox.Size = new System.Drawing.Size(89, 20);
            this.findXbox.TabIndex = 17;
            this.findXbox.TextChanged += new System.EventHandler(this.findYEvent);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(645, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "К-ть операцій:";
            // 
            // operationBox
            // 
            this.operationBox.Enabled = false;
            this.operationBox.Location = new System.Drawing.Point(786, 331);
            this.operationBox.Name = "operationBox";
            this.operationBox.Size = new System.Drawing.Size(90, 20);
            this.operationBox.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(645, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Час пошуку:";
            // 
            // timeBox
            // 
            this.timeBox.Enabled = false;
            this.timeBox.Location = new System.Drawing.Point(786, 305);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(90, 20);
            this.timeBox.TabIndex = 21;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(648, 214);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 25;
            this.delBtn.Text = "Видалити";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(645, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "К-ть ітерацій:";
            // 
            // iterationBox
            // 
            this.iterationBox.Enabled = false;
            this.iterationBox.Location = new System.Drawing.Point(786, 357);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.Size = new System.Drawing.Size(90, 20);
            this.iterationBox.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(461, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Поліном:";
            // 
            // polyLabel
            // 
            this.polyLabel.AutoSize = true;
            this.polyLabel.Location = new System.Drawing.Point(519, 388);
            this.polyLabel.Name = "polyLabel";
            this.polyLabel.Size = new System.Drawing.Size(0, 13);
            this.polyLabel.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 420);
            this.Controls.Add(this.polyLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.iterationBox);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.operationBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.foundYbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.findXbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.methodPicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rebuildBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xMax);
            this.Controls.Add(this.xMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addInputBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputYbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputXbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.knownGridView);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Курсова робота";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knownGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView knownGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputXbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputYbox;
        private System.Windows.Forms.Button addInputBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xMin;
        private System.Windows.Forms.TextBox xMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button rebuildBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox methodPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox foundYbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox findXbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox operationBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label polyLabel;
    }
}

