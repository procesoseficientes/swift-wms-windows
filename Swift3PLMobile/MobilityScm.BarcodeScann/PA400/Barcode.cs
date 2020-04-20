//
// Copyright (c) 2007-2014 Trimble Navigation Limited
// This source code is subject to the included license agreement.
//

using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace BarcodeControlLib
{

    public class Barcode
    {

        #region Structs for PInvoke

// ReSharper disable once InconsistentNaming
        public const int Max_DATA = 512;


        [StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        };

        [StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
        public struct SCAN_BUFFER
        {
            public uint dwStatus;
            public uint dwDataBuffSize;
            public uint dwOffsetDataBuff;
            public uint dwDataLength;
            public uint dwLabelType;
            public SYSTEMTIME TimeStamp;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = Max_DATA)]
            public byte[] szData;
        };

        //
        // Driver Error Codes
        //
// ReSharper disable once InconsistentNaming
        public enum E_SCN_CODE
        {
            E_SCN_SUCCESS = 0x0, //The function completed successfully 
            E_SCN_NOTENOUGHMEMORY = unchecked((int)0xA0000001), //An attempt to allocate memory failed.
            E_SCN_INVALIDDVCCONTEXT = unchecked((int)0xA0000002), //An invalid device context ID was used.
            E_SCN_INVALIDOPENCONTEXT = unchecked((int)0xA0000003), //An attempt was made to access an invalid open context.
            E_SCN_NOTINITIALIZED = unchecked((int)0xA0000004), //The driver was accessed before a successful initialization. 
            E_SCN_CANTSTARTDEVICE = unchecked((int)0xA0000005), //The device could not be started. 
            E_SCN_NOTSTARTED = unchecked((int)0xA0000006), //An attempt was made to use or stop the scanner device and it was not started. 
            E_SCN_ALREADYSTARTED = unchecked((int)0xA0000007), //An attempt was made to start the device when the device was already started.
            E_SCN_NOTENABLED = unchecked((int)0xA0000008), //An attempt was made to access the scanner device and it was not enabled. 
            E_SCN_ALREADYENABLED = unchecked((int)0xA0000009), //An attempt was made to enable scanning when scanning was already enabled. 
            E_SCN_INVALIDIOCTRL = unchecked((int)0xA000000A), //The control code passed to DeviceIoControl is invalid. 
            E_SCN_NULLPTR = unchecked((int)0xA000000B), //A NULL pointer was passed for a required argument. 
            E_SCN_INVALIDARG = unchecked((int)0xA000000C), //A passed argument is out of range. 
            E_SCN_BUFFERSIZEIN = unchecked((int)0xA000000D), //The size of the buffer passed as an input to DeviceIoControl is less than sizeof(STRUCT_INFO) or is less than the size specified in StructInfo.dwUsed.
            E_SCN_BUFFERSIZEOUT = unchecked((int)0xA000000E), //The size of the buffer passed as an output to DeviceIoControl is less than sizeof(STRUCT_INFO) or is less than the size specified in StructInfo.dwAllocated. 
            E_SCN_INVALIDHANDLE = unchecked((int)0xA000000F), //An invalid handle was passed to a function. 
            E_SCN_INVALIDPARAM = unchecked((int)0xA0000010), //The value of a parameter either passed as an argument to a function or as a member of a structure is out of range or conflicts with other parameters. 
            E_SCN_CREATEEVENT = unchecked((int)0xA0000011), //Unable to create a required event. 
            E_SCN_CREATETHREAD = unchecked((int)0xA0000012), //Unable to create a required thread.
            E_SCN_READCANCELLED = unchecked((int)0xA0000013), //A read request was cancelled.
            E_SCN_READTIMEOUT = unchecked((int)0xA0000014), //A read request timed out.
            E_SCN_READNOTPENDING = unchecked((int)0xA0000015), //Attempt to cancel a read that is not pending. 
            E_SCN_READPENDING = unchecked((int)0xA0000016), //Attempt to start a read when one is pending. 
            E_SCN_BUFFERTOOSMALL = unchecked((int)0xA0000017), //Data buffer is too small for incoming data. 
            E_SCN_NOTSUPPORTED = unchecked((int)0xA0000018), //Version of function not supported (e.g. ANSI vs. UNICODE).
            E_SCN_EXCEPTION = unchecked((int)0xA0000019), //An exception occurred while trying to call the scanner driver.
            E_SCN_WIN32ERROR = unchecked((int)0xA000001A), //A scanner API function failed with a non-scanner API error code. Call GetLastError to get extended error code.
            E_SCN_ALREADYINUSE = unchecked((int)0xA000001B), //A requested scanner resource is already in use. 
            E_SCN_NOTINUSE = unchecked((int)0xA000001C), //The specified scanner resource was not allocated.
            E_SCN_INVALIDSCANDLL = unchecked((int)0xA000001D), //Scan Dll version does not compatible with driver version
            E_SCN_NODATA = unchecked((int)0xA000001E), //No data available
            E_SCN_WAITTIMEOUT = unchecked((int)0xA000001F), //WaitEvent timeout
            E_SCN_SWTRIGGER_DISABLED = unchecked((int)0xA0000020), //Scan attempt with disabled SW trigger
            E_SCN_WRITE_ERROR = unchecked((int)0xA0000021), //Write to the PDD gave an error
            E_SCN_CANTSHUTDOWNDEVICE = unchecked((int)0xA0000022), //Cant shutdown device
            E_SCN_DEVICEBUSY = unchecked((int)0xA0000023), //Device would not accept command within 1 second
            E_SCN_ERRORUNKNOWN = unchecked((int)0xA0000042) //Unknown error
        };

        public const int E_SCN_SUCCESS = 0x0;
        public const int E_SCN_EXCEPTION = unchecked((int)0xFFFFFFFF);

        public const int SCAN_TYPE_TRIGGER = 0; // Indicates the app will trigger the scan session
        public const int SCAN_TYPE_MONITOR = 1; // Indicates the app wants to receive scan results, but not initiate scans

        #endregion
        #region PInvoke



        // Initialization



        /// <summary>
        /// The SCAN_Open function opens the specified scanner device and creates a handle to be used for all subsequent accesses to this scanner.
        /// </summary>
        /// <param name="hScanner">Pointer to a handle created for all subsequent accesses to this scanner. </param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        ///
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_ALREADYSTARTED. If E_SCN_INVALIDSCANDLL is returned, the system has failed an
        /// internal check due to mismatched driver/dll versions. If E_SCN_CANTSTARTDEVICE is returned, the caller can get a more specific error code by calling
        /// GetLastError. GetLastError could return a Win32 error code or one of the scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll", CharSet = CharSet.Auto)]
        public static extern uint SCAN_Open(ref IntPtr hScanner);

        /// <summary>
        /// The SCAN_Close function closes an open scanner.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner to close.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value is E_SCN_NOTINITIALIZED or E_SCN_INVALIDARG
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_Close(IntPtr hScanner);

        /// <summary>
        /// The SCAN_GetVersionInfo function gets the version information for the scanner engine, driver, and scan dll.  
        /// If the handle is a valid open scanner handle, the function returns versions for the entire driver stack 
        /// and the scanner engine. If the handle is NULL, only the C API (scan dll) version is returned
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="lpScanVersionInfo"> Pointer to a SCAN_VERSION_INFO structure to be filled in with the version info.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetVersionInfo(IntPtr hScanner, IntPtr pScanVersionInfo);

        /// <summary>
        /// The Scanner Settings applet allows the user to change all the settings in a global configuration. 
        /// This configuration is always used by the SIP scanner and the Scanner Agent (hard-key mappable scanner). 
        /// Other applications may choose to use this global configuration instead of writing their own settings user interface. 
        /// Calling SCAN_UseControlPanelConfiguration will enable the application to stay in sync with the global configuration.
        /// Newly opened handles always receive a copy of the global configuration.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="bEnable">TRUE to enable using global configuration, FALSE to disable.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_UseControlPanelConfiguration(IntPtr hScanner, int bEnable);

        /// <summary>
        /// The SCAN_Enable function enables or disables scanning operations on an open scanner.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <param name="bEnable">TRUE to enable scanning on an open handle, FALSE to disable.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_EnableScanning(IntPtr hScanner, int bEnable);

        /// <summary>
        /// The SCAN_EnableSoftTrigger function enables or disables software trigger operations on an open scanner.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <param name="bEnable">TRUE to enable scanning on an open handle, FALSE to disable.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_EnableSoftTrigger(IntPtr hScanner, int bEnable);



        // Scan buffer management



        /// <summary>
        /// The SCAN_AllocateBuffer function allocates the buffer used to receive barcode data
        /// </summary>
        /// <param name="dwSize">Must be greater or equal to longest expected barcode data + prefix/suffix bytes. Pass in MAX_DECODE_DATA 
        /// to receive a buffer that will hold the maximum barcode data + the maximum prefix/suffix bytes.</param>
        /// <returns>If the function succeeds, the return value is non-null. Use GetLastError to retrieve error codes</returns>
        [DllImport("ScanDLL.dll")]
        public static extern IntPtr SCAN_AllocateBuffer(uint dwSize);

        /// <summary>
        /// The SCAN_DeallocateBuffer function allocates the buffer used to receive barcode data. 
        /// </summary>
        /// <param name="pScanBuffer">Pointer to SCAN_BUFFER structure to be deallocated.</param>
        [DllImport("ScanDLL.dll")]
        public static extern void SCAN_DeallocateBuffer(IntPtr pScanBuffer);



        // Scan commands



        /// <summary>
        /// Read a bacode and wait (blocked) until a barcode is scanned, or a timeout.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <param name="pScanBuffer">Pointer to SCAN_BUFFER structure to receive scan results</param>
        /// <param name="dwScanType">Must be SCAN_TYPE_TRIGGER to trigger scan operation, or SCAN_TYPE_MONITOR to monitor scan results, but not trigger the scanner.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_ReadLabelWait(IntPtr hScanner, IntPtr pScanBuffer, uint dwScanType);

        /// <summary>
        /// The SCAN_ReadLabelMsg function initiates a scan session. Application will receive a windows message when the session completes 
        /// (scanned data matches the current code settings, or the operation times out, or an error occurs).
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <param name="pScanBuffer">Pointer to SCAN_BUFFER structure to receive scan results</param>
        /// <param name="hWnd">HANDLE to the window receiving posted results</param>
        /// <param name="uiMsgNo">Message to post indicating completion</param>
        /// <param name="dwScanType">Must be SCAN_TYPE_TRIGGER to trigger scan operation, or SCAN_TYPE_MONITOR to monitor scan results, but not trigger the scanner.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_ReadLabelMsg(IntPtr hScanner, IntPtr pScanBuffer,
                                                    uint hWnd, uint uiMsgNo, uint dwScanType);

        /// <summary>
        /// The SCAN_ReadLabelEvent function initiates a scan session. A win32 event object will be signaled 
        /// when the session completes (scanned data matches the current code settings, or the operation times out, or an error occurs).
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <param name="pScanBuffer">Pointer to SCAN_BUFFER structure to receive scan results</param>
        /// <param name="hEvent">HANDLE to a Win32 event object to be signaled when the scan session completes</param>
        /// <param name="dwScanType">Must be SCAN_TYPE_TRIGGER to trigger scan operation, or SCAN_TYPE_MONITOR to monitor scan results, but not trigger the scanner.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_ReadLabelEvent(IntPtr hScanner, IntPtr pScanBuffer,
                                                    uint hEvent, uint dwScanType);

        /// <summary>
        /// The SCAN_CancelRead function cancels any scan session. The function blocks until the scan session is completed. 
        /// Applications will receive notifications as usual in the case of ReadLabelMsg and ReadLabelEvent. 
        /// The timing is not guaranteed, and it is possible to receive valid data in the SCAN_BUFFER after calling this method.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or E_SCN_NOREADPENDING or one of 
        /// the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_CancelRead(IntPtr hScanner);



        // Decoders and decoder params



        /// <summary>
        /// Gets the decoders supported by the scanner.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pDecoders">Pointer to a DECODERARRAY structure to be filled in with the supported decoders.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetSupportedDecoders(IntPtr hScanner, IntPtr pDecoders);

        /// <summary>
        /// Gets the currently enabled decoders.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pDecoders">Pointer to a DECODERARRAY structure to be filled in with the enabled decoders.</param>
        /// <returns>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetEnabledDecoders(IntPtr hScanner, IntPtr pDecoders);

        /// <summary>
        /// Sets the currently enabled decoders.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pDecoders">Pointer to a DECODERARRAY structure filled in with the enabled decoders.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetEnabledDecoders(IntPtr hScanner, IntPtr pDecoders);

        /// <summary>
        /// Gets the parameters for a decoder.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="decoder">One of the DECODER types defined in ScanDef.h.</param>
        /// <param name="pParams">Pointer to a DECODER_PARAMS structure to receive the params.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetDecoderParams(IntPtr hScanner, uint decoder, IntPtr pDecoders);

        /// <summary>
        /// Sets the parameters for a decoder.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="decoder">One of the DECODER types defined in ScanDef.h</param>
        /// <param name="pDecoders">Pointer to a DECODER_PARAMS structure filled in with the decoder parameters.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetDecoderParams(IntPtr hScanner, uint decoder, IntPtr pDecoders);

        /// <summary>
        /// Gets the UPC EAN parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pParams">Pointer to a UPC_EAN_PARAMS structure to be filled in by the driver.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetUPCEANParams(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Sets the UPC EAN parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pParams">Pointer to a UPC_EAN_PARAMS structure filled in by the application.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetUPCEANParams(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Resets enabled decoders, all decoder params, and UPC EAN params to their factory default values.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="dwReserved">Reserved. Should be set to 0.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_ResetCodesToFactoryDefaults(IntPtr hScanner, uint dwReserved);


        /// <summary>
        /// Gets the scan parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open or NULL.</param>
        /// <param name="pParams">Pointer to a SCAN_PARAMS structure to be filled in by the driver.</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetScanParams(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Sets the scan parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name="pParams">Pointer to a SCAN_PARAMS structure filled in by the application</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetScanParams(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Gets the prefix/suffix parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name=" pParams">Pointer to a SCAN_PREFIX structure to be filled in by the driver</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetPrefixSuffix(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Sets the prefix/suffix parameters for an open handle.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name="pParams">Pointer to a SCAN_PREFIX structure filled in by the application</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetPrefixSuffix(IntPtr hScanner, IntPtr pParams);



        // Device info



        /// <summary>
        /// Gets the scanner serial number.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name="pSerial">Pointer to a SCAN_SERIAL_NUMBER structure to be filled in by the driver</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetSerialNo(IntPtr hScanner, IntPtr pSerial);


        // Device-level params
        //	NOTE:	Rarely set by applications. These parameters affect all open handles. 
        //					They are written directly to the scanner device.
        //

        /// <summary>
        /// Gets the scanner reader params.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name="pParams">Pointer to a READER_PARAMS structure to be filled in by the driver</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_GetReaderParams(IntPtr hScanner, IntPtr pParams);

        /// <summary>
        /// Sets the scanner reader params.
        /// </summary>
        /// <param name="hScanner">Handle of an open scanner returned by SCAN_Open.</param>
        /// <param name="pParams">Pointer to a READER_PARAMS structure filled in by the application</param>
        /// If the function succeeds, the return value is E_SCN_SUCCESS.
        /// If the function fails, the return value may be E_SCN_INVALIDARG or E_SCN_NOTINITIALIZED or one of the other scanner error codes defined in ScanDef.h.
        /// </returns>
        [DllImport("ScanDLL.dll")]
        public static extern uint SCAN_SetReaderParams(IntPtr hScanner, IntPtr pParams);

        #endregion
    }

}

