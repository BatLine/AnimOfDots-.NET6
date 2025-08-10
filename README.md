
# AnimOfDots (Loading Indicator)
[.NET WinForms/WPF] Loading animations for C# WinForms, VB.NET and WPF.
#
Preview:

![Preview animation](https://raw.githubusercontent.com/mt-alts/AnimOfDots/main/preview.gif)

| Pulse           | Circular        | DotScaling      |
|-----------------|----------------|-----------------|
| DotGridFlashing | MultiplePulse   | DoubleDotSpin   |
| DotTyping       | Overlay         | DotFlashing     |

## WPF Support
The package includes a WPF wrapper project that hosts the WinForms
spinners inside a `WindowsFormsHost`. This allows the same animations to
be used in WPF applications.

```xaml
<Window
    xmlns:aodw="clr-namespace:AnimOfDots.WPF.Controls;assembly=AnimOfDots.WPF">
    <aodw:DotFlashing Running="True" />
</Window>
```

#

## Properties and Methods
### Common property and methods
| Property or Method | Type  | Description |
| :-------- | :------- | :------------------------- |
| AnimationSpeed | Property | Changes animation speed |
| Running | Property | Indicates whether the animation is running |
| HideOnStop | Property | Hides the indicator when the animation is stopped |
| BackColor | Property | Changes the background color of the indicator |
| Start() | Method | Start animating |
| Stop() | Method | Stop animating |
#
#### Circular, DotGridFlashing, DotTyping, DoubleDotSpin, Pulse, MultiplePulse
| Property or Method | Type | Description  |
| :-------- | :------- | :------------------------- |
| ForeColor | Property | Changes the color of the indicator |
#
#### Overlay, ColorfulCircular, DotScaling
| Property or Method | Type | Description   |
| :-------- | :------- | :------------------------- |
| Colors | Property | Changes the color of the indicator <br /> according to the color array |
#
#### DotGridFlashing
| Property or Method | Type | Description |
| :-------- | :------- | :------------------------- |
| ColorAlpha | Property | Changes the transparency level of <br /> half of the indicator elements |
#
#### DotFlashing, DoubleDotSpin
| Property or Method | Type | Description |
| :-------- | :------- | :------------------------- |
| PrimaryColor | Property | Changes the primary color         |
| SecondaryColor | Property | Changes the secondary color     |
#
 ℹ️ Some controls must have the same aspect ratio to work properly.</br>
