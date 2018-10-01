using System;
namespace SamplR.Services
{
    public class Sample
    {
        public string Name { get; set; }
        public short Channel { get; set; }
        public bool IsSelectedYet { get; set; }
    }

    public interface ISamplerService
    {
        Sample GetMySample();
        void ReleaseSample(short Channel);
        void Play(short Channel);
        void Reset();
    }
}
