#ifndef S_STATUS
#define S_STATUS
//=======================================================================
// Структура для получения, хранения и индикации статуса микросхемы FLASH памяти
//=======================================================================

struct sStatus{
  static SPISettings mySet;
  byte First;
  byte Second;
  String Answer;
  
  void get();
  void view();
  String viewX();
};

void sStatus::get()
{
  
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);   //CS_ON
  SPI.transfer(RSTATUS);
  First = SPI.transfer(0); 
  Second = SPI.transfer(0);
  digitalWrite(CS_PIN, HIGH);  //CS_OFF
  SPI.endTransaction();
  
}

void sStatus::view()
{
  Serial.print("Status register read: ");
  Serial.print("first status byte= ");
  Serial.print(First,HEX);
  Serial.print(", second status byte= ");
  Serial.print(Second,HEX);
  Serial.println();
}

String sStatus::viewX()
{
  this->Answer = "Status: "; 
  this->Answer = this->Answer + String((First + (256*Second)),HEX); 
  this->Answer = this->Answer + "\n";
  return this->Answer;
}


#endif
