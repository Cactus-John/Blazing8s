﻿using Microsoft.Maui.Layouts;

namespace Blazing8s;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

        MainPage = new AppShell();
	}
}
