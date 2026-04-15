# hibaripluse_B
plethysmograph     

HibariPulse Basic is  a medical instrument, plethysmograph developed by Future Wave,Inc. in Tokyo, Japan.
We show source code, schematics, PCB layout and other information about HibariPulse Basic.

Hibari Pulse Basic is composed of sensor and PC apprication software. The sensor is connected to Windows PC by USB cable. PC apprication software is distributed in CD-R.

DD151207 is the folder of device driver for USB. Hibari Pulse Basic uses the device driver of FTDI,Inc. The user should install both PC apprication software and the device driver.

SK121105_delay10 is the folder of firmware.

pats_list111004.xls is BOM. The PCB has socket, but no MPU. MPU is ATMEGA328p-PU by Microchip Technology,Inc. 
So, first, we burn firmware on ROM in MPU. Second, we insert MPU on the socket.

apprication software :  Visual studio 2010(C#)  firmware :Arduino IDE  schematics:CADLUS Design by Nisoul, Inc.  PCB laout:CADLUS X by Nisoul. Inc.  CASE: JW-CAD(customized product byTAKACHI Co,.LTD)

***********************************
https://youtu.be/cTy66kJvDls?si=9v41cSytfnO6r9-v     another version (with OLED) https://youtu.be/LcAzEBJ3FTY?si=bp07WSiirY0aO0Qf
