using Microsoft.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table; //needed for the access to table storage
using System.Diagnostics;
using System.Net.Http; // needed for the HTTP classes for the XML get operations
using System.Xml; //needed for the XML Handling
using System.IO;  //needed for StreamReader 

namespace NFWatcherAzureStorageClassV2
{
    public class TableAccessToolsV2
    {
        public double VersionNumber()
        {
            return (0.9);
        }

        public string GetTableConnString()
        {
            string TableConnString;
            TableConnString = CloudConfigurationManager.GetSetting("StorageConnection");
            return (TableConnString);
        }

        public class FilmEntity : TableEntity
        {
            public FilmEntity()
            {

            }

            public FilmEntity(string Filmname)
            {
                PartitionKey = "Films";
                RowKey = Filmname;
            }
        }


        public String ConcatWatchList()
        {
            string ConcatWatchList = null;
            CloudStorageAccount ProgrammeStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnection"));
            CloudTableClient WatchListtableclient = ProgrammeStorageAccount.CreateCloudTableClient();
            CloudTable WatchListtable = WatchListtableclient.GetTableReference("FilmWatchList");
            var entities = WatchListtable.ExecuteQuery(new TableQuery<FilmEntity>()).ToList();
            foreach (var FilmEntity in entities)
            {
                Debug.WriteLine(FilmEntity.RowKey);
                ConcatWatchList = ConcatWatchList + " " + FilmEntity.RowKey;
            }
            return (ConcatWatchList);
        }


        public async Task<string> GetXMLstring()
        {
            // Get the XML file via HTTP
            //string test1 = System.Configuration.ConfigurationSettings.AppSettings["Key1"];
            string XMLcontents = string.Empty;
            string XMLURL = "http://uk.newonnetflix.info/feed.php";
            string StatusCode;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(XMLURL);
                if (response.IsSuccessStatusCode)
                {
                    XMLcontents = await response.Content.ReadAsStringAsync();
                    StatusCode = response.StatusCode.ToString();
                }
                else
                {
                    StatusCode = response.StatusCode.ToString();
                }
            }

            if (!string.IsNullOrEmpty(XMLcontents))
            {
                Debug.WriteLine("XML retrieved:" + XMLcontents);
            }
            else
            {
                Debug.WriteLine("XML failure:" + StatusCode);
            }
            // END: get the XML file 
            return (XMLcontents);
        }

        // text handling function to stip out the programme name from the XML entity
        public string StripProgrammeName(string titlestring)
        {
            string returnstring = "null";
            Debug.WriteLine("titlestring" + titlestring);
            int PosFirstColon = titlestring.IndexOf(":") + 1;
            int PosFirstBracket = titlestring.IndexOf("(");
            // check that both chaacters were found 
            if (PosFirstColon > -1 && PosFirstBracket > -1)
            {
                int ProgrammeLength = PosFirstBracket - PosFirstColon - 2;
                returnstring = titlestring.Substring(PosFirstColon + 1, ProgrammeLength);
            }
            return (returnstring);
        }



        public bool FindTitlesinXML(string XMLString)
        {
            
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.Async = false;
            using (XmlReader XMLSynReader = XmlReader.Create(new StringReader(XMLString)))
            {
                while (XMLSynReader.Read())
                {
                    string PreviousTag = "null";
                    //Debug.WriteLine(XMLSynReader.NodeType);
                    switch (XMLSynReader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (XMLSynReader.LocalName == "title")
                            {
                                //Debug.WriteLine("At an element called <title>");
                                // We are at the title node, so advance by one element

                                XMLSynReader.Read();
                                // check the next node is a text node (should be contents of the <title> node
                                if (XMLSynReader.NodeType == XmlNodeType.Text)
                                {
                                    // Title has been found 
                                    // Title needs to be processed
                                    Debug.WriteLine("Title = " + XMLSynReader.Value);
                                }
                            }
                            break;
                        case XmlNodeType.Text:
                            //Debug.WriteLine("Text Node: ", XMLSynReader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            //Debug.WriteLine("End Element: ", XMLSynReader.Name);
                            break;
                        default:
                            //Debug.WriteLine("Other node {0} with value {1}",XMLSynReader.NodeType, XMLSynReader.Value);
                            break;

                    }
                }
            }

            return (true);
        }


    }
}
