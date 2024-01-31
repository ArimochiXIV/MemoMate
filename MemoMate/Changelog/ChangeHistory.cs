namespace MemoMate.Changelog;

public static class ChangeHistory
{
    public static ChangelogEntry[] Changes = new[]
    {
        new ChangelogEntry
        {
            VersionString = "0.10.0",
            Changes = new[]
            {
                "• Added a changelog window!",
                "• Added an entry for Dalamud's changelog directing users to new changelog.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.9.1",
            Changes = new[]
            {
                "• Made database load at plugin launch, rather than when opening the context menu. This will prevent performance hitches when right-clicking players for the first time."
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.9.0",
            Changes = new[]
            {
                "• Changed the save hint to be in the Save button.",
                "• Added a new delete button, activated by holding down either Control/Ctrl button.",
                "• Outline some planned features in our README.md"
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.8.0",
            Changes = new[]
            {
                "• Add coloring for the [M] icon in context menus to show if a player has a memo already or not.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.7.0",
            Changes = new[]
            {
                "• Add \"/mm version\" command for debugging purposes.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.6.0",
            Changes = new[]
            {
                "• Add an automated release pipeline for new version releases.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.5.0",
            Changes = new[]
            {
                "• Fixed bug where window wouldn't remember last position when viewing a new player.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.4.0",
            Changes = new[]
            {
                "• Ignore non-player objects when opening the context menu.",
                "• Ignore the local player when right-clicking other players",
                "• Fix incorrect window styling at different font scaling settings",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.3.0",
            Changes = new[]
            {
                "• Ignore non-player objects when opening the context menu.",
                "• Ignore the local player when right-clicking other players",
                "• Fix incorrect window styling at different font scaling settings",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.2.0",
            Changes = new[]
            {
                "• Remove dependency on AetherLib. This will be revisited in later plugins.",
            }
        },
        new ChangelogEntry
        {
            VersionString = "0.1.0",
            Changes = new[]
            {
                "• First \"release\". Not much going on here.",
            }
        },
    };
}