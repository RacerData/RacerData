using System;

namespace RacerData.iRacing.Telemetry.Models
{
    public partial class Frame : IFrame
    {
        /// <summary>
        /// Seconds since session start	(s)
        /// </summary>
        public Double SessionTime
        {
            get
            {
                return GetTelemetryValue<Double>("SessionTime");
            }
        }

        /// <summary>
        /// Ticks since session start	
        /// </summary>
        public Double SessionTick
        {
            get
            {
                return GetTelemetryValue<Double>("SessionTick");
            }
        }

        /// <summary>
        /// Session number	()
        /// </summary>
        public Int32 SessionNum
        {
            get
            {
                return GetTelemetryValue<Int32>("SessionNum");
            }
        }

        /// <summary>
        /// Session state	(irsdk_SessionState)
        /// </summary>
        public Int32 SessionState
        {
            get
            {
                return GetTelemetryValue<Int32>("SessionState");
            }
        }

        /// <summary>
        /// Session ID	()
        /// </summary>
        public Int32 SessionUniqueID
        {
            get
            {
                return GetTelemetryValue<Int32>("SessionUniqueID");
            }
        }

        /// <summary>
        /// Seconds left till session ends	(s)
        /// </summary>
        public Double SessionTimeRemain
        {
            get
            {
                return GetTelemetryValue<Double>("SessionTimeRemain");
            }
        }

        /// <summary>
        /// Laps left till session ends	()
        /// </summary>
        public Int32 SessionLapsRemain
        {
            get
            {
                return GetTelemetryValue<Int32>("SessionLapsRemain");
            }
        }

        /// <summary>
        /// Driver activated flag	()
        /// </summary>
        public Boolean DriverMarker
        {
            get
            {
                return GetTelemetryValue<Boolean>("DriverMarker");
            }
        }

        /// <summary>
        /// 1=Car on track physics running with player in car	()
        /// </summary>
        public Boolean IsOnTrack
        {
            get
            {
                return GetTelemetryValue<Boolean>("IsOnTrack");
            }
        }

        /// <summary>
        /// Average frames per second	(fps)
        /// </summary>
        public Single FrameRate
        {
            get
            {
                return GetTelemetryValue<Single>("FrameRate");
            }
        }

        /// <summary>
        /// Percent of available tim bg thread took with a 1 sec avg	(%)
        /// </summary>
        public Single CpuUsageBG
        {
            get
            {
                return GetTelemetryValue<Single>("CpuUsageBG");
            }
        }

        /// <summary>
        /// Players position in race	()
        /// </summary>
        public Int32 PlayerCarPosition
        {
            get
            {
                return GetTelemetryValue<Int32>("PlayerCarPosition");
            }
        }

        /// <summary>
        /// Players class position in race	()
        /// </summary>
        public Int32 PlayerCarClassPosition
        {
            get
            {
                return GetTelemetryValue<Int32>("PlayerCarClassPosition");
            }
        }

        /// <summary>
        /// Is the player car on pit road between the cones	()
        /// </summary>
        public Boolean OnPitRoad
        {
            get
            {
                return GetTelemetryValue<Boolean>("OnPitRoad");
            }
        }

