using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace ProgrammableVents {
    class Comp_Closable : ThingComp {

        public bool isOpen = false;

        public override string CompInspectStringExtra() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("State: ");
            if (isOpen) {
                stringBuilder.Append("open");
            } else {
                stringBuilder.Append("closed");
            }
            return stringBuilder.ToString();
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra() {
            IList<Gizmo> gizmos = new List<Gizmo>();

            Command_Action cact = new Command_Action();
            cact.defaultDesc = "Toggle state";
            cact.action = new Action(this.toggle_state);
            cact.icon = ContentFinder<Texture2D>.Get("Commands/CompClosable/Halt");

            gizmos.Add(cact);

            return gizmos;
        }

        public void toggle_state() {
            isOpen = !isOpen;
        }
    }
}
