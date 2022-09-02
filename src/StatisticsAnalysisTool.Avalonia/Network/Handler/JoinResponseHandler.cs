using System;
using System.Threading.Tasks;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using StatisticsAnalysisTool.Avalonia.Models.NetworkModel;
using StatisticsAnalysisTool.Avalonia.Models.TranslationModel;
using StatisticsAnalysisTool.Avalonia.Network.Manager;
using StatisticsAnalysisTool.Avalonia.Network.Operations.Responses;
using StatisticsAnalysisTool.Avalonia.Settings;
using StatisticsAnalysisTool.Avalonia.ViewModels;

namespace StatisticsAnalysisTool.Avalonia.Network.Handler
{
    public class JoinResponseHandler
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly TrackingController _trackingController;

        public JoinResponseHandler(TrackingController trackingController, MainWindowViewModel mainWindowViewModel)
        {
            _trackingController = trackingController;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public async Task OnActionAsync(JoinResponse value)
        {
            await SetLocalUserData(value);

            _trackingController.ClusterController.SetJoinClusterInformation(value.MapIndex, value.MainMapIndex);

            _mainWindowViewModel.UserTrackingBindings.Username = value.Username;
            _mainWindowViewModel.UserTrackingBindings.GuildName = value.GuildName;
            _mainWindowViewModel.UserTrackingBindings.AllianceName = value.AllianceName;

            SetCharacterTrackedVisibility(value.Username);

            _mainWindowViewModel.DungeonBindings.DungeonCloseTimer.IsVisible = false;

            await AddEntityAsync(value.UserObjectId, value.UserGuid, value.InteractGuid, 
                value.Username, value.GuildName, value.AllianceName, GameObjectType.Player, GameObjectSubType.LocalPlayer);

            _trackingController.DungeonController.AddDungeonAsync(value.MapType, value.MapGuid).ConfigureAwait(false);

            ResetFameCounterByMapChangeIfActive();
            SetTrackingActivityText();
        }

        private async Task SetLocalUserData(JoinResponse value)
        {
            await _trackingController.EntityController.LocalUserData.SetValuesAsync(new LocalUserData
            {
                UserObjectId = value.UserObjectId,
                Guid = value.UserGuid,
                InteractGuid = value.InteractGuid,
                Username = value.Username,
                LearningPoints = value.LearningPoints,
                Reputation = value.Reputation,
                ReSpecPoints = value.ReSpecPoints,
                Silver = value.Silver,
                Gold = value.Gold,
                GuildName = value.GuildName,
                MainMapIndex = value.MainMapIndex,
                PlayTimeInSeconds = value.PlayTimeInSeconds,
                AllianceName = value.AllianceName,
                IsReSpecActive = value.IsReSpecActive
            });
        }

        private async Task AddEntityAsync(long? userObjectId, Guid? guid, Guid? interactGuid, string name, string guild, string alliance, GameObjectType gameObjectType, GameObjectSubType gameObjectSubType)
        {
            if (guid == null || interactGuid == null || userObjectId == null)
            {
                return;
            }

            _trackingController.EntityController.AddEntity((long)userObjectId, (Guid)guid, interactGuid, name, guild, alliance, null, GameObjectType.Player, GameObjectSubType.LocalPlayer);
            await _trackingController.EntityController.AddToPartyAsync((Guid)guid, name);
        }

        private void SetTrackingActivityText()
        {
            if (_trackingController.ExistIndispensableInfos)
            {
                _mainWindowViewModel.TrackingActivityBindings.TrackingActiveText = MainWindowTranslation.TrackingIsActive;
                _mainWindowViewModel.TrackingActivityBindings.TrackingActivityType = TrackingIconType.On;
            }
        }

        private void ResetFameCounterByMapChangeIfActive()
        {
            if (_mainWindowViewModel.IsTrackingResetByMapChangeActive)
            {
                _mainWindowViewModel?.TrackingController?.LiveStatsTracker?.Reset();
            }
        }

        private void SetCharacterTrackedVisibility(string name)
        {
            if (string.IsNullOrEmpty(SettingsController.CurrentUserSettings.MainTrackingCharacterName) || name == SettingsController.CurrentUserSettings.MainTrackingCharacterName)
            {
                _mainWindowViewModel.TrackingActivityBindings.CharacterIsNotTrackedInfoVisibility = false;
            }
            else
            {
                _mainWindowViewModel.TrackingActivityBindings.CharacterIsNotTrackedInfoVisibility = true;
            }
        }
    }
}