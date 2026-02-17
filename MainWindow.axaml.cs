using System;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Media;

namespace avalonia_test;

public partial class MainWindow : Window
{
    // DateTime? lastTitleBarClick = null;
    // const int MAX_DOUBLECLICK_MS = 20;


    void ToggleMaximize()
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        TitleBar.PointerPressed += (sender, args) =>
        {
            if (args.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(args);
            }
        };
        MinimizeBtn.Click += (_, _) => WindowState = WindowState.Minimized;
        MaximizeBtn.Click += (_, _) =>
            WindowState = (WindowState == WindowState.FullScreen) ? WindowState.Normal : WindowState.FullScreen;
        CloseWinBtn.Click += (_, _) => Close();
        Width = Screens.All[0].Bounds.Width * 0.4;
        Height = Screens.All[0].Bounds.Height * 0.7;
    }
}