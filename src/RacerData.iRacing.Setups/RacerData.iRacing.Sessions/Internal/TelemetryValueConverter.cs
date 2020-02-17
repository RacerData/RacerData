using RacerData.iRacing.Extensions;

namespace RacerData.iRacing.Sessions.Internal
{
    internal static class TelemetryValueConverter
    {
        //private static IDictionary<string, SetupSettingDataTypes> _typeMap = new Dictionary<string, SetupSettingDataTypes>();
        /*
        
         // 4659	   Chassis.Front	RockScreenOn	0   BIT
            // 4016    Chassis.FrontArb Attach          1   BIT
            // 4562    Chassis.FrontArb AttachLeftSide  1   BIT
        
        */
        static TelemetryValueConverter()
        {
            //_typeMap.Add("RockScreenOn", SetupSettingDataTypes.irBool);
            //_typeMap.Add("Attach", SetupSettingDataTypes.irBool);
            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);

            //_typeMap.Add("SpringDeflection", SetupSettingDataTypes.irArrayFloat);

            //_typeMap.Add("ShockCompression", SetupSettingDataTypes.irChar);

            //_typeMap.Add("Packer", SetupSettingDataTypes.irFloat);

            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);
            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);
            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);
            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);
            //_typeMap.Add("AttachLeftSide", SetupSettingDataTypes.irBool);
        }

        public static ConvertedTypeAndUnit ConvertSetupValue(string name, string rawValue)
        {
            if (name == "TruckArmMount" || name == "TrailingArmMount")
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "Position", rawValue);
            }
            else if ((name == "ShockCompression" || name == "ShockRebound") && rawValue.Contains("build"))
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
            }
            else if (name == "TapeConfiguration")
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
            }
            else if (name == "ArmAsymmetry")
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
            }
            else if (name == "ReboundStiffness" && rawValue.Contains("degrees"))
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
            }
            else if (name == "AbsSwitch" || name == "TractionControlSwitch")
            {
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irBool, "", (rawValue.ToUpper() == "ON"));
            }
            
            /***** metric *****/

            // SpringRate: 70 N/mm
            else if (rawValue.EndsWith("N/mm"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "Lbs/in", rawValue.GetSpringRate());

            // RideHeight: 69 mm
            // Stagger: 25 mm
            // ToeIn: -3 mm
            // AntiRollBarSize: 40 mm
            // LeftBarEndClearance: 0 mm
            // ShockCollarOffset: 95 mm
            // TrackBarHeight: +267 mm
            else if (rawValue.EndsWith("mm"))
            {
                if (name == "TrackBarHeight")
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetTrackBarHeight());
                }
                else if (name == "ToeIn")
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetToeIn());
                }
                else if (name == "AntiRollBarSize")
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetAntiRollBarSize());
                }
                else if (name == "Stagger")
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetStagger());
                }
                else if (name == "SwayBarArmLength")
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetSwayBarArmLength());
                }
                else
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetInchesFromMillimeters());
            }


            // BallastForward: -0.356 m
            else if (rawValue.EndsWith("m"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "in", rawValue.GetInchesFromMeters());

            // CornerWeight: 3198 N
            else if (rawValue.EndsWith("N"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "Lbs", rawValue.GetPounds());

            // ColdPressure: 124 kPa
            // LastHotPressure: 139 kPa
            else if (rawValue.EndsWith("kPa"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "psi", rawValue.GetPsi());

            // LastTempsIMO: 62C, 62C, 61C
            else if (rawValue.EndsWith("C"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irArrayFloat, "F", rawValue.GetTireTemps());

            // FuelFillTo: 39.4 L
            else if (rawValue.EndsWith("L"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "G", rawValue.GetGallons());

            /***** common *****/

            // CrossWeight: 47.2%
            // NoseWeight: 49.0%
            // FrontBrakeBias: 70%
            // TreadRemaining: 100%, 100%, 100%
            else if (rawValue.EndsWith("%"))
            {
                if (rawValue.Contains(","))
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irArrayFloat, "%", rawValue.GetTireWear());
                else
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "%", rawValue.GetPercent());
            }

            // SteeringOffset: +0 deg
            // Camber: +4.4 deg
            // Caster: +1.4 deg
            else if (rawValue.EndsWith("deg"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "deg", rawValue.GetDegrees());

            // ReboundStiffness: -17 clicks
            else if (rawValue.EndsWith("clicks"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, rawValue.GetClicks());

            // SteeringRatio: 10:1
            else if (rawValue.Contains(":"))
                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, ":1", rawValue.GetSteeringRatio());
            // UpdateCount: 26
            // RearEndRatio: 5.55
            // AttachLeftSide: 1
            else
            {
                if (name == "UpdateCount")
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, rawValue);
                else if (name == "RearEndRatio")
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, ":1", rawValue);
                else if (name == "AttachLeftSide")
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irBool, (rawValue == "1"));
                else
                {
                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
                    //throw new ArgumentException($"Unrecognized Setting/Value: {name}/{rawValue}");
                }
            }
        }

//        public static ConvertedTypeAndUnit ConvertSetupValueWIP(string name, string rawValue)
//        {
//            /*
           
            
//4555	Chassis.LeftFront	Packer	-57.0 mm shim

//4126	Chassis.LeftFront	SpringDeflection	108 mm 148 mm

//            3831    Chassis.LeftFront ShockCompression    build 3
//3832    Chassis.LeftFront ShockRebound    build 3
//3997    Chassis.LeftFront ShockDeflection 100 mm 203 mm           

            
//4595	Chassis.LeftRear	BumpStiffness	-5 clicks
//4676	Chassis.LeftRear	BumpStiffness	3.0 valving

