﻿using Newtonsoft.Json;

namespace TomTomLib
{
    public class PlaceCollection
    {
        [JsonProperty("Places")]
        public Place[] Places { get; set; }
        public static PlaceCollection FromJson(string json) => 
            JsonConvert.DeserializeObject<PlaceCollection>(json);

        public string ToJson() => 
            JsonConvert.SerializeObject(this);
    }

    public class Place
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("zoom")]
        public long Zoom { get; set; }

        [JsonProperty("center")]
        public double[] Center { get; set; }

        [JsonProperty("coordinates")]
        public double[][][] Coordinates { get; set; }

        public static Place FromJson(string json) =>
            JsonConvert.DeserializeObject<Place>(json);

        public string ToJson() =>
            JsonConvert.SerializeObject(this);
    }
}
