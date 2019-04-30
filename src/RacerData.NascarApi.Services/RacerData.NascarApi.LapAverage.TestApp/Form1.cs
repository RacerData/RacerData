using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.LapAverage.Service.Internal;

namespace RacerData.NascarApi.LapAverage.TestApp
{
    public partial class Form1 : Form
    {
        //LapAverageService svc = new LapAverageService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (var fileName in Directory.GetFiles(@"C:\Users\Rob\Documents\RacerData\Harvested Data\Dover 1 Truck Practice 1"))
            //    {
            //        var json = File.ReadAllText(fileName);
            //        var data = JsonConvert.DeserializeObject<LiveFeedData>(json);

            //        svc.ParseVehicleLapData(data);
            //    }

            //    int targetLapCount =5;

            //    var bestLapAverages = svc.GetBestLapAverages(targetLapCount);

            //    Console.WriteLine();
            //    Console.WriteLine($"Best {targetLapCount} lap averages");
            //    Console.WriteLine("====================================");
            //    foreach (var item in bestLapAverages)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //    var lastLapAverages = svc.GetLastLapAverages(targetLapCount);

            //    Console.WriteLine();
            //    Console.WriteLine($"Last {targetLapCount} lap averages");
            //    Console.WriteLine("====================================");
            //    foreach (var item in lastLapAverages)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //    Console.WriteLine();

            //    //var svcJson = JsonConvert.SerializeObject(
            //    //  svc.VehicleLapHistory,
            //    //  Formatting.Indented,
            //    //  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

            //    //Console.WriteLine();
            //    //Console.WriteLine("#################################################");

            //    //Console.WriteLine(svcJson);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        //private void Printout()
        //{
        //    foreach (string key in _vehicleLapHistory.Keys.OrderBy(k => k))
        //    {
        //        var v = _vehicleLapHistory[key];

        //        Console.WriteLine($"Vehicle {key}");
        //        Console.WriteLine("================");

        //        foreach (var laps in v.VehicleConsecutiveLaps)
        //        {
        //            Console.WriteLine($"{laps.ToString()}");
        //            //foreach (var lapEvt in laps.VehicleLapEvents)
        //            //{
        //            //    Console.WriteLine($"{lapEvt.ToString()}");
        //            //}
        //        }

        //        Console.WriteLine("- - - - - -");
        //        foreach (var lapEvent in v.VehicleEvents.OrderBy(l => l.Elapsed))
        //        {
        //            Console.WriteLine($"{lapEvent.ToString()}");
        //        }

        //        Console.WriteLine();
        //    }
        //}
    }
}
