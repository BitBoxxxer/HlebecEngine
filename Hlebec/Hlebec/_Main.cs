using Silk.NET.OpenGL;
using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Windowing;
using Silk.NET.Maths;

namespace MySilkProgram;

public class Program
{
    private static IWindow _window;
    private static GL _gl;
    private static uint _vao;
    private static uint _vbo;

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


    private static unsafe void OnLoad()
    {
        IInputContext input = _window.CreateInput();
        _gl = GL.GetApi(_window); // another take to work with OpenGL: _window.CreateOpenGL()
        _gl.ClearColor(Color.Gray);

        _vao = _gl.GenVertexArray();
        float[] vertices = {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };
        _gl.BindVertexArray(_vao);

        _vbo = _gl.GenBuffer(); // buffer object
        _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);

        fixed (float* buf = vertices)
            _gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (vertices.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);

        /* _gl.BufferData<float>(BufferTargetARB.ArrayBuffer, (uint)(vertices.Length * sizeof(float)), vertices, BufferUsageARB.StaticDraw);
        _gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        _gl.EnableVertexAttribArray(0); */ // Kasey: This is a basic example of the projection of a two-dimensional figure.

        for (int i = 0; i < input.Keyboards.Count; i++)
        {
            input.Keyboards[i].KeyDown += KeyDown;
            System.Console.WriteLine(KeyDown);
        }
    }


    private static void OnUpdate(double deltaTime)
    {

    }

    private static void OnRender(double deltaTime)
    {
        _gl.Clear(ClearBufferMask.ColorBufferBit);

        _gl.BindVertexArray(_vao);
        _gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    private static void OnClose() // when the window is closed engine should clean up resources
    {
        
    }
    private static void KeyDown(IKeyboard keyboard, Key key, int keyCode)
    {
        if (key == Key.Escape)
            _window.Close();
    }

}
