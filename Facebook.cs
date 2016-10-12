using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using Facebook;
using RestSharp;
using RestSharp.Authenticators;

namespace ApiInvoker
{
    public class Facebook
    {
        public const string Scope =
            "user_about_me,user_birthday,public_profile,user_friends,email,user_relationship_details";

        private string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _token = value;
                _client.AccessToken = value;
            }
        }

        private readonly FacebookClient _client = new FacebookClient
        {
            AppId = "1760196040898671",
            AppSecret = "3c496aafa4b202935751b4490c7f53a8"
        };

        public async Task<object> GetMe()
        {
            if (Token == null)
            {
                throw new InvalidOperationException("no token");
            }
            var response = await _client.GetTaskAsync("/v2.8/me");
            var client2 = new RestClient
            {
                BaseUrl = new Uri("http://graph.facebook.com"),
                Authenticator = new HttpBasicAuthenticator(_client.AppId, Token)
            };
            var request = new RestRequest("me");
            var res = await client2.ExecuteGetTaskAsync(request);
            Debug.WriteLine(res.Content);
            return response;
        }

        public Uri LoginUrl()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = _client.AppId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
            parameters.response_type = "token";
            parameters.display = "popup";
            parameters.scope = Scope;
            return _client.GetLoginUrl(parameters);
        }
    }
}