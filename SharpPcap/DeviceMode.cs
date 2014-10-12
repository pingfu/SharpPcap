/*
This file is part of SharpPcap.

SharpPcap is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

SharpPcap is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with SharpPcap.  If not, see <http://www.gnu.org/licenses/>.
*/
/* 
 * Copyright 2010 Chris Morgan <chmorgan@gmail.com>
 */

using System;

namespace SharpPcap
{
    /// <summary>
    /// The mode used when opening a device.
    ///
    /// 2014-10-12 - Updated to include OpenFlags defined in the pcap_open() function of winpcap.
    /// http://www.winpcap.org/docs/docs_41b5/html/group__remote__open__flags.html
    ///
    /// In libpcap the DeviceMode flag ends up set as an int int data structure pcap_opt->promisc
    /// the libpcap library treats pcap_opt->promisc as a bool. i.e. if(pcap_opt->promisc) { ... }
    /// so options other than 0 (normal) and 1 (promiscuous) are likely only supported by winpcap.
    /// </summary>
    public enum DeviceMode : short
    {
        /// <summary>
        /// Not promiscuous mode
        /// </summary>
        Normal = 0,
    
        /// <summary>
        /// Promiscuous mode.
        /// Instructs the OS that we want to receive all packets, even those not
        /// intended for the adapter. On non-switched networks this can result in
        /// a large amount of addtional traffic.
        /// NOTE: Devices in this mode CAN be detected via the network
        /// </summary>
        Promiscuous = 1,

        /// <summary>
        /// PCAP_OPENFLAG_DATATX_UDP (winpcap only)
        ///
        /// Defines if the data trasfer (in case of a remote capture) has to be done with UDP protocol. 
        /// A UDP connection is much lighter, but it does not guarantee that all the captured packets arrive to the 
        /// client workstation. Moreover, it could be harmful in case of network congestion. This flag is meaningless 
        /// if the source is not a remote interface. In that case, it is simply ignored.
        /// </summary>
        DataTxUdp = 2,
        
        /// <summary>
        /// PCAP_OPENFLAG_NOCAPTURE_RPCAP (winpcap only)
        ///
        /// Defines if the remote probe will capture its own generated traffic. In case the remote probe uses the 
        /// same interface to capture traffic and to send data back to the caller, the captured traffic includes the 
        /// RPCAP traffic as well. If this flag is turned on, the RPCAP traffic is excluded from the capture, so that 
        /// the trace returned back to the collector is does not include this traffic.
        /// </summary>
        NoCaptureRpcap = 4,
        
        /// <summary>
        /// PCAP_OPENFLAG_NOCAPTURE_LOCAL (winpcap only)
        ///
        /// Defines if the local adapter will capture its own generated traffic. This flag tells the underlying 
        /// capture driver to drop the packets that were sent by itself. This is usefult when building applications 
        /// like bridges, that should ignore the traffic they just sent.
        /// </summary>
        NoCaptureLocal = 8,
        
        /// <summary>
        /// PCAP_OPENFLAG_MAX_RESPONSIVENESS (winpcap only)
        ///
        /// This flag configures the adapter for maximum responsiveness. In presence of a large value for nbytes, 
        /// WinPcap waits for the arrival of several packets before copying the data to the user. This guarantees a low 
        /// number of system calls, i.e. lower processor usage, i.e. better performance, which is good for applications 
        /// like sniffers. If the user sets the PCAP_OPENFLAG_MAX_RESPONSIVENESS flag, the capture driver will copy the 
        /// packets as soon as the application is ready to receive them. This is suggested for real time applications 
        /// (like, for example, a bridge) that need the best responsiveness.
        /// </summary>
        MaxResponsiveness = 16
    }
}
