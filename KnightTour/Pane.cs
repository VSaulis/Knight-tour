using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTour
{
    public class Pane 
    {
        private int _i;
        private int _j;
        private PaneStatus _paneStatus;
        private int _stepNumber;

        public Pane(int i, int j) 
        {
            _i = i;
            _j = j;
            _paneStatus = PaneStatus.empty;
        }

        public PaneStatus GetPaneStatus() 
        {
            return _paneStatus;
        }

        public void SetPaneStatus(PaneStatus paneStatus) 
        {
            _paneStatus = paneStatus;
        }

        public void SetStepNumber(int stepNumber) 
        {
            _stepNumber = stepNumber;
        }

        public int GetStepNumber() 
        {
            return _stepNumber;
        }

    }
}
