using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsys.EAI.BizTalkUtilities.Helper
{
    public static class BizTalkHelper
    {
        private const string BINDINGTYPE = "BindingType";
        private const string BINDINGCONFIGURATION = "BindingConfiguration";

        #region SendPort
        public static List<Microsoft.BizTalk.ExplorerOM.Application> GetApplicationList(ref BtsCatalogExplorer catalog)
        {
            List<Microsoft.BizTalk.ExplorerOM.Application> retValues = new List<Microsoft.BizTalk.ExplorerOM.Application>();
            try
            {
                foreach (Microsoft.BizTalk.ExplorerOM.Application app in catalog.Applications)
                {
                    retValues.Add(app);
                }

                return retValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SendPort> GetSendPortList(ref BtsCatalogExplorer catalog, string applicationName, Capabilities? capability)
        {
            List<SendPort> retValues = new List<SendPort>();
            try
            {
                foreach (SendPort spt in catalog.Applications[applicationName].SendPorts)
                {
                    if (!(spt.IsDynamic || spt.Status != PortStatus.Bound))
                        retValues.Add(spt);
                }

                if (capability != null)
                    return retValues.Where(x => (x.PrimaryTransport.TransportType.Capabilities & capability) == capability).ToList();
                else
                    return retValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SendHandler> GetSendHandlerList(ref BtsCatalogExplorer catalog)
        {
            List<SendHandler> sHList = new List<SendHandler>();
            try
            {
                foreach (SendHandler sh in catalog.SendHandlers)
                {
                    sHList.Add(sh);
                }
                return sHList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetSendHandlerNameList(ref BtsCatalogExplorer catalog)
        {
            List<string> sHList = new List<string>();

            foreach (SendHandler sh in catalog.SendHandlers)
            {
                sHList.Add(sh.Name);
            }

            return sHList.Distinct().ToList();
        }

        public static string SetSendPortHandler(this SendPort spt, string newHandler, ref BtsCatalogExplorer catalog)
        {
            try
            {
                List<SendHandler> sHList = GetSendHandlerList(ref catalog);
                string objectWithoutChanges = string.Empty;
                //Check exists a sendport with the same TransportType 
                if (sHList.Any(x => x.Name == newHandler && x.TransportType == spt.PrimaryTransport.TransportType))
                {
                    spt.PrimaryTransport.SendHandler = sHList.Where(x => x.Name == newHandler && x.TransportType == spt.PrimaryTransport.TransportType).FirstOrDefault();
                    //objectWithoutChanges = string.Format("Send Port: '{0}' - Ok", spt.Name);
                }
                else
                    objectWithoutChanges = string.Format("Object: '{0}' - the Adapter '{1}' is not configured to use the selected Host '{2}'.", spt.Name, spt.PrimaryTransport.TransportType.Name, newHandler);

                return objectWithoutChanges;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetSendPortTransportTypeData(this SendPort spt, ref BtsCatalogExplorer catalog, List<StandardBindingElement> standardBindingElement)
        {
            try
            {
                spt.PrimaryTransport.TransportTypeData = SetTransportTypeDataXml(standardBindingElement, spt.PrimaryTransport.TransportTypeData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static List<string> GetSendPortAdapterList(ref BtsCatalogExplorer catalog, string applicationName)
        //{
        //    List<string> retValues = new List<string>();
        //    try
        //    {
        //        foreach (SendPort spt in catalog.Applications[applicationName].SendPorts)
        //        {
        //            if (!(spt.IsDynamic || spt.Status != PortStatus.Bound))
        //                retValues.Add(spt.PrimaryTransport.TransportType.Name);
        //        }

        //        return retValues;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        #region ReceiveLocationPort
        public static List<ReceiveLocation> GetReceiveLocationPortList(ref BtsCatalogExplorer catalog, string applicationName, Capabilities? capability)
        {
            List<ReceiveLocation> retValues = new List<ReceiveLocation>();
            try
            {
                foreach (ReceivePort rpt in catalog.Applications[applicationName].ReceivePorts)
                {
                    foreach (ReceiveLocation rlc in rpt.ReceiveLocations)
                    {
                        if (rlc.Enable != true)
                            retValues.Add(rlc);
                    }
                }

                if (capability != null)
                    return retValues.Where(x => (x.TransportType.Capabilities & capability) == capability).ToList();
                else
                    return retValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ReceiveHandler> GetReceiveLocationHandlerList(ref BtsCatalogExplorer catalog)
        {
            List<ReceiveHandler> rHList = new List<ReceiveHandler>();

            foreach (ReceiveHandler rh in catalog.ReceiveHandlers)
            {
                rHList.Add(rh);
            }

            return rHList.Distinct().ToList();
        }

        public static List<string> GetReceiveLocationHandlerNameList(ref BtsCatalogExplorer catalog)
        {
            List<string> rHList = new List<string>();

            foreach (ReceiveHandler rh in catalog.ReceiveHandlers)
            {
                rHList.Add(rh.Name);
            }

            return rHList.Distinct().ToList();
        }

        public static string SetReceiveLocationPortHandler(this ReceiveLocation rlc, string newHandler, ref BtsCatalogExplorer catalog)
        {
            try
            {
                List<ReceiveHandler> sHList = GetReceiveLocationHandlerList(ref catalog);
                string objectWithoutChanges = string.Empty;
                //Check exists a sendport with the same TransportType 
                if (sHList.Any(x => x.Name == newHandler && x.TransportType == rlc.TransportType))
                {
                    rlc.ReceiveHandler = sHList.Where(x => x.Name == newHandler && x.TransportType == rlc.TransportType).FirstOrDefault();
                    //objectWithoutChanges = string.Format("Receive Location: '{0}' - Ok", spt.Name);
                }
                else
                    objectWithoutChanges = string.Format("Object: '{0}' - the Adapter '{1}' is not configured to use the selected Host '{2}'.", rlc.Name, rlc.TransportType.Name, newHandler);

                return objectWithoutChanges;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetReceiveLocationPortTransportTypeData(this ReceiveLocation rlc, ref BtsCatalogExplorer catalog, List<StandardBindingElement> standardBindingElement)
        {
            try
            {
                rlc.TransportTypeData = SetTransportTypeDataXml(standardBindingElement, rlc.TransportTypeData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Orchestration

        public static List<BtsOrchestration> GetOrchestrationList(ref BtsCatalogExplorer catalog, string applicationName)
        {
            List<BtsOrchestration> retValues = new List<BtsOrchestration>();
            try
            {
                foreach (BtsOrchestration orc in catalog.Applications[applicationName].Orchestrations)
                {
                    if (!(orc.Status != OrchestrationStatus.Unenlisted))
                        retValues.Add(orc);
                }

                return retValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Host> GetOrchestrationHostList(ref BtsCatalogExplorer catalog)
        {
            List<Host> orcHList = new List<Host>();

            foreach (Host host in catalog.Hosts)
            {
                // Get only In-Process Hosts
                if (host.Type == HostType.InProcess)
                    orcHList.Add(host);
            }

            return orcHList.Distinct().ToList();
        }

        public static List<string> GetOrchestrationHostNameList(ref BtsCatalogExplorer catalog)
        {
            List<string> orcHList = new List<string>();

            foreach (Host host in catalog.Hosts)
            {
                // Get only In-Process Hosts
                if (host.Type == HostType.InProcess)
                    orcHList.Add(host.Name);
            }

            return orcHList.Distinct().ToList();
        }

        public static void SetOrchestration(this BtsOrchestration orc, string newHost, ref BtsCatalogExplorer catalog)
        {
            try
            {
                List<Host> orcHList = GetOrchestrationHostList(ref catalog);

                orc.Host = orcHList.Where(x => x.Name == newHost).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public static string SetTransportTypeDataXml(List<StandardBindingElement> standardBindingElement, string transportTypeData)
        {
            try
            {
                var xdoc = XDocument.Parse(transportTypeData);
                string newTransportTypeData = transportTypeData;

                if (xdoc.Root.Elements(BINDINGTYPE).Any() && xdoc.Root.Elements(BINDINGCONFIGURATION).Any())
                {
                    //use the XML in BindingConfiguration tag to set attributes
                    foreach (StandardBindingElement entry in standardBindingElement)
                    {
                        if (entry.Update)
                        {
                            var xdocBindingConfiguration = XDocument.Parse(xdoc.Root.Elements(BINDINGCONFIGURATION).FirstOrDefault().Value);
                            //Replace or add, if not present, the attribute value
                            xdocBindingConfiguration.Root.SetAttributeValue(entry.Key, standardBindingElement.GetPropertyValues(entry.Key));
                            //Replace the old string element value with the new one.                            
                            xdoc.Root.SetElementValue(BINDINGCONFIGURATION, xdocBindingConfiguration.ToString());
                        }
                    }
                }
                else
                {
                    foreach (StandardBindingElement entry in standardBindingElement)
                    {
                        if (entry.Update)
                        {
                            if (xdoc.Root.Elements(entry.Key2).Any())
                            {
                                //Replace the value only if the element tag exists.
                                xdoc.Root.SetElementValue(entry.Key2, entry.Value);
                            }
                        }
                    }
                }

                return xdoc.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class PortList
    {
        public List<SendPort> SendPortList { get; set; }
        public List<ReceiveLocation> ReceiveLocationList { get; set; }
        public PortList()
        {
            SendPortList = new List<SendPort>();
            ReceiveLocationList = new List<ReceiveLocation>();
        }

    }

}
