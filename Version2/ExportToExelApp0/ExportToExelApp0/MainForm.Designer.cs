/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 30.07.2019
 * Time: 9:23
 * 
 * 
 * 
 */
namespace ExportToExelApp0
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBoxExel;
		private System.Windows.Forms.Button buttonExelSave;
		private System.Windows.Forms.RichTextBox richTextBoxData;
		private System.Windows.Forms.Button buttonReadPage;
		private System.Windows.Forms.ProgressBar progressBarDuration;
		private System.Windows.Forms.Label labelInputFileName;
		private System.Windows.Forms.Label labelOutputFileName;
		private System.Windows.Forms.StatusStrip statusStripInfo;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBoxExel = new System.Windows.Forms.GroupBox();
			this.buttonReadPage = new System.Windows.Forms.Button();
			this.buttonExelSave = new System.Windows.Forms.Button();
			this.richTextBoxData = new System.Windows.Forms.RichTextBox();
			this.progressBarDuration = new System.Windows.Forms.ProgressBar();
			this.labelInputFileName = new System.Windows.Forms.Label();
			this.labelOutputFileName = new System.Windows.Forms.Label();
			this.statusStripInfo = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxExel.SuspendLayout();
			this.statusStripInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxExel
			// 
			this.groupBoxExel.Controls.Add(this.buttonReadPage);
			this.groupBoxExel.Controls.Add(this.buttonExelSave);
			this.groupBoxExel.Location = new System.Drawing.Point(12, 70);
			this.groupBoxExel.Name = "groupBoxExel";
			this.groupBoxExel.Size = new System.Drawing.Size(88, 180);
			this.groupBoxExel.TabIndex = 1;
			this.groupBoxExel.TabStop = false;
			this.groupBoxExel.Text = "Exel";
			// 
			// buttonReadPage
			// 
			this.buttonReadPage.Location = new System.Drawing.Point(7, 19);
			this.buttonReadPage.Name = "buttonReadPage";
			this.buttonReadPage.Size = new System.Drawing.Size(75, 23);
			this.buttonReadPage.TabIndex = 0;
			this.buttonReadPage.Text = "Read page";
			this.buttonReadPage.UseVisualStyleBackColor = true;
			this.buttonReadPage.Click += new System.EventHandler(this.ButtonReadPageClick);
			// 
			// buttonExelSave
			// 
			this.buttonExelSave.Location = new System.Drawing.Point(6, 151);
			this.buttonExelSave.Name = "buttonExelSave";
			this.buttonExelSave.Size = new System.Drawing.Size(75, 23);
			this.buttonExelSave.TabIndex = 2;
			this.buttonExelSave.Text = "Save";
			this.buttonExelSave.UseVisualStyleBackColor = true;
			this.buttonExelSave.Click += new System.EventHandler(this.ButtonExelSaveClick);
			// 
			// richTextBoxData
			// 
			this.richTextBoxData.Location = new System.Drawing.Point(106, 12);
			this.richTextBoxData.Name = "richTextBoxData";
			this.richTextBoxData.Size = new System.Drawing.Size(276, 238);
			this.richTextBoxData.TabIndex = 2;
			this.richTextBoxData.Text = "";
			// 
			// progressBarDuration
			// 
			this.progressBarDuration.Location = new System.Drawing.Point(12, 256);
			this.progressBarDuration.Maximum = 256;
			this.progressBarDuration.Name = "progressBarDuration";
			this.progressBarDuration.Size = new System.Drawing.Size(370, 23);
			this.progressBarDuration.Step = 1;
			this.progressBarDuration.TabIndex = 3;
			// 
			// labelInputFileName
			// 
			this.labelInputFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelInputFileName.Location = new System.Drawing.Point(12, 287);
			this.labelInputFileName.Name = "labelInputFileName";
			this.labelInputFileName.Size = new System.Drawing.Size(172, 23);
			this.labelInputFileName.TabIndex = 4;
			this.labelInputFileName.Text = "label1";
			this.labelInputFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelOutputFileName
			// 
			this.labelOutputFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelOutputFileName.Location = new System.Drawing.Point(190, 287);
			this.labelOutputFileName.Name = "labelOutputFileName";
			this.labelOutputFileName.Size = new System.Drawing.Size(192, 23);
			this.labelOutputFileName.TabIndex = 5;
			this.labelOutputFileName.Text = "label1";
			this.labelOutputFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusStripInfo
			// 
			this.statusStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1,
			this.toolStripStatusLabel2,
			this.toolStripStatusLabel3});
			this.statusStripInfo.Location = new System.Drawing.Point(0, 325);
			this.statusStripInfo.Name = "statusStripInfo";
			this.statusStripInfo.Size = new System.Drawing.Size(394, 22);
			this.statusStripInfo.TabIndex = 6;
			this.statusStripInfo.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 347);
			this.Controls.Add(this.statusStripInfo);
			this.Controls.Add(this.labelOutputFileName);
			this.Controls.Add(this.labelInputFileName);
			this.Controls.Add(this.progressBarDuration);
			this.Controls.Add(this.richTextBoxData);
			this.Controls.Add(this.groupBoxExel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Export to Exel application v1.0.0";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.groupBoxExel.ResumeLayout(false);
			this.statusStripInfo.ResumeLayout(false);
			this.statusStripInfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
