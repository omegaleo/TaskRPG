using System;
using GameDevLibrary.Models;
using Godot;

namespace TaskRPG.Runtime.Models;

public partial class InstancedNode<T> : Node where T : class
{
	public static T Instance { get; private set; }

	protected InstancedNode()
	{
		InstancedNode<T>.Instance = (object) InstancedNode<T>.Instance == null ? this as T : throw new InvalidOperationException($"An instance of {typeof (T).Name} already exists.");
		if ((object) InstancedObject<T>.Instance == null)
			throw new InvalidOperationException($"Failed to cast {this.GetType().Name} to {typeof (T).Name}.");
	}

	~InstancedNode()
	{
		if ((object) InstancedNode<T>.Instance != this)
			return;
		InstancedNode<T>.Instance = default (T);
	}
}