        /// <summary>
        /// Steering wheel angle	(rad)
        /// </summary>
        public Single SteeringWheelAngle
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelAngle").RadiansToDegrees();
            }
        }

        /// <summary>
        /// 0=off throttle to 1=full throttle	(%)
        /// </summary>
        public Single Throttle
        {
            get
            {
                return GetTelemetryValue<Single>("Throttle");
            }
        }

        /// <summary>
        /// 0=brake released to 1=max pedal force	(%)
        /// </summary>
        public Single Brake
        {
            get
            {
                return GetTelemetryValue<Single>("Brake");
            }
        }

        /// <summary>
        /// 0=disengaged to 1=fully engaged	(%)
        /// </summary>
        public Single Clutch
        {
            get
            {
                return GetTelemetryValue<Single>("Clutch");
            }
        }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear	()
        /// </summary>
        public Int32 Gear
        {
            get
            {
                return GetTelemetryValue<Int32>("Gear");
            }
        }

        /// <summary>
        /// Engine rpm	(revs/min)
        /// </summary>
        public Single RPM
        {
            get
            {
                return GetTelemetryValue<Single>("RPM");
            }
        }

        /// <summary>
        /// Lap count	()
        /// </summary>
        public Int32 Lap
        {
            get
            {
                return GetTelemetryValue<Int32>("Lap");
            }
        }

        /// <summary>
        /// Meters traveled from S/F this lap	(m)
        /// </summary>
        public Single LapDist
        {
            get
            {
                return GetTelemetryValue<Single>("LapDist").MetersToInches();
            }
        }

        /// <summary>
        /// Percentage distance around lap	(%)
        /// </summary>
        public Single LapDistPct
        {
            get
            {
                return GetTelemetryValue<Single>("LapDistPct");
            }
        }

        /// <summary>
        /// Players best lap number	()
        /// </summary>
        public Int32 LapBestLap
        {
            get
            {
                return GetTelemetryValue<Int32>("LapBestLap");
            }
        }

        /// <summary>
        /// Players best lap time	(s)
        /// </summary>
        public Single LapBestLapTime
        {
            get
            {
                return GetTelemetryValue<Single>("LapBestLapTime");
            }
        }

        /// <summary>
        /// Players last lap time	(s)
        /// </summary>
        public Single LapLastLapTime
        {
            get
            {
                return GetTelemetryValue<Single>("LapLastLapTime");
            }
        }

        /// <summary>
        /// Estimate of players current lap time as shown in F3 box	(s)
        /// </summary>
        public Single LapCurrentLapTime
        {
            get
            {
                return GetTelemetryValue<Single>("LapCurrentLapTime");
            }
        }

        /// <summary>
        /// Player num consecutive clean laps completed for N average	()
        /// </summary>
        public Int32 LapLasNLapSeq
        {
            get
            {
                return GetTelemetryValue<Int32>("LapLasNLapSeq");
            }
        }

        /// <summary>
        /// Player last N average lap time	(s)
        /// </summary>
        public Single LapLastNLapTime
        {
            get
            {
                return GetTelemetryValue<Single>("LapLastNLapTime");
            }
        }

        /// <summary>
        /// Player last lap in best N average lap time	()
        /// </summary>
        public Int32 LapBestNLapLap
        {
            get
            {
                return GetTelemetryValue<Int32>("LapBestNLapLap");
            }
        }

        /// <summary>
        /// Player best N average lap time	(s)
        /// </summary>
        public Single LapBestNLapTime
        {
            get
            {
                return GetTelemetryValue<Single>("LapBestNLapTime");
            }
        }

        /// <summary>
        /// Delta time for best lap	(s)
        /// </summary>
        public Single LapDeltaToBestLap
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToBestLap");
            }
        }

        /// <summary>
        /// Rate of change of delta time for best lap	(s/s)
        /// </summary>
        public Single LapDeltaToBestLap_DD
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToBestLap_DD");
            }
        }

        /// <summary>
        /// Delta time for best lap is valid	()
        /// </summary>
        public Boolean LapDeltaToBestLap_OK
        {
            get
            {
                return GetTelemetryValue<Boolean>("LapDeltaToBestLap_OK");
            }
        }

        /// <summary>
        /// Delta time for optimal lap	(s)
        /// </summary>
        public Single LapDeltaToOptimalLap
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToOptimalLap");
            }
        }

        /// <summary>
        /// Rate of change of delta time for optimal lap	(s/s)
        /// </summary>
        public Single LapDeltaToOptimalLap_DD
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToOptimalLap_DD");
            }
        }

        /// <summary>
        /// Delta time for optimal lap is valid	()
        /// </summary>
        public Boolean LapDeltaToOptimalLap_OK
        {
            get
            {
                return GetTelemetryValue<Boolean>("LapDeltaToOptimalLap_OK");
            }
        }

        /// <summary>
        /// Delta time for session best lap	(s)
        /// </summary>
        public Single LapDeltaToSessionBestLap
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionBestLap");
            }
        }

        /// <summary>
        /// Rate of change of delta time for session best lap	(s/s)
        /// </summary>
        public Single LapDeltaToSessionBestLap_DD
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionBestLap_DD");
            }
        }

        /// <summary>
        /// Delta time for session best lap is valid	()
        /// </summary>
        public Boolean LapDeltaToSessionBestLap_OK
        {
            get
            {
                return GetTelemetryValue<Boolean>("LapDeltaToSessionBestLap_OK");
            }
        }

        /// <summary>
        /// Delta time for session optimal lap	(s)
        /// </summary>
        public Single LapDeltaToSessionOptimalLap
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionOptimalLap");
            }
        }

        /// <summary>
        /// Rate of change of delta time for session optimal lap	(s/s)
        /// </summary>
        public Single LapDeltaToSessionOptimalLap_DD
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionOptimalLap_DD");
            }
        }

        /// <summary>
        /// Delta time for session optimal lap is valid	()
        /// </summary>
        public Boolean LapDeltaToSessionOptimalLap_OK
        {
            get
            {
                return GetTelemetryValue<Boolean>("LapDeltaToSessionOptimalLap_OK");
            }
        }

        /// <summary>
        /// Delta time for session last lap	(s)
        /// </summary>
        public Single LapDeltaToSessionLastlLap
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionLastlLap");
            }
        }

        /// <summary>
        /// Rate of change of delta time for session last lap	(s/s)
        /// </summary>
        public Single LapDeltaToSessionLastlLap_DD
        {
            get
            {
                return GetTelemetryValue<Single>("LapDeltaToSessionLastlLap_DD");
            }
        }

        /// <summary>
        /// Delta time for session last lap is valid	()
        /// </summary>
        public Boolean LapDeltaToSessionLastlLap_OK
        {
            get
            {
                return GetTelemetryValue<Boolean>("LapDeltaToSessionLastlLap_OK");
            }
        }

        /// <summary>
        /// Longitudinal acceleration (including gravity)	(m/s^2)
        /// </summary>
        public Single LongAccel
        {
            get
            {
                return GetTelemetryValue<Single>("LongAccel").Ms2ToG();
            }
        }

        /// <summary>
        /// Lateral acceleration (including gravity)	(m/s^2)
        /// </summary>
        public Single LatAccel
        {
            get
            {
                return GetTelemetryValue<Single>("LatAccel").Ms2ToG();
            }
        }

        /// <summary>
        /// Vertical acceleration (including gravity)	(m/s^2)
        /// </summary>
        public Single VertAccel
        {
            get
            {
                return GetTelemetryValue<Single>("VertAccel").Ms2ToG();
            }
        }

        /// <summary>
        /// Roll rate	(rad/s)
        /// </summary>
        public Single RollRate
        {
            get
            {
                return GetTelemetryValue<Single>("RollRate").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Pitch rate	(rad/s)
        /// </summary>
        public Single PitchRate
        {
            get
            {
                return GetTelemetryValue<Single>("PitchRate").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Yaw rate	(rad/s)
        /// </summary>
        public Single YawRate
        {
            get
            {
                return GetTelemetryValue<Single>("YawRate").RadiansToDegrees();
            }
        }

        /// <summary>
        /// GPS vehicle speed	(m/s)
        /// </summary>
        public Single Speed
        {
            get
            {
                return GetTelemetryValue<Single>("Speed").MetersToInches();
            }
        }

        /// <summary>
        /// X velocity	(m/s)
        /// </summary>
        public Single VelocityX
        {
            get
            {
                return GetTelemetryValue<Single>("VelocityX").MetersToInches();
            }
        }

        /// <summary>
        /// Y velocity	(m/s)
        /// </summary>
        public Single VelocityY
        {
            get
            {
                return GetTelemetryValue<Single>("VelocityY").MetersToInches();
            }
        }

        /// <summary>
        /// Z velocity	(m/s)
        /// </summary>
        public Single VelocityZ
        {
            get
            {
                return GetTelemetryValue<Single>("VelocityZ").MetersToInches();
            }
        }

        /// <summary>
        /// Yaw orientation	(rad)
        /// </summary>
        public Single Yaw
        {
            get
            {
                return GetTelemetryValue<Single>("Yaw").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Pitch orientation	(rad)
        /// </summary>
        public Single Pitch
        {
            get
            {
                return GetTelemetryValue<Single>("Pitch").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Roll orientation	(rad)
        /// </summary>
        public Single Roll
        {
            get
            {
                return GetTelemetryValue<Single>("Roll").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Indicate action the reset key will take 0 enter 1 exit 2 reset	()
        /// </summary>
        public Int32 EnterExitReset
        {
            get
            {
                return GetTelemetryValue<Int32>("EnterExitReset");
            }
        }

        /// <summary>
        /// Latitude in decimal degrees	(deg)
        /// </summary>
        public Double Lat
        {
            get
            {
                return GetTelemetryValue<Double>("Lat");
            }
        }

        /// <summary>
        /// Longitude in decimal degrees	(deg)
        /// </summary>
        public Double Lon
        {
            get
            {
                return GetTelemetryValue<Double>("Lon");
            }
        }

        /// <summary>
        /// Altitude in meters	(m)
        /// </summary>
        public Single Alt
        {
            get
            {
                return GetTelemetryValue<Single>("Alt").MetersToInches();
            }
        }

        /// <summary>
        /// Temperature of track at start/finish line	(C)
        /// </summary>
        public Single TrackTemp
        {
            get
            {
                return GetTelemetryValue<Single>("TrackTemp").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// Temperature of air at start/finish line	(C)
        /// </summary>
        public Single AirTemp
        {
            get
            {
                return GetTelemetryValue<Single>("AirTemp").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// Weather type (0=constant  1=dynamic)	()
        /// </summary>
        public Int32 WeatherType
        {
            get
            {
                return GetTelemetryValue<Int32>("WeatherType");
            }
        }

        /// <summary>
        /// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast)	()
        /// </summary>
        public Int32 Skies
        {
            get
            {
                return GetTelemetryValue<Int32>("Skies");
            }
        }

        /// <summary>
        /// Density of air at start/finish line	(kg/m^3)
        /// </summary>
        public Single AirDensity
        {
            get
            {
                return GetTelemetryValue<Single>("AirDensity");
            }
        }

        /// <summary>
        /// Pressure of air at start/finish line	(Hg)
        /// </summary>
        public Single AirPressure
        {
            get
            {
                return GetTelemetryValue<Single>("AirPressure");
            }
        }

        /// <summary>
        /// Wind velocity at start/finish line	(m/s)
        /// </summary>
        public Single WindVel
        {
            get
            {
                return GetTelemetryValue<Single>("WindVel").MetersToInches();
            }
        }

        /// <summary>
        /// Wind direction at start/finish line	(rad)
        /// </summary>
        public Single WindDir
        {
            get
            {
                return GetTelemetryValue<Single>("WindDir").RadiansToDegrees();
            }
        }

        /// <summary>
        /// Relative Humidity	(%)
        /// </summary>
        public Single RelativeHumidity
        {
            get
            {
                return GetTelemetryValue<Single>("RelativeHumidity");
            }
        }

        /// <summary>
        /// Fog level	(%)
        /// </summary>
        public Single FogLevel
        {
            get
            {
                return GetTelemetryValue<Single>("FogLevel");
            }
        }

        /// <summary>
        /// Time left for mandatory pit repairs if repairs are active	(s)
        /// </summary>
        public Single PitRepairLeft
        {
            get
            {
                return GetTelemetryValue<Single>("PitRepairLeft");
            }
        }

        /// <summary>
        /// Time left for optional repairs if repairs are active	(s)
        /// </summary>
        public Single PitOptRepairLeft
        {
            get
            {
                return GetTelemetryValue<Single>("PitOptRepairLeft");
            }
        }

        /// <summary>
        /// 1=Car on track physics running	()
        /// </summary>
        public Boolean IsOnTrackCar
        {
            get
            {
                return GetTelemetryValue<Boolean>("IsOnTrackCar");
            }
        }

        /// <summary>
        /// Output torque on steering shaft	(N*m)
        /// </summary>
        public Single SteeringWheelTorque
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelTorque").NmToFtLbs();
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft unsigned	(%)
        /// </summary>
        public Single SteeringWheelPctTorque
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelPctTorque");
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed	(%)
        /// </summary>
        public Single SteeringWheelPctTorqueSign
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelPctTorqueSign");
            }
        }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed stops	(%)
        /// </summary>
        public Single SteeringWheelPctTorqueSignStops
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelPctTorqueSignStops");
            }
        }

        /// <summary>
        /// Force feedback % max damping	(%)
        /// </summary>
        public Single SteeringWheelPctDamper
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelPctDamper");
            }
        }

        /// <summary>
        /// Steering wheel max angle	(rad)
        /// </summary>
        public Single SteeringWheelAngleMax
        {
            get
            {
                return GetTelemetryValue<Single>("SteeringWheelAngleMax").RadiansToDegrees();
            }
        }

        /// <summary>
        /// DEPRECATED use DriverCarSLBlinkRPM instead	(%)
        /// </summary>
        public Single ShiftIndicatorPct
        {
            get
            {
                return GetTelemetryValue<Single>("ShiftIndicatorPct");
            }
        }

        /// <summary>
        /// Friction torque applied to gears when shifting or grinding	(%)
        /// </summary>
        public Single ShiftPowerPct
        {
            get
            {
                return GetTelemetryValue<Single>("ShiftPowerPct");
            }
        }

        /// <summary>
        /// RPM of shifter grinding noise	(RPM)
        /// </summary>
        public Single ShiftGrindRPM
        {
            get
            {
                return GetTelemetryValue<Single>("ShiftGrindRPM");
            }
        }

        /// <summary>
        /// Raw throttle input 0=off throttle to 1=full throttle	(%)
        /// </summary>
        public Single ThrottleRaw
        {
            get
            {
                return GetTelemetryValue<Single>("ThrottleRaw");
            }
        }

        /// <summary>
        /// Raw brake input 0=brake released to 1=max pedal force	(%)
        /// </summary>
        public Single BrakeRaw
        {
            get
            {
                return GetTelemetryValue<Single>("BrakeRaw");
            }
        }

        /// <summary>
        /// Bitfield for warning lights	(irsdk_EngineWarnings)
        /// </summary>
        public irsdk_EngineWarnings EngineWarnings
        {
            get
            {
                return GetTelemetryValue<irsdk_EngineWarnings>("EngineWarnings");
            }
        }

        /// <summary>
        /// Liters of fuel remaining	(l)
        /// </summary>
        public Single FuelLevel
        {
            get
            {
                return GetTelemetryValue<Single>("FuelLevel").LiterToGallon();
            }
        }

        /// <summary>
        /// Percent fuel remaining	(%)
        /// </summary>
        public Single FuelLevelPct
        {
            get
            {
                return GetTelemetryValue<Single>("FuelLevelPct");
            }
        }

        /// <summary>
        /// Bitfield of pit service checkboxes	(irsdk_PitSvFlags)
        /// </summary>
        public irsdk_PitSvFlags PitSvFlags
        {
            get
            {
                return GetTelemetryValue<irsdk_PitSvFlags>("PitSvFlags");
            }
        }

        /// <summary>
        /// Pit service left front tire pressure	(kPa)
        /// </summary>
        public Single PitSvLFP
        {
            get
            {
                return GetTelemetryValue<Single>("PitSvLFP").kPaToPSI();
            }
        }

        /// <summary>
        /// Pit service right front tire pressure	(kPa)
        /// </summary>
        public Single PitSvRFP
        {
            get
            {
                return GetTelemetryValue<Single>("PitSvRFP").kPaToPSI();
            }
        }

        /// <summary>
        /// Pit service left rear tire pressure	(kPa)
        /// </summary>
        public Single PitSvLRP
        {
            get
            {
                return GetTelemetryValue<Single>("PitSvLRP").kPaToPSI();
            }
        }

        /// <summary>
        /// Pit service right rear tire pressure	(kPa)
        /// </summary>
        public Single PitSvRRP
        {
            get
            {
                return GetTelemetryValue<Single>("PitSvRRP").kPaToPSI();
            }
        }

        /// <summary>
        /// Pit service fuel add amount	(l)
        /// </summary>
        public Single PitSvFuel
        {
            get
            {
                return GetTelemetryValue<Single>("PitSvFuel").LiterToGallon();
            }
        }

        /// <summary>
        /// Pitstop qtape adjustment	()
        /// </summary>
        public Single dpQtape
        {
            get
            {
                return GetTelemetryValue<Single>("dpQtape");
            }
        }

        /// <summary>
        /// In car brake bias adjustment	()
        /// </summary>
        public Single dcBrakeBias
        {
            get
            {
                return GetTelemetryValue<Single>("dcBrakeBias");
            }
        }

        /// <summary>
        /// Engine coolant temp	(C)
        /// </summary>
        public Single WaterTemp
        {
            get
            {
                return GetTelemetryValue<Single>("WaterTemp").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// Engine coolant level	(l)
        /// </summary>
        public Single WaterLevel
        {
            get
            {
                return GetTelemetryValue<Single>("WaterLevel").LiterToGallon();
            }
        }

        /// <summary>
        /// Engine fuel pressure	(bar)
        /// </summary>
        public Single FuelPress
        {
            get
            {
                return GetTelemetryValue<Single>("FuelPress").BarToHg();
            }
        }

        /// <summary>
        /// Engine oil temperature	(C)
        /// </summary>
        public Single OilTemp
        {
            get
            {
                return GetTelemetryValue<Single>("OilTemp").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// Engine oil pressure	(bar)
        /// </summary>
        public Single OilPress
        {
            get
            {
                return GetTelemetryValue<Single>("OilPress").BarToHg();
            }
        }

        /// <summary>
        /// Engine oil level	(l)
        /// </summary>
        public Single OilLevel
        {
            get
            {
                return GetTelemetryValue<Single>("OilLevel").LiterToGallon();
            }
        }

        /// <summary>
        /// Engine voltage	(V)
        /// </summary>
        public Single Voltage
        {
            get
            {
                return GetTelemetryValue<Single>("Voltage");
            }
        }

        /// <summary>
        /// Engine manifold pressure	(bar)
        /// </summary>
        public Single ManifoldPress
        {
            get
            {
                return GetTelemetryValue<Single>("ManifoldPress").BarToHg();
            }
        }

        /// <summary>
        /// RR brake line pressure	(bar)
        /// </summary>
        public Single RRbrakeLinePress
        {
            get
            {
                return GetTelemetryValue<Single>("RRbrakeLinePress").BarToHg();
            }
        }

        /// <summary>
        /// RR wheel speed	(m/s)
        /// </summary>
        public Single RRspeed
        {
            get
            {
                return GetTelemetryValue<Single>("RRspeed").MetersToInches();
            }
        }

        /// <summary>
        /// RR tire pressure	(kPa)
        /// </summary>
        public Single RRpressure
        {
            get
            {
                return GetTelemetryValue<Single>("RRpressure").kPaToPSI();
            }
        }

        /// <summary>
        /// RR tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        public Single RRcoldPressure
        {
            get
            {
                return GetTelemetryValue<Single>("RRcoldPressure").kPaToPSI();
            }
        }

        /// <summary>
        /// RR tire left surface temperature	(C)
        /// </summary>
        public Single RRtempL
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire middle surface temperature	(C)
        /// </summary>
        public Single RRtempM
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire right surface temperature	(C)
        /// </summary>
        public Single RRtempR
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire left carcass temperature	(C)
        /// </summary>
        public Single RRtempCL
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempCL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire middle carcass temperature	(C)
        /// </summary>
        public Single RRtempCM
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempCM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire right carcass temperature	(C)
        /// </summary>
        public Single RRtempCR
        {
            get
            {
                return GetTelemetryValue<Single>("RRtempCR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RR tire left percent tread remaining	(%)
        /// </summary>
        public Single RRwearL
        {
            get
            {
                return GetTelemetryValue<Single>("RRwearL");
            }
        }

        /// <summary>
        /// RR tire middle percent tread remaining	(%)
        /// </summary>
        public Single RRwearM
        {
            get
            {
                return GetTelemetryValue<Single>("RRwearM");
            }
        }

        /// <summary>
        /// RR tire right percent tread remaining	(%)
        /// </summary>
        public Single RRwearR
        {
            get
            {
                return GetTelemetryValue<Single>("RRwearR");
            }
        }

        /// <summary>
        /// LR brake line pressure	(bar)
        /// </summary>
        public Single LRbrakeLinePress
        {
            get
            {
                return GetTelemetryValue<Single>("LRbrakeLinePress").BarToHg();
            }
        }

        /// <summary>
        /// LR wheel speed	(m/s)
        /// </summary>
        public Single LRspeed
        {
            get
            {
                return GetTelemetryValue<Single>("LRspeed").MetersToInches();
            }
        }

        /// <summary>
        /// LR tire pressure	(kPa)
        /// </summary>
        public Single LRpressure
        {
            get
            {
                return GetTelemetryValue<Single>("LRpressure").kPaToPSI();
            }
        }

        /// <summary>
        /// LR tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        public Single LRcoldPressure
        {
            get
            {
                return GetTelemetryValue<Single>("LRcoldPressure").kPaToPSI();
            }
        }

        /// <summary>
        /// LR tire left surface temperature	(C)
        /// </summary>
        public Single LRtempL
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire middle surface temperature	(C)
        /// </summary>
        public Single LRtempM
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire right surface temperature	(C)
        /// </summary>
        public Single LRtempR
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire left carcass temperature	(C)
        /// </summary>
        public Single LRtempCL
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempCL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire middle carcass temperature	(C)
        /// </summary>
        public Single LRtempCM
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempCM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire right carcass temperature	(C)
        /// </summary>
        public Single LRtempCR
        {
            get
            {
                return GetTelemetryValue<Single>("LRtempCR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LR tire left percent tread remaining	(%)
        /// </summary>
        public Single LRwearL
        {
            get
            {
                return GetTelemetryValue<Single>("LRwearL");
            }
        }

        /// <summary>
        /// LR tire middle percent tread remaining	(%)
        /// </summary>
        public Single LRwearM
        {
            get
            {
                return GetTelemetryValue<Single>("LRwearM");
            }
        }

        /// <summary>
        /// LR tire right percent tread remaining	(%)
        /// </summary>
        public Single LRwearR
        {
            get
            {
                return GetTelemetryValue<Single>("LRwearR");
            }
        }

        /// <summary>
        /// RF brake line pressure	(bar)
        /// </summary>
        public Single RFbrakeLinePress
        {
            get
            {
                return GetTelemetryValue<Single>("RFbrakeLinePress").BarToHg();
            }
        }

        /// <summary>
        /// RF wheel speed	(m/s)
        /// </summary>
        public Single RFspeed
        {
            get
            {
                return GetTelemetryValue<Single>("RFspeed").MetersToInches();
            }
        }

        /// <summary>
        /// RF tire pressure	(kPa)
        /// </summary>
        public Single RFpressure
        {
            get
            {
                return GetTelemetryValue<Single>("RFpressure").kPaToPSI();
            }
        }

        /// <summary>
        /// RF tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        public Single RFcoldPressure
        {
            get
            {
                return GetTelemetryValue<Single>("RFcoldPressure").kPaToPSI();
            }
        }

        /// <summary>
        /// RF tire left surface temperature	(C)
        /// </summary>
        public Single RFtempL
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire middle surface temperature	(C)
        /// </summary>
        public Single RFtempM
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire right surface temperature	(C)
        /// </summary>
        public Single RFtempR
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire left carcass temperature	(C)
        /// </summary>
        public Single RFtempCL
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempCL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire middle carcass temperature	(C)
        /// </summary>
        public Single RFtempCM
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempCM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire right carcass temperature	(C)
        /// </summary>
        public Single RFtempCR
        {
            get
            {
                return GetTelemetryValue<Single>("RFtempCR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// RF tire left percent tread remaining	(%)
        /// </summary>
        public Single RFwearL
        {
            get
            {
                return GetTelemetryValue<Single>("RFwearL");
            }
        }

        /// <summary>
        /// RF tire middle percent tread remaining	(%)
        /// </summary>
        public Single RFwearM
        {
            get
            {
                return GetTelemetryValue<Single>("RFwearM");
            }
        }

        /// <summary>
        /// RF tire right percent tread remaining	(%)
        /// </summary>
        public Single RFwearR
        {
            get
            {
                return GetTelemetryValue<Single>("RFwearR");
            }
        }

        /// <summary>
        /// LF brake line pressure	(bar)
        /// </summary>
        public Single LFbrakeLinePress
        {
            get
            {
                return GetTelemetryValue<Single>("LFbrakeLinePress").BarToHg();
            }
        }

        /// <summary>
        /// LF wheel speed	(m/s)
        /// </summary>
        public Single LFspeed
        {
            get
            {
                return GetTelemetryValue<Single>("LFspeed").MetersToInches();
            }
        }

        /// <summary>
        /// LF tire pressure	(kPa)
        /// </summary>
        public Single LFpressure
        {
            get
            {
                return GetTelemetryValue<Single>("LFpressure").kPaToPSI();
            }
        }

        /// <summary>
        /// LF tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        public Single LFcoldPressure
        {
            get
            {
                return GetTelemetryValue<Single>("LFcoldPressure").kPaToPSI();
            }
        }

        /// <summary>
        /// LF tire left surface temperature	(C)
        /// </summary>
        public Single LFtempL
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire middle surface temperature	(C)
        /// </summary>
        public Single LFtempM
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire right surface temperature	(C)
        /// </summary>
        public Single LFtempR
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire left carcass temperature	(C)
        /// </summary>
        public Single LFtempCL
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempCL").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire middle carcass temperature	(C)
        /// </summary>
        public Single LFtempCM
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempCM").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire right carcass temperature	(C)
        /// </summary>
        public Single LFtempCR
        {
            get
            {
                return GetTelemetryValue<Single>("LFtempCR").CelciusToFarenheit();
            }
        }

        /// <summary>
        /// LF tire left percent tread remaining	(%)
        /// </summary>
        public Single LFwearL
        {
            get
            {
                return GetTelemetryValue<Single>("LFwearL");
            }
        }

        /// <summary>
        /// LF tire middle percent tread remaining	(%)
        /// </summary>
        public Single LFwearM
        {
            get
            {
                return GetTelemetryValue<Single>("LFwearM");
            }
        }

        /// <summary>
        /// LF tire right percent tread remaining	(%)
        /// </summary>
        public Single LFwearR
        {
            get
            {
                return GetTelemetryValue<Single>("LFwearR");
            }
        }

        /// <summary>
        /// RR shock deflection	(m)
        /// </summary>
        public Single RRshockDefl
        {
            get
            {
                return GetTelemetryValue<Single>("RRshockDefl").MetersToInches();
            }
        }

        /// <summary>
        /// RR shock velocity	(m/s)
        /// </summary>
        public Single RRshockVel
        {
            get
            {
                return GetTelemetryValue<Single>("RRshockVel").MetersToInches();
            }
        }

        /// <summary>
        /// LR shock deflection	(m)
        /// </summary>
        public Single LRshockDefl
        {
            get
            {
                return GetTelemetryValue<Single>("LRshockDefl").MetersToInches();
            }
        }

        /// <summary>
        /// LR shock velocity	(m/s)
        /// </summary>
        public Single LRshockVel
        {
            get
            {
                return GetTelemetryValue<Single>("LRshockVel").MetersToInches();
            }
        }

        /// <summary>
        /// RF shock deflection	(m)
        /// </summary>
        public Single RFshockDefl
        {
            get
            {
                return GetTelemetryValue<Single>("RFshockDefl").MetersToInches();
            }
        }

        /// <summary>
        /// RF shock velocity	(m/s)
        /// </summary>
        public Single RFshockVel
        {
            get
            {
                return GetTelemetryValue<Single>("RFshockVel").MetersToInches();
            }
        }

        /// <summary>
        /// LF shock deflection	(m)
        /// </summary>
        public Single LFshockDefl
        {
            get
            {
                return GetTelemetryValue<Single>("LFshockDefl").MetersToInches();
            }
        }

        /// <summary>
        /// LF shock velocity	(m/s)
        /// </summary>
        public Single LFshockVel
        {
            get
            {
                return GetTelemetryValue<Single>("LFshockVel").MetersToInches();
            }
        }

        /// <summary>
        /// LF ride height	(m)
        /// </summary>
        public Single LFrideHeight
        {
            get
            {
                return GetTelemetryValue<Single>("LFrideHeight").MetersToInches();
            }
        }

        /// <summary>
        /// RF ride height	(m)
        /// </summary>
        public Single RFrideHeight
        {
            get
            {
                return GetTelemetryValue<Single>("RFrideHeight").MetersToInches();
            }
        }

        /// <summary>
        /// LR ride height	(m)
        /// </summary>
        public Single LRrideHeight
        {
            get
            {
                return GetTelemetryValue<Single>("LRrideHeight").MetersToInches();
            }
        }

        /// <summary>
        /// RR ride height	(m)
        /// </summary>
        public Single RRrideHeight
        {
            get
            {
                return GetTelemetryValue<Single>("RRrideHeight").MetersToInches();
            }
        }

    }
}
