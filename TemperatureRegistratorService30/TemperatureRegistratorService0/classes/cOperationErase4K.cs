/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 07.08.2019
 * Time: 9:11
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
using TemperatureRegistratorService0.classes;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Класс описывает операцию очистки содержимого блока 4К FLASH-памяти
	/// </summary>
	public class cOperationErase4K : cOperation
	{
		//
		// Атрибуты
		//
		TextBox TextBoxPageAddress;
		
		//
		// Методы
		//
		/// <summary>
		/// Обработчик нажатия кнопки ОЧИСТИТЬ 4К
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button ERASE4K pressed");
	
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.ERASE_BLOCK_4;
 			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + ":";
			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + this.TextBoxPageAddress.Text;
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
		}//End of ButtonErase4Click
		
		
		
		//
		// ctor
		//
		public cOperationErase4K(Button btn, TextBox text_box): base( btn)
		{
			
			this.TextBoxPageAddress = text_box;
			btn.Click += this.ButtonClick;
			
		}//End of ctor
		
	}//End of public class cOperationErase4K
	
}//End of namespace TemperatureRegistratorService0.classes
