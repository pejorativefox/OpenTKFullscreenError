
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTKResizeIssue;

public class Window : GameWindow
{

    public Window(NativeWindowSettings nativeWindowSettings, GameWindowSettings gameWindowSettings) 
        : base(gameWindowSettings, nativeWindowSettings)
    {
        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        SwapBuffers();
    }
    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        switch (e.Key)
        {
            case Keys.F:
                WindowState = OpenTK.Windowing.Common.WindowState.Fullscreen;
                break;
            case Keys.G:
                WindowState = OpenTK.Windowing.Common.WindowState.Normal;
                break;
            default:
                break;
        }
    }
}
class MainClass
{

    public static void Main(string[] args)
    {
        var nativeWindowSettings = new NativeWindowSettings()
        {
            Size = new Vector2i(1280, 720),
            Title = "Fullscreen Test",
            APIVersion = new Version(4, 2),
        };
        var gameWindowSettings = GameWindowSettings.Default;
        var window = new Window(nativeWindowSettings, gameWindowSettings);
        window.Run();
    }
}
