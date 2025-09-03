using Silk.NET.OpenGL;
using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Windowing;
using Silk.NET.Maths;

var options = WindowOptions.Default;
options.Size = new Vector2D<int>(800, 600);
options.Title = "Моё первое окно на Silk.NET";

var window = Window.Create(options);



window.Run();