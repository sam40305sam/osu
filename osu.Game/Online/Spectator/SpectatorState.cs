// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using osu.Game.Online.API;

namespace osu.Game.Online.Spectator
{
    [Serializable]
    public class SpectatorState : IEquatable<SpectatorState>
    {
        public int? BeatmapID { get; set; }

        [NotNull]
        public IEnumerable<APIMod> Mods { get; set; } = Enumerable.Empty<APIMod>();

        public SpectatorState(int? beatmapId = null, IEnumerable<APIMod> mods = null)
        {
            BeatmapID = beatmapId;
            if (mods != null)
                Mods = mods;
        }

        public bool Equals(SpectatorState other) => BeatmapID == other?.BeatmapID && Mods.SequenceEqual(other?.Mods);

        public override string ToString() => $"Beatmap:{BeatmapID} Mods:{string.Join(',', Mods)}";
    }
}
