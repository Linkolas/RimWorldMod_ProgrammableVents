using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace ProgrammableVents {
    class Comp_ClosableManual : CompFlickable {

        public override string CompInspectStringExtra() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("State: ");
            if (SwitchIsOn) {
                stringBuilder.Append("open");
            } else {
                stringBuilder.Append("closed");
            }
            return stringBuilder.ToString();
        }
        
        public override IEnumerable<Gizmo> CompGetGizmosExtra() {
            IEnumerable<Gizmo> bgizmos = base.CompGetGizmosExtra();
            if(bgizmos.Count() != 1) {
                return bgizmos;
            }
            
            Command_Toggle ca = (Command_Toggle) bgizmos.ElementAt(0);
            ca.icon = ContentFinder<Texture2D>.Get("Commands/CompClosable/Halt");
            ca.defaultDesc = "Toggle state (open or closed)";
            ca.defaultLabel = "Toggle state";

            List<Gizmo> gizmos = new List<Gizmo>();
            gizmos.Add(ca);

            return gizmos;
            
        }
    }
}
