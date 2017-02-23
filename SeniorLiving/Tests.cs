using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace SeniorLiving
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.Android
				// TODO: Update this path to point to your Android app and uncomment the
				// code if the app is not included in the solution.
				.ApkFile ("/Users/junecho/Desktop/apkS/SeniorLiving.apk")
				.StartApp();
		}

		[Test]
		public void AppLaunches()
		{
			//Carousel Swipe
			app.SwipeRightToLeft();
			app.WaitForElement(x => x.Id("NoResourceEntry-1"));
			app.SwipeRightToLeft();
			app.WaitForElement(x => x.Id("NoResourceEntry-2"));
			app.SwipeRightToLeft();
			app.WaitForElement(x => x.Id("NoResourceEntry-3"));
			app.SwipeRightToLeft();
			app.Screenshot("LoginPage");

			//Login Credentials
			app.WaitForElement(x => x.Marked("Email address"));
			app.Tap(x => x.Index(48));
			app.EnterText("jengu@microsoft.com");
			app.DismissKeyboard();
			app.Tap(x => x.Button("btnContinue"));
			app.WaitForElement(x => x.Marked("PIN"));
			app.EnterText("6804");
			app.DismissKeyboard();
			app.Tap(x => x.Button("btnContinue"));
			app.Screenshot("Logging in with my credentials");

			//End of Introduction
			app.WaitForElement(x => x.Marked("NEXT"));
			app.Flash(x => x.Marked("NEXT"));
			app.Tap(x => x.Marked("NEXT"));
			app.Tap(x => x.Marked("NEXT")); 
			app.Tap(x => x.Marked("NEXT"));
			app.Tap(x => x.Marked("OK, GOT IT"));
			app.Screenshot("End of Introduction");
			app.Back();

			//Hollenbeck Home
			app.Flash(x => x.Marked("Hollenbeck Home"));
			app.Tap(x => x.Marked("Hollenbeck Home"));
			app.WaitForElement(x => x.Marked("SCHEDULE A TOUR"));
			app.ScrollDownTo(x => x.Marked("MORE"));
			app.Tap(x => x.Marked("Prices (starting at)"));
			Thread.Sleep(TimeSpan.FromSeconds(3));
			app.Screenshot("Hollenbeck Home Info");
			app.Back();

			app.Repl();



		}
	}
}

