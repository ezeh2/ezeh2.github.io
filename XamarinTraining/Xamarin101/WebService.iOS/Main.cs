using System;
using System.Collections.Generic;
using System.Linq;

using WebService.Core.Services.People;
using WebService.Core.Services.People.Impl;
using WebService.Core.Handlers.Http.Impl;
using Foundation;
using UIKit;

namespace WebService.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

		public static IPersonService PersonService => new WebService.Core.Services.People.Impl.PersonService (new HttpHandler());
    }
}