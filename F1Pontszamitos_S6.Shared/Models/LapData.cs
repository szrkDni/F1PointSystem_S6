using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//ID 2

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LapData
{
    public UInt32 m_lastLapTimeInMS;	       	 // Last lap time in milliseconds
    public UInt32 m_currentLapTimeInMS; 	 // Current time around the lap in milliseconds
    public UInt16 m_sector1TimeMSPart;         // Sector 1 time milliseconds part
    public byte m_sector1TimeMinutesPart;    // Sector 1 whole minute part
    public UInt16 m_sector2TimeMSPart;         // Sector 2 time milliseconds part
    public byte m_sector2TimeMinutesPart;    // Sector 2 whole minute part
    public UInt16 m_deltaToCarInFrontMSPart;   // Time delta to car in front milliseconds part
    public byte m_deltaToCarInFrontMinutesPart; // Time delta to car in front whole minute part
    public UInt16 m_deltaToRaceLeaderMSPart;      // Time delta to race leader milliseconds part
    public byte m_deltaToRaceLeaderMinutesPart; // Time delta to race leader whole minute part
    public float m_lapDistance;         // Distance vehicle is around current lap in metres – could
                                        // be negative if line hasn’t been crossed yet
    public float m_totalDistance;       // Total distance travelled in session in metres – could
                                        // be negative if line hasn’t been crossed yet
    public float m_safetyCarDelta;            // Delta in seconds for safety car
    public byte m_carPosition;   	         // Car race position
    public byte m_currentLapNum;		 // Current lap number
    public byte m_pitStatus;            	 // 0 = none, 1 = pitting, 2 = in pit area
    public byte m_numPitStops;            	 // Number of pit stops taken in this race
    public byte m_sector;               	 // 0 = sector1, 1 = sector2, 2 = sector3
    public byte m_currentLapInvalid;    	 // Current lap invalid - 0 = valid, 1 = invalid
    public byte m_penalties;            	 // Accumulated time penalties in seconds to be added
    public byte m_totalWarnings;             // Accumulated number of warnings issued
    public byte m_cornerCuttingWarnings;     // Accumulated number of corner cutting warnings issued
    public byte m_numUnservedDriveThroughPens;  // Num drive through pens left to serve
    public byte m_numUnservedStopGoPens;        // Num stop go pens left to serve
    public byte m_gridPosition;         	 // Grid position the vehicle started the race in
    public byte m_driverStatus;            // Status of driver - 0 = in garage, 1 = flying lap
                                           // 2 = in lap, 3 = out lap, 4 = on track
    public byte m_resultStatus;              // Result status - 0 = invalid, 1 = inactive, 2 = active
                                             // 3 = finished, 4 = didnotfinish, 5 = disqualified
                                             // 6 = not classified, 7 = retired
    public byte m_pitLaneTimerActive;     	 // Pit lane timing, 0 = inactive, 1 = active
    public UInt16 m_pitLaneTimeInLaneInMS;   	 // If active, the current time spent in the pit lane in ms
    public UInt16 m_pitStopTimerInMS;        	 // Time of the actual pit stop in ms
    public byte m_pitStopShouldServePen;   	 // Whether the car should serve a penalty at this stop
    public float m_speedTrapFastestSpeed;     // Fastest speed through speed trap for this car in kmph
    public byte m_speedTrapFastestLap;       // Lap no the fastest speed was achieved, 255 = not set

    public readonly void WriteAllToConsole()
    {
        Console.WriteLine($"Last Lap Time (in MS): {m_lastLapTimeInMS}");
        Console.WriteLine($"Current Lap Time (in MS): {m_currentLapTimeInMS}");
        Console.WriteLine($"Sector 1 Time (Milliseconds Part): {m_sector1TimeMSPart}");
        Console.WriteLine($"Sector 1 Time (Minutes Part): {m_sector1TimeMinutesPart}");
        Console.WriteLine($"Sector 2 Time (Milliseconds Part): {m_sector2TimeMSPart}");
        Console.WriteLine($"Sector 2 Time (Minutes Part): {m_sector2TimeMinutesPart}");
        Console.WriteLine($"Delta to Car in Front (Milliseconds Part): {m_deltaToCarInFrontMSPart}");
        Console.WriteLine($"Delta to Car in Front (Minutes Part): {m_deltaToCarInFrontMinutesPart}");
        Console.WriteLine($"Delta to Race Leader (Milliseconds Part): {m_deltaToRaceLeaderMSPart}");
        Console.WriteLine($"Delta to Race Leader (Minutes Part): {m_deltaToRaceLeaderMinutesPart}");
        Console.WriteLine($"Lap Distance: {m_lapDistance}");
        Console.WriteLine($"Total Distance: {m_totalDistance}");
        Console.WriteLine($"Safety Car Delta: {m_safetyCarDelta}");
        Console.WriteLine($"Car Position: {m_carPosition}");
        Console.WriteLine($"Current Lap Number: {m_currentLapNum}");
        Console.WriteLine($"Pit Status: {m_pitStatus}");
        Console.WriteLine($"Number of Pit Stops: {m_numPitStops}");
        Console.WriteLine($"Sector: {m_sector}");
        Console.WriteLine($"Current Lap Invalid: {m_currentLapInvalid}");
        Console.WriteLine($"Penalties: {m_penalties}");
        Console.WriteLine($"Total Warnings: {m_totalWarnings}");
        Console.WriteLine($"Corner Cutting Warnings: {m_cornerCuttingWarnings}");
        Console.WriteLine($"Unserved Drive Through Penalties: {m_numUnservedDriveThroughPens}");
        Console.WriteLine($"Unserved Stop Go Penalties: {m_numUnservedStopGoPens}");
        Console.WriteLine($"Grid Position: {m_gridPosition}");
        Console.WriteLine($"Driver Status: {m_driverStatus}");
        Console.WriteLine($"Result Status: {m_resultStatus}");
        Console.WriteLine($"Pit Lane Timer Active: {m_pitLaneTimerActive}");
        Console.WriteLine($"Pit Lane Time in Lane (in MS): {m_pitLaneTimeInLaneInMS}");
        Console.WriteLine($"Pit Stop Timer (in MS): {m_pitStopTimerInMS}");
        Console.WriteLine($"Pit Stop Should Serve Penalty: {m_pitStopShouldServePen}");
        Console.WriteLine($"Speed Trap Fastest Speed: {m_speedTrapFastestSpeed}");
        Console.WriteLine($"Speed Trap Fastest Lap: {m_speedTrapFastestLap}");
    }
};
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketLapData
{
    public PacketHeader m_header;              // Header
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public LapData[] m_lapData;       // Lap data for all cars on track

    public byte m_timeTrialPBCarIdx; 	// Index of Personal Best car in time trial (255 if invalid)
    public byte m_timeTrialRivalCarIdx;     // Index of Rival car in time trial (255 if invalid)


};
