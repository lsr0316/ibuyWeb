using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    class User
    {
        public long id { get; set; }
        public string user_FirstName { get; set; }
        public string user_LastName { get; set; }
        public string  user_PhoneNumber { get; set; }
        public string user_Address { get; set; }
        public string user_Country { get; set; }
        public string user_Email { get; set; }//  username on th api
        public string user_Password { get; set; }
    }
}