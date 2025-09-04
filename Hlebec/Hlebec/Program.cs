using Silk.NET.OpenGL;
using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Windowing;
using Silk.NET.Maths;

namespace MySilkProgram;

public class Program
{
    private static IWindow _window;

    private static void OnLoad() { Console.WriteLine("Load"); } // комменты чисто для теста консоли

    private static void OnUpdate(double deltaTime) { Console.WriteLine("Update"); }

    private static void OnRender(double deltaTime) { Console.WriteLine("Render"); }
    public static void Main(string[] args) {

        WindowOptions options = WindowOptions.Default with
        {
            Size = new Vector2D<int>(800, 600),
            Title = "My first Silk.NET application!"
        };
        _window = Window.Create(options);
        _window.Load += OnLoad;
        _window.Update += OnUpdate;
        _window.Render += OnRender;
        _window.Run();
    }
}
