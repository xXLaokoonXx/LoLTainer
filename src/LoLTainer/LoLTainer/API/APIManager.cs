﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using WebSocketSharp;

namespace LoLTainer.API
{

    public class APIManager : Interfaces.IAPIManager
    {
        #region private properties
        private Interfaces.ISettingsManager _settingsManager;
        private Interfaces.ISoundPlayer _soundPlayer;
        private LCUManager _lCUManager;
        private InGameApiManager _inGameApiManager;
        private InGameEventMapper _inGameEventMapper;
        #endregion

        /// <summary>
        /// Constructor of <see cref="APIManager"/>
        /// </summary>
        /// <param name="settingsManager"><see cref="Interfaces.ISettingsManager"/> to draw the Settings from</param>
        public  APIManager(Interfaces.ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            _soundPlayer = new SoundPlayer.SoundPlayer();

            _lCUManager = new LCUManager();
            _lCUManager.InGame += OnIngameChange;
        }

        #region IAPIManager Implementation
        public Binding APIConnectionMessageBinding()
        {
            throw new NotImplementedException();
        }

        public void SetInGameAPIOnOff(bool active)
        {
            throw new NotImplementedException();
        }

        public Binding SummonerIconBinding()
        {
            throw new NotImplementedException();
        }

        public Binding SummonerNameBinding()
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Listener for changes on the State of being ingame.
        /// Opens / Closes InGameApiManager
        /// </summary>
        /// <param name="sender">can be null</param>
        /// <param name="inGame">true if ingame</param>
        private void OnIngameChange(object sender, bool inGame)
        {
            if (inGame && _inGameApiManager == null)
            {
                _inGameApiManager = new InGameApiManager();
                _inGameEventMapper = new InGameEventMapper(_inGameApiManager);
                MakeIngameMapping();
            }
            else
            if (!inGame && _inGameApiManager != null)
            {
                _inGameApiManager.Close();
                _inGameApiManager = null;
                _inGameEventMapper = null;
                _soundPlayer.TerminateAllSounds();
            }
        }

        private void MakeIngameMapping()
        {
            foreach(var setting in _settingsManager.GetAllSettings())
            {
                _inGameEventMapper.GetEventHandler(setting.Event) += (s, e) => { _soundPlayer.PlaySound(setting.SoundPlayerGroup, setting.FileName, setting.PlayLengthInSec); };
            }
        }
    }
}