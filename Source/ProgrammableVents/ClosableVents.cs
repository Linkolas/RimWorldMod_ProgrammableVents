using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammableVents {

    class ClosableVents : Building_TempControl {

        private CompFlickable flickableComp;

        public override void SpawnSetup(Map map) {
            base.SpawnSetup(map);
            this.flickableComp = base.GetComp<CompFlickable>();
        }

        public override void TickRare() {
            if (this.flickableComp.SwitchIsOn) {
                GenTemperature.EqualizeTemperaturesThroughBuilding((Building) this, 14f, true);
            }
        }

    }
}
