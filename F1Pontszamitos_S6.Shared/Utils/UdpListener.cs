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

        public UdpListener(int port)
        {
            _udpClient = new UdpClient(port);
            _endPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public List<Individual> StartListening(CancellationToken stoppingToken)
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
            Console.WriteLine("UDP Listener started.");

            while (_isListening && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    byte[] receivedBytes = _udpClient.Receive(ref _endPoint);



                    if (receivedBytes != null)
                    {
                        header = ByteArrayToStructure<PacketHeader>(receivedBytes);
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

                            
                            for (int i = 1 - 1; i < finalData.Length; i++)
                            {
                                individualsToReturn.Add(new Individual(participants[i].GetName(), finalData[i].m_position));
                            }

                            break;
                    }

                    if (finalData is not null && participants is not null)
                    {
                        return individualsToReturn;
                    }
                           
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving UDP packet: {ex.Message}");
                }
            }
            Console.WriteLine("UDP Listener stopped.");
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
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}

