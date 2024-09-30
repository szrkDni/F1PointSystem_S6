using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using F1Pontszamitos_S6.Shared.Models;

namespace F1Pontszamitos_S6.Shared.Utils
{
    public class UdpListener
    {
        private UdpClient _udpClient;
        private IPEndPoint _endPoint;
        private bool _isListening = false;
        private bool filled = false;

        public UdpListener(int port)
        {
            _udpClient = new UdpClient(port);
            _endPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public async Task<List<Individual>> StartListeningAsync(CancellationToken stoppingToken) //Threadsek miatt async function kell
        {
            PacketHeader header = new();

            PacketMotionData motionData = new PacketMotionData();
            CarMotionData car = new CarMotionData();

            PacketLapData packetLapData = new PacketLapData();
            LapData lapData = new LapData();

            PacketFinalClassificationData packetFinalClassificationData = new PacketFinalClassificationData();
            FinalClassificationData[] finalData = new FinalClassificationData[22];

            PacketParticipantsData participant = new PacketParticipantsData();
            ParticipantData[] participants = new ParticipantData[22];
            List<Individual> individualsToReturn = new List<Individual>();

            _isListening = true;
            Console.WriteLine("UDP Listener is Open.");

            while (_isListening && !stoppingToken.IsCancellationRequested)
            {
                //await Task.Delay(10); //Nemtudom érdmes e hasznalni erőforrás kímélés miatt

                try
                {
                    byte[] receivedBytes = _udpClient.Receive(ref _endPoint);


                    if (receivedBytes != null)
                    {
                        header = ByteArrayToStructure<PacketHeader>(receivedBytes);
                        //Console.WriteLine($"Active Packet ID: {header.m_packetId}");
                    }

                    switch (header.m_packetId)
                    {
                        case 0:
                            motionData = ByteArrayToStructure<PacketMotionData>(receivedBytes);
                            car = motionData.m_carMotionData[0];
                            break;
                        case 2:
                            packetLapData = ByteArrayToStructure<PacketLapData>(receivedBytes);
                            lapData = packetLapData.m_lapData[0];
                            break;
                        case 4:
                            participant = ByteArrayToStructure<PacketParticipantsData>(receivedBytes);
                            participants = participant.m_participants;
                            break;
                        case 8:
                            packetFinalClassificationData = ByteArrayToStructure<PacketFinalClassificationData>(receivedBytes);
                            finalData = packetFinalClassificationData.m_classificationData;

                            if (!filled && !String.IsNullOrEmpty(participants[0].GetName())) //Így csak egyszer tölti bele, ha nem lenne többszöri lefutas miatt teletölti a listát
                            {   //Kellene egy hiba küszöbölés is mert ha akkor inditod el amikor mar a verseny veget latod ugyanugy feltolti
                                // csak nevek nelkül es az nem túl előnyös
                                for (int i = 1 - 1; i < finalData.Length; i++)
                                {
                                    individualsToReturn.Add(new Individual(participants[i].GetName(), finalData[i].m_position));
                                }
                                filled = true;
                            }
                            break;
                    }

                    if (individualsToReturn.Count > 0 && !String.IsNullOrEmpty(individualsToReturn[0].Name))//null vizsgalat helyett mert azokkal valamiert belepett
                    {
                        Console.WriteLine("UDP Listener is Closed.");
                        _isListening = false;
                        return individualsToReturn;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving UDP packet: {ex.Message}");
                }
            }
            Console.WriteLine("UDP Listener is Closed.");
            return null;
        }

        public void StopListening()
        {
            _isListening = false;
            _udpClient.Close(); // Zárjuk le a kapcsolatot, ha végeztünk
        }

        protected static T ByteArrayToStructure<T>(byte[] bytes)
        {
            int size = Marshal.SizeOf(typeof(T));
            if (bytes.Length < size)
                throw new Exception("Invalid parameter");

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, ptr, size);
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {

            }
        }
    }
}

