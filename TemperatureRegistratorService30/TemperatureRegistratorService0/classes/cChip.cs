/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 14.06.2019
 * Time: 11:14
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Класс для управления кристаллом FLASH-памяти
	/// </summary>
	public class cChip
	{
		//Атрибуты
		public cSector[] Sector;
		
		//Методы
		public void install(
			Label label0, Label label1, Label label2, Label label3,
			Label label4, Label label5, Label label6, Label label7,
			Label label8, Label label9, Label label10, Label label11,
			Label label12, Label label13, Label label14, Label label15,
			Label label16, Label label17, Label label18, Label label19,
			Label label20, Label label21, Label label22, Label label23,
			Label label24, Label label25, Label label26, Label label27,
			Label label28, Label label29, Label label30, Label label31
		)
		{
			this.Sector[0] = new cSector(label0, 0);
			this.Sector[1] = new cSector(label1, 1);
			this.Sector[2] = new cSector(label2, 2);
			this.Sector[3] = new cSector(label3, 3);
			this.Sector[4] = new cSector(label4, 4);
			this.Sector[5] = new cSector(label5, 5);
			this.Sector[6] = new cSector(label6, 6);
			this.Sector[7] = new cSector(label7, 7);
			this.Sector[8] = new cSector(label8, 8);
			this.Sector[9] = new cSector(label9, 9);
			this.Sector[10] = new cSector(label10, 10);
			this.Sector[11] = new cSector(label11, 11);
			this.Sector[12] = new cSector(label12, 12);
			this.Sector[13] = new cSector(label13, 13);
			this.Sector[14] = new cSector(label14, 14);
			this.Sector[15] = new cSector(label15, 15);
			this.Sector[16] = new cSector(label16, 16);
			this.Sector[17] = new cSector(label17, 17);
			this.Sector[18] = new cSector(label18, 18);
			this.Sector[19] = new cSector(label19, 19);
			this.Sector[20] = new cSector(label20, 20);
			this.Sector[21] = new cSector(label21, 21);
			this.Sector[22] = new cSector(label22, 22);
			this.Sector[23] = new cSector(label23, 23);
			this.Sector[24] = new cSector(label24, 24);
			this.Sector[25] = new cSector(label25, 25);
			this.Sector[26] = new cSector(label26, 26);
			this.Sector[27] = new cSector(label27, 27);
			this.Sector[28] = new cSector(label28, 28);
			this.Sector[29] = new cSector(label29, 29);
			this.Sector[30] = new cSector(label30, 30);
			this.Sector[31] = new cSector(label31, 31);
		}
		
		public void view()
		{
			
		}//End of public void view()
		
		//Конструкторы
		public cChip()
		{
			this.Sector = new cSector[32];

		}//End of ctor
	
	}//End of public class cChip
	
}//End of namespace TemperatureRegistratorService0.classes
