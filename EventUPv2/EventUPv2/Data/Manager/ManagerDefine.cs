using EventUPv2.RestService;
using System;
namespace EventUPv2.Manager
{
    public class ManagerDefine<T, P, S>
    {
        public static Manager<T, P, S> manager = new Manager<T, P, S>(new RestService<T, P, S>());

    }
    public class ManagerDefine<T>
    {
        public static Manager<T, T, T> manager = new Manager<T, T, T>(new RestService<T, T, T>());

    }
}