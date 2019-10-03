/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 31.07.2019
 * Time: 11:35
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using ExportToExelApp0.classes;

using Exel = Microsoft.Office.Interop.Excel;

namespace ExportToExelApp0
{
	/// <summary>
	/// Класс главной формы программя
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Константы
		/// </summary>
		
		string RangeInitialName = "A";//Задание имени столбца для вывода данных
		
		//string PAGE_FILE_NAME = "../data/TestPage.txt";
		string SECTOR_FILE_NAME = "../data/14.txt";//
		string OUTPUT_FILE_NAME = "Workbook1Sector14-1.xlsx";
		//string OUTPUT_FILE_NAME = Application.StartupPath + @"\" + "Workbook1Sector14.xlsx";
		
		//===================================================================================
		// Атрибуты
		//===================================================================================
		
		// Переменные для обслуживания Exel вывода
		Exel.Application ExelApp;
		Exel.Workbooks ExelAppWorkbooks;
		Exel.Workbook ExelAppWorkbook;
		
		Exel.Sheets ExelSheets;
		Exel.Worksheet ExelWorksheet;
		Exel.Range ExelCells;
		
		
		//int[]Account;	//Массив для одного отсчёта
		//int[]Cortage;	//Массив для одного кортежа
		
		cDecoding Decoding;
		
			
		/// <summary>
		/// Ctor
		/// </summary>
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			//Начальный путь к папке
			Debug.WriteLine("Current Path: " + Application.StartupPath);
			
			// Начальная установка переменных
			this.Decoding = new cDecoding();
			
			//
			//Создание Exel файла и предварительное форматирование его первого листа
			//
			this.ExelApp = new Exel.Application();
			this.ExelApp.Visible = true;
			//Определяем количество листов
			this.ExelApp.SheetsInNewWorkbook = 15;
			//Открываем книгу
			this.ExelApp.Workbooks.Add(Type.Missing);
			
			this.ExelAppWorkbooks = this.ExelApp.Workbooks;
			Debug.WriteLine("ExelWorkbooks count:" + Convert.ToString(this.ExelAppWorkbooks.Count));
			this.ExelAppWorkbook = this.ExelAppWorkbooks[1];
			
			//Делаем активной созданную книгу
			//this.ExelAppWorkbook.Activate();
			
