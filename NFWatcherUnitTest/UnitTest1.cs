﻿using System;
using System.Diagnostics;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace NFWatcherUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVersionNumber()
        {
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            double versionNum = NFW.VersionNumber();
            Assert.AreEqual(versionNum, 0.9);
        }

        [TestMethod]
        public void TestGetConnectionString()
        {
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            string TableConnString = NFW.GetTableConnString();
            Debug.WriteLine(TableConnString.Length);
            Assert.AreEqual(TableConnString.Length > 150, true);
        }

        [TestMethod]
        public void ReadFilmName()
        {
            // create helper object that gives access to the method
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            string ConcatWatchLists = NFW.ConcatWatchList();
            // ASSERT NEEDS TO BE COMPLETED
            Assert.AreEqual(ConcatWatchLists.Length > 0, true);
        }

        [TestMethod]
        public async Task AsyncCallforXML()
        {
            // create helper object that gives access to the method
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            string XMLString = await NFW.GetXMLstring();
            Assert.AreEqual(XMLString.Length > 0, true);
        }

        [TestMethod]
        public void StripProgrammeName()
        {
            string TitleString = "Title = 18th Dec: Homecoming (2009), 1 Season [GUIDANCE] (6/10)";
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            string ProgrammeName = NFW.StripProgrammeName(TitleString);
            Assert.AreEqual((ProgrammeName.Length < TitleString.Length), true);
        }


        [TestMethod]
        public void ParseXMLforNewFilmTitles()
        {
            // test XML string to be replaced by live XML version
            string XMLString = "<?xml version =\"1.0\" encoding=\"utf-8\" ?>\n<rss version=\"2.0\" xmlns:webfeeds=\"http://webfeeds.org/rss/1.0\">\n<webfeeds:logo>https://uk.newonnetflix.info/gfx/nf-logo-2.png</webfeeds:logo>\n<webfeeds:accentColor>ff0000</webfeeds:accentColor>\n<webfeeds:analytics id=\"UA-56870640-1\" engine=\"GoogleAnalytics\"/>\n\n<channel>\n\t<title>New On Netflix UK</title>\n\t<link>https://uk.newonnetflix.info</link>\n\t<description>RSS feed for new additions over the last 5 days to Netflix UK (100% unofficial!). A project by MaFt.co.uk</description>\n\t<language>en-gb</language>\n\t<pubDate>Sat, 21 Dec 2019 04:11:03 GMT</pubDate>\n\t<lastBuildDate>Sat, 21 Dec 2019 04:11:03 GMT</lastBuildDate>\n\t<managingEditor>mail@maft.co.uk (MaFt Morley)</managingEditor>\n\t<webMaster>mail@maft.co.uk (MaFt Morley)</webMaster>\n\n\n\t\t<item>\n\t\t\t<title>21st Dec: Back of the Net (2019), 1hr 26m [ALL] (5.5/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81108479</link>\n\t\t\t<description>An American science geek ready to spend a summer at sea accidentally ends up at an Australian soccer academy and is forced to kick it with the locals.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABfmxl7k2R_j2Js8X_01Adi6xQviwp08cdRzyhpTpnWYSv4p7SQPXfx16zu4SLui2r7BtAWtM-oNrVu-1AQofRCVeevqw.jpg?r=050\" />]]></description>\n\t\t\t<pubDate>Sat, 21 Dec 2019 04:11:03 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81108479</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>21st Dec: Million Pound Menu (2018), 1 Season [GUIDANCE] (6.2/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81004322</link>\n\t\t\t<description>Next-gen restaurateurs get the chance to open their own pop-up eateries to impress the paying public -- and a panel of discerning U.K. investors.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABT_773HUSVKOYdjOg_SQSpoASKp4qJSk5ob390_sPeAQoXBr0kcHFJFWN8C1fa1OeBysLDrV3imwOt7020SfGs9GGoEM.jpg?r=6bf\" />]]></description>\n\t\t\t<pubDate>Sat, 21 Dec 2019 04:11:03 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81004322</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Lost in London (2017), 1hr 26m [GUIDANCE] (6.1/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81172830</link>\n\t\t\t<description>Nigerian students Okon and Bona experience culture shock -- several shocks, really -- after being selected for an exchange program in London.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABYQWTgIi8w6zDOigKPe8Ykc5F6bD9xK8YwT8QOE9TDzDDnZlZv5yG2NerRqRc5fyF374AUWfgB65aWkw06setZrsOv5r.jpg?r=9a9\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 20:11:03 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81172830</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: The Brothers Grimsby (2016), 1hr 23m [15] - Streaming Again (6.1/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80079256</link>\n\t\t\t<description>[Streaming Again] When a smooth MI6 assassin embarks on a dangerous mission that reunites him with his happy, numbskull  brother, they must team up to save the world.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABZd8mUfIIM6-meY0XX0pMnsq2_iaYrICAbCDFhJfYdwUj5Hu4rFw_r5FwwPn6nLPNzNYZ9ItKH8S7RK8gbcncK0N5CLh.jpg?r=f02\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:11 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80079256</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Christmas with the Kranks (2004), 1hr 39m [PG] - Streaming Again (6.15/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/70011207</link>\n\t\t\t<description>[Streaming Again] When Luther Krank and his wife opt to skip Christmas -- no tree and no rooftop Frosty -- can they handle the fallout from their family and neighbors?<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABXFFxwDfs-2zPz_iW5iIXJ8aCC-a1u3siqzBJJn6ljXTcc08giRbmTdkzUT_oc4I6aQonsmQ0bgTc2SD-tOuIb9kvNEC.jpg?r=90f\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:11 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/70011207</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Doing Hard Time (2004), 1hr 41m [18] - Streaming Again (6.05/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/70017716</link>\n\t\t\t<description>[Streaming Again] When his son's killers are given a light sentence, a man purposely gets himself arrested so he can take matters into his own hands.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABU1zHCvL7SCvNDB5mfdcEYHC1AHxpoFyUlfjVuY_VQ9uUzr_v442sTcdkIQsNk1kcpUzfZhgOqoxyiAMoV24CX2Kx6v3.jpg?r=2a2\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:11 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/70017716</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Agent (2019), 1 Season [ADULT] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81157169</link>\n\t\t\t<description>A former footballer tries to make it as a player agent in the world of African soccer, but a secret from his past threatens to destroy everything.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABTnSYjFxRLf9XQ2RE4We6kS2t_wqgCkVJ7IEyayFRqqWhuojAOVvGMlYtP9hE6oiks20oL_VElJbk7b_ZveY3VspnujO.jpg?r=ecb\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81157169</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: American Dreamer (2018), 1hr 32m [MATURE] (5.9/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81172896</link>\n\t\t\t<description>A hapless, ride-hailing driver makes extra cash chauffeuring a drug dealer until desperation leads him to a plan that begins badly and gets worse.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABSwODhdBRDoWsgPS00gplMbbQ-Ih1YSvgarK5viM46nWN1bdrWaRSIoamSJ2n9LWE2AsRFF431G9DbLUI0d7U8fPxHPW.jpg?r=9b5\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81172896</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Angel of Mine (2019), 1hr 38m [TEEN] (6.3/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80239917</link>\n\t\t\t<description>Consumed by grief, a mother's life unravels when she firmly grasps onto the belief that her daughter might still be alive.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABclLwWnUKNOEQ7BrCqzz1TFWdC_4bL7VX_UwK5h6TaGiuNAJ4NowyCV0d36fv2pJkDDCRzIRZvlxHlZBFibsOS6rim2m.jpg?r=b7d\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80239917</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Being Mrs Elliot (2014), 1hr 53m [MATURE] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81172911</link>\n\t\t\t<description>When a scorned wife from the city shares a cab with a troubled villager, a fiery accident forces them to live out each other's lives.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABd1xupM3xN2phI_Aobhjk6ZINYfyPNps0BeIlN43fARKN4XqazxWxUqrQPJeMTGY7OQ9Tg27Q_TBc2H1yGRMTet0JqrW.jpg?r=52f\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81172911</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Black Death (2010), 1hr 41m [15] (6.5/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/70122631</link>\n\t\t\t<description>During the first Bubonic Plague, a church-appointed knight investigates a woman rumored to bring the dead back to life -- but may be tied to Satan.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABdvlIKjCWvo5PVqjgl8VV7lwYH_g_FzOI6bAOMhMwZEAk-MvlosuZSNQ2dGGmGzIm4bnZa8qhNsFeDTskINqnC5X5eki.jpg?r=1aa\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/70122631</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Falz Experience (2018), 1hr 22m [MATURE] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81172866</link>\n\t\t\t<description>Playing multiple characters, from lawyer to preacher, Nigerian artist Falz combines cinema with a concert after his successful 2017 end-of-year show.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABWnuSNEr2Rug2B_ZnvMQmI7HTOzJc6Zo9KaJB0jqbDhAj6oLTWzmOvS0MZIsIN2q-uc-inw7dKo8M0flknF4ib92UWt6.jpg?r=9ea\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81172866</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: The First Lady (2015), 1hr 47m [MATURE] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80126996</link>\n\t\t\t<description>Dreaming of a better life, an imperiled prostitute crosses paths with a wealthy company heir who's been transformed into a child by his evil uncle.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABZm2Y2mWcBVS7MVvoAUO_mo_DriI8_P6CWWARPoOTtKp40hlnPg0eCYO7pxiLqeWD4GypCyWqKH-UHEfxZS_c73NeecN.jpg?r=dfb\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80126996</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: Iyore (2015), 2hr 20m [TEEN] (6.35/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81172897</link>\n\t\t\t<description>A tragic romance unfolds during a teacher's lessons on the Benin empire after they begin to mirror her love life when her childhood love reappears.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABURHcUgD_fqdykbKABqrSJHgr3Or0pG9J6Wu6K15cmubLaeMzuZaKHP171gY9uzutF5KXzDjRSJ-EBuVps9E9UUBzmrC.jpg?r=51d\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81172897</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: The Throwaways (2015), 1hr 27m [15] (5.25/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80080490</link>\n\t\t\t<description>Given a choice between assisting the CIA or life in prison, a notorious hacker agrees to help the government and recruits a team of misfits to assist.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABSUnqHUuUujJD47ju9o5kJ_0fBvAG1rpAC8jdHoN_qsIquCz1XdI0jqWEMGSM9hickdG0ghhVz4rkM_16bTKF7L-ayFo.jpg?r=983\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 04:11:01 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80080490</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: The Two Popes (2019), 2hr 5m [12] (6.85/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80174451</link>\n\t\t\t<description>At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABb1secAVBTnNMwfJe5HxpepEvrJFeS3jExSXpLQyy41FHpkyEHS6cxP5SmnnoTtlFZ4KvajHBDn6t6W_h_VubY0EemUmuqsHqsk-ZLOQonnnmFVy2UhYFtb_bll-QQ.jpg?r=a8a\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80174451</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>20th Dec: The Witcher (2019), 1 Season [15] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80189685</link>\n\t\t\t<description>Geralt of Rivia, a mutated monster-hunter for hire, journeys toward his destiny in a turbulent world where people often prove more wicked than beasts.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABTukDQXfzp8chw7q5vVIqkfaC9S4T_BjIhGmr6XPFVYBKc58zcJNVl_N6sZKCmp88GkfRDgV31wPaVBFrrRyizwpyPjuIXkUIJ2fSvaiX0Ox-ku1kCj45CiZkD9UAw.jpg?r=382\" />]]></description>\n\t\t\t<pubDate>Fri, 20 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80189685</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>19th Dec: Ultraviolet (2019), 2 Seasons [15] - New Episodes (6.5/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80225020</link>\n\t\t\t<description>[New Episodes] An online community of amateur sleuths use technology to solve crimes -- and make quirky friends -- in their quest for justice.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABVusQtu3DUrswLnHI2HsqKncq1kGY3r3lffYDVharo5V4AUorLVXgHcowJPwSWqtlwi7Y5Q5I7Bz4jyHQuegmqGyXGG8GztdJY-pgBIMAQhjIQs2i1H6vQlOxlrHBCS4B3Bl6M2WdL9di88Xwy4OIwKlx0J2t84.jpg?r=f13\" />]]></description>\n\t\t\t<pubDate>Thu, 19 Dec 2019 08:09:04 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80225020</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>19th Dec: Jurassic World (2015), 2hr 4m [12] - Streaming Again (7.2/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80029196</link>\n\t\t\t<description>[Streaming Again] The owners of a dinosaur theme park try to attract tourists with a thrilling new exhibit, but a deadly giant breaks loose and terrorizes the island.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABY35MVVxut-Wlrjzyr2OrP_NXGH1BIyXgcQjxTycwHEDX8JTInL3JCmxVKPWG2ZspHvvT0WwH74YFpg6_RPuvleGK3dM.jpg?r=72b\" />]]></description>\n\t\t\t<pubDate>Thu, 19 Dec 2019 04:11:13 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80029196</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>19th Dec: After the Raid (2019), 25m [ALL] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80244681</link>\n\t\t\t<description>A large immigration raid in a small town leaves emotional fallout and hard questions for its churchgoers about what it means to love thy neighbor.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABRo-0gWZ-Ay1gIWlNE_9zD3Njcg4ziL1zwvgdeTOg2pIvC0TkfrsiQ-zjARTZQKK9wjrrPcMWrNV2c7sonQURcs0oMh92wesuUpB3oR-rp8juENReZbbre1jRIXtZQ.jpg?r=e2f\" />]]></description>\n\t\t\t<pubDate>Thu, 19 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80244681</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>19th Dec: Twice Upon A Time (2019), 1 Season [15] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80989919</link>\n\t\t\t<description>Months after a crushing breakup, a man receives a mysterious package that opens a portal to the past -- and gives him a chance to win back his ex.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABTTxgeiVz8uIPf4gGoW8iZfVp2gxiDDEesFjguFxnrEK8I4E55-5I6MOqOU6JxS9nLUZbIh09ZAURBFmFSdTmtauaXLsRMt_efYVL3gB-bkYXwIB3FC3mgmn1IBgAw.jpg?r=056\" />]]></description>\n\t\t\t<pubDate>Thu, 19 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80989919</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>18th Dec: Homecoming (2009), 1 Season [GUIDANCE] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80136791</link>\n\t\t\t<description>In Kuala Lumpur, the owner of a Chinese medicine shop and his eccentric family navigate the ups and downs of business, romance and parenting.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABf9U06yU_U2rnTNms94dgt_fOD9ygVSD5lN82NCZQuXmjMxBMoI2PSimr3hAWq3S7Q6dpgfV-CwR-ovSXxNJ3xnWF2i2.jpg?r=628\" />]]></description>\n\t\t\t<pubDate>Wed, 18 Dec 2019 11:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80136791</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>18th Dec: The Death of Stalin (2017), 1hr 46m [15] (6.6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80208631</link>\n\t\t\t<description>The death of Russian dictator Joseph Stalin throws the Soviet Union into comic chaos as his ambitious but addled ministers maneuver to succeed him.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABbej_24HYIwb08Cc6-OXWLB-Lqpoleejd_EkCTuCzzo2Pi96miguaoCIjsd7SDFqJ1_lGvwX6xhyPm-uHBL-P-vTYGsv.jpg?r=bbc\" />]]></description>\n\t\t\t<pubDate>Wed, 18 Dec 2019 04:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80208631</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>18th Dec: Don't F**k with Cats: Hunting an Internet Killer (2019), Limited Series [18] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/81031373</link>\n\t\t\t<description>A twisted criminal's gruesome videos drive a group of amateur online sleuths to launch a risky manhunt that pulls them into a dark underworld.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABcN4s3O9REpWBEQGdlz4H5EwRi07Ld3tH4In9Ux1xmVEUj0NIPhy_m-6gwToO5V39OdlPOmbVTDm88qMVG14nJ9EPtMMgDCcgJGkCN7QoUF9wRxAM2r5ck79zB3WJg.jpg?r=936\" />]]></description>\n\t\t\t<pubDate>Wed, 18 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/81031373</guid>\n\t\t</item>\n\t\t<item>\n\t\t\t<title>18th Dec: Soundtrack (2019), 1 Season [15] (6/10)</title>\n\t\t\t<link>https://uk.newonnetflix.info/info/80241410</link>\n\t\t\t<description>Love, loss and transformative luck intersect in this musical drama about two struggling artists experiencing life at full volume in Los Angeles.<![CDATA[<br /><img src=\"https://occ-0-299-300.1.nflxso.net/dnm/api/v6/0DW6CdE4gYtYx8iy3aj8gs9WtXE/AAAABdiyVpouWCsE3vMMO5NqbmZ9lTx5rAdcr2KoEBjJqcnn28wq8CYvVDOmGdB5YR4XCeNyMQNzar1q2ojgUfugVQPp6r2au2cKc4zf1YGDH7Lyt3YB5qWf8jXdWrC37g.jpg?r=448\" />]]></description>\n\t\t\t<pubDate>Wed, 18 Dec 2019 00:11:02 GMT</pubDate>\n\t\t\t<guid>https://uk.newonnetflix.info/info/80241410</guid>\n\t\t</item>\n</channel>\n</rss>";
            // create helper object that gives access to the method
            NFWatcherAzureStorageClassV2.TableAccessToolsV2 NFW = new NFWatcherAzureStorageClassV2.TableAccessToolsV2();
            bool response = NFW.FindTitlesinXML(XMLString);
            Assert.AreEqual(response , true);
        }


    }
}
