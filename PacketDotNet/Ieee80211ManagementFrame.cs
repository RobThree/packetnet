﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using MiscUtil.Conversion;
using PacketDotNet.Utils;

namespace PacketDotNet
{
    /// <summary>
    /// Format of a CTS or an ACK frame
    /// </summary>
    public abstract class Ieee80211ManagementFrame : Ieee80211MacFrame
    {
        /// <summary>
        /// DestinationAddress
        /// </summary>
        public PhysicalAddress DestinationAddress
        {
            get
            {
                return GetAddress(0);
            }

            set
            {
                SetAddress(0, value);
            }
        }

        /// <summary>
        /// SourceAddress
        /// </summary>
        public PhysicalAddress SourceAddress
        {
            get
            {
                return GetAddress(1);
            }

            set
            {
                SetAddress(1, value);
            }
        }

        /// <summary>
        /// BssID
        /// </summary>
        public PhysicalAddress BssId
        {
            get
            {
                return GetAddress(2);
            }

            set
            {
                SetAddress(2, value);
            }
        }


        /// <summary>
        /// Frame control bytes are the first two bytes of the frame
        /// </summary>
        public UInt16 SequenceControlBytes
        {
            get
            {
                return EndianBitConverter.Little.ToUInt16(header.Bytes,
                                                      (header.Offset + Ieee80211MacFields.Address1Position + (Ieee80211MacFields.AddressLength * 3)));
            }

            set
            {
                EndianBitConverter.Little.CopyBytes(value,
                                                 header.Bytes,
                                                 (header.Offset + Ieee80211MacFields.Address1Position + (Ieee80211MacFields.AddressLength * 3)));
            }
        }

        /// <summary>
        /// Sequence control field
        /// </summary>
        public Ieee80211SequenceControlField SequenceControl
        {
            get;
            set;
        }
    }

}
