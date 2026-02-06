using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Gigi.Services
{
    public static class RewardService
    {
        private const string RewardsKey = "user_rewards";
        private const string PointsKey = "user_points";

        private static List<string> _rewards = new();
        private static int _points = 0;

        static RewardService()
        {
            LoadRewards();
        }

        public static List<string> GetRewards() => _rewards;

        public static int GetPoints() => _points;

        public static void AddReward(string reward)
        {
            if (!_rewards.Contains(reward))
            {
                _rewards.Add(reward);
                _points += 10; // example: each reward adds 10 points
                SaveRewards();
            }
        }

        public static bool SpendPoints(int cost)
        {
            if (_points >= cost)
            {
                _points -= cost;
                SaveRewards();
                return true;
            }
            return false;
        }

        private static void SaveRewards()
        {
            Preferences.Set(RewardsKey, JsonSerializer.Serialize(_rewards));
            Preferences.Set(PointsKey, _points);
        }

        private static void LoadRewards()
        {
            var savedRewards = Preferences.Get(RewardsKey, string.Empty);
            var savedPoints = Preferences.Get(PointsKey, 0);

            if (!string.IsNullOrEmpty(savedRewards))
                _rewards = JsonSerializer.Deserialize<List<string>>(savedRewards) ?? new List<string>();

            _points = savedPoints;
        }

        public static void Reset()
        {
            _rewards.Clear();
            _points = 0;
            Preferences.Remove(RewardsKey);
            Preferences.Remove(PointsKey);
        }
        //private static List<string> unlockedRewards = new();

        //private const string RewardsKey = "UnlockedRewards";

        //static RewardService()
        //{
        //    LoadRewards();
        //}

        //public static void AddReward(string reward)
        //{
        //    if (!unlockedRewards.Contains(reward))
        //    {
        //        unlockedRewards.Add(reward);
        //        SaveRewards();
        //    }
        //}

        //public static List<string> GetRewards()
        //{
        //    return unlockedRewards;
        //}

        //private static void SaveRewards()
        //{
        //    string json = JsonSerializer.Serialize(unlockedRewards);
        //    Preferences.Set(RewardsKey, json);
        //}

        //private static void LoadRewards()
        //{
        //    if (Preferences.ContainsKey(RewardsKey))
        //    {
        //        string json = Preferences.Get(RewardsKey, "[]");
        //        unlockedRewards = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        //    }
        //}

        //public static void ResetRewards()
        //{
        //    unlockedRewards.Clear();
        //    Preferences.Remove(RewardsKey);
        //}
    }
}