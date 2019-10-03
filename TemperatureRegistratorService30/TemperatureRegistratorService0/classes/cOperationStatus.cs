/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 06.08.2019
 * Time: 15:13
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
	/// Класс описывает операцию чтения статуса FLASH - памяти
	/// </summary>
	public class cOperationStatus : cOperation
	{
		
		//
		// Методы
		//
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button STATUS pressed");
			
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.READ_STATUS;
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
		}//End of ButtonClick(object sender, EventArgs e)
		
		//
		// ctor
		//
		public cOperationStatus(Button btn): base( btn)
		{
			
			btn.Click += this.ButtonClick;
			
		}//End of ctor
		
	}//End of public class cOperationStatus
	
}//End of namespace TemperatureRegistratorService0.classes
