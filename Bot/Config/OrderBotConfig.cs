﻿using System;
using System.Collections.Generic;
using NHSE.Core;

namespace SysBot.ACNHOrders
{
    [Serializable]
    public class OrderBotConfig
    {
        private int _maxQueueCount = 50;
        private int _timeAllowed = 180;
        private int _waitForArriverTime = 60;
        private int _arrivalTime = 75;

        /// <summary> Amount of people allowed in the queue before the bot stop accepting requests. Won't accept more than 99 (around 8 hours) </summary>
        public int MaxQueueCount
        {
            get => _maxQueueCount;
            set => _maxQueueCount = Math.Max(1, Math.Min(99, value));
        }

        /// <summary> Maximum amount of time in seconds before a user is kicked from your island to avoid loiterers. Minimum is 2 minutes (120 seconds). </summary>
        public int UserTimeAllowed 
        { 
            get => _timeAllowed; 
            set => _timeAllowed = Math.Max(120, value); 
        }

        /// <summary> Maximum amount of time to wait until they're a no-show and the bot restarts in seconds. </summary>
        public int WaitForArriverTime
        {
            get => _waitForArriverTime;
            set => _waitForArriverTime = Math.Max(45, value);
        }

        /// <summary> Guesstimation amount of time in seconds it takes for someone to player the arrival animation from inability to move to start. Minimum is 60 seconds, depends on both of your connections. </summary>
        public int ArrivalTime
        {
            get => _arrivalTime;
            set => _arrivalTime = Math.Max(75, value);
        }

        /// <summary> Message to send at the end of the order completion string </summary>
        public string CompleteOrderMessage { get; set; } = "Have a great day!";

        /// <summary> If some of the inputs get eaten while talking to orville, should we try talking to him one more time? </summary>
        public bool RetryFetchDodoOnFail { get; set; } = true;

        /// <summary> Should we include IDs in the echos and order replies? </summary>
        public bool ShowIDs { get; set; } = false;

        /// <summary> Send messages of orders starting/arriving in the echo channels </summary>
        public List<ulong> EchoArrivingLeavingChannels { get; set; } = new();
    }
}
