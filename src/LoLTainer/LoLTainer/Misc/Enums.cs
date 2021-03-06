﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLTainer.Misc
{
    /// <summary>
    /// Events that are supported in this application.
    /// Implementation for support can be found in <see cref="API.InGameEventMapper"/> or <see cref="API.LCUEventMapper"/>.
    /// </summary>
    public enum Event
    {
        /* !IMPORTANT!
         * When adding a new event here ensure support in API.InGameEventMapper or API.LCUEventMapper
         */
        PlayerAnyKill = 10,
        PlayerSingleKill = 11,
        PlayerDoubleKill = 12,
        PlayerTripleKill = 13,
        PlayerQuodraKill = 14,
        PlayerPentaKill = 15,
        PlayerFirstBlood = 16,
        //TeamKill = 21,
        //TeamDoubleKill = 22,
        //TeamTripleKill = 23,
        //TeamQuodraKill = 24,
        //TeamPentaKill = 25,
        //PlayerTurretDestroyed = 31,
        //PlayerInhibitorDestroyed = 32,
        //TeamTurretDestroyed = 41,
        //TeamInhibitorDestroyed = 42,
        PlayerDragonKill = 51,
        PlayerBaronKill = 52,
        //PlayerDragonKillAssist = 53,
        //PlayerBaronKillAssist = 54,
        //PlayerDragonSteal = 55,
        //PlayerBaronSteal = 56,
        //TeamDragonSteal = 57,
        //TeamBaronSteal = 58
        /*
         * --LCU--
         */
         EnterChampSelect = 1010,
         EnterGame = 1020,
         EndGame = 1030
    }
    public enum PlayMode
    {
        /// <summary>
        /// The sound will wait until the current sound from the group is finished
        /// </summary>
        WaitPlaying,
        /// <summary>
        /// The sound will stop the current sound from the group and start immediately
        /// </summary>
        StopPlaying,
        /// <summary>
        /// Before starting to play all other sounds will be shut down
        /// </summary>
        StopAllPlaying
    }
}
