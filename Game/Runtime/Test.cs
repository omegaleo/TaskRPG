using Godot;

namespace TaskRPG.Runtime;

public partial class Test : Node
{
    public override void _Ready()
    {
        base._Ready();
        
        GlobalManager.Instance.Test();
    }
}