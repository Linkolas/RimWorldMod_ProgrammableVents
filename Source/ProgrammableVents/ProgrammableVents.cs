using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ProgrammableVents {

    class ProgrammableVents : Building_TempControl {

        private CompFlickable flickableComp;
        private Comp_ShowAirFlow airFlowComp;

        public override void SpawnSetup(Map map) {
            base.SpawnSetup(map);
            this.flickableComp = base.GetComp<CompFlickable>();
            this.airFlowComp = base.GetComp<Comp_ShowAirFlow>();
        }

        public override void TickRare() {
            if (!this.flickableComp.SwitchIsOn) {
                InfoPanelUpdate(false);
                return;
            }

            IntVec3 intVec = base.Position + IntVec3.South.RotatedBy(base.Rotation);
            IntVec3 intVec2 = base.Position + IntVec3.North.RotatedBy(base.Rotation);

            if (intVec2.Impassable(base.Map) || intVec.Impassable(base.Map)) {
                InfoPanelUpdate(false);
                return;
            }

            float temp1 = intVec.GetTemperature(base.Map);
            float temp2 = intVec2.GetTemperature(base.Map);
            float target = this.compTempControl.targetTemperature;
            
            if ((temp1 >= target && temp2 >= target)
                || temp1 <= target && temp2 <= target) {
                InfoPanelUpdate(false);
                return;
            }

            InfoPanelUpdate(true);
            GenTemperature.EqualizeTemperaturesThroughBuilding((Building)this, 10f, true);
        }

        public void InfoPanelUpdate(bool airflow) {
            airFlowComp.isAirFlowing = airflow;
        }
    }
}
