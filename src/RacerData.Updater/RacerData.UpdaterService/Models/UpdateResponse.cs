using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.UpdaterService.Models
{
    public class UpdateResponse
    {
        public bool HasUpdatesAvailable
        {
            get
            {
                return Patches.Any(p => p.Version > CurrentVersion) || Upgrades.Any(u => u.Version > CurrentVersion);
            }
        }
        public Version CurrentVersion { get; set; }
        public IList<Patch> Patches { get; set; }
        public IList<Upgrade> Upgrades { get; set; }

        public IUpdate LatestUpdate
        {
            get
            {
                if (!HasUpdatesAvailable)
                    return null;

                var latestPatch = Patches.OrderBy(p => p.Version).LastOrDefault();
                var latestUpgrade = Upgrades.OrderBy(p => p.Version).LastOrDefault();

                if (latestPatch == null && latestUpgrade == null)
                    return null;

                if (latestPatch == null && latestUpgrade != null)
                    return latestUpgrade;

                if (latestPatch != null && latestUpgrade == null)
                    return latestPatch;

                return latestPatch.Version > latestUpgrade.Version ? (IUpdate)latestPatch : (IUpdate)latestUpgrade;
            }
        }

        public UpdateResponse()
        {
            Patches = new List<Patch>();
            Upgrades = new List<Upgrade>();
        }
    }
}
