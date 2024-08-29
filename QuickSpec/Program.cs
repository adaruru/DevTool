// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using SQLitePCL;

namespace QuickSpec;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Batteries.Init();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new QuickSpecForm());
    }
}