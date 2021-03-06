﻿using System;
using System.Text;
using RestSharp;
using Ngauge.Caching;

namespace Model
{
    public class FeedService
    {
        private readonly RestClient _client;

        public FeedService()
        {
            _client = new RestClient("http://www.360voice.com");
        }

        public bool GamerExists(string gamertag)
        {
            if (string.IsNullOrWhiteSpace(gamertag))
            {
                return false;
            }

            var request = new RestRequest("api/gamertag-exists.asp");
            request.AddParameter("tag", gamertag);
            var x = _client.Execute<GamerTagExists>(request);
            return Convert.ToBoolean(x.Data.Gamertag);
        }

        public GamesPlayed GamesPlayed(string gamertag)
        {
            if (!GamerExists(gamertag))
            {
                throw new Exception("Gamertag is not valid");
            }                                    
            var request = new RestRequest("api/games-listfav.asp");
            request.AddParameter("tag", gamertag);            

            Func<RestResponse<GamesPlayed>> execute = () => _client.Execute<GamesPlayed>(request);

            var output = Execute(request, execute);
            return output.Data;
        }

        private RestResponse<T> Execute<T>(IRestRequest request, Func<RestResponse<T>> func) where T : class
        {
            var sb = new StringBuilder();
            sb.Append(_client.BaseUrl);
            sb.Append(request.Resource);
            foreach (var parm in request.Parameters)
            {
                sb.Append(parm.Name);
                sb.Append(parm.Value);
            }

            var cache = new MemoryCacheProvider();
            return cache.GetOrExecuteAndAdd(sb.ToString(), func);
        }
    }
}
