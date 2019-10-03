/*
 Класс управления процессом измерения температуры
 Состояния процесса работы служат для исключения пропадания питания в процессе работы с памятью
 Состояния процесса работы
 - стартовый (START). В стартовом режиме производится инициализация микросхемы памяти, 
 сбрасывается в ноль счётчик WorkTime.
 - холостой ход (IDLE). В режиме холостого хода изменяется счётчик RealTime, 
 счётчик WorkTime не изменяется, измерение не производится, операции с памятью не производятся. 
 - рабочий ход  (WORK). В режиме рабочего хода изменяется счётчик RealTime, изменяется счётчик WorkTime, 
 измерение начинается после стартовой паузы, могут производиться операции с памятью. 
 - удержание в процессе рабочего хода (SUSPEND). В данном режиме изменяется счётчик RealTime, 
 изменение счётчика WorkTime приостанавливается, измерение не производится. 
 */
 
#ifndef MESUREMENT_H
#define MESUREMENT_H 
//========================================================================
//---------------------------- ПОДКЛЮЧАЕМЫЕ ФАЙЛЫ ------------------------
//========================================================================
#include "define.h"
#include "cTime.h"
#include "sPage.h"

//========================================================================
//--------------------------- ОБЪЯВЛЕНИЕ КЛАССОВ -------------------------
//========================================================================

enum MesurementStates{
    START,
    MESSAGE_START_TO_SUSPEND,
    IDLE,
    WORK,
    SUSPEND
};

class cMesurement{
 
 //------------------------------------------------------------------------
 // Атрибуты
 //------------------------------------------------------------------------
 private:
 
 double MillisCurrent;
 double MillisPrevious;

 sPage Page;
 int Cortage;
  
 public:
 int State;// Состояние процесса измерения

 static cTime Time;     // Объект учёта времени
 static cFlash Flash;   //Экземпляр FLASH-памяти

 
 //------------------------------------------------------------------------
 // Конструкторы
 //------------------------------------------------------------------------
 cMesurement();
  
 //------------------------------------------------------------------------
 // Методы
 //------------------------------------------------------------------------

 //Инициализация процесса измерений
 void install();

 //Реализация функциональности
 void operate();   

private:
 //Управление процессом измерений
 void control();

};//End of class cMesurement

 //========================================================================
 //--------------------------- РЕАЛИЗАЦИЯ МЕТОДОВ -------------------------
 //========================================================================

//
// Конструктор
//
cMesurement::cMesurement() 
{
  this->MillisCurrent = millis();
  this->MillisPrevious = this->MillisCurrent;

  this->Cortage = 0;
  this->State = START;

  }//End of ctor 


//
// Инициализация процесса измерений
//
void cMesurement::install()
{
  //Задание разрядности АЦП
  analogReadResolution(ADC_RANGE);

}//End of void cMesurement::install()


//
// Реализация функциональности: 
// - опрос датчиков
// - подсчёт циклов
// - кодирование данных для сохранения
// - выставление флага готовности  
//
void cMesurement::operate()
{
  this->MillisCurrent = millis();
  if(this->MillisCurrent - this->MillisPrevious > MESUREMENT_CYCLE)
  {
    this->MillisPrevious = this->MillisCurrent;

    //Подсчёт числа циклов реального времени, реализация часов
    cMesurement::Time.operate();
    
    //Реализация функции управления
    this->control();
    //-----------------------------------------
  }
}//End of void cMesurement::operate()


