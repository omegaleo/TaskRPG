using Godot;
using System;
using GameDevLibrary.Helpers;
using TaskRPG.Core.Models;
using TaskRPG.Runtime.Models;

public partial class GlobalManager : InstancedNode<GlobalManager>
{
	private PlayerData _playerData = new PlayerData("Hero");

	public void Test()
	{
		var time = BenchmarkUtility.Record(() => { 
			_playerData.StatList.Add(new Stat { Type = Stat.StatType.Strength, Value = 10 });
			_playerData.StatList.Add(new Stat { Type = Stat.StatType.Dexterity, Value = 8 });
			_playerData.StatList.Add(new Stat { Type = Stat.StatType.Constitution, Value = 12 });
			_playerData.StatList.Add(new Stat { Type = Stat.StatType.Intelligence, Value = 6 });
			_playerData.StatList.Add(new Stat { Type = Stat.StatType.Wisdom, Value = 7 });
			
			_playerData.GainExperience(250, out var leveledUp);
			GD.Print(_playerData.ToString());
		});
		
		GD.Print($"Log took {time} ms");
	}
}
