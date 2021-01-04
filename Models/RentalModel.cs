using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RealEstateData.Models
{
    [DataContract]
    public class RentalModel
    {
        [DataMember(Order = 1)]
        public string property_id { get; set; }

        [DataMember]
        public string listing_id { get; set; }

        [DataMember]
        public string prop_type { get; set; }

        [DataMember]
        public DateTime last_update { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string prop_status { get; set; }

        [DataMember]
        public float price_raw { get; set; }

        [DataMember(Order = 7)]
        public DateTime list_date { get; set; }

        [DataMember]
        public bool is_showcase { get; set; }

        [DataMember]
        public bool has_specials { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public int beds { get; set; }

        [DataMember(Order = 9)]
        public float baths { get; set; }

        [DataMember(Order = 10)]
        public string sqft { get; set; }

        [DataMember(Order = 10)]
        public string name { get; set; }

        [DataMember]
        public string photo { get; set; }

        [DataMember]
        public string short_price { get; set; }

        [DataMember]
        public int photo_count { get; set; }

        [DataMember]
        public List<string> products { get; set; }

        [DataMember]
        public float lat { get; set; }

        [DataMember(Order = 12)]
        public float lon { get; set; }

        [DataMember]
        public int community_id { get; set; }

        [DataMember]
        public string pet_policy { get; set; }

        [DataMember]
        public bool has_leadform { get; set; }

        [DataMember]
        public string source { get; set; }

        [DataMember]
        public int page_no { get; set; }

        [DataMember(Order = 13)]
        public int rank { get; set; }

        [DataMember(Order = 13)]
        public string list_tracking { get; set; }
    }
}