using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ProgrammableVents {

    class ProgrammableVents : Building_TempControl
    {
        private Comp_ShowAirFlow airFlowComp;

        public override void SpawnSetup(Map map, bool respawningAfterLoad) {
            base.SpawnSetup(map, respawningAfterLoad);
            this.airFlowComp = base.GetComp<Comp_ShowAirFlow>();
        }

        public override void TickRare() {
            airFlowComp.isAirFlowing = false;
            
            if (!FlickUtility.WantsToBeOn(this) || !compPowerTrader.PowerOn) {
                // not powered on
                return;
            }

            IntVec3 intVec = base.Position + IntVec3.South.RotatedBy(base.Rotation);
            IntVec3 intVec2 = base.Position + IntVec3.North.RotatedBy(base.Rotation);

            if (intVec2.Impassable(base.Map) || intVec.Impassable(base.Map)) {
                // air can't flow
                return;
            }

            float temp1 = intVec.GetTemperature(base.Map);
            float temp2 = intVec2.GetTemperature(base.Map);
            float target = this.compTempControl.targetTemperature;

            if ((temp1 > target && temp2 > target)
                || temp1 < target && temp2 < target) {
                // don't let air flow if it would not help reach target temperature
                return;
            }

            // all good, air can flow
            airFlowComp.isAirFlowing = true;
            GenTemperature.EqualizeTemperaturesThroughBuilding((Building)this, 14f, true);
        }
    }
}