//
//Управление процессом измерений
//
void cMesurement::control()
{
  int MemoryPointer;
  //int Cortage;
  int x;
  int Repeate;
  
  switch(this->State)
  {
    case START:
    cMesurement::Time.WorkTime = 0;//Счётчик работы
    cMesurement::Flash.Page.install();
    this->State = MESSAGE_START_TO_SUSPEND;
    this->Cortage = 0;
    break;

    case IDLE:
    break;

    case MESSAGE_START_TO_SUSPEND:
    Serial.println("{\nStart mode complete, suspend mode is ON\n}");
    this->State = SUSPEND;
    break;
    
    case WORK:
   //--- Чтение данных
   /* 
    * Перед чтением данных формируется адрес текущего отсчёта во Flash-памяти: MemoryPointer.  
    * После вычисления адреса текущего кортежа производится измерение по 12 каналам. 
    * Значение, считанное  по каждому каналу сохраняется в буфере страницы памяти: сначала младший, затем старший байт.
    * Затем указатель буфера страницы памяти увеличивается на 2 и производится проверка на 
    * число кортежей. Если конец счётчика кортежей достигнут (значение указателя = 240), то указатель 
    * буфера страницы сбрасывается в 0 и производится запись страницы во Flash-память, после чего 
    * указатель страницы в массиве Flash-памяти увеличивается на 1. 
    */
    //Вычисление адреса в памяти
    MemoryPointer = cMesurement::Flash.Page.Address * 256 +  cMesurement::Flash.Page.Pointer;
    // Кортеж измерений
    for (int i = 0; i < CHENNEL_NUMBER; i++)
    {
      x = analogRead(i);//Реальное значение  
      //x = i;//Тестовое значение 2
      //x = cMesurement::Flash.Page.Pointer;//Тестовое значение 1
      //x = MemoryPointer;//Тестовое значение 3
      cMesurement::Flash.Page.data[cMesurement::Flash.Page.Pointer] = x & 0xff;//Запись в память младшего байта
      cMesurement::Flash.Page.data[cMesurement::Flash.Page.Pointer + 1] = (x >> 8) & 0xff;//Запись в память старшего байта
      cMesurement::Flash.Page.Pointer = cMesurement::Flash.Page.Pointer + 2;
    }
    this->Cortage++;
    if(this->Cortage == CORTAGE_NUMBER)
    {
      this->Cortage = 0;// Сброс счётчика кортежей
      //...Здесь дописываются данные в конец кортежа
            
      //...Запись страницы в память
      /*
       * Для записи буфера страницы во Flash-память определяется текущий адрес страницы исходя из 
       * адреса текущего отсчёта во Flash-памяти, после чего производится запись буфера во Flash-память
       * (ожидаемое время около 7 мс)
       */
      cMesurement::Flash.Address.get((cMesurement::Flash.Page.Address) * 256);

      // Разблокирование сектора для записи
  
      // Установка бита разрешения записи
      cMesurement::Flash.setWriteEnable();
      Repeate = REPEATE;
      if(!cMesurement::Flash.getWriteEnable() && (Repeate > 0))
      {
        Repeate--;
      }
      if(Repeate < 0)Serial.println("Set WEL bit error, Repeate = " + Repeate);
        
      // Разрешение сектора 0 для записи
      cMesurement::Flash.clearSectorProtection();
      
      // Установка бита разрешения записи
      cMesurement::Flash.setWriteEnable();
      Repeate = REPEATE;
      if(!cMesurement::Flash.getWriteEnable() && (Repeate > 0))
      {
        Repeate--;
      }
      if(Repeate < 0)Serial.println("Set WEL bit error, Repeate = " + Repeate);

      //cMesurement::Flash.Timer.start();
      cMesurement::Flash.writePage();
      //cMesurement::Flash.Timer.stop();
      //cMesurement::Flash.Timer.view();

      //Serial.println("---");
      //Здесь оканчивается процедура записи страницы в память
      
      cMesurement::Flash.Page.Pointer = 0;
      cMesurement::Flash.Page.Address++;  
      
   }//End of if(this->Cortage == CORTAGE_NUMBER)
 
    //--- Индикация рабочего режима
    /*
    if(((cMesurement::Flash.Page.Pointer & 0xff) > 0)) Serial.print(".");
    //
    // Маркер после каждых 10 кортежей
    //
    if((this->Cortage == 0)&&(MemoryPointer > 0))
    {
      //Serial.println("!");
    }
    */
    // Проверка окончания процесса измерений
    if(cMesurement::Time.WorkTime >FINISH_TIME) 
    {
      this->State = IDLE;
      Serial.println("Mesurement is finished, goto IDLE state");
    }
    /*
    if(cMesurement::Time.WorkTime > TEST_MEMORY_TIME) 
    {
      this->State = IDLE;
      Serial.println("Memory test is finished, goto IDLE state");
    }
    
    // Проверка окончания процесса измерений
    
    if(MemoryPointer > 0xffff) 
    {
      this->State = IDLE;
      Serial.println("Sector 0 is full, goto IDLE state");
    }
    */
    // Следующий рабочий цикл
    cMesurement::Time.WorkTime++;

    break;

    case SUSPEND:
    //Подсчёт числа циклов рабочего времени
    //cMesurement::Time.WorkTime++;
    break;

    default:
    break;
  }

}//End of void cMesurement::control()

 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
#endif

