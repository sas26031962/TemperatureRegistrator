//=======================================================================
// Структура для измерения времени выполнения операций микросхемы FLASH памяти
//=======================================================================
#ifndef STIMER
#define STIMER
struct sTime{
  long Previous;  //Предыдущая метка времени
  long Current;   //Текущая метка времени
  bool IsReady;   //Флаг останова
  
  void start();   //Запуск таймера
  void stop();    //Остановка таймера
  void view();    //Просмотр измеренного значения
  String viewX();    //Просмотр измеренного значения
};
  //Запуск таймера
  void sTime::start()
  {
    this->Current = millis();
    this->Previous = this->Current; 
    this->IsReady = false;    
  }
  
  //Остановка таймера
  void  sTime::stop()
  {
    this->Current = millis();
    this->IsReady = true;
  }
  
  //Просмотр измеренного значения 
  void sTime::view()
  {
    Serial.println("Dwell:" + String((this->Current - this->Previous), DEC) + " ms");      
  }

  //Просмотр измеренного значения 
  String sTime::viewX()
  {
    String s = "Dwell:" + String((this->Current - this->Previous), DEC) + " ms\n";  
    return s;    
  }

#endif
