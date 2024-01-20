using System.Numerics;
using System.Text;
using AetherLib.Extensions;
using AetherLib.Extensions.Math;
using AetherLib.GUI.Gizmos;
using AetherLib.GUI.Windows;
using AetherLib.Helpers;
using AetherLib.Math;
using AetherLib.Modules;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;

namespace MemoMate.Windows;

public class DebugWindow : AetherWindow
{
    public override string Title { get; set; } = "MemoMate Debug Tools";
    public override ImGuiWindowFlags Flags { get; set; } = ImGuiWindowFlags.NoResize;

    private const float SizeW = 350;
    private const float SizeH = 350;
    
    public override WindowSizeConstraints SizeConstraints { get; set; }
        = new()
        {
            MinimumSize = new Vector2(SizeW, SizeH),
            MaximumSize = new Vector2(SizeW, SizeH)
        };

    private bool drawDetectionCircle = true;
    private float detectionRadius = 5f;
    private float minimumFacingAmount = 0.97f;

    public DebugWindow()
    {
        // IsOpen = true;
    }
    
    public override void OnOpen()
    {
        base.OnOpen();
        detectionRadius = Plugin.PluginConfiguration.DetectionRadius;
    }

    public override void Draw()
    {
        base.Draw();
        DrawControls();
        DrawDebugVisuals();
    }

    private void DrawControls()
    {
        if (ImGui.InputFloat("Minimum Distance", ref detectionRadius, 0.1f))
        {
            Plugin.PluginConfiguration.DetectionRadius = detectionRadius;
            Plugin.PluginConfiguration.Save();
        }
        if (ImGui.InputFloat("Minimum Facing", ref minimumFacingAmount, 0.01f))
        {
            Plugin.PluginConfiguration.MinimumFacingPercent = minimumFacingAmount;
            Plugin.PluginConfiguration.Save();
        }
    }

    private void DrawDebugVisuals()
    {
        var textOffset = WorldVector.Down * 0.1f;
        ImGizmo.Circle3D(Player.Local.Position, WorldVector.Up, detectionRadius, false, ImGuiColors.Yellow, 4f);
        
        ImGizmo.Line(Player.Local.Position, Player.Local.Position + Player.Local.Forward * detectionRadius, ImGuiColors.Cyan);
        ImGizmo.Circle2D(Player.Local.Position, 4f, true, ImGuiColors.Cyan);
        
        foreach (var player in Players.GetNearbyLocalPlayer(detectionRadius, true))
        {
            ImGizmo.Circle2D(player.Position, 4f, true, ImGuiColors.Cyan);
            
            var position = player.Position with { Y = Player.Local.Position.Y };

            ImGizmo.Line(position, player.Position, ImGuiColors.Cyan, true);
            ImGizmo.Line(position, position + player.Forward * detectionRadius, ImGuiColors.Cyan);

            var lookingAtMePercent = player.AmountLookingTowards(Player.Local.Position);
            var lookingAtThemPercent = Player.Local.AmountLookingTowards(position);
            
            var isLookingAtMe = lookingAtMePercent >= minimumFacingAmount;
            var isBeingLookedAtByLocal = lookingAtThemPercent >= minimumFacingAmount;
            
            var stats = new StringBuilder();
            stats.AppendLine($"Distance: {player.DistanceToPlayer.Rounded()}y");
            
            stats.AppendLine($"Dot (Them->Me): {lookingAtMePercent.Rounded()}");
            stats.AppendLine($"Dot (Me->Them): {lookingAtThemPercent.Rounded()}");

            if (isLookingAtMe) stats.AppendLine("** They are looking at you **");
            if (isBeingLookedAtByLocal) stats.AppendLine("** You are looking at them **");
            
            ImGizmo.Text(stats.ToString(), position + textOffset, ImGuiColors.Yellow);
        }
    }
}