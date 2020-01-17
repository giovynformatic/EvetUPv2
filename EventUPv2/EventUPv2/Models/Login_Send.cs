using System;
namespace EventUPv2
{
    public class Login_Send
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceid { get; set; }
        public Login_Send(String username, String Password, String uid)
        {
            this.username = username;
            this.password = Password;
            this.deviceid = uid;
        }
    }
}
