using Silk.NET.OpenGL;
using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Windowing;
using Silk.NET.Maths;

namespace MySilkProgram;

public class Program
{
    private static IWindow _window;

    public static void Main(string[] args)
    {

        WindowOptions options = WindowOptions.Default with
        {
            Size = new Vector2D<int>(800, 600),
            Title = "HlebecEngine"
        };
        _window = Window.Create(options);
        _window.Load += OnLoad;
        _window.Update += OnUpdate;
        _window.Render += OnRender;


        _window.Run();
    }


    private static void OnLoad()
    {
        IInputContext input = _window.CreateInput();
        for (int i = 0; i < input.Keyboards.Count; i++)
        {
            input.Keyboards[i].KeyDown += KeyDown;
            System.Console.WriteLine(KeyDown);
        }
    }

    private static void KeyDown(IKeyboard keyboard, Key key, int keyCode)
    {
        if (key == Key.Escape)
            _window.Close();
    }

    private static void OnUpdate(double deltaTime)
    {

    }

    private static void OnRender(double deltaTime)
    {

    }

}
