using BE.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DAL
{
    public class HolyDates
    {
        public const string urlNow = @"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on&c=on&geo=none";
        public const string urlChanged = @"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&start={DATEstart}&end={DATEend}";

        public List<HolydatesInfo> getHoldayForNextWeek()
        {
            List<HolydatesInfo> res = new List<HolydatesInfo>();
            DateTime now = DateTime.Now;
            string urlNowAndEndWithAWeek = urlChanged.Replace("{DATEstart}", now.ToString("yyyy-MM-dd")).Replace("{DATEend}", now.AddDays(7.0).ToString("yyyy-MM-dd"));
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(urlNowAndEndWithAWeek);
                    var holydate = JObject.Parse(json);
                    foreach (var item in holydate["items"])
                    {
                        HolydatesInfo holydatesInfo = new HolydatesInfo();
                        holydatesInfo.title = item["title"].ToString();
                        holydatesInfo.memo = item["memo"].ToString();
                        holydatesInfo.date = new HelperClass().GetDateTimeFromString(item["date"].ToString());
                        res.Add(holydatesInfo);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return res;
        }

        public List<HolydatesInfo> getHoldayBetweenDates(DateTime start, DateTime end)
        {
            List<HolydatesInfo> res = new List<HolydatesInfo>();
            string urlNowAndEndWithAWeek = urlChanged.Replace("{DATEstart}", start.ToString("yyyy-MM-dd")).Replace("{DATEend}", end.ToString("yyyy-MM-dd"));
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(urlNowAndEndWithAWeek);
                    var holydate = JObject.Parse(json);
                    foreach (var item in holydate["items"])
                    {
                        HolydatesInfo holydatesInfo = new HolydatesInfo();
                        holydatesInfo.title = item["title"].ToString();
                        holydatesInfo.memo = item["memo"].ToString();
                        holydatesInfo.date = new HelperClass().GetDateTimeFromString(item["date"].ToString());
                        res.Add(holydatesInfo);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return res;
        }
    }
}