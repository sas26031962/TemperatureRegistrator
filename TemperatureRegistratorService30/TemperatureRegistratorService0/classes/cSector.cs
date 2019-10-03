/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 14.06.2019
 * Time: 11:10
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using TemperatureRegistratorService0;
using System.Diagnostics;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Description of cSector.
	/// </summary>
	public class cSector
	{
		//Атрибуты
		
		public static int Address;
		
		public Label Sign;
		int Number;
		
		//Методы
		
		//Конструкторы
		public cSector()
		{
			
		}//End of ctor
		
		public cSector(Label label, int num)
		{
			this.Sign = label;
			this.Number = num;
			this.Sign.ForeColor = Color.Navy;
			this.Sign.Cursor = Cursors.Hand;
			//this.Sign.Click += this.Erase64Click;
			this.Sign.Click += this.GetSectorAddressClick;
			
		}//End of ctor
		

		public void GetSectorAddressClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Button " + Convert.ToString(this.Number) + " pressed");
			cSector.Address = this.Number * 65536;
		}
		
		public void Erase64Click(object sender, EventArgs e)
		{
			Debug.WriteLine("Sector " + Convert.ToString(this.Number) + " Label pressed for erasing");
	
			MainForm.Incoming.SendBuffer = MainForm.Incoming.ERASE_BLOCK_64;
 			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + ":";
 			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + Convert.ToString(this.Number * 65536);//Здесь должна быть строка с адресом памяти
			MainForm.Incoming.SendBuffer = MainForm.Incoming.SendBuffer + "\n";
			
			//MainForm.Messages.Add("Command:" + MainForm.SendBuffer + "\n");//Строка в журнал
  			
			char[] buf = new char [MainForm.Incoming.SendBuffer.Length];
			for (int i = 0; i < MainForm.Incoming.SendBuffer.Length; i++) buf[i] = MainForm.Incoming.SendBuffer[i];

			     //Посылка текущего сообщения
			if(MainForm._serialPort != null)
			{
				MainForm._serialPort.Write(buf,0, buf.Length);
				//Подсчёт переданных байт
				MainForm.Incoming.SendByteCounter += MainForm.Incoming.SendBuffer.Length;
			}
		}//End of Erase64Click
		
	}//End of public class cSector
	
}//End of namespace TemperatureRegistratorService0.classes
