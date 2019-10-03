/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 06.08.2019
 * Time: 15:25
 * 
 * 
 * 
 */
using System;
using TemperatureRegistratorService0.classes;
using System.Windows.Forms;
using System.Diagnostics;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Класс описывает операцию чтения значения сигнала из порта
	/// </summary>
	public class cOperationGet : cOperation
	{
		//
		// Атрибуты
		//
		NumericUpDown numericUpDown;
		
		//
		// Методы
		//
		
		/// <summary>
		/// Обработчик нажатия кнопки GET
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button GET pressed");
			
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.GET_CHENNEL;
			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + ":";
			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + this.numericUpDown.Value.ToString();
			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + "\n";
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
	
		}//End of void ButtonSaveClick(object sender, EventArgs e)
		
		/// <summary>
		/// Обработчик клика по элементу выбора канала
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void NumericUpDownClick(object sender, EventArgs e)
		{
			if(this.numericUpDown.Value == 0)
				this.numericUpDown.Value = 1;
		}

		//
		// ctor
		//
		public cOperationGet(Button btn, NumericUpDown numUpDown):base(btn)
		{
			this.numericUpDown = numUpDown;
			this.numericUpDown.Click += this.NumericUpDownClick;
			btn.Click += this.ButtonClick;
			
		}//End of ctor
	
	}//End of public class cOperationGet
	
}//End of TemperatureRegistratorService0.classes
