using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SamplR.Models;
using SamplR.Services;

namespace SamplR.Hubs
{
    public class SamplerHub : Hub<IConductorClient>
    {
        public async Task GetSamples()
        {
            var samples = new Sample[] {
                new Sample { Channel = 1, Name = "Bass Drop" },
                new Sample { Channel = 2, Name = "Bass Drum" },
                new Sample { Channel = 3, Name = "Snare Drum" },
                new Sample { Channel = 4, Name = "Hand Clap" },
                new Sample { Channel = 5, Name = "Cowbel" },
                new Sample { Channel = 6, Name = "Yeah" },
                new Sample { Channel = 7, Name = "Hey" },
                new Sample { Channel = 8, Name = "Wah Guitar" },
                new Sample { Channel = 9, Name = "Closed Hi-hat" },
                new Sample { Channel = 10, Name = "Open Hi-hat" }
            };
            
            await Clients.Caller.SamplesLoaded(samples);
        }

        public async Task Play(int channel)
        {
            await Clients.Others.OnSamplePlayed(channel);
        }
    }
}
