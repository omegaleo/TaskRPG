using Godot;
using System;

public partial class TopBar : Panel
{
	[Export] private Label _playerNameLabel;
	[Export] private Label _playerLevelLabel;
	[Export] private Label _playerExperienceLabel;
	[Export] private TextureProgressBar _playerExperienceBar;
	[Export] private RichTextLabel _playerCurrencyLabel;
	
	public override void _Ready()
	{
		base._Ready();
		
		UpdatePlayerInfo("Hero", 5, 1200, 2000, 350);
	}
	
	public void UpdatePlayerInfo(string playerName, int playerLevel, int currentExperience, int experienceToNextLevel, int currency)
	{
		_playerNameLabel.Text = playerName;
		_playerLevelLabel.Text = $"Level {playerLevel}";
		_playerExperienceLabel.Text = $"{currentExperience} / {experienceToNextLevel} XP";
		_playerExperienceBar.MaxValue = experienceToNextLevel;
		_playerExperienceBar.Value = currentExperience;
		_playerCurrencyLabel.Text = $"Gold: {currency}";
	}
}
