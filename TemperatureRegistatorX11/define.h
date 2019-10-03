#ifndef DEFINEX
#define DEFINEX
//========================================================================
//------------------------- АППАРАТНАЯ КОНФИГУРАЦИЯ ----------------------
//========================================================================
#define SERIAL_SPEED 115200    //Скорость передачи по каналу последовательного порта

//-----------------------------------------------------------------------
// КОНСТАНТЫ, СВЯЗАННЫЕ С МИКРОСХЕМОЙ FLASH-ПАМЯТИ SPI AT25DF161-SH-T 
//-----------------------------------------------------------------------

const int CS_PIN = 10;   //Вывод CS микросхемы памяти

const byte WREN = 0x06; //Команда разрешения записи
const byte WRDI = 0x04; //Команда запрета записи
const byte READ = 0x03; //Команда чтения массива
const byte PP = 0x02;   //Команда записи байта (страницы)

const byte BLOCK_ERASE_4KB = 0x20;    //Команда BlockErase (4kB)
const byte BLOCK_ERASE_32KB = 0x52;   //Команда BlockErase (32kB)
const byte BLOCK_ERASE_64KB = 0xd8;   //Команда BlockErase (64kB)

const byte CHIP_ERASE1 = 0x60;        //Команда ChipErase1 
const byte CHIP_ERASE2 = 0xC7;        //Команда ChipErase2 

const byte SET_SECTOR_PROTECTION = 0x36;   //Команда установки защиты с сектора
const byte CLEAR_SECTOR_PROTECTION = 0x39;   //Команда снятия защиты с сектора

const byte RSTATUS = 0x05;   //Команда чтения регистра статуса
const byte WSTATUS1 = 0x01;  //Команда записи байта 1 регистра статуса
const byte WSTATUS2 = 0x31;  //Команда записи байта 2 регистра статуса

//-----------------------------------------------------------------------
// КОНСТАНТЫ, СВЯЗАННЫЕ С ПРОЦЕССОМ ИЗМЕРЕНИЯ
//-----------------------------------------------------------------------

#define START_PAUSE 200             //Стартовая пауза в циклах (1 цикл - 100 мс)
#define FINISH_TIME 36000           //Время окончания измерения
#define TEST_MEMORY_TIME 432000     //Число отсчётов для проверки области памяти

#define CHENNEL_NUMBER 12           //число каналов измерения
#define CORTAGE_NUMBER 10           //число кортежей на страницу

#define ADC_RANGE 12          //разрядность АЦП
#define MESUREMENT_CYCLE 100  //цикл измерения в миллисекундах

#define REPEATE 10//0000        //число опросов при ожидании готовности

#endif
