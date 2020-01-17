using System;
namespace EventUPv2
{
    public class Login
    {
        public string token { get; set; }
        public string user_email { get; set; }
        public string user_display_name { get; set; }
        public bool first_access { get; set; }
        public Login(String token, String user_email, String user_display_name)
        {
            this.token = token;
            this.user_email = user_email;
            this.user_display_name = user_display_name;
        }
    }
}
