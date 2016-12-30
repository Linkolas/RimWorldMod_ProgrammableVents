using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ProgrammableVents {
    class Comp_ShowAirFlow : ThingComp {

        public bool isAirFlowing = false;

        public override string CompInspectStringExtra() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Vent state: ");
            if (isAirFlowing) {
                stringBuilder.Append("open");
            } else {
                stringBuilder.Append("closed");
            }
            return stringBuilder.ToString();
        }
    }
}
