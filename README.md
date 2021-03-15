# DataCaptureGui

Coding challenge for C# software development using Windows Forms or WPF.

## Basic Spec

Please see the [demo video](DataCaptureGuiDemo.mp4) to see how the final product should look and behave.

* This project should just take a few (1-4) hours to complete.
* It is assumed you have Visual Studio (Professional or Community is fine).
    * The provided projects target .NET framework 4.7.2 
* Feel free to use the internet as needed.
* Clone the solution and create a Windows Forms or WPF application with the desired behavior. 
* The exact appearance is not important but the app should resize correctly, like the demo.
    * Feel free to use different colors.
* The plot title should be set to the waveform type generated.
* Make sure to include your email in the app title bar, and your name in the banner.
* Use the [DataCapture](DataCapture/Readme.md) library in this repo to generate the plot data.
* Use the [FormsPlotControl](FormsPlotControl/Readme.md) if you are using Windows Forms or the [WpfPlotControl](WpfPlotControl/readme.md) if you are using WPF
    * You can use a different Framework, but you will have figure out the plotting using an appropriate library. (The plot controls provided here are thin wrappers around [OxyPlot](https://oxyplot.readthedocs.io/).)
* You don't need to add error checking, but think about what types of errors could occur in the app and how you would handle them.

## Extra Credit
* Add a menu bar with a help->about dialog. Put a link to a personal project page or something cool.
* Create a new Waveform type called `Piecewise` in the `DataCapture` project add this to the drop down 
of waveform choices in the GUI so it can be plotted. The value of the nth sample should be calculated as
follows:
    * 0 <= n < 5 - linearly interpolate between 20 and 180 (0->20, 4->180)
    * 5 <= n < 10 - linearly interpolate between 200 and 500 (5->200, 9->500)
    * 10 <= n < 15 - linearly interpolate between 450 and -150 (10->150, 140->-150)
    * 15 <= n < 20 - linearly interpolate between -300 and 0 (15->-300, 19->0)
    * for any sample n > 20, calculate as above using the remainder of n / 20.