//1489	Chassis.LeftRear	ReboundStiffness	-5 clicks
//4677	Chassis.LeftRear	ReboundStiffness	7.0 valving

//4627	Suspension.LeftFront	SpringPerchOffset	0 x 1.6 mm
//4267	Suspension.LeftFront	SpringPerchOffset	23 mm

//4559	Chassis.FrontArb	ArbDiameter	43 mm
//4034	Chassis.Rear		ArbDiameter	None

//1810	Chassis.Rear	RearEndRatio	3.37
            
//4302	Suspension.Rear	AntiRollBar	soft
//3338	Chassis.LeftRear	TrailingArmMount	bottom
//2427	Chassis.LeftRear	TruckArmMount	bottom
//4669	Chassis.LeftFront	TorsionBarStop	-0.50 turns
//4792	Chassis.LeftFront	SpringSet	Set 3
//4013	Chassis.FrontArb	ChainOrSolidLink	Solid link
//4790	Chassis.Front	BrakePads	Medium friction
//4789	Chassis.Front	ArbBlades	D6 - D6
//4838	Chassis.Rear	ArbBlades	D1
//4034	Chassis.Rear	ArbDiameter	None
//4035	Chassis.Rear	ArmAsymmetry	None
//4013	Chassis.FrontArb	ChainOrSolidLink	Solid link
//4813	Chassis.InCarDials	AbsSetting	7 (ABS)
//4812	Chassis.InCarDials	AbsSwitch	ON
//4811	Chassis.InCarDials	BrakePressureBias	54.2%
//4816	Chassis.InCarDials	EngineMapSetting	3 (MAP)
//4815	Chassis.InCarDials	TractionControlSetting	10 (ASR)
//4814	Chassis.InCarDials	TractionControlSwitch	ON
//            */
//            if (name == "TruckArmMount" || name == "TrailingArmMount")
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "Position", rawValue);
//            }
//            else if ((name == "ShockCompression" || name == "ShockRebound") && rawValue.Contains("build"))
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
//            }
//            else if (name == "TapeConfiguration")
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
//            }
//            else if (name == "ArmAsymmetry")
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
//            }
//            else if (name == "ReboundStiffness" && rawValue.Contains("degrees"))
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
//            }
//            else if (name == "AbsSwitch" || name == "TractionControlSwitch")
//            {
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irBool, "", (rawValue.ToUpper() == "ON"));
//            }

//            /***** metric *****/

//            // SpringRate: 70 N/mm
//            else if (rawValue.EndsWith(" N/mm"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "Lbs/in", rawValue.GetSpringRate());

//            // RideHeight: 69 mm
//            // Stagger: 25 mm
//            // ToeIn: -3 mm
//            // AntiRollBarSize: 40 mm
//            // LeftBarEndClearance: 0 mm
//            // ShockCollarOffset: 95 mm
//            // TrackBarHeight: +267 mm
//            else if (rawValue.EndsWith(" mm"))
//            {
//                if (name == "TrackBarHeight")
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetTrackBarHeight());
//                }
//                else if (name == "ToeIn")
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetToeIn());
//                }
//                else if (name == "AntiRollBarSize")
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetAntiRollBarSize());
//                }
//                else if (name == "Stagger")
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetStagger());
//                }
//                else if (name == "SwayBarArmLength")
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetSwayBarArmLength());
//                }
//                else
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "in", rawValue.GetInchesFromMillimeters());
//            }


//            // BallastForward: -0.356 m
//            else if (rawValue.EndsWith(" m"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "in", rawValue.GetInchesFromMeters());

//            // CornerWeight: 3198 N
//            else if (rawValue.EndsWith(" N"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, "Lbs", rawValue.GetPounds());

//            // ColdPressure: 124 kPa
//            // LastHotPressure: 139 kPa
//            else if (rawValue.EndsWith(" kPa"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "psi", rawValue.GetPsi());

//            // LastTempsIMO: 62C, 62C, 61C
//            else if (rawValue.EndsWith("C"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irArrayFloat, "F", rawValue.GetTireTemps());

//            // FuelFillTo: 39.4 L
//            else if (rawValue.EndsWith(" L"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "G", rawValue.GetGallons());

//            /***** common *****/

//            // CrossWeight: 47.2%
//            // NoseWeight: 49.0%
//            // FrontBrakeBias: 70%
//            // TreadRemaining: 100%, 100%, 100%
//            else if (rawValue.EndsWith("%"))
//            {
//                if (rawValue.Contains(","))
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irArrayFloat, "%", rawValue.GetTireWear());
//                else
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "%", rawValue.GetPercent());
//            }

//            // SteeringOffset: +0 deg
//            // Camber: +4.4 deg
//            // Caster: +1.4 deg
//            else if (rawValue.EndsWith("deg"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, "deg", rawValue.GetDegrees());

//            // ReboundStiffness: -17 clicks
//            else if (rawValue.EndsWith("clicks"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, rawValue.GetClicks());

//            // SteeringRatio: 10:1
//            else if (rawValue.Contains(":"))
//                return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, ":1", rawValue.GetSteeringRatio());
//            // UpdateCount: 26
//            // RearEndRatio: 5.55
//            // AttachLeftSide: 1
//            else
//            {
//                if (name == "UpdateCount")
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irInt, rawValue);
//                else if (name == "RearEndRatio")
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irFloat, ":1", rawValue);
//                else if (name == "AttachLeftSide")
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irBool, (rawValue == "1"));
//                else
//                {
//                    return new ConvertedTypeAndUnit(SetupSettingDataTypes.irChar, "", rawValue);
//                    //throw new ArgumentException($"Unrecognized Setting/Value: {name}/{rawValue}");
//                }
//            }
//        }

    }
}
