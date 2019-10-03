//=======================================================================
// Структура для организации доступа к страницам микросхемы FLASH памяти
//=======================================================================
#ifndef SPAGE
#define SPAGE

struct sPage{
 int    Address;
 int    Pointer;

 byte data[256];

 void install();
 void table();
 void step();
 
};//

 void sPage::install()
{
  this->Address = 0;
  this->Pointer = 0;
  for(int i=0; i < 256; i++) this->data[i] = 0xff;
}

 void sPage::table()
{
  for(int i=0; i < 256; i++) this->data[i] = i;
}

 void sPage::step()
{
  this->Pointer = this->Pointer + 2;
  if(this->Pointer = 256)
  {
    this->Pointer = 0;
    this->Address++;
  }
}



#endif
