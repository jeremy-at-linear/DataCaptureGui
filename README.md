# DataCaptureGui

Coding challenge for C# software development using Windows Forms or WPF.

## Basic Spec

Please see the [demo video](DataCaptureGuiDemo.mp4) to see how the final product should look and behave.

* This project should just take a few (1-4) hours to complete.
* It is assumed you have Visual Studio (Professional or Community is fine).
    * The provided projects target .NET framework 4.7.2 
* Feel free to use the internet as needed.
* Clone the solution and create a Windows Forms or WPF application with the desired behavior. 
    * Use the [FormsPlotControl](FormsPlotControl/Readme.md) if you are using Windows Forms or the [WpfPlotControl](WpfPlotControl/Readme.md) if you are using WPF.
    * You can use a different Framework, but you will have figure out the plotting using an appropriate library. (The plot controls provided here are thin wrappers around [OxyPlot](https://oxyplot.readthedocs.io/).)
* Your application should function as a web client and use HTTP requests to get the data (see the section on the server below).
* The Collect button should be disabled during capture, but all other controls should still be usable during the capture.
* The exact appearance is not important but the app should resize correctly, like the demo.
    * Feel free to use different colors.
* The plot title should be set to the waveform type generated.
* Make sure to include your email in the app title bar, and your name in the banner.
* The app should handle up to 10000 points. (Note that the server only provides up to 100 points at a time.)
* You don't need to add error checking, but think about what types of errors could occur in the app and how you would handle them.

# Web Server

* The server is a standalone exectuable called data-capture-service.exe
* It is contained in the cloned solution, along with a text file "Rocket.toml". (These should be kept together in the same location.)
* Out of the box it serves files to http://localhost:8194
    * You can change the port by editing Rocket.toml.
    * You can get a summary of the API endpoints by going to the URL above in your browser.
    * If you have any issues running the server or getting set up, please contact us!

## Extra Credit
* Add a menu bar with a help->about dialog. Put a link to a personal project page or something cool.
* Make it possible to cancel the capture. 
    * Instead of disabling the collect button, change the text to say "Cancel".
    * Clicking the button during a capture should stop the capture early. 
        * If, for example, you are reading 1000 points and cancel just after points 300-399 get read,
          it is OK to finish reading 400-499, but not to start 500-599).
    * You can plot the partial capture.
    * Whether the capture finishes or is cancelled, the capture button should reset to green and say "Capture" again.
