using System;
using System.Collections.Generic;
using System.Text;

using SunnyChen.Gulu.Gulus;

namespace SunnyChen.Gulu.Win.EventArgs
{
    public class GuluWorkerFinishedEventArgs : System.EventArgs
    {
        private GuluBase gulu__;
        private bool interrupted__ = false;

        public GuluWorkerFinishedEventArgs(GuluBase _gulu, bool _interrupted)
            : base()
        {
            gulu__ = _gulu;
            interrupted__ = _interrupted;
        }

        public GuluBase Gulu
        {
            get { return gulu__; }
            set { gulu__ = value; }
        }

        public bool Interrupted
        {
            get { return interrupted__; }
            set { interrupted__ = value; }
        }
    }
}
