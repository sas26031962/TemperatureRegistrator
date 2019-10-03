/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 06.08.2019
 * Time: 8:47
 * 
 * 
 * 
 */
using System;
using System.IO.Ports;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Класс для управления процессом обмена по последовательному порту
	/// </summary>
	public class cIncoming
	{
		//
		// Константы
		//
		
		public string READ_STATUS = "#status\n";
		public string GET_CHENNEL = "#get";
		public string READ_PAGE = "#readPage";
		public string READ_SECTOR = "#readSector";
		public string READ_CHIP = "#readChip";
		public string READ_WORK_TIME = "#workTime";
		public string WORK_ADDRESS = "#workAddress";
		public string WRITE_PAGE = "#writePage";
		public string ERASE_BLOCK_64 = "#eraseBlock64K";
		public string ERASE_BLOCK_4 = "#eraseBlock4K";
			
		public string STATE_WORK = "#state:work\n";
		public string STATE_SUSPEND = "#state:suspend\n";
		public string STATE_START = "#state:start\n";
		public string STATE_IDLE = "#state:idle\n";
		public string STATE = "#state\n";

		//
		// Атрибуты
		//
		
		public bool	IsInitialCurlyBracket;
		public bool	IsFinalCurlyBracket;
 
		public string SinkBuffer;
    	public string SendBuffer;
    	
    	public long SendByteCounter;
    	public long SinkByteCounter;
		
    	public bool IsSendBufferReady;

    	//
		// Конструктор
		//		
		public cIncoming()
		{
			this.IsFinalCurlyBracket = false;
			
			this.SinkBuffer = "";
			this.SendBuffer = "";
			
			this.SendByteCounter = 0;
			this.SinkByteCounter = 0;
			
		}//End of ctor
		
	}//End of public class cIncoming
	
}//End of namespace TemperatureRegistratorService0.classes
