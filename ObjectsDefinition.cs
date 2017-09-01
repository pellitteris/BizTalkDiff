using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsys.EAI.BizTalkUtilities
{

    public enum BizTalkObjectType
    {
        Application,
        Host,
        ReceiveLocation,
        ReceivePort,
        SendPortGroup,
        SendPort,
        Folder,
        Orchestration
    }

    public class BizTalkObject
    {
        public BizTalkObjectType ObjectType;
        public bool IsExportable;
        public object NativeObject;
        public IList<string> InboundTransformsList;
        public IList<string> OutboundTransformsList;
        public IList<string> PortList;

        public BizTalkObject(BizTalkObjectType objectType, bool isExportable)
        {
            ObjectType = objectType;
            IsExportable = isExportable;
        }

        public BizTalkObject(BizTalkObjectType objectType, bool isExportable, object nativeObject)
        {
            ObjectType = objectType;
            IsExportable = isExportable;
            NativeObject = nativeObject;
        }

        public BizTalkObject(BizTalkObjectType objectType, bool isExportable, object nativeObject, IList<string> ports)
        {
            ObjectType = objectType;
            IsExportable = isExportable;
            NativeObject = nativeObject;
            PortList = ports;
        }

        public BizTalkObject(BizTalkObjectType objectType, bool isExportable, object nativeObject, IList<string> inboundTransforms, IList<string> outboundTransforms)
        {
            ObjectType = objectType;
            IsExportable = isExportable;
            NativeObject = nativeObject;
            InboundTransformsList = inboundTransforms;
            OutboundTransformsList = outboundTransforms;
        }
    }


    public sealed class CompareParameters
    {
        private static readonly CompareParameters instance = new CompareParameters();

        private CompareParameters() { }

        public static CompareParameters Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool SendPortCheckAddress = false;
        public static bool SendPortCheckAddressFileMask = false;
        public static bool SendPortCheckHost = false;
        public static bool SendPortCheckFilter = false;
        public static bool SendPortCheckPipeline = false;
        public static bool SendPortCheckMaps = false;

        public static bool SendPortGroupCheckFilter = false;

        public static bool ReceivePortCheckEnableRouting = false;
        public static bool ReceivePortCheckMaps = false;

        public static bool ReceiveLocationCheckAddress = false;
        public static bool ReceiveLocationCheckAddressFileMask = false;
        public static bool ReceiveLocationCheckPipeline = false;
        public static bool ReceiveLocationCheckHost = false;

        public static bool OrchestrationCheckHost = false;
        public static bool OrchestrationCheckBindings = false;

    }

}
