using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammableVents {

    class ClosableVents : Building_TempControl {

        private CompFlickable flickableComp;
        private Comp_ShowAirFlow airFlowComp;

        public override void SpawnSetup(Map map) {
            base.SpawnSetup(map);
            this.flickableComp = base.GetComp<CompFlickable>();
            this.airFlowComp = base.GetComp<Comp_ShowAirFlow>();
        }

        public override void TickRare() {
            // assume air is not flowing
            InfoPanelUpdate(false);

            if (this.flickableComp.SwitchIsOn) {
                InfoPanelUpdate(true);
                GenTemperature.EqualizeTemperaturesThroughBuilding((Building) this, 14f, true);
            }
        }

        public void InfoPanelUpdate(bool airflow) {
            airFlowComp.isAirFlowing = airflow;
        }
    }
}
