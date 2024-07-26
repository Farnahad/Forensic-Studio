﻿using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.ProcessMonitor;

public class ProcessMonitorViewModel : GeneralViewModel
{
    protected ProcessMonitorViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}