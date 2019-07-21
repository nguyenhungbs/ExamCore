using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Exam.CoreData.Enums
{
    public enum PatientStatus
    {
        [Description("InTherapy")]
        InTherapy = 1,

        [Description("Paused")]
        Paused = 2,

        [Description("Completed")]
        Completed = 3
    }
}
