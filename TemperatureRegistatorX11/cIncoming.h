/*******************************************************************
 * Класс управления коммуникацией по последовательному порту
 * Строка с командой начинается  символом "решётки", а оканчивается 
 * символом ASCII(10). В начале строки могут шумовые символы.
 * Тело строки с командой содержит код команды и параметр, которые
 * разделяются символом "двоеточие".
 * Команды:
 * > Чтение показаний аналогового канала
 * get:<номер канала>
 * > Чтение статуса памяти
 * status
 * > Чтение страницы памяти
 * readPage:<address>
 * > Запись страницы памяти
 * writePage:<address>
 * > Стирание страницы памяти
 * erasePage:<address>
 * 
 * Формат ответа на команды
 * '{' - начало ответа
 * '}' - конец ответа
 * если присутствуют ошибки в синтаксисе команды, в сообщение добавляется
 * '!'
 * 
 *******************************************************************/
#ifndef C_INCOMING
#define C_INCOMING
//-----------------------------------------------------------------------
// КОНСТАНТЫ
//-----------------------------------------------------------------------

#define LF 10
#define OCTOTHORP 0x23

//-----------------------------------------------------------------------
// ПОДКЛЮЧАЕМЫЕ ФАЙЛЫ
//-----------------------------------------------------------------------
#include "cFlash.h"
#include "cMesurement.h"

//-----------------------------------------------------------------------
// КЛАССЫ И СТРУКТУРЫ
//-----------------------------------------------------------------------
enum IncomingPhase{
    NONE = 0,
    SEARCH_HEAD = 1,
    SEARCH_TAIL = 2,
    SEARCH_COMPLETE = 3
};

class cIncoming
{
protected:
String Command;
String Parameter;
bool IsValid;
bool IsData;


public:

static cMesurement Mesurement;

String Answer;
String Buffer;

char incomingByte;
char Phase;
int InvalidBytes;


cIncoming();
void operate();

private:
void execute();  

};//End of class cIncoming

cIncoming::cIncoming()
{
  this->Buffer = "";
  this->incomingByte = 0;
  this->InvalidBytes = 0;
  this->Command = "";
  this->Parameter = "";
  this->Phase = SEARCH_HEAD;
  this->IsValid = false;
  this->IsData = false;
}

// Реализация приёма команды
void cIncoming::operate()
{
  if(Serial.available() > 0) 
  {
    //Чтение байта из последовательного порта
    this->incomingByte = Serial.read();
    //Разбор принятого байта в зависимости от фазы приёма
    switch(this->Phase)
    {
      case SEARCH_HEAD:
      if(this->incomingByte == OCTOTHORP)
      {
        this->Phase = SEARCH_TAIL;  
        //Serial.print("#");
      }
      else
      {
        this->InvalidBytes++;
      }
      break;

      case SEARCH_TAIL:
      if(this->incomingByte == LF)
      {
        this->Phase = SEARCH_COMPLETE;  
        //Serial.print("!");
      }
      else
      {
        this->Buffer += String(this->incomingByte);
        //Serial.print(".");
      }
      break;

      case SEARCH_COMPLETE:

      break;

      case NONE:

      break;

      default:
      break;
    }//End of switch(this->Phase)
    
  }//End of while(Serial.available() > 0)

  //Выполнение принятой команды
  this->execute();
   
}//End of void cIncoming::operate()

