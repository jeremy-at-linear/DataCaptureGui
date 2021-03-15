# DataCapture

This project contains a class for simulating a data capture device.
It returns an array of integer data in the range of +/- 1024.
The data values can be affected by setting the `Waveform` property of
the class to a valid enumerated value (see the `WaveformType` class). The number of points per capture
can also be set by a property. To get the data call the `Capture` function.