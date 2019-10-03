/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 19.06.2019
 * Time: 8:45
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace TemperatureRegistratorService0.classes
{
/***********************************************************************************************
 Состояния процесса работы
 - стартовый (START). В стартовом режиме производится инициализация микросхемы памяти, 
 сбрасывается в ноль счётчик WorkTime.
 - холостой ход (IDLE). В режиме холостого хода изменяется счётчик RealTime, 
 счётчик WorkTime не изменяется, измерение не производится, операции с памятью не производятся. 
 - рабочий ход  (WORK). В режиме рабочего хода изменяется счётчик RealTime, изменяется счётчик WorkTime, 
 измерение начинается после стартовой паузы, могут производиться операции с памятью. 
 - удержание в процессе рабочего хода (SUSPEND). В данном режиме изменяется счётчик RealTime, 
 изменение счётчика WorkTime останавливается, измерение не производится. 
 ***********************************************************************************************/
	/// <summary>
	/// Класс для визуализации процесса измерения
	/// </summary>
	public class cMesurement
	{
		enum MesurementStates{
    		START,
    		MESSAGE_START_TO_SUSPEND,
    		IDLE,
    		WORK,
    		SUSPEND
		};

		
		/// <summary>
		/// Атрибуты
		/// </summary>
		ProgressBar Duration;
		
		//Button ButtonState;
		
		public cOperation StartOp;
		public cOperation StopOp;
		public cOperation ResetOp;
		public cOperation StateOp;
		
		/// <summary>
		/// Обработчики событий
		/// </summary>

		/// <summary>
		/// Обработчик нажатия на кнопку СОСТОЯНИЕ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStateClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button STATE pressed");
			
			this.StateOp.IsActive = true;
			this.StateOp.State = cOperation.OperationState.SEND;
			cOperation.Timer = 0;

			MainForm.Incoming.SendBuffer = MainForm.Incoming.STATE;
			char[] buf = new char [MainForm.Incoming.SendBuffer.Length];
			for (int i = 0; i < MainForm.Incoming.SendBuffer.Length; i++) buf[i] = MainForm.Incoming.SendBuffer[i];

			     //Посылка текущего сообщения
			if(MainForm._serialPort != null)
			{
				MainForm._serialPort.Write(buf,0, buf.Length);
				//Подсчёт переданных байт
				MainForm.Incoming.SendByteCounter += MainForm.Incoming.SendBuffer.Length;
			}
	
		}//End of void ButtonStateClick(object sender, EventArgs e)
		
		/// <summary>
		/// Обработчик нажатия на кнопку СБРОС
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonResetClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button START pressed");
			
			this.Duration.Value = 0;
			
			this.ResetOp.IsActive = true;
			this.ResetOp.State = cOperation.OperationState.SEND;
			cOperation.Timer = 0;

			MainForm.Incoming.SendBuffer = MainForm.Incoming.STATE_START;
			char[] buf = new char [MainForm.Incoming.SendBuffer.Length];
			for (int i = 0; i < MainForm.Incoming.SendBuffer.Length; i++) buf[i] = MainForm.Incoming.SendBuffer[i];

			     //Посылка текущего сообщения
			if(MainForm._serialPort != null)
			{
				MainForm._serialPort.Write(buf,0, buf.Length);
				//Подсчёт переданных байт
				MainForm.Incoming.SendByteCounter += MainForm.Incoming.SendBuffer.Length;
			}
	
		}
		
		/// <summary>
		/// Обработчик нажатия на кнопку СТАРТ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStartClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button WORK pressed");
			
			this.StartOp.IsActive = true;
			this.StartOp.State = cOperation.OperationState.SEND;
			cOperation.Timer = 0;

			MainForm.Incoming.SendBuffer = MainForm.Incoming.STATE_WORK;
   			cOperation.richTextBoxLog.AppendText("Command:" + MainForm.Incoming.SendBuffer + "\n");
			char[] buf = new char [MainForm.Incoming.SendBuffer.Length];
			for (int i = 0; i < MainForm.Incoming.SendBuffer.Length; i++) buf[i] = MainForm.Incoming.SendBuffer[i];

			     //Посылка текущего сообщения
			if(MainForm._serialPort != null)
			{
				MainForm._serialPort.Write(buf,0, buf.Length);
				//Подсчёт переданных байт
				MainForm.Incoming.SendByteCounter += MainForm.Incoming.SendBuffer.Length;
			}

		}//End of void ButtonStartClick(object sender, EventArgs e)
		
		/// <summary>
		/// Обработчик нажатия на кнопку СТОП
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStopClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button SUSPEND pressed");
			
			this.StartOp.IsActive = true;
			this.StartOp.State = cOperation.OperationState.SEND;
			cOperation.Timer = 0;

			MainForm.Incoming.SendBuffer = MainForm.Incoming.STATE_SUSPEND;
   			cOperation.richTextBoxLog.AppendText("Command:" + MainForm.Incoming.SendBuffer + "\n");
			char[] buf = new char [MainForm.Incoming.SendBuffer.Length];
			for (int i = 0; i < MainForm.Incoming.SendBuffer.Length; i++) buf[i] = MainForm.Incoming.SendBuffer[i];

			     //Посылка текущего сообщения
			if(MainForm._serialPort != null)
			{
				MainForm._serialPort.Write(buf,0, buf.Length);
				//Подсчёт переданных байт
				MainForm.Incoming.SendByteCounter += MainForm.Incoming.SendBuffer.Length;
			}

		}//End of void ButtonStopClick(object sender, EventArgs e)
		
		/// <summary>
		/// Конструктор
		/// </summary>
		public cMesurement(
			ProgressBar bar,
			Button state_btn,
			Button reset_btn,
			Button start_btn,
			Button stop_btn
		)
		{
			this.Duration = bar;
			this.StateOp = new cOperation(state_btn);
			state_btn.Click += this.ButtonStateClick;
			
			this.ResetOp = new cOperation(reset_btn);
			reset_btn.Click += this.ButtonResetClick;
			
			this.StartOp = new cOperation(start_btn);
			start_btn.Click += this.ButtonStartClick;
			
			this.StopOp = new cOperation(stop_btn);
			stop_btn.Click += this.ButtonStopClick;
			
		}//End of ctor
		
	}//End of public class cMesurement: cChip
	
}//End of namespace TemperatureRegistratorService0.classes 
