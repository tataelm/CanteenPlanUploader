
namespace MakelYemekhanePlanYukleyici
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
            this.buttonPostFoodPlan = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonExcelRead = new System.Windows.Forms.Button();
            this.label_excelReadReport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPostFoodPlan
            // 
            this.buttonPostFoodPlan.Location = new System.Drawing.Point(12, 41);
            this.buttonPostFoodPlan.Name = "buttonPostFoodPlan";
            this.buttonPostFoodPlan.Size = new System.Drawing.Size(126, 24);
            this.buttonPostFoodPlan.TabIndex = 0;
            this.buttonPostFoodPlan.Text = "Sunucuya Yükle";
            this.buttonPostFoodPlan.UseVisualStyleBackColor = true;
            this.buttonPostFoodPlan.Click += new System.EventHandler(this.buttonPostFoodPlan_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonExcelRead
            // 
            this.buttonExcelRead.Location = new System.Drawing.Point(12, 12);
            this.buttonExcelRead.Name = "buttonExcelRead";
            this.buttonExcelRead.Size = new System.Drawing.Size(126, 23);
            this.buttonExcelRead.TabIndex = 1;
            this.buttonExcelRead.Text = "Excel oku";
            this.buttonExcelRead.UseVisualStyleBackColor = true;
            this.buttonExcelRead.Click += new System.EventHandler(this.buttonExcelRead_Click);
            // 
            // label_excelReadReport
            // 
            this.label_excelReadReport.AutoSize = true;
            this.label_excelReadReport.Location = new System.Drawing.Point(145, 17);
            this.label_excelReadReport.Name = "label_excelReadReport";
            this.label_excelReadReport.Size = new System.Drawing.Size(35, 13);
            this.label_excelReadReport.TabIndex = 2;
            this.label_excelReadReport.Text = "label1";
            this.label_excelReadReport.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 71);
            this.Controls.Add(this.label_excelReadReport);
            this.Controls.Add(this.buttonExcelRead);
            this.Controls.Add(this.buttonPostFoodPlan);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Makel Yemekhane Aylık Plan Yükleyici";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPostFoodPlan;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonExcelRead;
        private System.Windows.Forms.Label label_excelReadReport;
    }
}

