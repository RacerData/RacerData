using System;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface IFrame
    {
        T GetTelemetryValue<T>(string key);

        /// <summary>
        /// Seconds since session start	(s)
        /// </summary>
        Double SessionTime { get; }

        /// <summary>
        /// Session number	()
        /// </summary>
        Int32 SessionNum { get; }

        /// <summary>
        /// Session state	(irsdk_SessionState)
        /// </summary>
        Int32 SessionState { get; }

        /// <summary>
        /// Session ID	()
        /// </summary>
        Int32 SessionUniqueID { get; }

        /// <summary>
        /// Seconds left till session ends	(s)
        /// </summary>
        Double SessionTimeRemain { get; }

        /// <summary>
        /// Laps left till session ends	()
        /// </summary>
        Int32 SessionLapsRemain { get; }

        /// <summary>
        /// Driver activated flag	()
        /// </summary>
        Boolean DriverMarker { get; }

        /// <summary>
        /// 1=Car on track physics running with player in car	()
        /// </summary>
        Boolean IsOnTrack { get; }

        /// <summary>
        /// Average frames per second	(fps)
        /// </summary>
        Single FrameRate { get; }

        /// <summary>
        /// Percent of available tim bg thread took with a 1 sec avg	(%)
        /// </summary>
        Single CpuUsageBG { get; }

        /// <summary>
        /// Players position in race	()
        /// </summary>
        Int32 PlayerCarPosition { get; }

        /// <summary>
        /// Players class position in race	()
        /// </summary>
        Int32 PlayerCarClassPosition { get; }

        /// <summary>
        /// Is the player car on pit road between the cones	()
        /// </summary>
        Boolean OnPitRoad { get; }

        /// <summary>
        /// Steering wheel angle	(rad)
        /// </summary>
        Single SteeringWheelAngle { get; }

        /// <summary>
        /// 0=off throttle to 1=full throttle	(%)
        /// </summary>
        Single Throttle { get; }

        /// <summary>
        /// 0=brake released to 1=max pedal force	(%)
        /// </summary>
        Single Brake { get; }

        /// <summary>
        /// 0=disengaged to 1=fully engaged	(%)
        /// </summary>
        Single Clutch { get; }

        /// <summary>
        /// -1=reverse  0=neutral  1..n=current gear	()
        /// </summary>
        Int32 Gear { get; }

        /// <summary>
        /// Engine rpm	(revs/min)
        /// </summary>
        Single RPM { get; }

        /// <summary>
        /// Lap count	()
        /// </summary>
        Int32 Lap { get; }

        /// <summary>
        /// Meters traveled from S/F this lap	(m)
        /// </summary>
        Single LapDist { get; }

        /// <summary>
        /// Percentage distance around lap	(%)
        /// </summary>
        Single LapDistPct { get; }

        /// <summary>
        /// Players best lap number	()
        /// </summary>
        Int32 LapBestLap { get; }

        /// <summary>
        /// Players best lap time	(s)
        /// </summary>
        Single LapBestLapTime { get; }

        /// <summary>
        /// Players last lap time	(s)
        /// </summary>
        Single LapLastLapTime { get; }

        /// <summary>
        /// Estimate of players current lap time as shown in F3 box	(s)
        /// </summary>
        Single LapCurrentLapTime { get; }

        /// <summary>
        /// Player num consecutive clean laps completed for N average	()
        /// </summary>
        Int32 LapLasNLapSeq { get; }

        /// <summary>
        /// Player last N average lap time	(s)
        /// </summary>
        Single LapLastNLapTime { get; }

        /// <summary>
        /// Player last lap in best N average lap time	()
        /// </summary>
        Int32 LapBestNLapLap { get; }

        /// <summary>
        /// Player best N average lap time	(s)
        /// </summary>
        Single LapBestNLapTime { get; }

        /// <summary>
        /// Delta time for best lap	(s)
        /// </summary>
        Single LapDeltaToBestLap { get; }

        /// <summary>
        /// Rate of change of delta time for best lap	(s/s)
        /// </summary>
        Single LapDeltaToBestLap_DD { get; }

        /// <summary>
        /// Delta time for best lap is valid	()
        /// </summary>
        Boolean LapDeltaToBestLap_OK { get; }

        /// <summary>
        /// Delta time for optimal lap	(s)
        /// </summary>
        Single LapDeltaToOptimalLap { get; }

        /// <summary>
        /// Rate of change of delta time for optimal lap	(s/s)
        /// </summary>
        Single LapDeltaToOptimalLap_DD { get; }

        /// <summary>
        /// Delta time for optimal lap is valid	()
        /// </summary>
        Boolean LapDeltaToOptimalLap_OK { get; }

        /// <summary>
        /// Delta time for session best lap	(s)
        /// </summary>
        Single LapDeltaToSessionBestLap { get; }

        /// <summary>
        /// Rate of change of delta time for session best lap	(s/s)
        /// </summary>
        Single LapDeltaToSessionBestLap_DD { get; }

        /// <summary>
        /// Delta time for session best lap is valid	()
        /// </summary>
        Boolean LapDeltaToSessionBestLap_OK { get; }

        /// <summary>
        /// Delta time for session optimal lap	(s)
        /// </summary>
        Single LapDeltaToSessionOptimalLap { get; }

        /// <summary>
        /// Rate of change of delta time for session optimal lap	(s/s)
        /// </summary>
        Single LapDeltaToSessionOptimalLap_DD { get; }

        /// <summary>
        /// Delta time for session optimal lap is valid	()
        /// </summary>
        Boolean LapDeltaToSessionOptimalLap_OK { get; }

        /// <summary>
        /// Delta time for session last lap	(s)
        /// </summary>
        Single LapDeltaToSessionLastlLap { get; }

        /// <summary>
        /// Rate of change of delta time for session last lap	(s/s)
        /// </summary>
        Single LapDeltaToSessionLastlLap_DD { get; }

        /// <summary>
        /// Delta time for session last lap is valid	()
        /// </summary>
        Boolean LapDeltaToSessionLastlLap_OK { get; }

        /// <summary>
        /// Longitudinal acceleration (including gravity)	(m/s^2)
        /// </summary>
        Single LongAccel { get; }

        /// <summary>
        /// Lateral acceleration (including gravity)	(m/s^2)
        /// </summary>
        Single LatAccel { get; }

        /// <summary>
        /// Vertical acceleration (including gravity)	(m/s^2)
        /// </summary>
        Single VertAccel { get; }

        /// <summary>
        /// Roll rate	(rad/s)
        /// </summary>
        Single RollRate { get; }

        /// <summary>
        /// Pitch rate	(rad/s)
        /// </summary>
        Single PitchRate { get; }

        /// <summary>
        /// Yaw rate	(rad/s)
        /// </summary>
        Single YawRate { get; }

        /// <summary>
        /// GPS vehicle speed	(m/s)
        /// </summary>
        Single Speed { get; }

        /// <summary>
        /// X velocity	(m/s)
        /// </summary>
        Single VelocityX { get; }

        /// <summary>
        /// Y velocity	(m/s)
        /// </summary>
        Single VelocityY { get; }

        /// <summary>
        /// Z velocity	(m/s)
        /// </summary>
        Single VelocityZ { get; }

        /// <summary>
        /// Yaw orientation	(rad)
        /// </summary>
        Single Yaw { get; }

        /// <summary>
        /// Pitch orientation	(rad)
        /// </summary>
        Single Pitch { get; }

        /// <summary>
        /// Roll orientation	(rad)
        /// </summary>
        Single Roll { get; }

        /// <summary>
        /// Indicate action the reset key will take 0 enter 1 exit 2 reset	()
        /// </summary>
        Int32 EnterExitReset { get; }

        /// <summary>
        /// Latitude in decimal degrees	(deg)
        /// </summary>
        Double Lat { get; }

        /// <summary>
        /// Longitude in decimal degrees	(deg)
        /// </summary>
        Double Lon { get; }

        /// <summary>
        /// Altitude in meters	(m)
        /// </summary>
        Single Alt { get; }

        /// <summary>
        /// Temperature of track at start/finish line	(C)
        /// </summary>
        Single TrackTemp { get; }

        /// <summary>
        /// Temperature of air at start/finish line	(C)
        /// </summary>
        Single AirTemp { get; }

        /// <summary>
        /// Weather type (0=constant  1=dynamic)	()
        /// </summary>
        Int32 WeatherType { get; }

        /// <summary>
        /// Skies (0=clear/1=p cloudy/2=m cloudy/3=overcast)	()
        /// </summary>
        Int32 Skies { get; }

        /// <summary>
        /// Density of air at start/finish line	(kg/m^3)
        /// </summary>
        Single AirDensity { get; }

        /// <summary>
        /// Pressure of air at start/finish line	(Hg)
        /// </summary>
        Single AirPressure { get; }

        /// <summary>
        /// Wind velocity at start/finish line	(m/s)
        /// </summary>
        Single WindVel { get; }

        /// <summary>
        /// Wind direction at start/finish line	(rad)
        /// </summary>
        Single WindDir { get; }

        /// <summary>
        /// Relative Humidity	(%)
        /// </summary>
        Single RelativeHumidity { get; }

        /// <summary>
        /// Fog level	(%)
        /// </summary>
        Single FogLevel { get; }

        /// <summary>
        /// Time left for mandatory pit repairs if repairs are active	(s)
        /// </summary>
        Single PitRepairLeft { get; }

        /// <summary>
        /// Time left for optional repairs if repairs are active	(s)
        /// </summary>
        Single PitOptRepairLeft { get; }

        /// <summary>
        /// 1=Car on track physics running	()
        /// </summary>
        Boolean IsOnTrackCar { get; }

        /// <summary>
        /// Output torque on steering shaft	(N*m)
        /// </summary>
        Single SteeringWheelTorque { get; }

        /// <summary>
        /// Force feedback % max torque on steering shaft unsigned	(%)
        /// </summary>
        Single SteeringWheelPctTorque { get; }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed	(%)
        /// </summary>
        Single SteeringWheelPctTorqueSign { get; }

        /// <summary>
        /// Force feedback % max torque on steering shaft signed stops	(%)
        /// </summary>
        Single SteeringWheelPctTorqueSignStops { get; }

        /// <summary>
        /// Force feedback % max damping	(%)
        /// </summary>
        Single SteeringWheelPctDamper { get; }

        /// <summary>
        /// Steering wheel max angle	(rad)
        /// </summary>
        Single SteeringWheelAngleMax { get; }

        /// <summary>
        /// DEPRECATED use DriverCarSLBlinkRPM instead	(%)
        /// </summary>
        Single ShiftIndicatorPct { get; }

        /// <summary>
        /// Friction torque applied to gears when shifting or grinding	(%)
        /// </summary>
        Single ShiftPowerPct { get; }

        /// <summary>
        /// RPM of shifter grinding noise	(RPM)
        /// </summary>
        Single ShiftGrindRPM { get; }

        /// <summary>
        /// Raw throttle input 0=off throttle to 1=full throttle	(%)
        /// </summary>
        Single ThrottleRaw { get; }

        /// <summary>
        /// Raw brake input 0=brake released to 1=max pedal force	(%)
        /// </summary>
        Single BrakeRaw { get; }

        /// <summary>
        /// Bitfield for warning lights	(irsdk_EngineWarnings)
        /// </summary>
        irsdk_EngineWarnings EngineWarnings { get; }

        /// <summary>
        /// Liters of fuel remaining	(l)
        /// </summary>
        Single FuelLevel { get; }

        /// <summary>
        /// Percent fuel remaining	(%)
        /// </summary>
        Single FuelLevelPct { get; }

        /// <summary>
        /// Bitfield of pit service checkboxes	(irsdk_PitSvFlags)
        /// </summary>
        irsdk_PitSvFlags PitSvFlags { get; }

        /// <summary>
        /// Pit service left front tire pressure	(kPa)
        /// </summary>
        Single PitSvLFP { get; }

        /// <summary>
        /// Pit service right front tire pressure	(kPa)
        /// </summary>
        Single PitSvRFP { get; }

        /// <summary>
        /// Pit service left rear tire pressure	(kPa)
        /// </summary>
        Single PitSvLRP { get; }

        /// <summary>
        /// Pit service right rear tire pressure	(kPa)
        /// </summary>
        Single PitSvRRP { get; }

        /// <summary>
        /// Pit service fuel add amount	(l)
        /// </summary>
        Single PitSvFuel { get; }

        /// <summary>
        /// Pitstop qtape adjustment	()
        /// </summary>
        Single dpQtape { get; }

        /// <summary>
        /// In car brake bias adjustment	()
        /// </summary>
        Single dcBrakeBias { get; }

        /// <summary>
        /// Engine coolant temp	(C)
        /// </summary>
        Single WaterTemp { get; }

        /// <summary>
        /// Engine coolant level	(l)
        /// </summary>
        Single WaterLevel { get; }

        /// <summary>
        /// Engine fuel pressure	(bar)
        /// </summary>
        Single FuelPress { get; }

        /// <summary>
        /// Engine oil temperature	(C)
        /// </summary>
        Single OilTemp { get; }

        /// <summary>
        /// Engine oil pressure	(bar)
        /// </summary>
        Single OilPress { get; }

        /// <summary>
        /// Engine oil level	(l)
        /// </summary>
        Single OilLevel { get; }

        /// <summary>
        /// Engine voltage	(V)
        /// </summary>
        Single Voltage { get; }

        /// <summary>
        /// Engine manifold pressure	(bar)
        /// </summary>
        Single ManifoldPress { get; }

        /// <summary>
        /// RR brake line pressure	(bar)
        /// </summary>
        Single RRbrakeLinePress { get; }

        /// <summary>
        /// RR wheel speed	(m/s)
        /// </summary>
        Single RRspeed { get; }

        /// <summary>
        /// RR tire pressure	(kPa)
        /// </summary>
        Single RRpressure { get; }

        /// <summary>
        /// RR tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        Single RRcoldPressure { get; }

        /// <summary>
        /// RR tire left surface temperature	(C)
        /// </summary>
        Single RRtempL { get; }

        /// <summary>
        /// RR tire middle surface temperature	(C)
        /// </summary>
        Single RRtempM { get; }

        /// <summary>
        /// RR tire right surface temperature	(C)
        /// </summary>
        Single RRtempR { get; }

        /// <summary>
        /// RR tire left carcass temperature	(C)
        /// </summary>
        Single RRtempCL { get; }

        /// <summary>
        /// RR tire middle carcass temperature	(C)
        /// </summary>
        Single RRtempCM { get; }

        /// <summary>
        /// RR tire right carcass temperature	(C)
        /// </summary>
        Single RRtempCR { get; }

        /// <summary>
        /// RR tire left percent tread remaining	(%)
        /// </summary>
        Single RRwearL { get; }

        /// <summary>
        /// RR tire middle percent tread remaining	(%)
        /// </summary>
        Single RRwearM { get; }

        /// <summary>
        /// RR tire right percent tread remaining	(%)
        /// </summary>
        Single RRwearR { get; }

        /// <summary>
        /// LR brake line pressure	(bar)
        /// </summary>
        Single LRbrakeLinePress { get; }

        /// <summary>
        /// LR wheel speed	(m/s)
        /// </summary>
        Single LRspeed { get; }

        /// <summary>
        /// LR tire pressure	(kPa)
        /// </summary>
        Single LRpressure { get; }

        /// <summary>
        /// LR tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        Single LRcoldPressure { get; }

        /// <summary>
        /// LR tire left surface temperature	(C)
        /// </summary>
        Single LRtempL { get; }

        /// <summary>
        /// LR tire middle surface temperature	(C)
        /// </summary>
        Single LRtempM { get; }

        /// <summary>
        /// LR tire right surface temperature	(C)
        /// </summary>
        Single LRtempR { get; }

        /// <summary>
        /// LR tire left carcass temperature	(C)
        /// </summary>
        Single LRtempCL { get; }

        /// <summary>
        /// LR tire middle carcass temperature	(C)
        /// </summary>
        Single LRtempCM { get; }

        /// <summary>
        /// LR tire right carcass temperature	(C)
        /// </summary>
        Single LRtempCR { get; }

        /// <summary>
        /// LR tire left percent tread remaining	(%)
        /// </summary>
        Single LRwearL { get; }

        /// <summary>
        /// LR tire middle percent tread remaining	(%)
        /// </summary>
        Single LRwearM { get; }

        /// <summary>
        /// LR tire right percent tread remaining	(%)
        /// </summary>
        Single LRwearR { get; }

        /// <summary>
        /// RF brake line pressure	(bar)
        /// </summary>
        Single RFbrakeLinePress { get; }

        /// <summary>
        /// RF wheel speed	(m/s)
        /// </summary>
        Single RFspeed { get; }

        /// <summary>
        /// RF tire pressure	(kPa)
        /// </summary>
        Single RFpressure { get; }

        /// <summary>
        /// RF tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        Single RFcoldPressure { get; }

        /// <summary>
        /// RF tire left surface temperature	(C)
        /// </summary>
        Single RFtempL { get; }

        /// <summary>
        /// RF tire middle surface temperature	(C)
        /// </summary>
        Single RFtempM { get; }

        /// <summary>
        /// RF tire right surface temperature	(C)
        /// </summary>
        Single RFtempR { get; }

        /// <summary>
        /// RF tire left carcass temperature	(C)
        /// </summary>
        Single RFtempCL { get; }

        /// <summary>
        /// RF tire middle carcass temperature	(C)
        /// </summary>
        Single RFtempCM { get; }

        /// <summary>
        /// RF tire right carcass temperature	(C)
        /// </summary>
        Single RFtempCR { get; }

        /// <summary>
        /// RF tire left percent tread remaining	(%)
        /// </summary>
        Single RFwearL { get; }

        /// <summary>
        /// RF tire middle percent tread remaining	(%)
        /// </summary>
        Single RFwearM { get; }

        /// <summary>
        /// RF tire right percent tread remaining	(%)
        /// </summary>
        Single RFwearR { get; }

        /// <summary>
        /// LF brake line pressure	(bar)
        /// </summary>
        Single LFbrakeLinePress { get; }

        /// <summary>
        /// LF wheel speed	(m/s)
        /// </summary>
        Single LFspeed { get; }

        /// <summary>
        /// LF tire pressure	(kPa)
        /// </summary>
        Single LFpressure { get; }

        /// <summary>
        /// LF tire cold pressure  as set in the garage	(kPa)
        /// </summary>
        Single LFcoldPressure { get; }

        /// <summary>
        /// LF tire left surface temperature	(C)
        /// </summary>
        Single LFtempL { get; }

        /// <summary>
        /// LF tire middle surface temperature	(C)
        /// </summary>
        Single LFtempM { get; }

        /// <summary>
        /// LF tire right surface temperature	(C)
        /// </summary>
        Single LFtempR { get; }

        /// <summary>
        /// LF tire left carcass temperature	(C)
        /// </summary>
        Single LFtempCL { get; }

        /// <summary>
        /// LF tire middle carcass temperature	(C)
        /// </summary>
        Single LFtempCM { get; }

        /// <summary>
        /// LF tire right carcass temperature	(C)
        /// </summary>
        Single LFtempCR { get; }

        /// <summary>
        /// LF tire left percent tread remaining	(%)
        /// </summary>
        Single LFwearL { get; }

        /// <summary>
        /// LF tire middle percent tread remaining	(%)
        /// </summary>
        Single LFwearM { get; }

        /// <summary>
        /// LF tire right percent tread remaining	(%)
        /// </summary>
        Single LFwearR { get; }

        /// <summary>
        /// RR shock deflection	(m)
        /// </summary>
        Single RRshockDefl { get; }

        /// <summary>
        /// RR shock velocity	(m/s)
        /// </summary>
        Single RRshockVel { get; }

        /// <summary>
        /// LR shock deflection	(m)
        /// </summary>
        Single LRshockDefl { get; }

        /// <summary>
        /// LR shock velocity	(m/s)
        /// </summary>
        Single LRshockVel { get; }

        /// <summary>
        /// RF shock deflection	(m)
        /// </summary>
        Single RFshockDefl { get; }

        /// <summary>
        /// RF shock velocity	(m/s)
        /// </summary>
        Single RFshockVel { get; }

        /// <summary>
        /// LF shock deflection	(m)
        /// </summary>
        Single LFshockDefl { get; }

        /// <summary>
        /// LF shock velocity	(m/s)
        /// </summary>
        Single LFshockVel { get; }

        /// <summary>
        /// LF ride height	(m)
        /// </summary>
        Single LFrideHeight { get; }

        /// <summary>
        /// RF ride height	(m)
        /// </summary>
        Single RFrideHeight { get; }

        /// <summary>
        /// LR ride height	(m)
        /// </summary>
        Single LRrideHeight { get; }

        /// <summary>
        /// RR ride height	(m)
        /// </summary>
        Single RRrideHeight { get; }

    }
}
