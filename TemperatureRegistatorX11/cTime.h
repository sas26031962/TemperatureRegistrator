/*
 * Класс для управления временем
 * Формат строки даты: дд-мм-гг-чч-мм-сс
 */
//=======================================================================
// Структура для хранения времени 
//=======================================================================
#ifndef C_TIME
#define C_STIME

class cTime{
  int Year;
  int Month;
  int Day;
  int Hour;
  int Minute;
  int Second;

public:   
  int RealTime;
  int WorkTime;

  cTime();                //Конструктор
  
  void operate();         //Реализация счёта времени (100 мс)
  bool setDate(String s); //Установка даты-времени
  String getDate();       //Чтение даты-времени
};

  //Конструктор
  cTime::cTime()
  {
    this->Year = 2019;
    this->Month = 06;
    this->Day = 06;
    this->Hour = 12;
    this->Minute = 0;
    this->Second = 0;
    this->RealTime = 0;
  }
  
  //Реализация счёта времени (100 мс)
  void cTime::operate()
  {
    this->RealTime++;
    if(this->RealTime % 10 == 0)//Секунда
    {
      this->Second ++;
      if(this->Second == 60)
      {
        this->Second = 0;
        this->Minute ++;
        if(this->Minute == 60)
        {
          this->Minute = 0;
          this->Hour ++;
          if(this->Hour == 24)
          {
            this->Hour = 0;  
          }
        }
      }
    }
  }//End of void cTime::operate()
  
  //Установка даты-времени
  bool  cTime::setDate(String s)
  {
    bool x = true;
    x = x & (s.length() == 17);//Проверка длины строки
    String sDD = s.substring(0,2); //Serial.println("dd=" + sDD);
    this->Day = sDD.toInt();
    x = x & (this->Day < 31);
    String sMM = s.substring(3,5); //Serial.println("mm=" + sMM);
    this->Month = sMM.toInt();
    x = x & (this->Month < 13);
    String sYY = s.substring(6,8); //Serial.println("yy=" + sYY);
    this->Year = sYY.toInt();
    x = x & (this->Year > 18); 
    String sCC = s.substring(9,11); //Serial.println("cc=" + sCC);
    this->Hour = sCC.toInt();
    x = x & (this->Hour < 24);
    String sII = s.substring(12,14); //Serial.println("ii=" + sII);
    this->Minute = sII.toInt();
    x = x & (this->Minute < 60);
    String sSS = s.substring(15,17); //Serial.println("ss=" + sSS);
    this->Second = sSS.toInt();
    x = x & (this->Second < 60);
    return x;
  }
  
  //Чтение даты-времени 
  String cTime::getDate()
  {
    String s = "";
    if(this->Day < 10) s += "0";
    s += String(this->Day);
    s += "-";
    if(this->Month < 10) s += "0";
    s += String(this->Month);
    s += "-";
    if(this->Year < 10) s += "0";
    s += String(this->Year);
    s += "-";
    if(this->Hour < 10) s += "0";
    s += String(this->Hour);
    s += "-";
    if(this->Minute < 10) s += "0";
    s += String(this->Minute);
    s += "-";
    if(this->Second < 10) s += "0";
    s += String(this->Second);
    return s;
  }

#endif
