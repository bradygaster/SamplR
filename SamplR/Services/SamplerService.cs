using System;
using System.Linq;
using System.Collections.Generic;

namespace SamplR.Services
{
    public class SamplerService : ISamplerService
    {
        private List<Sample> _samples;

        public SamplerService()
        {
            Reset();
        }

        public void Reset()
        {
            _samples = new List<Sample>();
            _samples.Add(new Sample { Channel = 1, Name = "Bass Drum" });
            _samples.Add(new Sample { Channel = 2, Name = "Snare Drum" });
            _samples.Add(new Sample { Channel = 3, Name = "Closed Hi-hat" });
            _samples.Add(new Sample { Channel = 4, Name = "Open Hi-hat" });
            _samples.Add(new Sample { Channel = 5, Name = "Low Tom" });
            _samples.Add(new Sample { Channel = 6, Name = "Mid Tom" });
            _samples.Add(new Sample { Channel = 7, Name = "High tom" });
            _samples.Add(new Sample { Channel = 8, Name = "Synth Hit" });
            _samples.Add(new Sample { Channel = 9, Name = "Saxophone" });
            _samples.Add(new Sample { Channel = 10, Name = "Dubstep Pop" });
        }

        public Sample GetMySample()
        {
            if (!_samples.Any(x => x.IsSelectedYet == false)) return null;

            _samples.First(x => x.IsSelectedYet == false).IsSelectedYet = true;

            return _samples.Last(x => x.IsSelectedYet == true);
        }

        public void Play(short channel)
        {
            var sample = _samples.First(x => x.Channel == channel);
            Console.WriteLine("Playing {sample.Name} on {sample.Channel}.");
        }

        public void ReleaseSample(short channel)
        {
            _samples.First(x => x.Channel == channel).IsSelectedYet = false;
            _samples = _samples.OrderBy(x => x.Channel).ToList();
        }
    }
}
