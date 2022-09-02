using ReactiveUI;

namespace StatisticsAnalysisTool.Avalonia.Models.BindingModels;

public class UserTrackingBindings : ReactiveObject
{
    private string? _username;
    private string? _guildName;
    private string? _allianceName;
    private string? _currentMapName;
    private bool _usernameInformationVisibility;
    private bool _guildInformationVisibility;
    private bool _allianceInformationVisibility;
    private bool _currentMapInformationVisibility;
    private string? _islandName;
    private bool _islandNameVisibility;

    public string? Username
    {
        get => _username;
        set
        {
            _username = value;
            UsernameInformationVisibility = !string.IsNullOrEmpty(_username);
            this.RaiseAndSetIfChanged(ref _username, value);
        }
    }

    public string? GuildName
    {
        get => _guildName;
        set
        {
            _guildName = value;
            GuildInformationVisibility = !string.IsNullOrEmpty(_guildName);
            this.RaiseAndSetIfChanged(ref _guildName, value);
        }
    }

    public string? AllianceName
    {
        get => _allianceName;
        set
        {
            _allianceName = value;
            AllianceInformationVisibility = !string.IsNullOrEmpty(_allianceName);
            this.RaiseAndSetIfChanged(ref _allianceName, value);
        }
    }

    public string? CurrentMapName
    {
        get => _currentMapName;
        set
        {
            _currentMapName = value;
            CurrentMapInformationVisibility = !string.IsNullOrEmpty(_currentMapName);
            this.RaiseAndSetIfChanged(ref _currentMapName, value);
        }
    }

    public string? IslandName
    {
        get => _islandName;
        set
        {
            _islandName = value;
            IslandNameVisibility = !string.IsNullOrEmpty(_islandName);
            this.RaiseAndSetIfChanged(ref _islandName, value);
        }
    }

    public bool UsernameInformationVisibility
    {
        get => _usernameInformationVisibility;
        set
        {
            _usernameInformationVisibility = value;
            this.RaiseAndSetIfChanged(ref _usernameInformationVisibility, value);
        }
    }

    public bool GuildInformationVisibility
    {
        get => _guildInformationVisibility;
        set
        {
            _guildInformationVisibility = value;
            this.RaiseAndSetIfChanged(ref _guildInformationVisibility, value);
        }
    }

    public bool AllianceInformationVisibility
    {
        get => _allianceInformationVisibility;
        set
        {
            _allianceInformationVisibility = value;
            this.RaiseAndSetIfChanged(ref _allianceInformationVisibility, value);
        }
    }

    public bool CurrentMapInformationVisibility
    {
        get => _currentMapInformationVisibility;
        set
        {
            _currentMapInformationVisibility = value;
            this.RaiseAndSetIfChanged(ref _currentMapInformationVisibility, value);
        }
    }

    public bool IslandNameVisibility
    {
        get => _islandNameVisibility;
        set
        {
            _islandNameVisibility = value;
            this.RaiseAndSetIfChanged(ref _islandNameVisibility, value);
        }
    }
}