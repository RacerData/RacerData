namespace RacerData.iRacing
{
    // Weekend events may have more than one session (Practice, Qualifying, RacerData)
    // EventType -> SessionType Map
    // Test -> Test
    // Practice -> Practice
    // Race -> Practice
    //      -> HeatRace
    //      -> Qualifying
    //      -> Race
    // TimeTrial -> ???

    // Type for the weekend event
    public enum EventType
    {
        Test,
        Practice,
        Race,
        TimeTrial
    }
}
