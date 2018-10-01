using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using RtMidi.Core;
using RtMidi.Core.Devices;
using RtMidi.Core.Enums;
using RtMidi.Core.Messages;

namespace SamplR.HardwareClient
{
    class Program
    {
        const string URL = "https://localhost:5001/samplr";
        const string EVENT = "OnSamplePlayed";
        private readonly List<IMidiOutputDevice> devices = 
            new List<IMidiOutputDevice>();

        static void Main(string[] args)
        {
            using (MidiDeviceManager.Default)
            {
                var p = new Program();
            }
        }

        public Program()
        {
            /*
            var connection = new HubConnectionBuilder()
                .WithUrl(URL)
                .Build();

            connection.On<Sample>(EVENT, (sample) =>
            {
                SendNoteOnMessage(sample.Channel);

                Console.WriteLine(
                    $"{sample.Name} played on channel {sample.Channel}");
            });

            connection.StartAsync().Wait();


            GetTheAvailableAPIs();

            SetupOutputDevices();

            Console.ReadLine();

            CloseOutputDevices();
            */
        }

        /*
        void GetTheAvailableAPIs() {
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
        */
    }

    public class Sample
    {
        public string Name { get; set; }
        public short Channel { get; set; }
        public bool IsSelectedYet { get; set; }
    }
}
