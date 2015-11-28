# Windows IoT Core Interaction Pack (WICIP)

The Windows IoT Interaction Pack provides reusable components for Windows Universal Applications that target the Windows IoT Core platform.

Master branch: [![Build status](https://ci.appveyor.com/api/projects/status/github/balassy/iot-interaction-pack?branch=master&svg=true)](https://ci.appveyor.com/project/balassy/iot-interaction-pack/branch/master)

Last build (any branch): [![Build status](https://ci.appveyor.com/api/projects/status/github/balassy/iot-interaction-pack?svg=true)](https://ci.appveyor.com/project/balassy/iot-interaction-pack)


## Features

The Pack contains the following components:

### LED

The `Led` class allows controlling a light-emitting diode (LED) connected to the Windows IoT Core device with its simple `TurnOn` and `TurnOff` methods.


### Push button

With the `PushButton` class you can write code that reacts to the events fired when the user pushes or releases a hardware button that is attached to the Windows IoT Core device.


### Ultrasonic sensor

The `UltrasonicSensor` class allows measuring the distance of an object using the HC-SR04 Ultrasonic Ranging Module attached to the Windows IoT Core device.
This class ensures reliable measurement, also for continuous measuring, even though this hardware module has some very unique characteristics (e.g. such as initialization time).


### RFID reader

The `RfidReader` class allows you to read the content of an RFID card. The RFID-RC522 reader must be connected to an Arduino board, 
and the Arduino must be connected to the Windows IoT Core device via I2C. When an RFID card is scanned, the Arduino pulls up a GPIO pin
of the Windows IoT Core device that is monitored by the `RfidReader` class, which in turn sends an I2C command to the Arduino 
to retrieve the previous read content of the card.


### Camera

The `Camera` class allows creating photos using the camera attached to the Windows IoT Core device. It was tested with a Logitech C910 HD Pro Webcam which 
is although officially not supported yet, works perfectly for this scenario. The class provides information about the detected camera (device name, supported resolutions),
and provides a convenient way to show a preview, and take a picture with the desired resolution, and save it to a file on the device.


### Speech synthesis

The `Speaker` class provides a convenient way to use the text-to-speech engine built into Windows IoT Core. You can pass a plain text or a Speech Synthesis Markup Language
text, and your device will read it loud on a male or female voice.


### Voice recognition

Coming soon...


## For contributors

Feel free to contribute to this project and submit pull request, but please use the attached `.vssettings` file before committing to ensure code conformance. Thank you.


## About the author

This project is maintained by **[György Balássy](http://gyorgybalassy.wordpress.com)**.
