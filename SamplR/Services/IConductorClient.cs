using System;
using System.Threading.Tasks;
using SamplR.Models;

namespace SamplR.Services
{
    public interface IConductorClient
    {
        Task OnSamplePlayed(int sample);
        Task IAmHardware();
        Task SamplesLoaded(Sample[] samples);
    }
}
