﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public interface IDbAuditLogger
    {
        void SetAuditTrail();
    }
}
