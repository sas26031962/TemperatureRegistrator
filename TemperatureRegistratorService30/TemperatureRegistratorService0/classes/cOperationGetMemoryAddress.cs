/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 07.08.2019
 * Time: 10:42
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
	/// Класс описывает операцию чтения значения текущего адреса записи FLASH-памяти
	/// </summary>
	public class cOperationGetMemoryAddress : cOperation
	{
		//
		// Атрибуты
		//
		
		//
		// Методы
		//
		/// <summary>
		/// Обработчик нажатия на кнопку АДРЕС
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Read current work address");
		
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.WORK_ADDRESS;
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
	
		}//End of void ButtonAddressClick(object sender, EventArgs e)
		
		//
		// ctor
		//
		public cOperationGetMemoryAddress(Button btn): base( btn)
		{
			
			btn.Click += this.ButtonClick;
			
		}//End of ctor
		
	}//End of public class cOperationGetMemoryAddress
	
}//End of namespace TemperatureRegistratorService0.classes
