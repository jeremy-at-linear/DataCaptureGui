# WpfPlotControl

A simple plot control for use in WPF apps.
This control wraps an [OxyPlot](https://oxyplot.readthedocs.io/) plot control
and provides the following functionality:

* `SetData`: A function that takes an `IEnumerable\<double\>` collection of values and plots it.
* `Interpolation`: A property that can be set to one of "None" to plot single points, "Linear" to 
plot straight lines between points, or "Spline" to plot smooth curves between points. These options
are expressed in the `Interpolation` enumeration.
* `Title`: A property that sets the plot title.