// Реализация функциональности
void cIncoming::execute()
{
  if(this->Phase == SEARCH_COMPLETE)
  {
    //20190711 Serial.println("String:" + this->Buffer);
    int pos = this->Buffer.indexOf(':');
    if( pos >= 0 )
    {
      this->Command = this->Buffer.substring(0,pos);
      this->Parameter = this->Buffer.substring(pos+1);
    }
    else
    {
      this->Command = this->Buffer;
      this->Parameter = "";
    }
    //Сброс признака правильной команды
    this->IsValid = false;

    this->Answer = "{\n";//Начало ответа

    //Индикация результатов разбора
    //Serial.print("Command:");
    //Serial.print(this->Command);
    //Serial.print(" Parameter:");
    //Serial.println(this->Parameter);

    if(Command == "get")
    {
      int x = this->Parameter.toInt();
      int y = 0xff;
      
      //Serial.print("Command=get");
      //Serial.print(" Parameter=");
      //Serial.println(x);
      switch(x)
      {
        case 0:// Ошибочное значение
          this->Answer = this->Answer + "Format error!\n";
          
          this->IsValid = false;
        break;
        
        case 1:
          y = analogRead(0);
          this->Answer = this->Answer + "Chennel01:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 2:
          y = analogRead(1);
          this->Answer = this->Answer + "Chennel02:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 3:
          y = analogRead(2);
          this->Answer = this->Answer + "Chennel03:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 4:
         y = analogRead(3);
          this->Answer = this->Answer + "Chennel04:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 5:
          y = analogRead(4);
          this->Answer = this->Answer + "Chennel05:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 6:
          y = analogRead(5);
          this->Answer = this->Answer + "Chennel06:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 7:
          y = analogRead(6);
          this->Answer = this->Answer + "Chennel07:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 8:
          y = analogRead(7);
          this->Answer = this->Answer + "Chennel08:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 9:
          y = analogRead(8);
          this->Answer = this->Answer + "Chennel09:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 10:
          y = analogRead(9);
          this->Answer = this->Answer + "Chennel10:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 11:
          y = analogRead(10);
          this->Answer = this->Answer + "Chennel11:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;
        
        case 12:
          y = analogRead(11);
          this->Answer = this->Answer + "Chennel12:";
          this->Answer = this->Answer + y;
          this->IsValid = true;
        break;

        default:
          this->Answer = this->Answer + "Chennel number error! ";
          this->IsValid = false;
        break;
      }

    }//End of if(Command == "get")
    //------------------------------------------------------
    if(Command == "status")
    {
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      this->IsValid = true;
      
    }//End of Command == "status"
    //------------------------------------------------------
    if(Command == "readPage")
    {
      int x = this->Parameter.toInt();
      //Serial.println("Command=readPage:" + String(x,DEC));
     
      cMesurement::Flash.Address.get(x);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX();
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.readPage();
      cMesurement::Flash.Timer.stop();
      //this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      
      this->Answer = this->Answer + cMesurement::Flash.viewX();
      this->IsValid = true;
      
    }//End of Command == "readPage"
    
    //------------------------------------------------------
    if(Command == "readSector")
    {
      this->IsData = true;
      int addr = this->Parameter.toInt();
      this->Answer = this->Answer + "READ SECTOR FROM ";
      cMesurement::Flash.Address.get(addr);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX();
      this->Answer = this->Answer + " COMPLETE";
      
      Serial.println("{");
      for(int i = 0; i < 256; i++)
      {
        cMesurement::Flash.Address.get(addr + i * 256);
        cMesurement::Flash.Address.view();
        cMesurement::Flash.readPage();
        cMesurement::Flash.view();
      }
      Serial.println("}");
      
      this->IsValid = true;
      
    }//End of Command == "readSector"
    
    //------------------------------------------------------
    if(Command == "readChip")
    {
      this->IsData = true;
      int addr = 0;
      this->Answer = this->Answer + "READ CHIP ";
      cMesurement::Flash.Address.get(addr);
      this->Answer = this->Answer + " COMPLETE";
      
      Serial.println("{");
      for(int i = 0; i < 256 * 32; i++)
      {
        cMesurement::Flash.Address.get(addr + i * 256);
        cMesurement::Flash.Address.view();
        cMesurement::Flash.readPage();
        cMesurement::Flash.view();
      }
      Serial.println("}");
      
      this->IsValid = true;
      
    }//End of Command == "readChip"
    
    //------------------------------------------------------
    if(Command == "writePage")
    {
      // Заполнение массива данных в записи в ПЗУ!!!!
      // Serial.println("Prepare data data in the buffer");
      cMesurement::Flash.Page.table();

      //Serial.print("Command=writePage:");
      int x = this->Parameter.toInt();
      cMesurement::Flash.Address.get(x);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX();

      // Разблокирование сектора для записи
  
      // Установка бита разрешения записи
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Проверка бита разрешения записи
      if(cMesurement::Flash.getWriteEnable())
         this->Answer = this->Answer + "WEL bit is true\n";
      else
         this->Answer = this->Answer + "WEL bit is true\n";
        
      // Разрешение сектора 0 для записи
      this->Answer = this->Answer + "Clear sector protection from this address\n";
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      this->Answer = this->Answer + "Write data from array\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.writePage();
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      
      this->IsValid = true;
  
    }//End of Command == "writePage"
    
    //------------------------------------------------------
    if(Command == "eraseBlock4K")
    {
      //Serial.print("Command=eraseBlock4K:");
      this->Answer = this->Answer + "Command=eraseBlock4K:\n";

      int x = this->Parameter.toInt();
      cMesurement::Flash.Address.get(x);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Разрешение сектора 0 для записи
      Serial.println("Enable sector for erasing\n");
      this->Answer = this->Answer + "Enable sector for erasing\n";
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
 
      // Очистка блока:
  
      //Serial.println("Erase block 4kB using 20h opcode");
      this->Answer = this->Answer + "Erase block 4kB using 20h opcode\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.eraseBlock4K();
      
      cMesurement::Flash.Status.get();
      while(cMesurement::Flash.Status.First & 0x1)
      {
        cMesurement::Flash.Status.get();
      }
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      //Serial.println("Block 4kB from SPI flash is clear!");
      this->Answer = this->Answer + "Block 4kB from SPI flash is clear!\n";
      // Выставление запрета записи:
      //Serial.println("Clear WEL bit");
      this->Answer = this->Answer + "Clear WEL bit\n";
      cMesurement::Flash.clearWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      
      this->IsValid = true;
  
    }//End of Command == "eraseBlock4K"
    
    //------------------------------------------------------
    if(Command == "eraseBlock32K")
    {
      //Serial.print("Command=eraseBlock32K:");
      this->Answer = this->Answer + "Command=eraseBlock32K:\n";
      int x = this->Parameter.toInt();
      cMesurement::Flash.Address.get(x);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Разрешение сектора 0 для записи
      //Serial.println("Enable sector for erasing");
      this->Answer = this->Answer + "Enable sector for erasing\n";
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
 
      // Очистка блока:
  
      //Serial.println("Erase block 32kB using 52h opcode");
      this->Answer = this->Answer + "Erase block 32kB using 52h opcode\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.eraseBlock32K();
      
      cMesurement::Flash.Status.get();
      while(cMesurement::Flash.Status.First & 0x1)
      {
        cMesurement::Flash.Status.get();
      }
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      //Serial.println("Block 32kB from SPI flash is clear!");
      this->Answer = this->Answer + "Block 32kB from SPI flash is clear!\n";
      // Выставление запрета записи:
      //Serial.println("Clear WEL bit");
      this->Answer = this->Answer + "Clear WEL bit\n";
      cMesurement::Flash.clearWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      this->IsValid = true;
  
    }//End of Command == "eraseBlock32K"
    
    //------------------------------------------------------
    if(Command == "eraseBlock64K")
    {
      //Serial.print("Command=eraseBlock64K:");
      //Serial.print(", Parameter:");
      //Serial.println(this->Parameter);
      this->Answer = this->Answer + "EraseBlock64K:";
      int x = this->Parameter.toInt();
      cMesurement::Flash.Address.get(x);
      this->Answer = this->Answer + cMesurement::Flash.Address.viewX() + "\n";

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit" + "\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Разрешение сектора 0 для записи
      //Serial.println("Enable sector for erasing");
      this->Answer = this->Answer + "Enable sector for erasing" + "\n";
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit" + "\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
 
      // Очистка блока:
  
      //Serial.println("Erase block 64kB using 0D8h opcode");
      this->Answer = this->Answer + "Erase block 64kB using 0D8h opcode" + "\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.eraseBlock64K();
      
      cMesurement::Flash.Status.get();
      while(cMesurement::Flash.Status.First & 0x1)
      {
        cMesurement::Flash.Status.get();
      }
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      //Serial.println("Block 64kB from SPI flash is clear!");
      this->Answer = this->Answer + "Block 64kB from SPI flash is clear!" + "\n";

      // Выставление запрета записи:
      Serial.println("Clear WEL bit");
      this->Answer = this->Answer + "Clear WEL bit" + "\n";
      cMesurement::Flash.clearWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      
      this->IsValid = true;
  
    }//End of Command == "eraseBlock64K"
    
    //------------------------------------------------------
    if(Command == "eraseChip1")
    {
      //Serial.print("Command=eraseChip1:");
      //int x = this->Parameter.toInt();
      //cMesurement::Flash.Address.get(x);
      //cMesurement::Flash.Address.view();
      //Serial.println();
      this->Answer = this->Answer + "Command=eraseChip1\n";
      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Разрешение сектора 0 для записи
      //Serial.println("Enable sector for erasing");
      this->Answer = this->Answer + "Enable sector for erasing\n"; 
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
 
      // Очистка кристалла:
  
      //Serial.println("Erase chip using 60h opcode");
      this->Answer = this->Answer + "Erase chip using 60h opcode\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.eraseChip1();
      
      cMesurement::Flash.Status.get();
      while(cMesurement::Flash.Status.First & 0x1)
      {
        cMesurement::Flash.Status.get();
      }
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      //Serial.println("Chip SPI flash is clear!");
      this->Answer = this->Answer + "Chip SPI flash erasing is not success!\n";
      // Выставление запрета записи:
      //Serial.println("Clear WEL bit");
      this->Answer = this->Answer + "Clear WEL bit\n";
      cMesurement::Flash.clearWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      
      this->IsValid = true;
  
    }//End of Command == "eraseChip1"
    
    //------------------------------------------------------
    if(Command == "eraseChip2")
    {
      //Serial.print("Command=eraseChip2:");
      //int x = this->Parameter.toInt();
      //cMesurement::Flash.Address.get(x);
      //cMesurement::Flash.Address.view();
      //Serial.println();
      this->Answer = this->Answer + "Command=eraseChip2\n";
      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Разрешение сектора 0 для записи
      //Serial.println("Enable sector for erasing");
      this->Answer = this->Answer + "Enable sector for erasing\n"; 
      cMesurement::Flash.clearSectorProtection();

      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();

      // Установка бита разрешения записи
      //Serial.println("Set WEL bit");
      this->Answer = this->Answer + "Set WEL bit\n";
      cMesurement::Flash.setWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
 
      // Очистка кристалла:
  
      //Serial.println("Erase chip using 0C7h opcode");
      this->Answer = this->Answer + "Erase chip using 0C7h opcode\n";
      cMesurement::Flash.Timer.start();
      cMesurement::Flash.eraseChip2();
      
      cMesurement::Flash.Status.get();
      while(cMesurement::Flash.Status.First & 0x1)
      {
        cMesurement::Flash.Status.get();
      }
      cMesurement::Flash.Timer.stop();
      this->Answer = this->Answer + cMesurement::Flash.Timer.viewX();
      //Serial.println("Chip SPI flash is clear!");
      this->Answer = this->Answer + "Chip SPI flash erasing is not success!\n";
      // Выставление запрета записи:
      //Serial.println("Clear WEL bit");
      this->Answer = this->Answer + "Clear WEL bit\n";
      cMesurement::Flash.clearWriteEnable();
      // Чтение регистра статуса
      cMesurement::Flash.Status.get();
      this->Answer = this->Answer + cMesurement::Flash.Status.viewX();
      
      this->IsValid = true;
  
    }//End of Command == "eraseChip2"
    
    //------------------------------------------------------
    if(Command == "state")
    {
      this->Answer = this->Answer + "State:";
      //Serial.print("Command=state:");
      if(this->Parameter == "")
      {
        switch(cIncoming::Mesurement.State)
        {
          case START:
            //Serial.println("START");
            this->Answer = this->Answer + "START\n";
          break;

          case IDLE:
            //Serial.println("IDLE");
            this->Answer = this->Answer + "IDLE\n";
          break;

          case MESSAGE_START_TO_SUSPEND:
            //Serial.println("MESSAGE_START_TO_SUSPEND");
            this->Answer = this->Answer + "MESSAGE_START_TO_SUSPEND\n";
          break;
    
          case WORK:
            //Serial.println("WORK");
            this->Answer = this->Answer + "WORK\n";
          break;

          case SUSPEND:
            //Serial.println("SUSPEND");
            this->Answer = this->Answer + "SUSPEND\n";
          break;

          default:
            //Serial.println("DEFAULT");
            this->Answer = this->Answer + "DEFAULT\n";
          break;
        }

        this->IsValid = true;

      }//End of if(this->Parameter == "")

      if(this->Parameter == "idle")
      {
        //Serial.println(", parameter:" + this->Parameter);
        this->Answer = this->Answer + this->Parameter + " => execute...\n";
        this->IsValid = true;
        cIncoming::Mesurement.State = IDLE;
      }//End of if(this->Parameter == "idle")

      if(this->Parameter == "work")
      {
        //Serial.println(", parameter:" + this->Parameter);
        this->Answer = this->Answer + this->Parameter + " => execute...\n";
        this->IsValid = true;
        cIncoming::Mesurement.State = WORK;
      }//End of if(this->Parameter == "work")

      if(this->Parameter == "suspend")
      {
        //Serial.println(", parameter:" + this->Parameter);
        this->Answer = this->Answer + this->Parameter + " => execute...\n";
        this->IsValid = true;
        cIncoming::Mesurement.State = SUSPEND;
      }//End of if(this->Parameter == "suspend")

      if(this->Parameter == "start")
      {
        //Serial.println(", parameter:" + this->Parameter);
        this->Answer = this->Answer + this->Parameter + " => execute...\n";
        this->IsValid = true;
        cIncoming::Mesurement.State = START;
      }//End of if(this->Parameter == "start")

      
    }//End of Command == "state"
    
    //------------------------------------------------------
    if(Command == "realTime")
    {
      //Serial.print("Command=realTime:");
      //Serial.println(cMesurement::Time.RealTime);
       this->Answer = this->Answer + "RealTime:" + String(cMesurement::Time.RealTime, DEC) + "\n";
      
      this->IsValid = true;
    }//End of Command == "realTime"
    
    //------------------------------------------------------
    if(Command == "workTime")
    {
      //Serial.print("Command=workTime:");
      //Serial.println(cMesurement::Time.WorkTime);
      this->Answer = this->Answer + "Elapse:" + String(cMesurement::Time.WorkTime, DEC);
      this->Answer = this->Answer + " remain:" + String(FINISH_TIME - cMesurement::Time.WorkTime, DEC);
      this->Answer = this->Answer + "\n";

      this->IsValid = true;
    }//End of Command == "realTime"

    //------------------------------------------------------
    if(Command == "date")
    {
      //Serial.print("Command=date");
      this->Answer = this->Answer + "Date:";
       if(this->Parameter == "")
       {
          //Serial.println(":" + cMesurement::Time.getDate());
          //Serial.println("06-06-19-15-04-00");
          this->Answer = this->Answer + ":" + cMesurement::Time.getDate() + "\n";
          this->IsValid = true;
       }
       else
       {
          //Serial.println(", parameter:" + this->Parameter);
          this->Answer = this->Answer + this->Parameter + "\n";
          if(cMesurement::Time.setDate(this->Parameter)) this->IsValid = true;
       }
       
    }//End of Command == "date"

    //------------------------------------------------------
    if(Command == "workAddress")
    {
      //Serial.print("Command=workAddress:");
      this->Answer = this->Answer + "WorkAddress:";
      if((cIncoming::Mesurement.State == WORK) || true)
        this->Answer = String(cMesurement::Flash.Page.Address * 256 +  cMesurement::Flash.Page.Pointer);
      else
        this->Answer = String(0);

      this->IsValid = true;
    }//End of Command == "workAddress"

    // Индикация ошибки 
    
    if(this->IsValid)
    {
      if(this->IsData)
      {
        this->IsData = false;
      }
      else
      {
        //Окончание посылки и ее передача
        this->Answer = this->Answer + "\n}";
        Serial.println(this->Answer);
      }
    }
    else
    {
      this->Answer = this->Answer + "Invalid command or parameter value!";
    }
    
      //Очистка буфера
      this->Answer = "";
    //Возврат к поиску начального маркера
    this->Buffer = "";
    this->Phase = SEARCH_HEAD;
  }
}//End of void cIncoming::execute()

#endif
