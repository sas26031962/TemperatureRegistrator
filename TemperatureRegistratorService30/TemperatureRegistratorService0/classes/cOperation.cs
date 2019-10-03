/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 06.08.2019
 * Time: 14:56
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace TemperatureRegistratorService0.classes
{
	/// <summary>
	/// Description of cOperation.
	/// </summary>
	public class cOperation
	{
		//
		// Константы
		//
		public enum OperationState{
			
			IDLE,	//Состояние ожидания: выход по нажатию кнопки, переход в состояние SEND
			SEND,	//Состояние передачи: выход по приёму '{', переход в состояние SINK
			SINK	//Состояние приёма: выход по приёму '}', переход в состояние ILDE
		
		};
		
		//
		// Атрибуты
		//
		
		public static int Timer;// Таймер для измерения времени выполнения операции
		
		public static RichTextBox richTextBoxLog;// Журнал для логирования
		
		public OperationState State;// Состояние процесса
		
		Button button;// Кнопка включения / индикации
		
		public bool IsActive;
		
		//
		// Методы
		//

		/// <summary>
		/// Отображение состояние процесса в цвете текста на кнопке
		/// </summary>
		public void draw()
		{
			switch(this.State)
			{
				case OperationState.IDLE:
					this.button.ForeColor = Color.Navy;
					break;
				case OperationState.SEND:
					this.button.ForeColor = Color.Red;
					break;
				case OperationState.SINK:
					this.button.ForeColor = Color.GreenYellow;
					break;
				default:
					break;
			}
		}

		public void operate()
		{
			if(this.IsActive)
			{
				cOperation.Timer++;//Реализация функции таймера
				
				if(MainForm.Incoming.IsInitialCurlyBracket)
				{
					Debug.WriteLine("{");
					MainForm.Incoming.IsInitialCurlyBracket = false;
					this.State = OperationState.SINK;
				}
					
				
				if(MainForm.Incoming.IsFinalCurlyBracket)
				{
					Debug.WriteLine("}");
					MainForm.Incoming.IsFinalCurlyBracket = false;
					this.State = OperationState.IDLE;
					this.IsActive = false;
				}
			}
		}
				
		/// <summary>
		/// ctor
		/// </summary>
		public cOperation( Button btn)
		{
			this.button = btn;
			this.IsActive = false;
			this.State = OperationState.IDLE;
			this.button.ForeColor = Color.Black;
		}
	
	}//End of public class cOperation
	
}//End of namespace TemperatureRegistratorService0.classes
