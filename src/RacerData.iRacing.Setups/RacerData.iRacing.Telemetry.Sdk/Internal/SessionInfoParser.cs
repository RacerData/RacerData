using System.Collections.Generic;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class SessionInfoParser
    {
        public ISessionInfo ParseYaml(string sessionInfoYaml)
        {
            ISessionInfo sessionInfo = new SessionInfo();

            SessionDictionaries sessionData = new SessionDictionaries(sessionInfoYaml);

            var weekendInfoParser = new WeekendInfoParser();
            sessionInfo.WeekendInfo = weekendInfoParser.ParseYaml(sessionData.weekendInfo);

            IList<object> sessionsList = (IList<object>)sessionData.sessionInfo["Sessions"];
            var sessionParser = new SessionParser();
            foreach (Dictionary<object, object> sessionItem in sessionsList)
            {
                var session = sessionParser.ParseYaml(sessionItem);
                sessionInfo.Sessions.Add(session);
            }

            var driverInfoParser = new DriverInfoParser();
            sessionInfo.DriverInfo = driverInfoParser.ParseYaml(sessionData.driverInfo);

            if (sessionData.qualifyingInfo != null && sessionData.qualifyingInfo.ContainsKey("Results"))
            {
                IList<object> qualifyingResultsList = (IList<object>)sessionData.qualifyingInfo["Results"];
                var qualifyingResultsParser = new QualifyingResultsParser();
                foreach (Dictionary<object, object> qualifyingResultsItem in qualifyingResultsList)
                {
                    var qualifyingResults = qualifyingResultsParser.ParseYaml(qualifyingResultsItem);
                    sessionInfo.QualifyingResults.Add(qualifyingResults);
                }
            }

            if (sessionData.carSetupInfo != null)
            {
                var setupParser = new CarSetupParser();

                sessionInfo.CarSetup = setupParser.ParseYaml(
                    sessionData.carSetupInfo,
                    sessionInfoYaml.Substring(sessionInfoYaml.IndexOf("CarSetup:")));
            }

            return sessionInfo;
        }
    }
}
