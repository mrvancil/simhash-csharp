using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestSimhashIndexJenkins
    {
        //1=14473962, 2=14454106, 3=14454124, 4=14454110
        private Dictionary<long, string> testData = new Dictionary<long, string>();
        [TestInitialize]
        public void setUp()
        {
            testData.Add(1, "Skype is bringing its promising real-time translation tool to millions more users by adding six new voice languages and rolling it into the Windows desktop app.\r\n\r\nThe Skype Translator tool, which has been in preview since December 2014, is rolling out to all desktop users within the Windows app.\r\n\r\nThe app can now convert video calls in English, French, German, Italian, Mandarin and Spanish.\r\n\r\nIt\u2019ll also convert message text in over 50 languages and, thanks to the machine learning tech, both tools will get better the more people use it.\r\n\r\nThe new version of the Skype for Windows app will now feature a translator icon, which will inform you it\u2019s all set to be called into action.\r\n\r\nDuring the preview period Skype points out plenty of inspirational uses for the tool.\r\n\r\nIt says a student planned an entire study year in China using Translator, while helping a newly engaged, multicultural couple get to know each other\u2019s parents.\r\n\r\nMeanwhile, a PhD student used it to consult with experts around the world, while a non-profit worker was able to bring in donations.\r\n\r\nSee also: Windows 10 review\r\n\r\n\u201cIt has been a long-time dream at Skype to break down language barriers and bring everyone across the globe closer together. Researchers, engineers, and many others across Microsoft have been working hard to make this dream a reality and we are looking forward to bringing this preview technology to more devices,\u201d the company said (via Engadget)\r\n\r\nCheck out the video below for information on how to set it up.");
            testData.Add(2, "Written by: Gary Morrow \n 10/01/15 - 2:15 PM EDT \n \n \nTickers in this article: \n  IBM \n \n   \nNEW YORK (TheStreet) -- IBM  is drifting lower at midday on Thursday after beginning the session slightly higher. \n\nAt this morning's early high, the stock bumped up against heavy trend line resistance that capped the August and September highs. With today's rejection at this key level, IBM is becoming vulnerable to further downside. For IBM investors, an upcoming retest of major support will be critical. \n  As October begins, it appears IBM is headed for its third straight lower monthly low. This current downtrend, which began on July 21 with a huge downside gap, has dropped shares nearly 20%. Late last month, the initial down leg of the post-earnings breakdown found support near $140. IBM began to rebound on Aug. 26, but the upside was well-contained. With very light bullish interest, despite the steep decline from the summer highs, the stock was unable to move past its massive Aug. 24 opening gap. Shares have been trading in a tight range since while the major indices went on to recover most of the mid-August selloff. The significant lagging action continues to weigh on Big Blue and will likely drive it lower in the near term.  IBM will soon retest a major support zone between the $141-to-$138 area. The stock's August spike low marks the upper band of this area while the 1999 peak sits at $138.35. On a long-term chart, the 1999 high near $138.50 was a major turning point. This level was not taken out until the fourth quarter of 2010. Once through, IBM began a monster bull run that carried shares over 55% above the stock's 1999 high. \nInvestors should keep a close on eye on this zone. A solid base here, along with a divergent moving average convergence/divergence indicator , could provide a very attractive entry opportunity for patient bulls.");
            testData.Add(3, "SAN FRANCISCO (Reuters) - Many short sellers appear to have unwound their bets against Apple this week, and a 6 percent fall in the stock price suggests they made money as investor worries about the company countered a record launch of its newest iPhone.\nThe relentless ascent of Apple Inc's  stock since it debuted its first smartphone in 2007 has made it unpopular for most short sellers.\nBut worries about slowing economic growth in China, an increasingly important market for Apple, have recently hurt the Cupertino, California company's shares, sending them down about 19 percent from a record high in April.\nOn Thursday, Apple was down 2.2 percent at $107.83 on a report that chip suppliers were concerned the iPhone maker would cut chip orders for the fourth quarter.\nThe stock fell 2 percent on Monday even after Apple announced record first-weekend sales of its new iPhone 6S and 6S Plus handsets, suggesting investors have concerns about whether Chief Executive Officer Tim Cook can top sales of previous devices.\nBorrowing in Apple shares grew 32 percent through most of September, and then abruptly dropped 31 percent this week, according to lending data from SunGard's Astec Analytics, which provides a strong glimpse into short-selling activity. \nShort sellers borrow shares and sell them, hoping to buy them back later for less to return to the lender. During that time, they have to pay interest to the lender.\nThis week, Apple's stock has fallen almost 6 percent, suggesting short sellers wrapping up their bets may have made money.    \nShort selling in Apple increased from 1.1 percent of its outstanding shares in July to 1.6 percent in mid-September, although that level of short selling remained below the average rate of 2.7 percent for tech companies, according to Thomson Reuters data.\nSince a selloff in Chinese equities in late August, Apple's stock has fallen about 7 percent, slightly less than the S&P 500's 9 percent decline. \nBrad Lamensdorf, who manages the AdvisorShares Ranger Equity Bear ETF, is currently short Apple shares. He suspects investors are overestimating iPhone sales in future quarters and he believes recent trading volume in Apple shares hints at more weakness to come.\nHe also likes shorting Apple because he doesn't have to compete with other short sellers to borrow the company's shares.\n\"We don't like to get into highly crowded 'war shorts' that people have been in forever,\" he said. \"Apple is the cheapest to borrow. There's plenty of supply and it's the lowest rate they'll charge you.\"\n (Reporting by Noel Randewich; Editing by Cynthia Osterman)\n");
            testData.Add(4, "KANSAS CITY, Mo. , Oct. 1, 2015 /PRNewswire/ --\u00a0Global technology solutions company EDZ Systems announces a new product and service offering that gives business and technology managers the tools needed to find the right people for the right project, at the right time. EDZ's proprietary databases and intelligent algorithms identify the best resources available, whether they're looking through their own employee ranks, or need to go outside of the company to search for expertise worldwide.   \nEDZ Systems was founded by \n (President and CEO), \n (VP - Sales and Marketing) and \n (CFO).\u00a0 As a minority and woman owned business, our solid reputation has been established through more than 35 years of business and information technology experience. \n   \"IT professionals continuously acquire new credentials and experience with rapidly advancing technologies,\" notes \n, EDZ CFO. \"We saw a growing need for companies to capture and curate employees' evolving credentials to help IT managers effectively align and manage their people to impact the bottom line.\" \nThis new business is built around a proprietary IT management tool known as the Intelligent Resource Management System TM (IRMS).\u00a0This multi-lingual system curates client IT staff credentials: certifications, expertise, work style and measures of productivity for each resource. \n\"Businesses are struggling to maximize the talents and productivity of their people, and to outsource IT projects to teams that are the right fit,\" says EDZ President \n. \"Our matching analytics and technology go deep into expertise, culture, personality, compatibility, language, past performance and accuracy to help companies optimize their resources, their outsourced projects and their results.\" \n\"Typically, companies look for contract IT resources based on two criteria: skill sets and cost,\" noted DeZeeuw. \"We know building successful outsourcing relationships requires a lot more. We consider an organization's culture, skills, location and time zone. For example, if South Asia's time zones are a problem for U.S. clients, we can offer proven IT partners in South America .\" \nEDZ Systems can match the most qualified IT professional to complex projects that involve: The Internet of Things  Advanced Analytics  Software-defined Applications  Web-Scale IT  \n About  \nEDZ Systems (EDZ) is a global technology solutions firm providing Intelligent Global IT Solutions, a proprietary Intelligent Resource Management System TM (IRMS) and Strategic Consulting Services worldwide. Specialties include: Professional Services, Software Development, Business Transformation, Security, Enterprise Content Management, Strategy & Operations, Program Management, Enterprise Architecture, Analytics and Mobility. \nLearn more at: www.EDZSystems.com  \nLogo - http://photos.prnewswire.com/prnh/20151001/273185LOGO \n\u00a0");
        }

        private SimhashIndex setUpIndex(int kValue)
        {
            Dictionary<long, Simhash> objs = new Dictionary<long, Simhash>();

            foreach (var it in testData)
            {
                var simHash = new Simhash();
                var shingling = new Shingling();
                var features = shingling.tokenize(it.Value, 3);
                simHash.GenerateSimhash(features);
                objs.Add(it.Key, simHash);

            }
            return new SimhashIndex(objs: objs, k: kValue);
        }

        [TestMethod]
        public void test_get_near_dup_hash_jenkins_not_close()
        {
            var index = setUpIndex(1);
            var s = new Simhash();
            s.GenerateSimhash("This is not even close to the text that is loaded by default");
            var dups = index.get_near_dups(s);
            Assert.AreEqual(0, dups.Count);

        }

        [TestMethod]
        public void test_get_near_dup_hash_jenkins_find_one()
        {
            var index = setUpIndex(1);

            var s = new Simhash();
            var shingling = new Shingling();
            var features = shingling.tokenize(testData[1], 3);
            s.GenerateSimhash(features);

            var dups = index.get_near_dups(s);
            Assert.AreEqual(1, dups.Count);
        }
    }
}
