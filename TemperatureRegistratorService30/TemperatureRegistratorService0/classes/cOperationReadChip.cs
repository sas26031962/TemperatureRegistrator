/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 07.08.2019
 * Time: 13:03
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
	/// Класс описывает операцию чтения содержимого всего кристалла FLASH-памяти
	/// </summary>
	public class cOperationReadChip : cOperation
	{
		//
		// Атрибуты
		//
		
		//
		// Методы
		//
		/// <summary>
		/// Обработчик клика по кнопке ЧТЕНИЕ КРИСТАЛЛА
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Chip begin reading");
		
			this.IsActive = true;
			this.State = OperationState.SEND;
			cOperation.Timer = 0;
			
			MainForm.Incoming.SendBuffer = MainForm.Incoming.READ_CHIP;
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
	
		}//End of void ButtonSectorReadClick(object sender, EventArgs e)
		
		
		//
		// ctor
		//
		public cOperationReadChip(Button btn): base( btn)
		{

			btn.Click += this.ButtonClick;

		}//End of ctor
		
	}//End of public class cOperationReadChip
	
}//End of namespace TemperatureRegistratorService0.classes
