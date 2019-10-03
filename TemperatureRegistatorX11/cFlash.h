#ifndef C_FLASH
#define C_FLASH
//=======================================================================
// Структура для работы с микросхемой FLASH памяти
//=======================================================================
/*
 * При попытке записи на страницу массива, выходящего за границу страницы,
 * байты, которые выходят за границу записываются с начала страницы
 * 
 */

//-----------------------------------------------------------------------
// ПОДКЛЮЧЕНИЕ БИБЛИОТЕК
//-----------------------------------------------------------------------
#include "sTimer.h"
#include "sAddress.h"
#include "sStatus.h"
#include "sPage.h"
 
class cFlash{
  int CS_PIN;
public:

  sStatus Status;
  sAddress Address;
  sTime Timer;

  sPage Page;
  
  void install(int pin);
  void setWriteEnable();
  bool getWriteEnable();
  void clearWriteEnable();
  void clearSectorProtection();
  void writePage();
  void readPage();
  void eraseBlock4K();
  void eraseBlock32K();
  void eraseBlock64K();
  void eraseChip1();
  void eraseChip2();
  bool checkPage();
  void writeArray(byte*data,int len);
  void view();
  String viewX();
    
};//End of struct sFlash

void cFlash::install(int pin)
{
  this->CS_PIN = pin;
  pinMode(this->CS_PIN, OUTPUT); //Программирование вывода управления CS на вывод
  
  this->Page.install();
}

void cFlash::setWriteEnable()
{
    SPI.beginTransaction(sStatus::mySet);
    digitalWrite(this->CS_PIN, LOW);   //CS_ON
    SPI.transfer(WREN);
    digitalWrite(this->CS_PIN, HIGH);  //CS_OFF
    SPI.endTransaction();
}

void cFlash::clearWriteEnable()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(this->CS_PIN, LOW);   //CS_ON
  SPI.transfer(WRDI);
  digitalWrite(this->CS_PIN, HIGH);  //CS_OFF  
  SPI.endTransaction();

}

void cFlash::writeArray(byte*data,int len)
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(this->CS_PIN, LOW);   //CS_ON
  SPI.transfer(PP);
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  
  for (int i=0; i<len; i++) 
  {
    SPI.transfer(data[i]);
  }
  
  digitalWrite(this->CS_PIN, HIGH);  //CS_OFF
  SPI.endTransaction();

}

void cFlash::writePage()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(this->CS_PIN, LOW);   //CS_ON
  SPI.transfer(PP);
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  
  for (int i=0; i<256; i++) 
  {
    SPI.transfer((byte)this->Page.data[i]);
  }
  //delay(1);
  digitalWrite(this->CS_PIN, HIGH);  //CS_OFF
  SPI.endTransaction();

}

void  cFlash::clearSectorProtection()
{
    SPI.beginTransaction(sStatus::mySet);
    digitalWrite(this->CS_PIN, LOW);   //CS_ON
    SPI.transfer(CLEAR_SECTOR_PROTECTION);
    SPI.transfer(this->Address.First);
    SPI.transfer(this->Address.Second);
    SPI.transfer(this->Address.Third);
    digitalWrite(this->CS_PIN, HIGH);  //CS_OFF
    SPI.endTransaction();
}

void cFlash::readPage()
{
  //Чтение данных в ОЗУ
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(READ); 
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  for (int i=0; i<256; i++) this->Page.data[i] = SPI.transfer(0);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}

bool cFlash::checkPage()
{
  bool x = true;
  //Чтение данных в ОЗУ
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(READ); 
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  for (int i=0; i<256; i++) x = x & (this->Page.data[i] == SPI.transfer(0));
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
  
  return x;
}

//Просмотр буфера данных
void cFlash::view()
{
  //Представление данных и выдача по последовательному порту
  for (int i=0; i<256; i++) {
    Serial.print(String(this->Page.data[i],HEX));
    Serial.print(": ");
    if(
      (i == 0x0f)||
      (i == 0x1f)||
      (i == 0x2f)||
      (i == 0x3f)||
      (i == 0x4f)||
      (i == 0x5f)||
      (i == 0x6f)||
      (i == 0x7f)||
      (i == 0x8f)||
      (i == 0x9f)||
      (i == 0xaf)||
      (i == 0xbf)||
      (i == 0xcf)||
      (i == 0xdf)||
      (i == 0xef)||
      (i == 0xff)
      ) 
      Serial.println();
  }
  Serial.println();
}

//Просмотр буфера данных
String cFlash::viewX()
{
  String s = "";
  //Представление данных и выдача по последовательному порту
  for (int i=0; i<256; i++) {
    s = s + String(this->Page.data[i],HEX);
    s = s + ": ";
    if(
      (i == 0x0f)||
      (i == 0x1f)||
      (i == 0x2f)||
      (i == 0x3f)||
      (i == 0x4f)||
      (i == 0x5f)||
      (i == 0x6f)||
      (i == 0x7f)||
      (i == 0x8f)||
      (i == 0x9f)||
      (i == 0xaf)||
      (i == 0xbf)||
      (i == 0xcf)||
      (i == 0xdf)||
      (i == 0xef)||
      (i == 0xff)
      ) 
      s = s + "\n";
  }
  //s = s + "\n";
  return s;
}

// Проверка бита разрешения записи  
bool cFlash::getWriteEnable()
{
  this->Status.get();
  bool x = (this->Status.First & 0x2 > 0);
  return x;  
}

// Очистка блока 4К
void cFlash::eraseBlock4K()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(BLOCK_ERASE_4KB);
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}

// Очистка блока 32К
void cFlash::eraseBlock32K()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(BLOCK_ERASE_32KB);
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}

// Очистка блока 64К
void cFlash::eraseBlock64K()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(BLOCK_ERASE_64KB);
  SPI.transfer(this->Address.First);
  SPI.transfer(this->Address.Second);
  SPI.transfer(this->Address.Third);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}

// Очистка чипа с помощью команды 0х60
void cFlash::eraseChip1()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(CHIP_ERASE1);
  //SPI.transfer(this->Address.First);
  //SPI.transfer(this->Address.Second);
  //SPI.transfer(this->Address.Third);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}

// Очистка чипа с помощью команды 0хC7
void cFlash::eraseChip2()
{
  SPI.beginTransaction(sStatus::mySet);
  digitalWrite(CS_PIN, LOW);
  SPI.transfer(CHIP_ERASE2);
  //SPI.transfer(this->Address.First);
  //SPI.transfer(this->Address.Second);
  //SPI.transfer(this->Address.Third);
  digitalWrite(CS_PIN, HIGH);
  SPI.endTransaction();
}


#endif
