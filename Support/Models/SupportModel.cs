using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;

namespace Support.Models
{
    public class SupportModel
    {
        public async Task<string> retrieveSupportStringForId(int id)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "WtyRxZxUb94IPMpd0ho9VlCdvpTDz7yO7dGCY42F",
                BasePath = "https://globaltechsupport.firebaseio.com/"
            };

            FirebaseClient firebase = new FirebaseClient(config);
            string url = "https://globaltechsupport.firebaseio.com/" + id;
            FirebaseResponse response = await firebase.GetAsync(id.ToString());
            return response.ResultAs<string>();
        }
    }
}