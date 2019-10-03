#ifndef S_ADDRESS
#define S_ADDRESS
//=======================================================================
// Структура для адресации микросхемы FLASH памяти
//=======================================================================
struct sAddress{
  byte First;     //Старший байт
  byte Second;    //Средний байт
  byte Third;     //Младший байт

  String Answer;  //
  
  void view();    //Просмотр значения адреса через Serial
  String viewX(); //Просмотр значения адреса через String
  void get(int x);//Извлечение целевого адреса
};

//Просмотр значения адреса через Serial
void sAddress::view()
{
    int x = First + 256 * Second + 65536 *Third;
    Serial.println("FLASH address: " + 
    String(x, HEX) 
    );
}

//Просмотр значения адреса через Serial
String sAddress::viewX()
{
  int x = Third + 256 * Second + 65536 *First;
  this->Answer = "FLASH address: ";
  this->Answer = this->Answer + String(x,HEX);
  this->Answer = this->Answer + "\n";
  return this->Answer;
 }

//Извлечение целевого адреса
void sAddress::get(int x)
{
    this->First = ((x >> 16) & 0xff); 
    this->Second = ((x >> 8) & 0xff); 
    this->Third = (x & 0xff);
    
}

#endif
