using System.Numerics;
using AetherLib.GUI.Controls;
using AetherLib.Logging;
using AetherLib.Modules;
using ImGuiNET;

namespace MemoMate.Windows.Tabs;

public class NearbyTab : TabContent
{
    public override string Title { get; set; } = "Nearby Players";
    private float nearbyDistance = 10f;
    private float maxRange = 20f;

    private uint selectedId;
    private string test = "aa";
    
    public override void Draw()
    {
        var players = Players.GetNearbyPlayers(Player.Local, maxRange, true)
            .OrderBy(p => p.Name);

        var friends = players.Where(p => p.IsFriend).ToArray();
        var nearby = players.Where(p => !p.IsFriend && p.DistanceToPlayer <= nearbyDistance).ToArray();
        var distance = players.Where(p => !p.IsFriend && p.DistanceToPlayer > nearbyDistance).ToArray();

        DrawTree("Friends", friends, true);
        DrawTree("Nearby Players", nearby, true);
        DrawTree("Distant Players", distance);
    }

    private void DrawTree(string label, Player[] players, bool defaultOpen = false)
    {
        if (ImGui.CollapsingHeader(label, defaultOpen ? ImGuiTreeNodeFlags.DefaultOpen : ImGuiTreeNodeFlags.None))
        {
            foreach (var player in players)
            {
                if (ImGui.Selectable("\t" + player.Name, selectedId == player.ObjectId))
                {
                    selectedId = player.ObjectId;
                    MemoWindow.OpenToPlayer(player.Name, player.HomeWorldId);
                }
            }
        }
    }
}