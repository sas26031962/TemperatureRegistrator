/*
 * Created by SharpDevelop.
 * User: 123
 * Date: 14.10.2017
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using TemperatureRegistratorService0.classes;

namespace TemperatureRegistratorService0
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//=====================================================================
		// Константы
		//=====================================================================
		public Color COLOR_INFO = Color.Navy;
		public Color COLOR_MESSAGE = Color.DarkGray;
		public Color COLOR_INCOMING = Color.DarkCyan;
		
		public string FILE_NAME = "data";
		public string FILE_EXTENSION = "txt";
		
		public const string NAME = "COM57";
		//public const string NAME = "COM42";
		//public const string NAME = "COM39";
		//public const int BAUD = 9600;
		public const int BAUD = 115200;
		//public const int BAUD = 230400;
		public const int DATA_BITS = 8;
		public const Parity PARITY = Parity.None;
		public const StopBits STOP_BITS = StopBits.One;

		//=====================================================================
		// Атрибуты
		//=====================================================================
		
		//Экземпляр класса обслуживания последовательного порта
		public static cIncoming Incoming;
		
   		public static SerialPort _serialPort;

    	public static bool IsSerialPortReady;
    	public static bool IsSerialPortClose;
    	
    	public static string PortName;
    	
    	int TimerTick;
    	
    	cMesurement Process;
 		
 		public cChip Memory;
   		
 		public cOperationStatus OperationStatus;
    	public cOperationGet OperationGet;
    	public cOperationReadPage OperationReadPage;
    	public cOperationWritePage OperationWritePage;
    	public cOperationErase4K OperationErase4K;
    	public cOperationEraseSector OperationEraseSector;
    	public cOperationReadSector OperationReadSector;
    	public cOpetrationGetDurationTime OperationGetDurationTime;
    	public cOperationGetMemoryAddress OperationGetMemoryAddress;
    	public cOperationReadChip OperationReadChip;
    	
    	//=====================================================================
		//--------------------------------Потоки-------------------------------
		//=====================================================================
		
		//=====================================================================
		// Методы
		//=====================================================================
		
		//=====================================================================
		// Конструкторы
		//=====================================================================
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//=================================================================
			// Инициализация статических переменных
			//=================================================================

			MainForm.Incoming = new cIncoming();
			
			cSector.Address = 0;

			//=================================================================
			// Инициализация визуальных компонентов
			//=================================================================
			this.richTextBoxLog.SelectionColor = COLOR_INFO;
			this.richTextBoxLog.AppendText("Select serial port in ComboBox\n");
			
			this.toolStripStatusLabel1.Text = "Timer: ";
			this.toolStripStatusLabel2.Text = "Status: ";
			this.toolStripStatusLabel3.Text = "Send: ";
			this.toolStripStatusLabel4.Text = "Sink: ";
			this.toolStripStatusLabel5.Text = "";
			
			// Привязка области логирования
			cOperation.richTextBoxLog = this.richTextBoxLog;
			
			// Объекты управления операциями
			this.OperationStatus = new cOperationStatus(this.buttonStatus);
			this.OperationGet = new cOperationGet(this.buttonGet, this.numericUpDownGet);
			this.OperationReadPage = new cOperationReadPage(this.buttonReadPage, this.textBoxPageAddress);
			this.OperationWritePage = new cOperationWritePage(this.buttonWrite, this.textBoxPageAddress);
			this.OperationErase4K = new cOperationErase4K(this.buttonErase4K, this.textBoxPageAddress);
			this.OperationEraseSector = new cOperationEraseSector(this.buttonSectorClear, this.textBoxPageAddress);
			this.OperationReadSector = new cOperationReadSector(this.buttonSectorRead, this.textBoxPageAddress);
			this.OperationGetDurationTime = new cOpetrationGetDurationTime(this.buttonWorkTime);
			this.OperationGetMemoryAddress = new cOperationGetMemoryAddress(this.buttonAddress);
			this.OperationReadChip = new cOperationReadChip(this.buttonChipRead);
			
	
			// Привязка обработчиков событий
			this.comboBoxPort.SelectionChangeCommitted += ComboBoxPortSelectionChangeCommitted;
			this.timerView.Tick += TimerViewTick;
			this.buttonClear.Click += ButtonClearClick;
			this.buttonSave.Click += ButtonSaveClick;
			
			// Запуск таймера
			this.timerView.Start();
			//=================================================================
			// Инициализация COM порта
			//=================================================================
			
			//
			// Чтение доступных портов для проведения выбора
			//
			this.comboBoxPort.Items.Clear();
			foreach (string s in SerialPort.GetPortNames())
        	{
         		this.comboBoxPort.Items.Add(s);
        	}
			
			this.comboBoxPort.SelectedIndex = this.comboBoxPort.Items.Count - 1;
			
			this.Process = new cMesurement(
				this.progressBarDuration,
				this.buttonState,
				this.buttonReset,
				this.buttonStart,
				this.buttonStop
			);
			this.Memory = new cChip();
			
			this.Memory.install(
			this.labelMemoryMap0, this.labelMemoryMap1, this.labelMemoryMap2, this.labelMemoryMap3,
			this.labelMemoryMap4, this.labelMemoryMap5, this.labelMemoryMap6, this.labelMemoryMap7,
			this.labelMemoryMap8, this.labelMemoryMap9, this.labelMemoryMap10, this.labelMemoryMap11,
			this.labelMemoryMap12, this.labelMemoryMap13, this.labelMemoryMap14, this.labelMemoryMap15,
			this.labelMemoryMap16, this.labelMemoryMap17, this.labelMemoryMap18, this.labelMemoryMap19,
			this.labelMemoryMap20, this.labelMemoryMap21, this.labelMemoryMap22, this.labelMemoryMap23,
			this.labelMemoryMap24, this.labelMemoryMap25, this.labelMemoryMap26, this.labelMemoryMap27,
			this.labelMemoryMap28, this.labelMemoryMap29, this.labelMemoryMap30, this.labelMemoryMap31
			);
			
		}//End of ctor
		
		//===========================================================================
		//---------------------------- Обработчики событий --------------------------
		//===========================================================================
		
		/// <summary>
		/// Обработчик события приёма байтов из последовательного порта
		/// Здесь
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void serialPort1_DataResived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			this.Invoke(new EventHandler(DoUpdate));
		}
		
		/// <summary>
		/// Функция обработки события приёма байта по последовательному порту
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		private void DoUpdate(object s, EventArgs e)
		{
			string str =  _serialPort.ReadExisting();
			foreach(char x in str)
			{
				switch(x)
				{
					case '{':
						MainForm.Incoming.IsInitialCurlyBracket = true; 
						//Debug.WriteLine("{");
						break;
					case '}':
						MainForm.Incoming.IsFinalCurlyBracket = true; 
						//Debug.WriteLine("}");
						break;
						
					default:
						break;
				}
				MainForm.Incoming.SinkBuffer = MainForm.Incoming.SinkBuffer	+ x;
				MainForm.Incoming.SinkByteCounter++;
			}

		}//End of private void DoUpdate(object s, EventArgs e)

		/// <summary>
		/// Обработчик таймера
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TimerViewTick(object sender, EventArgs e)
		{
			this.TimerTick++;
			this.statusStrip1.Items[0].Text = "Timer: " + Convert.ToString(this.TimerTick);
			this.statusStrip1.Items[2].Text = "Send: " + Convert.ToString(MainForm.Incoming.SendByteCounter);
			this.statusStrip1.Items[3].Text = "Sink: " + Convert.ToString(MainForm.Incoming.SinkByteCounter);
			this.statusStrip1.Items[4].Text = "Elapsed: " + Convert.ToString(cOperation.Timer);
			
			this.labelSectorAddress.Text = Convert.ToString(cSector.Address);
			//this.textBoxPageAddress.Text = Convert.ToString(cSector.Address);
			
			if(MainForm.IsSerialPortReady)
			{
				this.statusStrip1.Items[1].Text = "Serial port ready";
			}
			else
			{
				this.statusStrip1.Items[1].Text = "Serial port not ready";
			}
				
			//Обработка потока приёма
			if(MainForm.Incoming.SinkBuffer.Length > 0)
			{
				
				//-------------------Реализация операций----------------

				this.OperationStatus.operate();
				this.OperationStatus.draw();
				
				this.OperationGet.operate();
				this.OperationGet.draw();
				
				this.OperationReadPage.operate();
				this.OperationReadPage.draw();
				
				this.OperationWritePage.operate();
				this.OperationWritePage.draw();
				
				this.OperationErase4K.operate();
				this.OperationErase4K.draw();
				
				this.OperationEraseSector.operate();
				this.OperationEraseSector.draw();
				
				this.OperationReadSector.operate();
				this.OperationReadSector.draw();
				
				this.OperationGetDurationTime.operate();
				this.OperationGetDurationTime.draw();
				
				this.OperationGetMemoryAddress.operate();
				this.OperationGetMemoryAddress.draw();
				
				this.OperationReadChip.operate();
				this.OperationReadChip.draw();
				
				this.Process.StartOp.operate();
				this.Process.StartOp.draw();
				
				this.Process.StopOp.operate();
				this.Process.StopOp.draw();
				
				this.Process.ResetOp.operate();
				this.Process.ResetOp.draw();
				
				this.Process.StateOp.operate();
				this.Process.StateOp.draw();
				
				//------------------------------------------------------

				// Отображение принятой информации
				this.richTextBoxLog.SelectionColor = COLOR_INCOMING;
   				this.richTextBoxLog.AppendText(MainForm.Incoming.SinkBuffer);
				MainForm.Incoming.SinkBuffer = "";
			}
			
			// Отобразить состояние памяти
			this.Memory.view();
	
		}//End of void TimerViewTick(object sender, EventArgs e)

		
		/// <summary>
		/// Обработчик события подтверждения выбора номера порта
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ComboBoxPortSelectionChangeCommitted(object sender, EventArgs e)
		{
			if(MainForm._serialPort == null)
			{
				//Назначение имени порта
				MainForm.PortName = this.comboBoxPort.Items[this.comboBoxPort.SelectedIndex].ToString();
				//
				// Создание экземпляра класса
				//
				MainForm._serialPort = new SerialPort(
					MainForm.PortName,
					MainForm.BAUD, 
					MainForm.PARITY, 
					MainForm.DATA_BITS, 
					MainForm.STOP_BITS
					);
			
				MainForm._serialPort.DataReceived += serialPort1_DataResived;
 			
				this.richTextBoxLog.SelectionColor = COLOR_MESSAGE;
				this.richTextBoxLog.AppendText("Serial port "+ MainForm.PortName + " created...\n");
			
        		// Попытка открытия порта
        	
         		try
        		{
        			_serialPort.Open();
        			//Выставление флага готовности порта
        			MainForm.IsSerialPortReady = true;
        			MainForm.IsSerialPortClose = false;
        		}
   				catch(Exception err)
     			{
        			// Сброс флага готовности порта
   					MainForm.IsSerialPortReady = false;
        			MainForm.IsSerialPortClose = true;
        			string Caption = "Исключение при работе с последовательным портом: ";
					Caption += "порт=";
					Caption += MainForm.PortName;
					string MessageString = "Исключение при открытии порта: ";//
					MessageString += Convert.ToString(err); 
				
					MessageBox.Show(
						MessageString, 
						Caption, 
						MessageBoxButtons.OK, 
						MessageBoxIcon.Asterisk
						);
     			}
 
			}// Завершение секции инициализации порта
	
		}//End of void ComboBoxPortSelectionChangeCommitted(object sender, EventArgs e)
		
		
		/// <summary>
		/// Обработчик события нажатия кнопки ОЧИСТКА
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClearClick(object sender, EventArgs e)
		{
			this.richTextBoxLog.Clear();
			
		}
		
		/// <summary>
		/// Обработчик события нажатия кнопки СОХРАНИТЬ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonSaveClick(object sender, EventArgs e)
		{
			
			this.saveFileDialogOutputFile = new SaveFileDialog();
			this.saveFileDialogOutputFile.FileName = FILE_NAME + "." + FILE_EXTENSION;
			if(this.saveFileDialogOutputFile.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamwriter = new StreamWriter(this.saveFileDialogOutputFile.FileName);
				streamwriter.Write(this.richTextBoxLog.Text);
				streamwriter.Close();
			}
		}
		

	}//End of public partial class MainForm : Form
	
}//End of TemperatureRegistratorService0
