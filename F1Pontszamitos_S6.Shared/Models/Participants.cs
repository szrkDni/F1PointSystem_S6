using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//ID 4

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ParticipantData
{
    byte m_aiControlled;      // Whether the vehicle is AI (1) or Human (0) controlled
    public byte m_driverId;	   // Driver id - see appendix, 255 if network human
    byte m_networkId;	   // Network id – unique identifier for network players
    byte m_teamId;            // Team id - see appendix
    byte m_myTeam;            // My team flag – 1 = My Team, 0 = otherwise
    byte m_raceNumber;        // Race number of the car
    byte m_nationality;         // Nationality of the driver

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    byte[] m_name;          // Name of participant in UTF-8 format – null terminated
                              // Will be truncated with … (U+2026) if too long
    byte m_yourTelemetry;     // The player's UDP setting, 0 = restricted, 1 = public
    byte m_showOnlineNames;   // The player's show online names setting, 0 = off, 1 = on
    UInt16 m_techLevel;         // F1 World tech level    
    byte m_platform;          // 1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = unknown

    public void ConsoleWrite() //Teszteléshez
    {
        Console.WriteLine("AI Controlled: {0}", m_aiControlled);
        Console.WriteLine("Driver ID: {0}", m_driverId);
        Console.WriteLine("Network ID: {0}", m_networkId);
        Console.WriteLine("Team ID: {0}", m_teamId);
        Console.WriteLine("My Team: {0}", m_myTeam);
        Console.WriteLine("Race Number: {0}", m_raceNumber);
        Console.WriteLine("Nationality: {0}", m_nationality);
        //Console.WriteLine("Name: {0}", new string(m_name));
        Console.WriteLine("Your Telemetry: {0}", m_yourTelemetry);
        Console.WriteLine("Show Online Names: {0}", m_showOnlineNames);
        Console.WriteLine("Tech Level: {0}", m_techLevel);
        Console.WriteLine("Platform: {0}", m_platform);
    }
    public override string ToString()
    {
        /*return string.Format("---------------------------------------------\n" +
                                 "AI Controlled: {0}\n" +
                                 "Driver ID: {1}\n" +
                                 "Network ID: {2}\n" +
                                 "Team ID: {3}\n" +
                                 "My Team: {4}\n" +
                                 "Race Number: {5}\n" +
                                 "Nationality: {6}\n" +
                                 "Name: {7}\n" +
                                 "Your Telemetry: {8}\n" +
                                 "Show Online Names: {9}\n" +
                                 "Tech Level: {10}\n" +
                                 "Platform: {11}",
                                 m_aiControlled,
                                 m_driverId,
                                 m_networkId,
                                 m_teamId,
                                 m_myTeam,
                                 m_raceNumber,
                                 m_nationality,
                                 new string(m_name),
                                 m_yourTelemetry,
                                 m_showOnlineNames,
                                 m_techLevel,
                                 m_platform);*/

        return null;
    }

    public string GetName()
    {
        string correctName = Encoding.UTF8.GetString(m_name);

        return correctName;
    }
    //public void WriteName()
    //{
    //    //Console.Write("Name: " + new string(m_name) + " - ");
    //    if (m_name != null)
    //    {
    //        Console.Write("Name: ");
    //        foreach (var item in m_name)
    //        {
    //            Console.Write(item);
    //        }
    //        Console.Write(" - ");
    //    }

    //}
}



[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketParticipantsData
{
    public PacketHeader m_header;            // Header

    public byte m_numActiveCars;  // Number of active cars in the data – should match number of
                            // cars on HUD
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ParticipantData[] m_participants;
};
