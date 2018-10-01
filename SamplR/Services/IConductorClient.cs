using System;
namespace SamplR.Services
{
    public interface IConductorClient
    {
        void OnSamplePlayed(Sample sample);
        void IAmHardware();
    }
}
