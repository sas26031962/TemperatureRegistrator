/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 06.08.2019
 * Time: 15:50
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Класс описывает операцию чтения содержимого страницы FLASH-памяти
	/// </summary>
	public class cOperationReadPage : cOperation
	{
		
		//
		// Атрибуты
		//
		TextBox TextBoxPageAddress;
		
		//
		// Методы
		//
		
		
		/// <summary>
		/// Обработчик нажатия кнопки ЧТЕНИЕ СТРАНИЦЫ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button READ_PAGE pressed");
			
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.READ_PAGE;
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

		}//End of ButtonReadPageClick
		
		//
		// ctor
		//
		public cOperationReadPage(Button btn, TextBox text_box): base( btn)
		{
			this.TextBoxPageAddress = text_box;
			btn.Click += this.ButtonClick;
			
		}//End of ctor
	
	}//End of public class cOperationReadPage
	
}//End of namespace TemperatureRegistratorService0.classes
