/*
 * Created by SharpDevelop.
 * User: 123
 * Date: 14.10.2017
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TemperatureRegistratorService0
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Timer timerView;
		private System.Windows.Forms.ComboBox comboBoxPort;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Label labelSerialPort;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.SaveFileDialog saveFileDialogOutputFile;
		private System.Windows.Forms.GroupBox groupBoxCommunication;
		private System.Windows.Forms.GroupBox groupBoxControl;
		private System.Windows.Forms.GroupBox groupBoxMonitor;
		private System.Windows.Forms.GroupBox groupBoxMesurement;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.GroupBox groupBoxMemory;
		private System.Windows.Forms.Button buttonReadPage;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.Button buttonStatus;
		private System.Windows.Forms.GroupBox groupBoxChennel;
		private System.Windows.Forms.Button buttonGet;
		private System.Windows.Forms.NumericUpDown numericUpDownGet;
		private System.Windows.Forms.TextBox textBoxPageAddress;
		private System.Windows.Forms.Label labelPageAddress;
		private System.Windows.Forms.GroupBox groupBoxMemoryMap;
		private System.Windows.Forms.Label labelMemoryMap0;
		private System.Windows.Forms.Label labelMemoryMap13;
		private System.Windows.Forms.Label labelMemoryMap12;
		private System.Windows.Forms.Label labelMemoryMap11;
		private System.Windows.Forms.Label labelMemoryMap10;
		private System.Windows.Forms.Label labelMemoryMap9;
		private System.Windows.Forms.Label labelMemoryMap8;
		private System.Windows.Forms.Label labelMemoryMap7;
		private System.Windows.Forms.Label labelMemoryMap6;
		private System.Windows.Forms.Label labelMemoryMap5;
		private System.Windows.Forms.Label labelMemoryMap4;
		private System.Windows.Forms.Label labelMemoryMap3;
		private System.Windows.Forms.Label labelMemoryMap2;
		private System.Windows.Forms.Label labelMemoryMap1;
		private System.Windows.Forms.Label labelMemoryMap20;
		private System.Windows.Forms.Label labelMemoryMap19;
		private System.Windows.Forms.Label labelMemoryMap18;
		private System.Windows.Forms.Label labelMemoryMap17;
		private System.Windows.Forms.Label labelMemoryMap16;
		private System.Windows.Forms.Label labelMemoryMap15;
		private System.Windows.Forms.Label labelMemoryMap14;
		private System.Windows.Forms.Button buttonSectorClear;
		private System.Windows.Forms.Label labelMemoryMap31;
		private System.Windows.Forms.Label labelMemoryMap30;
		private System.Windows.Forms.Label labelMemoryMap29;
		private System.Windows.Forms.Label labelMemoryMap28;
		private System.Windows.Forms.Label labelMemoryMap27;
		private System.Windows.Forms.Label labelMemoryMap26;
		private System.Windows.Forms.Label labelMemoryMap25;
		private System.Windows.Forms.Label labelMemoryMap24;
		private System.Windows.Forms.Label labelMemoryMap23;
		private System.Windows.Forms.Label labelMemoryMap22;
		private System.Windows.Forms.Label labelMemoryMap21;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Button buttonState;
		private System.Windows.Forms.Button buttonSectorRead;
		private System.Windows.Forms.Label labelSectorAddress;
		private System.Windows.Forms.ProgressBar progressBarDuration;
		private System.Windows.Forms.Button buttonAddress;
		private System.Windows.Forms.Button buttonWorkTime;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.Button buttonErase4K;
		private System.Windows.Forms.Button buttonChipRead;
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.timerView = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialogOutputFile = new System.Windows.Forms.SaveFileDialog();
			this.groupBoxCommunication = new System.Windows.Forms.GroupBox();
			this.labelSerialPort = new System.Windows.Forms.Label();
			this.comboBoxPort = new System.Windows.Forms.ComboBox();
			this.groupBoxControl = new System.Windows.Forms.GroupBox();
			this.groupBoxMemory = new System.Windows.Forms.GroupBox();
			this.textBoxPageAddress = new System.Windows.Forms.TextBox();
			this.labelPageAddress = new System.Windows.Forms.Label();
			this.buttonStatus = new System.Windows.Forms.Button();
			this.buttonErase4K = new System.Windows.Forms.Button();
			this.buttonReadPage = new System.Windows.Forms.Button();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.groupBoxMesurement = new System.Windows.Forms.GroupBox();
			this.buttonAddress = new System.Windows.Forms.Button();
			this.buttonWorkTime = new System.Windows.Forms.Button();
			this.progressBarDuration = new System.Windows.Forms.ProgressBar();
			this.buttonState = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.groupBoxChennel = new System.Windows.Forms.GroupBox();
			this.numericUpDownGet = new System.Windows.Forms.NumericUpDown();
			this.buttonGet = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.groupBoxMemoryMap = new System.Windows.Forms.GroupBox();
			this.buttonSectorRead = new System.Windows.Forms.Button();
			this.labelSectorAddress = new System.Windows.Forms.Label();
			this.buttonSectorClear = new System.Windows.Forms.Button();
			this.labelMemoryMap31 = new System.Windows.Forms.Label();
			this.labelMemoryMap30 = new System.Windows.Forms.Label();
			this.labelMemoryMap29 = new System.Windows.Forms.Label();
			this.labelMemoryMap28 = new System.Windows.Forms.Label();
			this.labelMemoryMap27 = new System.Windows.Forms.Label();
			this.labelMemoryMap26 = new System.Windows.Forms.Label();
			this.labelMemoryMap25 = new System.Windows.Forms.Label();
			this.labelMemoryMap24 = new System.Windows.Forms.Label();
			this.labelMemoryMap23 = new System.Windows.Forms.Label();
			this.labelMemoryMap22 = new System.Windows.Forms.Label();
			this.labelMemoryMap21 = new System.Windows.Forms.Label();
			this.labelMemoryMap20 = new System.Windows.Forms.Label();
			this.labelMemoryMap19 = new System.Windows.Forms.Label();
			this.labelMemoryMap18 = new System.Windows.Forms.Label();
			this.labelMemoryMap17 = new System.Windows.Forms.Label();
			this.labelMemoryMap16 = new System.Windows.Forms.Label();
			this.labelMemoryMap15 = new System.Windows.Forms.Label();
			this.labelMemoryMap14 = new System.Windows.Forms.Label();
			this.labelMemoryMap13 = new System.Windows.Forms.Label();
			this.labelMemoryMap12 = new System.Windows.Forms.Label();
			this.labelMemoryMap11 = new System.Windows.Forms.Label();
			this.labelMemoryMap10 = new System.Windows.Forms.Label();
			this.labelMemoryMap9 = new System.Windows.Forms.Label();
			this.labelMemoryMap8 = new System.Windows.Forms.Label();
			this.labelMemoryMap7 = new System.Windows.Forms.Label();
			this.labelMemoryMap6 = new System.Windows.Forms.Label();
			this.labelMemoryMap5 = new System.Windows.Forms.Label();
			this.labelMemoryMap4 = new System.Windows.Forms.Label();
			this.labelMemoryMap3 = new System.Windows.Forms.Label();
			this.labelMemoryMap2 = new System.Windows.Forms.Label();
			this.labelMemoryMap1 = new System.Windows.Forms.Label();
			this.labelMemoryMap0 = new System.Windows.Forms.Label();
			this.buttonChipRead = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.groupBoxCommunication.SuspendLayout();
			this.groupBoxControl.SuspendLayout();
			this.groupBoxMemory.SuspendLayout();
			this.groupBoxMesurement.SuspendLayout();
			this.groupBoxChennel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGet)).BeginInit();
			this.groupBoxMonitor.SuspendLayout();
			this.groupBoxMemoryMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// timerView
			// 
			this.timerView.Tick += new System.EventHandler(this.TimerViewTick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1,
			this.toolStripStatusLabel2,
			this.toolStripStatusLabel3,
			this.toolStripStatusLabel4,
			this.toolStripStatusLabel5});
			this.statusStrip1.Location = new System.Drawing.Point(0, 516);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(925, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
			// 
			// toolStripStatusLabel5
			// 
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			this.toolStripStatusLabel5.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
			// 
			// groupBoxCommunication
			// 
			this.groupBoxCommunication.Controls.Add(this.labelSerialPort);
			this.groupBoxCommunication.Controls.Add(this.comboBoxPort);
			this.groupBoxCommunication.Location = new System.Drawing.Point(12, 12);
			this.groupBoxCommunication.Name = "groupBoxCommunication";
			this.groupBoxCommunication.Size = new System.Drawing.Size(143, 68);
			this.groupBoxCommunication.TabIndex = 10;
			this.groupBoxCommunication.TabStop = false;
			this.groupBoxCommunication.Text = "Связь";
			// 
			// labelSerialPort
			// 
			this.labelSerialPort.AutoSize = true;
			this.labelSerialPort.Location = new System.Drawing.Point(6, 16);
			this.labelSerialPort.Name = "labelSerialPort";
			this.labelSerialPort.Size = new System.Drawing.Size(132, 13);
			this.labelSerialPort.TabIndex = 6;
			this.labelSerialPort.Text = "Последовательный порт";
			// 
			// comboBoxPort
			// 
			this.comboBoxPort.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxPort.FormattingEnabled = true;
			this.comboBoxPort.Location = new System.Drawing.Point(10, 35);
			this.comboBoxPort.Name = "comboBoxPort";
			this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
			this.comboBoxPort.TabIndex = 5;
			// 
			// groupBoxControl
			// 
			this.groupBoxControl.Controls.Add(this.groupBoxMemory);
			this.groupBoxControl.Controls.Add(this.groupBoxMesurement);
			this.groupBoxControl.Location = new System.Drawing.Point(12, 86);
			this.groupBoxControl.Name = "groupBoxControl";
			this.groupBoxControl.Size = new System.Drawing.Size(233, 341);
			this.groupBoxControl.TabIndex = 11;
			this.groupBoxControl.TabStop = false;
			this.groupBoxControl.Text = "Управление";
			// 
			// groupBoxMemory
			// 
			this.groupBoxMemory.Controls.Add(this.textBoxPageAddress);
			this.groupBoxMemory.Controls.Add(this.labelPageAddress);
			this.groupBoxMemory.Controls.Add(this.buttonStatus);
			this.groupBoxMemory.Controls.Add(this.buttonErase4K);
			this.groupBoxMemory.Controls.Add(this.buttonReadPage);
			this.groupBoxMemory.Controls.Add(this.buttonWrite);
			this.groupBoxMemory.Location = new System.Drawing.Point(6, 231);
			this.groupBoxMemory.Name = "groupBoxMemory";
			this.groupBoxMemory.Size = new System.Drawing.Size(218, 104);
			this.groupBoxMemory.TabIndex = 14;
			this.groupBoxMemory.TabStop = false;
			this.groupBoxMemory.Text = "Память";
			// 
			// textBoxPageAddress
			// 
			this.textBoxPageAddress.Location = new System.Drawing.Point(72, 20);
			this.textBoxPageAddress.Name = "textBoxPageAddress";
			this.textBoxPageAddress.Size = new System.Drawing.Size(79, 20);
			this.textBoxPageAddress.TabIndex = 5;
			this.textBoxPageAddress.Text = "0";
			// 
			// labelPageAddress
			// 
			this.labelPageAddress.Location = new System.Drawing.Point(6, 16);
			this.labelPageAddress.Name = "labelPageAddress";
			this.labelPageAddress.Size = new System.Drawing.Size(59, 23);
			this.labelPageAddress.TabIndex = 4;
			this.labelPageAddress.Text = "Страница";
			this.labelPageAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonStatus
			// 
			this.buttonStatus.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonStatus.Location = new System.Drawing.Point(112, 75);
			this.buttonStatus.Name = "buttonStatus";
			this.buttonStatus.Size = new System.Drawing.Size(100, 23);
			this.buttonStatus.TabIndex = 3;
			this.buttonStatus.Text = "СТАТУС";
			this.buttonStatus.UseVisualStyleBackColor = true;
			// 
			// buttonErase4K
			// 
			this.buttonErase4K.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonErase4K.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonErase4K.Location = new System.Drawing.Point(6, 75);
			this.buttonErase4K.Name = "buttonErase4K";
			this.buttonErase4K.Size = new System.Drawing.Size(100, 23);
			this.buttonErase4K.TabIndex = 2;
			this.buttonErase4K.Text = "ОЧИСТКА 4К";
			this.buttonErase4K.UseVisualStyleBackColor = true;
			// 
			// buttonReadPage
			// 
			this.buttonReadPage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonReadPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonReadPage.Location = new System.Drawing.Point(6, 46);
			this.buttonReadPage.Name = "buttonReadPage";
			this.buttonReadPage.Size = new System.Drawing.Size(100, 23);
			this.buttonReadPage.TabIndex = 1;
			this.buttonReadPage.Text = "ЧТЕНИЕ";
			this.buttonReadPage.UseVisualStyleBackColor = true;
			// 
			// buttonWrite
			// 
			this.buttonWrite.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonWrite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonWrite.Location = new System.Drawing.Point(112, 46);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(100, 23);
			this.buttonWrite.TabIndex = 0;
			this.buttonWrite.Text = "ЗАПИСЬ";
			this.buttonWrite.UseVisualStyleBackColor = true;
			// 
			// groupBoxMesurement
			// 
			this.groupBoxMesurement.Controls.Add(this.buttonAddress);
			this.groupBoxMesurement.Controls.Add(this.buttonWorkTime);
			this.groupBoxMesurement.Controls.Add(this.progressBarDuration);
			this.groupBoxMesurement.Controls.Add(this.buttonState);
			this.groupBoxMesurement.Controls.Add(this.buttonReset);
			this.groupBoxMesurement.Controls.Add(this.groupBoxChennel);
			this.groupBoxMesurement.Controls.Add(this.buttonStop);
			this.groupBoxMesurement.Controls.Add(this.buttonStart);
			this.groupBoxMesurement.Location = new System.Drawing.Point(6, 17);
			this.groupBoxMesurement.Name = "groupBoxMesurement";
			this.groupBoxMesurement.Size = new System.Drawing.Size(218, 208);
			this.groupBoxMesurement.TabIndex = 13;
			this.groupBoxMesurement.TabStop = false;
			this.groupBoxMesurement.Text = "Измерение";
			// 
			// buttonAddress
			// 
			this.buttonAddress.Location = new System.Drawing.Point(126, 163);
			this.buttonAddress.Name = "buttonAddress";
			this.buttonAddress.Size = new System.Drawing.Size(86, 23);
			this.buttonAddress.TabIndex = 20;
			this.buttonAddress.Text = "АДРЕС";
			this.buttonAddress.UseVisualStyleBackColor = true;
			// 
			// buttonWorkTime
			// 
			this.buttonWorkTime.Location = new System.Drawing.Point(12, 163);
			this.buttonWorkTime.Name = "buttonWorkTime";
			this.buttonWorkTime.Size = new System.Drawing.Size(94, 23);
			this.buttonWorkTime.TabIndex = 19;
			this.buttonWorkTime.Text = "ВРЕМЯ";
			this.buttonWorkTime.UseVisualStyleBackColor = true;
			// 
			// progressBarDuration
			// 
			this.progressBarDuration.Location = new System.Drawing.Point(12, 124);
			this.progressBarDuration.Name = "progressBarDuration";
			this.progressBarDuration.Size = new System.Drawing.Size(200, 23);
			this.progressBarDuration.TabIndex = 18;
			// 
			// buttonState
			// 
			this.buttonState.Location = new System.Drawing.Point(12, 95);
			this.buttonState.Name = "buttonState";
			this.buttonState.Size = new System.Drawing.Size(94, 23);
			this.buttonState.TabIndex = 17;
			this.buttonState.Text = "СОСТОЯНИЕ";
			this.buttonState.UseVisualStyleBackColor = true;
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(126, 13);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(86, 23);
			this.buttonReset.TabIndex = 16;
			this.buttonReset.Text = "СБРОС";
			this.buttonReset.UseVisualStyleBackColor = true;
			// 
			// groupBoxChennel
			// 
			this.groupBoxChennel.Controls.Add(this.numericUpDownGet);
			this.groupBoxChennel.Controls.Add(this.buttonGet);
			this.groupBoxChennel.Location = new System.Drawing.Point(6, 19);
			this.groupBoxChennel.Name = "groupBoxChennel";
			this.groupBoxChennel.Size = new System.Drawing.Size(109, 75);
			this.groupBoxChennel.TabIndex = 14;
			this.groupBoxChennel.TabStop = false;
			this.groupBoxChennel.Text = "Канал";
			// 
			// numericUpDownGet
			// 
			this.numericUpDownGet.Cursor = System.Windows.Forms.Cursors.Hand;
			this.numericUpDownGet.Location = new System.Drawing.Point(6, 12);
			this.numericUpDownGet.Maximum = new decimal(new int[] {
			12,
			0,
			0,
			0});
			this.numericUpDownGet.Name = "numericUpDownGet";
			this.numericUpDownGet.Size = new System.Drawing.Size(94, 20);
			this.numericUpDownGet.TabIndex = 1;
			this.numericUpDownGet.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// buttonGet
			// 
			this.buttonGet.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonGet.Location = new System.Drawing.Point(6, 38);
			this.buttonGet.Name = "buttonGet";
			this.buttonGet.Size = new System.Drawing.Size(94, 25);
			this.buttonGet.TabIndex = 0;
			this.buttonGet.Text = "Измерить";
			this.buttonGet.UseVisualStyleBackColor = true;
			// 
			// buttonStop
			// 
			this.buttonStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonStop.Location = new System.Drawing.Point(126, 93);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(86, 25);
			this.buttonStop.TabIndex = 13;
			this.buttonStop.Text = "СТОП";
			this.buttonStop.UseVisualStyleBackColor = true;
			// 
			// buttonStart
			// 
			this.buttonStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonStart.Location = new System.Drawing.Point(126, 57);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(86, 23);
			this.buttonStart.TabIndex = 12;
			this.buttonStart.Text = "СТАРТ";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// groupBoxMonitor
			// 
			this.groupBoxMonitor.Controls.Add(this.buttonSave);
			this.groupBoxMonitor.Controls.Add(this.buttonClear);
			this.groupBoxMonitor.Controls.Add(this.richTextBoxLog);
			this.groupBoxMonitor.Location = new System.Drawing.Point(462, 12);
			this.groupBoxMonitor.Name = "groupBoxMonitor";
			this.groupBoxMonitor.Size = new System.Drawing.Size(451, 501);
			this.groupBoxMonitor.TabIndex = 12;
			this.groupBoxMonitor.TabStop = false;
			this.groupBoxMonitor.Text = "Монитор последовательного порта";
			// 
			// buttonSave
			// 
			this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSave.Location = new System.Drawing.Point(89, 472);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 8;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// buttonClear
			// 
			this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonClear.Location = new System.Drawing.Point(8, 472);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(75, 23);
			this.buttonClear.TabIndex = 7;
			this.buttonClear.Text = "Очистить";
			this.buttonClear.UseVisualStyleBackColor = true;
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(6, 13);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.Size = new System.Drawing.Size(439, 453);
			this.richTextBoxLog.TabIndex = 4;
			this.richTextBoxLog.Text = "";
			// 
			// groupBoxMemoryMap
			// 
			this.groupBoxMemoryMap.Controls.Add(this.buttonChipRead);
			this.groupBoxMemoryMap.Controls.Add(this.buttonSectorRead);
			this.groupBoxMemoryMap.Controls.Add(this.labelSectorAddress);
			this.groupBoxMemoryMap.Controls.Add(this.buttonSectorClear);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap31);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap30);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap29);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap28);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap27);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap26);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap25);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap24);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap23);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap22);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap21);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap20);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap19);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap18);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap17);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap16);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap15);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap14);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap13);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap12);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap11);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap10);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap9);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap8);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap7);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap6);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap5);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap4);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap3);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap2);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap1);
			this.groupBoxMemoryMap.Controls.Add(this.labelMemoryMap0);
			this.groupBoxMemoryMap.Location = new System.Drawing.Point(256, 86);
			this.groupBoxMemoryMap.Name = "groupBoxMemoryMap";
			this.groupBoxMemoryMap.Size = new System.Drawing.Size(186, 341);
			this.groupBoxMemoryMap.TabIndex = 13;
			this.groupBoxMemoryMap.TabStop = false;
			this.groupBoxMemoryMap.Text = "Карта памяти";
			// 
			// buttonSectorRead
			// 
			this.buttonSectorRead.Location = new System.Drawing.Point(26, 261);
			this.buttonSectorRead.Name = "buttonSectorRead";
			this.buttonSectorRead.Size = new System.Drawing.Size(138, 23);
			this.buttonSectorRead.TabIndex = 34;
			this.buttonSectorRead.Text = "ЧТЕНИЕ СЕКТОРА";
			this.buttonSectorRead.UseVisualStyleBackColor = true;
			// 
			// labelSectorAddress
			// 
			this.labelSectorAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelSectorAddress.Location = new System.Drawing.Point(26, 202);
			this.labelSectorAddress.Name = "labelSectorAddress";
			this.labelSectorAddress.Size = new System.Drawing.Size(138, 23);
			this.labelSectorAddress.TabIndex = 33;
			this.labelSectorAddress.Text = "0";
			this.labelSectorAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonSectorClear
			// 
			this.buttonSectorClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonSectorClear.Location = new System.Drawing.Point(26, 232);
			this.buttonSectorClear.Name = "buttonSectorClear";
			this.buttonSectorClear.Size = new System.Drawing.Size(138, 23);
			this.buttonSectorClear.TabIndex = 32;
			this.buttonSectorClear.Text = "ОЧИСТКА СЕКТОРА";
			this.buttonSectorClear.UseVisualStyleBackColor = true;
			// 
			// labelMemoryMap31
			// 
			this.labelMemoryMap31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap31.Location = new System.Drawing.Point(36, 166);
			this.labelMemoryMap31.Name = "labelMemoryMap31";
			this.labelMemoryMap31.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap31.TabIndex = 31;
			this.labelMemoryMap31.Text = "31";
			this.labelMemoryMap31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap30
			// 
			this.labelMemoryMap30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap30.Location = new System.Drawing.Point(6, 166);
			this.labelMemoryMap30.Name = "labelMemoryMap30";
			this.labelMemoryMap30.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap30.TabIndex = 30;
			this.labelMemoryMap30.Text = "30";
			this.labelMemoryMap30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap29
			// 
			this.labelMemoryMap29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap29.Location = new System.Drawing.Point(156, 136);
			this.labelMemoryMap29.Name = "labelMemoryMap29";
			this.labelMemoryMap29.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap29.TabIndex = 29;
			this.labelMemoryMap29.Text = "29";
			this.labelMemoryMap29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap28
			// 
			this.labelMemoryMap28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap28.Location = new System.Drawing.Point(126, 136);
			this.labelMemoryMap28.Name = "labelMemoryMap28";
			this.labelMemoryMap28.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap28.TabIndex = 28;
			this.labelMemoryMap28.Text = "28";
			this.labelMemoryMap28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap27
			// 
			this.labelMemoryMap27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap27.Location = new System.Drawing.Point(96, 136);
			this.labelMemoryMap27.Name = "labelMemoryMap27";
			this.labelMemoryMap27.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap27.TabIndex = 27;
			this.labelMemoryMap27.Text = "27";
			this.labelMemoryMap27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap26
			// 
			this.labelMemoryMap26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap26.Location = new System.Drawing.Point(66, 136);
			this.labelMemoryMap26.Name = "labelMemoryMap26";
			this.labelMemoryMap26.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap26.TabIndex = 26;
			this.labelMemoryMap26.Text = "26";
			this.labelMemoryMap26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap25
			// 
			this.labelMemoryMap25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap25.Location = new System.Drawing.Point(36, 136);
			this.labelMemoryMap25.Name = "labelMemoryMap25";
			this.labelMemoryMap25.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap25.TabIndex = 25;
			this.labelMemoryMap25.Text = "25";
			this.labelMemoryMap25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap24
			// 
			this.labelMemoryMap24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap24.Location = new System.Drawing.Point(6, 136);
			this.labelMemoryMap24.Name = "labelMemoryMap24";
			this.labelMemoryMap24.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap24.TabIndex = 24;
			this.labelMemoryMap24.Text = "24";
			this.labelMemoryMap24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap23
			// 
			this.labelMemoryMap23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap23.Location = new System.Drawing.Point(156, 105);
			this.labelMemoryMap23.Name = "labelMemoryMap23";
			this.labelMemoryMap23.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap23.TabIndex = 23;
			this.labelMemoryMap23.Text = "23";
			this.labelMemoryMap23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap22
			// 
			this.labelMemoryMap22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap22.Location = new System.Drawing.Point(126, 105);
			this.labelMemoryMap22.Name = "labelMemoryMap22";
			this.labelMemoryMap22.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap22.TabIndex = 22;
			this.labelMemoryMap22.Text = "22";
			this.labelMemoryMap22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap21
			// 
			this.labelMemoryMap21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap21.Location = new System.Drawing.Point(96, 105);
			this.labelMemoryMap21.Name = "labelMemoryMap21";
			this.labelMemoryMap21.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap21.TabIndex = 21;
			this.labelMemoryMap21.Text = "21";
			this.labelMemoryMap21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap20
			// 
			this.labelMemoryMap20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap20.Location = new System.Drawing.Point(66, 105);
			this.labelMemoryMap20.Name = "labelMemoryMap20";
			this.labelMemoryMap20.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap20.TabIndex = 20;
			this.labelMemoryMap20.Text = "20";
			this.labelMemoryMap20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap19
			// 
			this.labelMemoryMap19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap19.Location = new System.Drawing.Point(36, 105);
			this.labelMemoryMap19.Name = "labelMemoryMap19";
			this.labelMemoryMap19.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap19.TabIndex = 19;
			this.labelMemoryMap19.Text = "19";
			this.labelMemoryMap19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap18
			// 
			this.labelMemoryMap18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap18.Location = new System.Drawing.Point(6, 105);
			this.labelMemoryMap18.Name = "labelMemoryMap18";
			this.labelMemoryMap18.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap18.TabIndex = 18;
			this.labelMemoryMap18.Text = "18";
			this.labelMemoryMap18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap17
			// 
			this.labelMemoryMap17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap17.Location = new System.Drawing.Point(156, 74);
			this.labelMemoryMap17.Name = "labelMemoryMap17";
			this.labelMemoryMap17.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap17.TabIndex = 17;
			this.labelMemoryMap17.Text = "17";
			this.labelMemoryMap17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap16
			// 
			this.labelMemoryMap16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap16.Location = new System.Drawing.Point(126, 75);
			this.labelMemoryMap16.Name = "labelMemoryMap16";
			this.labelMemoryMap16.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap16.TabIndex = 16;
			this.labelMemoryMap16.Text = "16";
			this.labelMemoryMap16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap15
			// 
			this.labelMemoryMap15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap15.Location = new System.Drawing.Point(96, 75);
			this.labelMemoryMap15.Name = "labelMemoryMap15";
			this.labelMemoryMap15.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap15.TabIndex = 15;
			this.labelMemoryMap15.Text = "15";
			this.labelMemoryMap15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap14
			// 
			this.labelMemoryMap14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap14.Location = new System.Drawing.Point(66, 75);
			this.labelMemoryMap14.Name = "labelMemoryMap14";
			this.labelMemoryMap14.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap14.TabIndex = 14;
			this.labelMemoryMap14.Text = "14";
			this.labelMemoryMap14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap13
			// 
			this.labelMemoryMap13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap13.Location = new System.Drawing.Point(36, 75);
			this.labelMemoryMap13.Name = "labelMemoryMap13";
			this.labelMemoryMap13.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap13.TabIndex = 13;
			this.labelMemoryMap13.Text = "13";
			this.labelMemoryMap13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap12
			// 
			this.labelMemoryMap12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap12.Location = new System.Drawing.Point(6, 75);
			this.labelMemoryMap12.Name = "labelMemoryMap12";
			this.labelMemoryMap12.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap12.TabIndex = 12;
			this.labelMemoryMap12.Text = "12";
			this.labelMemoryMap12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap11
			// 
			this.labelMemoryMap11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap11.Location = new System.Drawing.Point(156, 47);
			this.labelMemoryMap11.Name = "labelMemoryMap11";
			this.labelMemoryMap11.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap11.TabIndex = 11;
			this.labelMemoryMap11.Text = "11";
			this.labelMemoryMap11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap10
			// 
			this.labelMemoryMap10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap10.Location = new System.Drawing.Point(126, 47);
			this.labelMemoryMap10.Name = "labelMemoryMap10";
			this.labelMemoryMap10.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap10.TabIndex = 10;
			this.labelMemoryMap10.Text = "10";
			this.labelMemoryMap10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap9
			// 
			this.labelMemoryMap9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap9.Location = new System.Drawing.Point(96, 47);
			this.labelMemoryMap9.Name = "labelMemoryMap9";
			this.labelMemoryMap9.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap9.TabIndex = 9;
			this.labelMemoryMap9.Text = "9";
			this.labelMemoryMap9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap8
			// 
			this.labelMemoryMap8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap8.Location = new System.Drawing.Point(66, 47);
			this.labelMemoryMap8.Name = "labelMemoryMap8";
			this.labelMemoryMap8.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap8.TabIndex = 8;
			this.labelMemoryMap8.Text = "8";
			this.labelMemoryMap8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap7
			// 
			this.labelMemoryMap7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap7.Location = new System.Drawing.Point(36, 47);
			this.labelMemoryMap7.Name = "labelMemoryMap7";
			this.labelMemoryMap7.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap7.TabIndex = 7;
			this.labelMemoryMap7.Text = "7";
			this.labelMemoryMap7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap6
			// 
			this.labelMemoryMap6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap6.Location = new System.Drawing.Point(6, 47);
			this.labelMemoryMap6.Name = "labelMemoryMap6";
			this.labelMemoryMap6.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap6.TabIndex = 6;
			this.labelMemoryMap6.Text = "6";
			this.labelMemoryMap6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap5
			// 
			this.labelMemoryMap5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap5.Location = new System.Drawing.Point(156, 17);
			this.labelMemoryMap5.Name = "labelMemoryMap5";
			this.labelMemoryMap5.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap5.TabIndex = 5;
			this.labelMemoryMap5.Text = "5";
			this.labelMemoryMap5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap4
			// 
			this.labelMemoryMap4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap4.Location = new System.Drawing.Point(126, 17);
			this.labelMemoryMap4.Name = "labelMemoryMap4";
			this.labelMemoryMap4.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap4.TabIndex = 4;
			this.labelMemoryMap4.Text = "4";
			this.labelMemoryMap4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap3
			// 
			this.labelMemoryMap3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap3.Location = new System.Drawing.Point(96, 17);
			this.labelMemoryMap3.Name = "labelMemoryMap3";
			this.labelMemoryMap3.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap3.TabIndex = 3;
			this.labelMemoryMap3.Text = "3";
			this.labelMemoryMap3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap2
			// 
			this.labelMemoryMap2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap2.Location = new System.Drawing.Point(66, 17);
			this.labelMemoryMap2.Name = "labelMemoryMap2";
			this.labelMemoryMap2.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap2.TabIndex = 2;
			this.labelMemoryMap2.Text = "2";
			this.labelMemoryMap2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap1
			// 
			this.labelMemoryMap1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap1.Location = new System.Drawing.Point(36, 17);
			this.labelMemoryMap1.Name = "labelMemoryMap1";
			this.labelMemoryMap1.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap1.TabIndex = 1;
			this.labelMemoryMap1.Text = "1";
			this.labelMemoryMap1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMemoryMap0
			// 
			this.labelMemoryMap0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelMemoryMap0.Location = new System.Drawing.Point(6, 17);
			this.labelMemoryMap0.Name = "labelMemoryMap0";
			this.labelMemoryMap0.Size = new System.Drawing.Size(24, 24);
			this.labelMemoryMap0.TabIndex = 0;
			this.labelMemoryMap0.Text = "0";
			this.labelMemoryMap0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonChipRead
			// 
			this.buttonChipRead.Location = new System.Drawing.Point(26, 306);
			this.buttonChipRead.Name = "buttonChipRead";
			this.buttonChipRead.Size = new System.Drawing.Size(138, 23);
			this.buttonChipRead.TabIndex = 35;
			this.buttonChipRead.Text = "ЧТЕНИЕ КРИСТАЛЛА";
			this.buttonChipRead.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 538);
			this.Controls.Add(this.groupBoxMemoryMap);
			this.Controls.Add(this.groupBoxMonitor);
			this.Controls.Add(this.groupBoxControl);
			this.Controls.Add(this.groupBoxCommunication);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Программа управления температурным регистратором v 2.1.0";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxCommunication.ResumeLayout(false);
			this.groupBoxCommunication.PerformLayout();
			this.groupBoxControl.ResumeLayout(false);
			this.groupBoxMemory.ResumeLayout(false);
			this.groupBoxMemory.PerformLayout();
			this.groupBoxMesurement.ResumeLayout(false);
			this.groupBoxChennel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGet)).EndInit();
			this.groupBoxMonitor.ResumeLayout(false);
			this.groupBoxMemoryMap.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
