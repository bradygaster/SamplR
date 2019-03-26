using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using RtMidi.Core;
using RtMidi.Core.Devices;
using RtMidi.Core.Enums;
using RtMidi.Core.Messages;

namespace SamplR.HardwareClient
{
    public class Program
    {
        const string URL = "https://localhost:5001/samplr";
        private readonly List<IMidiOutputDevice> devices =
            new List<IMidiOutputDevice>();
            
        static void Main(string[] args)
        {
            using (MidiDeviceManager.Default)
            {
                var p = new Program();
                p.ConnectToHub().Wait();

                p.GetTheAvailableAPIs();
                p.SetupOutputDevices();

                Console.ReadLine();
                p.CloseOutputDevices();
            }
        }

        async Task ConnectToHub()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl(URL)
                .Build();

            connection.On<short>("OnSamplePlayed", (channel) =>
            {
                SendNoteOnMessage(channel);
            });

            await connection.StartAsync();
        }

        void GetTheAvailableAPIs()
        {
            var t = MidiDeviceManager.Default;
            foreach (var api in MidiDeviceManager.Default.GetAvailableMidiApis())
                Console.WriteLine($"Available API: {api}");
        }

        void SetupOutputDevices()
        {
            foreach (var outputDeviceInfo in MidiDeviceManager.Default.OutputDevices)
            {
                Console.WriteLine($"Opening {outputDeviceInfo.Name}");

                var outputDevice = outputDeviceInfo.CreateDevice();
                devices.Add(outputDevice);
                outputDevice.Open();
            }
        }

        void SendNoteOnMessage(short channel)
        {
            Channel midiChannel = Channel.Channel1;

            switch (channel)
            {
                case 1:
                    midiChannel = Channel.Channel1;
                    break;
                case 2:
                    midiChannel = Channel.Channel2;
                    break;
                case 3:
                    midiChannel = Channel.Channel3;
                    break;
                case 4:
                    midiChannel = Channel.Channel4;
                    break;
                case 5:
                    midiChannel = Channel.Channel5;
                    break;
                case 6:
                    midiChannel = Channel.Channel6;
                    break;
                case 7:
                    midiChannel = Channel.Channel7;
                    break;
                case 8:
                    midiChannel = Channel.Channel8;
                    break;
                case 9:
                    midiChannel = Channel.Channel9;
                    break;
                case 10:
                    midiChannel = Channel.Channel10;
                    break;
            }

            if (devices.Count > 0)
                devices[0].Send(
                    new NoteOnMessage(midiChannel, Key.Key64, 127)
                );
        }

        void CloseOutputDevices()
        {
            foreach (var device in devices)
            {
                device.Dispose();
            }
        }
    }
}
