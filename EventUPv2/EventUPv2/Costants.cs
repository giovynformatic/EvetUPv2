﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        //  public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        //  public static string TodoItemsUrl = BaseAddress + "/api/todoitems/{0}";
        public static string UserUrl = null;
        public static string AdminUrl = null;
    }
}
