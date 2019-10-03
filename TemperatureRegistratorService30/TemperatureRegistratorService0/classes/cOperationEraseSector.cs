/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 07.08.2019
 * Time: 9:35
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
	/// Класс описывает операцию очистки содержимого сектора 64К FLASH-памяти
	/// </summary>
	public class cOperationEraseSector : cOperation
	{
		//
		// Атрибуты
		//
		TextBox TextBoxPageAddress;
		
		//
		// Методы
		//
		/// <summary>
		/// Обработчик клика по кнопке ОЧИСТКА СЕКТОРА
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Sector from address " + Convert.ToString(cSector.Address) + " begin erasing");
	
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.ERASE_BLOCK_64;
 			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + ":";
 			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + this.TextBoxPageAddress.Text;//Здесь должна быть строка с адресом памяти
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
	
		}//End of void ButtonSectorClearClick(object sender, EventArgs e)
		
		//
		// ctor
		//
		public cOperationEraseSector(Button btn, TextBox text_box): base( btn)
		{
			
			this.TextBoxPageAddress = text_box;
			btn.Click += this.ButtonClick;
		}//End of ctor
		
	}//End of public class cOperationEraseSector
	
}//End of namespace TemperatureRegistratorService0.classes
