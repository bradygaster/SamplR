using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SamplR.Services;
using Microsoft.AspNetCore.SignalR;

namespace SamplR.Hubs
{
    public class SamplerHub : Hub<IConductorClient>
    {
        private ISamplerService _samplerService;

        public SamplerHub(ISamplerService samplerService)
        {
            _samplerService = samplerService;
        }
    }
}