			//Получение массива вкладок
			this.ExelSheets = this.ExelAppWorkbook.Worksheets;
			Debug.WriteLine("Sheets count = " + this.ExelSheets.Count);
			//Получение конкретной вкладки			
			this.ExelWorksheet = (Exel.Worksheet)this.ExelSheets.get_Item(1);
			//Выделение начальной ячейки группы и далее по смещению вниз по столбцу
			this.ExelCells = this.ExelWorksheet.get_Range("A1", Type.Missing);
			//Debug.WriteLine("Cells count = " + this.ExelCells.Count);
			//Действие с данной ячейкой (A1)
			this.ExelCells.Value2 = "Number";//Имя столбца с номерами

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,1);//Движение вдоль строки
			//Действие с ячейкой B1
			this.ExelCells.Value2 = "Х1";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,2);//Движение вдоль строки
			//Действие с ячейкой C1
			this.ExelCells.Value2 = "Х2";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,3);//Движение вдоль строки
			//Действие с ячейкой D1
			this.ExelCells.Value2 = "Х3";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,4);//Движение вдоль строки
			//Действие с ячейкой E1
			this.ExelCells.Value2 = "Х4";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,5);//Движение вдоль строки
			//Действие с ячейкой F1
			this.ExelCells.Value2 = "X5";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,6);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X6";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,7);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X7";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,8);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X8";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,9);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X9";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,10);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X10";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,11);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X11";

			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(0,12);//Движение вдоль строки
			//Действие с ячейкой G1
			this.ExelCells.Value2 = "X12";

			this.labelInputFileName.Text = SECTOR_FILE_NAME;
			this.labelOutputFileName.Text = OUTPUT_FILE_NAME;
			
			this.statusStripInfo.Items[0].Text = "Version 1.0.0";
			
		}//End of ctor
		
		//===================================================================================
		// Методы 
		//===================================================================================
		
		/// <summary>
		/// Save Exel button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonExelSaveClick(object sender, EventArgs e)
		{
			Debug.WriteLine("ButtonSaveExelClick");
			this.ExelApp.DisplayAlerts = true;
			this.ExelAppWorkbooks = this.ExelApp.Workbooks;
			Debug.WriteLine("ExelWorkbooks count:" + Convert.ToString(this.ExelAppWorkbooks.Count));
			this.ExelAppWorkbook = this.ExelAppWorkbooks[1];
			this.ExelAppWorkbook.Saved = true;
			//this.ExelAppWorkbook.Save();
			//this.ExelAppWorkbook.SaveAs("Workbook1", Exel.XlFileFormat.xlHtml);
			this.ExelAppWorkbook.SaveCopyAs(OUTPUT_FILE_NAME);
		}
		
		/// <summary>
		/// Read text and analysis
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonReadPageClick(object sender, EventArgs e)
		{
			Debug.WriteLine("ButtonReadPageClick");
			//
			// Чтение данных из файла в RichTextBox
			//
			string curFile = SECTOR_FILE_NAME;
			//Debug.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");	
			if(File.Exists(curFile)) this.statusStripInfo.Items[0].Text = "Source file exist"; else this.statusStripInfo.Items[0].Text = "Source not exist";
			
			if(File.Exists(curFile)) this.richTextBoxData.LoadFile(curFile, RichTextBoxStreamType.PlainText);
			//
			//Анализ текста по строкам
			//
			//Debug.WriteLine("Lines: " + Convert.ToString(this.richTextBoxData.Lines.Length));
			this.statusStripInfo.Items[1].Text = "Lines: " + Convert.ToString(this.richTextBoxData.Lines.Length);
			//
 			// Разбивка на типы строки
        	//
			for(int i = 0; i < this.richTextBoxData.Lines.Length; i++)
			{
				string Incoming = this.richTextBoxData.Lines[i];
				
				Decoding.Phase = StringType.DATA;
				
				// Проверка на начальную строку
				if (Decoding.regexStartPage.IsMatch(Incoming))
				{
					Decoding.Phase = StringType.PAGE_BEGIN;
					Decoding.Data = "";
					this.statusStripInfo.Items[2].Text = "Begin page:" + Convert.ToString(Decoding.CortageNumber);
				}

				// Проверка на чистую строку
				if (Decoding.regexEndPage.IsMatch(Incoming))
				{
					
					if(Decoding.Data.Length > 0)
					{
						// Декодирование строки
						this.Decoding.convertPageToCortage(Decoding.Data);
						// Здесь вставить вывод данных в Exel файл
						//----
						for(int j = 0; j < PARAMETERS.CORTAGE_LENGTH; j++)
						{
							for(int ix = 0; ix < PARAMETERS.CHENNEL_NUMBER; ix++)
							{
								this.Decoding.Account[ix] = this.Decoding.Cortage[j * PARAMETERS.CHENNEL_NUMBER + ix];
							}
							
							this.perfomData(j + 1 + Decoding.CortageNumber * 10);
						}
						//---
						Decoding.CortageNumber++;
					
						this.progressBarDuration.Value = Decoding.CortageNumber;
					
					}
					else
					{
						Debug.WriteLine("Empty page detected!");
					}
					
					Decoding.Phase = StringType.EMPTY;
				}
				
				// Проверка на пустую строку
				if (Incoming.Length == 0) 
				{
					Decoding.Phase = StringType.PAGE_END;
				}

				//Склеивание строк данных
				if(Decoding.Phase == StringType.DATA)
				{
					Decoding.Data = Decoding.Data + Incoming;
				}
				
			}//End of for(int i = 0; i < this.richTextBoxData.Lines.Length; i++)
			
			this.progressBarDuration.Value = this.progressBarDuration.Maximum;
			
			//Debug.WriteLine("Process complete!");
			this.statusStripInfo.Items[2].Text = "Process complete!";
			
		}//End of void ButtonReadPageClick(object sender, EventArgs e)
		
		/// <summary>
		/// Реакция на закрытие формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			this.ExelApp.Quit();
		}
		
		//=============================================================================
		

		/// <summary>
		/// Представление отдного отсчёта данных на странице Exel
		/// </summary>
		/// <param name="LineNumber"></param>
		void perfomData(int line_number)
		{
			//Получение конкретной вкладки
			this.ExelWorksheet = (Exel.Worksheet)this.ExelSheets.get_Item(1);
			//Выделение начальной ячейки группы и далее по смещению вниз по столбцу
			this.ExelCells = this.ExelWorksheet.get_Range((RangeInitialName + Convert.ToString(line_number)), Type.Missing);
			
			//Задание номера 
			this.ExelCells = this.ExelApp.ActiveCell.get_Offset(line_number,0);//Движение вдоль столбца
			this.ExelCells.Value2 = line_number;
			
			//Вычисление температуры по каналам
			for(int i = 0; i < PARAMETERS.CHENNEL_NUMBER; i++)
			{
				//Задание номера 
				this.ExelCells = this.ExelApp.ActiveCell.get_Offset(line_number, i + 1);//Движение вдоль столбца
				this.ExelCells.Value2 = this.Decoding.getTemperature(i);
			}
			
		}//End of void perfomData(int LineNumber)
		
		
	}//End of public partial class MainForm : Form
	
}//End of namespace ExportToExelApp0
