namespace Back_Propagation
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Num_Hidden_TXT_Box = new System.Windows.Forms.TextBox();
            this.Num_Epochs_TXT_Box = new System.Windows.Forms.TextBox();
            this.Learning_Rate_TXT_Box = new System.Windows.Forms.TextBox();
            this.Num_Neurons_TXT_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Bias_Check_Box = new System.Windows.Forms.CheckBox();
            this.Activation_Function_Compo_Box = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.With_MSE_Check_Box = new System.Windows.Forms.CheckBox();
            this.WithOut_MSE_Check_Box = new System.Windows.Forms.CheckBox();
            this.MSE_Threshold_TXT_Box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RUN_Button = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Num_Hidden_TXT_Box
            // 
            this.Num_Hidden_TXT_Box.Location = new System.Drawing.Point(152, 45);
            this.Num_Hidden_TXT_Box.Name = "Num_Hidden_TXT_Box";
            this.Num_Hidden_TXT_Box.Size = new System.Drawing.Size(100, 20);
            this.Num_Hidden_TXT_Box.TabIndex = 0;
            // 
            // Num_Epochs_TXT_Box
            // 
            this.Num_Epochs_TXT_Box.Location = new System.Drawing.Point(152, 123);
            this.Num_Epochs_TXT_Box.Name = "Num_Epochs_TXT_Box";
            this.Num_Epochs_TXT_Box.Size = new System.Drawing.Size(100, 20);
            this.Num_Epochs_TXT_Box.TabIndex = 1;
            this.Num_Epochs_TXT_Box.TextChanged += new System.EventHandler(this.Num_Epochs_TXT_Box_TextChanged);
            // 
            // Learning_Rate_TXT_Box
            // 
            this.Learning_Rate_TXT_Box.Location = new System.Drawing.Point(152, 97);
            this.Learning_Rate_TXT_Box.Name = "Learning_Rate_TXT_Box";
            this.Learning_Rate_TXT_Box.Size = new System.Drawing.Size(100, 20);
            this.Learning_Rate_TXT_Box.TabIndex = 2;
            // 
            // Num_Neurons_TXT_Box
            // 
            this.Num_Neurons_TXT_Box.Location = new System.Drawing.Point(152, 71);
            this.Num_Neurons_TXT_Box.Name = "Num_Neurons_TXT_Box";
            this.Num_Neurons_TXT_Box.Size = new System.Drawing.Size(100, 20);
            this.Num_Neurons_TXT_Box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Numer of Hidden Layers :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Neurons :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Learning Rate :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of Epochs :";
            // 
            // Bias_Check_Box
            // 
            this.Bias_Check_Box.AutoSize = true;
            this.Bias_Check_Box.Location = new System.Drawing.Point(119, 158);
            this.Bias_Check_Box.Name = "Bias_Check_Box";
            this.Bias_Check_Box.Size = new System.Drawing.Size(45, 17);
            this.Bias_Check_Box.TabIndex = 8;
            this.Bias_Check_Box.Text = "Bias";
            this.Bias_Check_Box.UseVisualStyleBackColor = true;
            this.Bias_Check_Box.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Activation_Function_Compo_Box
            // 
            this.Activation_Function_Compo_Box.FormattingEnabled = true;
            this.Activation_Function_Compo_Box.Items.AddRange(new object[] {
            "Sigmoid",
            "Hyperbolic"});
            this.Activation_Function_Compo_Box.Location = new System.Drawing.Point(152, 181);
            this.Activation_Function_Compo_Box.Name = "Activation_Function_Compo_Box";
            this.Activation_Function_Compo_Box.Size = new System.Drawing.Size(121, 21);
            this.Activation_Function_Compo_Box.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Activation Function :";
            // 
            // With_MSE_Check_Box
            // 
            this.With_MSE_Check_Box.AutoSize = true;
            this.With_MSE_Check_Box.Location = new System.Drawing.Point(140, 215);
            this.With_MSE_Check_Box.Name = "With_MSE_Check_Box";
            this.With_MSE_Check_Box.Size = new System.Drawing.Size(71, 17);
            this.With_MSE_Check_Box.TabIndex = 11;
            this.With_MSE_Check_Box.Text = "With MSE";
            this.With_MSE_Check_Box.UseVisualStyleBackColor = true;
            // 
            // WithOut_MSE_Check_Box
            // 
            this.WithOut_MSE_Check_Box.AutoSize = true;
            this.WithOut_MSE_Check_Box.Location = new System.Drawing.Point(27, 215);
            this.WithOut_MSE_Check_Box.Name = "WithOut_MSE_Check_Box";
            this.WithOut_MSE_Check_Box.Size = new System.Drawing.Size(87, 17);
            this.WithOut_MSE_Check_Box.TabIndex = 12;
            this.WithOut_MSE_Check_Box.Text = "Without MSE";
            this.WithOut_MSE_Check_Box.UseVisualStyleBackColor = true;
            // 
            // MSE_Threshold_TXT_Box
            // 
            this.MSE_Threshold_TXT_Box.Location = new System.Drawing.Point(317, 213);
            this.MSE_Threshold_TXT_Box.Name = "MSE_Threshold_TXT_Box";
            this.MSE_Threshold_TXT_Box.Size = new System.Drawing.Size(100, 20);
            this.MSE_Threshold_TXT_Box.TabIndex = 13;
            this.MSE_Threshold_TXT_Box.TextChanged += new System.EventHandler(this.MSE_Threshold_TXT_Box_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "MSE Threshold :";
            // 
            // RUN_Button
            // 
            this.RUN_Button.Location = new System.Drawing.Point(152, 283);
            this.RUN_Button.Name = "RUN_Button";
            this.RUN_Button.Size = new System.Drawing.Size(75, 23);
            this.RUN_Button.TabIndex = 15;
            this.RUN_Button.Text = "RUN";
            this.RUN_Button.UseVisualStyleBackColor = true;
            this.RUN_Button.Click += new System.EventHandler(this.RUN_Button_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(502, 28);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 408);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.RUN_Button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MSE_Threshold_TXT_Box);
            this.Controls.Add(this.WithOut_MSE_Check_Box);
            this.Controls.Add(this.With_MSE_Check_Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Activation_Function_Compo_Box);
            this.Controls.Add(this.Bias_Check_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Num_Neurons_TXT_Box);
            this.Controls.Add(this.Learning_Rate_TXT_Box);
            this.Controls.Add(this.Num_Epochs_TXT_Box);
            this.Controls.Add(this.Num_Hidden_TXT_Box);
            this.Name = "Form1";
            this.Text = "V";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Num_Hidden_TXT_Box;
        private System.Windows.Forms.TextBox Num_Epochs_TXT_Box;
        private System.Windows.Forms.TextBox Learning_Rate_TXT_Box;
        private System.Windows.Forms.TextBox Num_Neurons_TXT_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Bias_Check_Box;
        private System.Windows.Forms.ComboBox Activation_Function_Compo_Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox With_MSE_Check_Box;
        private System.Windows.Forms.CheckBox WithOut_MSE_Check_Box;
        private System.Windows.Forms.TextBox MSE_Threshold_TXT_Box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button RUN_Button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

