/*
 * Created by SharpDevelop.
 * User: 48007
 * Date: 01.08.2019
 * Time: 10:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace ExportToExelApp0.classes
{
	/// <summary>
	/// <summary>
	/// Константы
	/// </summary>
	public struct PARAMETERS{
			
		public const int CHENNEL_NUMBER = 12;
		public const int CORTAGE_LENGTH = 10;
		public const int PAGES_NUMBER = 256;
	};
	
	/// <summary>
	/// Типы строк данных
	/// </summary>
	public enum StringType{
			EMPTY,
			DATA,
			PAGE_BEGIN,
			PAGE_END
		};
		
	/// 
	/// Description of cDecoding.
	/// </summary>
	public class cDecoding
	{
		/// <summary>
		/// Атрибуты
		/// </summary>
		
		public 	int[]Account;	//Массив для одного отсчёта
		
		public 	int[]Cortage;	//Массив для одного кортежа
		
      	public 	StringType Phase;
     		
       	public	string Data = "";//Буфер данных для страницы
       		
       	//Номер кортежа из 10 записей по 12 каналов, должен модифицироваться после каждой страницы
       	public int 	CortageNumber = 0;
		
		
		// Тестовый массив реальных данных
		int[]ACCOUNT = new int[]{678, 679, 679, 684, 674, 677, 669, 3575, 673, 673, 679, 674};
		
		//Масштабные коэффициенты
		double[] A = new double[]{0.413036, 0.411603, 0.412138, 0.409824, 0.415032, 0.412811, 0.416959, 0.413348, 0.414050, 0.416858, 0.410996, 0.414251};
		double[] B = new double[]{253.279, 254.343, 254.668, 254.782, 254.229, 255.029, 254.976, 255.901, 254.572, 255.712, 254.412, 255.317};
		
 		public	Regex regexStartPage = new Regex("FLASH address:");
       	public 	Regex regexEndPage = new Regex("ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff: ff:");
      		
		/// <summary>
		/// Процедура вычисления показаний температуры по заданному отсчёту 
		/// </summary>
		/// <param name="i">Номер канала в отсчёте</param>
		/// <returns></returns>
		public double getTemperature(int i)
		{
			return ((float)this.Account[i] * A[i]) - B[i];//Т=N*A-B;
		}
		
		/// <summary>
		/// Преобразование строки в отсчёты кортежа
		/// Формат строки: "XX0: XX1: ... XX119:"
		/// </summary>
		/// <param name="Data"></param>
		public void convertPageToCortage(string Data)
		{
  			// Разбивка на типы строки
      		Regex regexByte = new Regex("[0-9,a-f,A-F]*:");
      		
			//Debug.WriteLine("Data length: " + Convert.ToString(Data.Length));
			
			MatchCollection matches = regexByte.Matches(Data);
			//Debug.WriteLine("Matches count: " + Convert.ToString(matches.Count));
			
			string[] Hashs = new string[matches.Count];
			string[] Parts = new string[2];
			
			// Разделение строки на байты
			int index = 0;
			foreach(Match match in matches)
			{
				Parts = match.Value.Split(':');
				Hashs[index] = Parts[0];
				index++;
			}
			
			//Объединение байтов в слова и декодирование в массив Cortage			
			for(int i=0; i< matches.Count / 2; i++)
			{
				string s  = Hashs[i*2 + 1] + Hashs[i*2];
				this.Cortage[i] = Convert.ToUInt16(s, 16);
			}
			
		}//End of void convertPageToCortage(string Data)
		/// <summary>
		/// Ctor
		/// </summary>
		public cDecoding()
		{
			// Начальная установка переменных
			this.Account = new int[PARAMETERS.CHENNEL_NUMBER];
			this.Cortage = new int[PARAMETERS.CHENNEL_NUMBER * PARAMETERS.CORTAGE_LENGTH];
			
			// Инициализация короткого массива
			for(int i = 0; i < this.Account.Length; i++)
			{
				this.Account[i] = this.ACCOUNT[i];
			}
			
			// Инициализация длинного массива
			for(int j = 0; j < PARAMETERS.CORTAGE_LENGTH; j++)
			{
				for(int i = 0; i < PARAMETERS.CHENNEL_NUMBER; i++)
				{
					this.Cortage[j * PARAMETERS.CHENNEL_NUMBER + i] = this.ACCOUNT[i];
				}
			}
			
		}//End of ctor
	
	}//End of public class cDecoding
	
}//End of namespace ExportToExelApp0.classes 
