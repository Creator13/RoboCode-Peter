﻿using CVB;

namespace BehaviourTree {
    public class InTargetRange : Action {
        private readonly FiringRange range;

        public InTargetRange(Blackboard bb, FiringRange range) : base(bb) {
            this.range = range;
        }

        public override NodeStatus Run() {
            var evt = blackboard.robot.LastScanEvent;
            // Definitely not in range when no bot was scanned
            if (evt == null) return NodeStatus.Failed;

            return range.ValueInRange(evt.Distance) ? NodeStatus.Success : NodeStatus.Failed;
        }
    }
}
