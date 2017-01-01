using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammableVents {

    class ClosableVents : Building_TempControl {

        private Comp_ClosableManual closableComp;

        public override void SpawnSetup(Map map) {
            base.SpawnSetup(map);
            this.closableComp = base.GetComp<Comp_ClosableManual>();
        }

        public override void TickRare() {
            if (this.closableComp.SwitchIsOn) {
                GenTemperature.EqualizeTemperaturesThroughBuilding((Building) this, 14f, true);
            }
        }
    }
}
