﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface InventoryMenuAccessor : ClickableMenuAccessor
    {
        String _GetHoverText();
        void _SetHoverText(String val);

        String _GetHoverTitle();
        void _SetHoverTitle(String val);

        String _GetDescriptionTitle();
        void _SetDescriptionTitle(String val);

        String _GetDescriptionText();
        void _SetDescriptionText(String val);

        IList _GetInventory();
        void _SetInventory(IList val);

        IList _GetActualInventory();
        void _SetActualInventory(IList val);

        bool _GetPlayerInventory();
        void _SetPlayerInventory(bool val);

        bool _GetDrawSlots();
        void _SetDrawSlots(bool val);

        bool _GetShowGrayedOutSlots();
        void _SetShowGrayedOutSlots(bool val);

        int _GetCapacity();
        void _SetCapacity(int val);

        int _GetRows();
        void _SetRows(int val);

        int _GetHorizontalGap();
        void _SetHorizontalGap(int val);

        int _GetVerticalGap();
        void _SetVerticalGap(int val);
    }
}