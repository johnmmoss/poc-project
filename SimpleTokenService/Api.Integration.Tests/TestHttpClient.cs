using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTokenService.Api.Integration.Tests
{
    public class TestHttpClient
    {
        public (HttpStatusCode Status, string Content) Get(string url)
        {
            HttpResponseMessage response;
            string content = string.Empty;

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }

            if (response != null)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }

            return (response.StatusCode, content);
        }

        public (HttpStatusCode stats, dynamic responseContent) Post(string url, object requestContentObj)
        {
            dynamic responseContent = null;
            HttpResponseMessage response = null;

            var requestContentJson = JsonConvert.SerializeObject(requestContentObj);
            var requestContentBytes = System.Text.Encoding.UTF8.GetBytes(requestContentJson);

            var requestPostContent = new ByteArrayContent(requestContentBytes);
            requestPostContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var client = new HttpClient())
            {
                response = client.PostAsync(url, requestPostContent).Result;
            }

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                responseContent = JsonConvert.DeserializeObject(content);
            }

            return (response.StatusCode, responseContent);
        }
    }
}
