﻿using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Chest : Object, Wrapper<ChestAccessor>
    {
        private ChestAccessor accessor;

        public Chest(StaticContext parent, ChestAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int CurrentLidFrame
        {
            get { return accessor._GetCurrentLidFrame(); }
            set { accessor._SetCurrentLidFrame(value); }
        }

        public int FrameCounter
        {
            get { return accessor._GetFrameCounter(); }
            set { accessor._SetFrameCounter(value); }
        }

        public int Coins
        {
            get { return accessor._GetCoins(); }
            set { accessor._SetCoins(value); }
        }

        public IList Items
        {
            get { return accessor._GetItems(); }
            set { accessor._SetItems(value); }
        }

        public FarmerAccessor Opener
        {
            get { return accessor._GetOpener(); }
            set { accessor._SetOpener(value); }
        }

        public String ChestType
        {
            get { return accessor._GetChestType(); }
            set { accessor._SetChestType(value); }
        }

        public Color Tint
        {
            get { return accessor._GetTint(); }
            set { accessor._SetTint(value); }
        }

        public bool PlayerChest
        {
            get { return accessor._GetPlayerChest(); }
            set { accessor._SetPlayerChest(value); }
        }

        public bool Giftbox
        {
            get { return accessor._GetGiftbox(); }
            set { accessor._SetGiftbox(value); }
        }

        public ChestAccessor Expose() => accessor;
    }
}