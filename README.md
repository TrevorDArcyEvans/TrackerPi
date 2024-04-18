# Reinventing the wheel but with a Raspberry Pi
Why buy a perfectly round wheel when you can build your own clunky one?

## Background
For new car drivers, many insurance companies require installing a smart phone
app which records speed and position.  This is so the insurer can monitor how
safely the new driver is performing (or not).  There are also various apps
which do similar things.  Some of the apps also connect to the car's
OBD (On Board Diagnostics) via a bluetooth adaptor to also record various 
vehicle parameters eg road speed, engine speed, selected gear, etc

## Solution
Raspberry Pis are readily available. USB GPS receivers are available. 
Buetooth OBD receivers are available. What about if we put all of these 
together in a nice, black, plastic box? What's the worst that could happen?

## Hardware
* Raspberry Pi Zero 2 W
* ELM327 based bluetooth OBD connector

  <details>
    <summary>Images</summary>
  
  ![](media/ELM327-OBD2.jpg)<p>
  
  </details>

* USB GPS device

  <details>
    <summary>Images</summary>

  ![](media/USB-GPS-Receiver.jpg)<p>

  </details>

### Optional
*  ECU/OBD simulator

    <details>
      <summary>Images</summary>
  
    ![](media/OBD-Simulator-ELM327-01.jpg)<p>
    ![](media/OBD-Simulator-ELM327-02.jpg)<p>
    ![](media/OBD-Simulator-ELM327-03.jpg)<p>
    ![](media/OBD-Simulator-ELM327-04.jpg)<p>
  
    </details>

## Software
* git 2.13+
* .NET 8 SDK

### Optional
* [ELM327 simulator](https://github.com/Ircama/ELM327-emulator)
* [PyGPSClient](https://github.com/semuconsulting/PyGPSClient)

    <details>

  ```bash
  sudo apt install python3-pip python3-tk python3-pil python3-pil.imagetk libjpeg-dev zlib1g-dev
  python3 -m pip install --upgrade pygpsclient
  ```

    </details>

* [Minicom](https://www.makeuseof.com/connect-to-serial-consoles-on-linux/)

## Getting started

```bash
# clone repository
git clone --recurse-submodules https://github.com/TrevorDArcyEvans/TrackerPi.git

# build code
cd TrackerPi/src
dotnet build

# run main app
cd TrackerPi/bin/Debug/net8.0/
./TrackerPi /dev/ttyACM0 /dev/ttyOBD0
```

## Acknowledgments
* OBD
  * [Get OBD2 Data via ELM327 C#.NET](https://burak.alakus.net/en/2011/07/27/to-get-obd2-data-via-elm327-c/) 
  * [OBD2NET](https://github.com/0x8DEADF00D/obd2NET)
  * [OBD-II PIDs](https://en.wikipedia.org/wiki/OBD-II_PIDs)
* GPS
  * [Linux support for GPS Receiver over serial port](https://sandervandevelde.wordpress.com/2019/08/21/linux-support-for-gps-receiver-over-serial-port/)
  * [NMEA Parser](https://github.com/sandervandevelde/nmeaparser)
* Other
  * [Circular Buffer](https://github.com/joaoportela/CircularBuffer-CSharp)