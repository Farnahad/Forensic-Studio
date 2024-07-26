using System;
using Prism.Commands;

namespace ForensicStudio.Core.Main.Command;

public class FsCommand : DelegateCommand
{
    public FsCommand(Action executeMethod) : base(executeMethod)
    {
    }

    public FsCommand(Action executeMethod, Func<bool> canExecuteMethod)
        : base(executeMethod, canExecuteMethod)
    {
    }
}


public class FsCommand<T> : DelegateCommand<T>
{
    public FsCommand(Action<T> executeMethod) : base(executeMethod)
    {
    }

    public FsCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        : base(executeMethod, canExecuteMethod)
    {
    }
}