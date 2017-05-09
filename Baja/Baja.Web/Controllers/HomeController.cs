//using TweetSharp;
using System.Web.Mvc;
using System;

namespace Baja.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult TwitterCallback(string oauth_token, string oauth_verifier)
        //{
        //    var requestToken = new OAuthRequestToken { Token = oauth_token };

        //    string key = "W7nisP4ZK14FeeTu5sn5Q9z3c";
        //    string secret = "F2kQSgBgFceir7B3UD0RODZSOvi7QDUdyU1quHh664cbxXhB9T";

        //    try
        //    {
        //        TwitterService service = new TwitterService(key, secret);
        //        OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);
        //        service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
        //        VerifyCredentialsOptions option = new VerifyCredentialsOptions();

        //        TwitterUser user = service.VerifyCredentials(option);
        //        TempData["Name"] = user.Name;
        //        TempData["userpic"] = user.ProfileImageUrl;
        //        return View();

        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //}


        //public ActionResult TwitterAuth()
        //{
        //    string key = "W7nisP4ZK14FeeTu5sn5Q9z3c";
        //    string secret = "F2kQSgBgFceir7B3UD0RODZSOvi7QDUdyU1quHh664cbxXhB9T";
        //    TwitterService service = new TwitterService(key, secret);
        //    OAuthRequestToken requestToken = service.GetRequestToken("http://localhost:55873/Home/TwitterCallback");
        //    Uri uri = service.GetAuthenticationUrl(requestToken);
        //    return Redirect(uri.ToString());

        //}
    }
}