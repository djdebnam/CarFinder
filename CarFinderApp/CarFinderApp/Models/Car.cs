namespace CarFinderApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        public int id { get; set; }

        [StringLength(50)]
        [DisplayName("Make")]
        public string make { get; set; }

        [StringLength(50)]
        [DisplayName("Model")]
        public string model_name { get; set; }

        [StringLength(128)]
        [DisplayName("Trim")]
        public string model_trim { get; set; }

        [StringLength(10)]
        [DisplayName("Year")]
        public string model_year { get; set; }

        [StringLength(50)]
        [DisplayName("Style")]
        public string body_style { get; set; }

        [StringLength(50)]
        [DisplayName("Engine Position")]
        public string engine_position { get; set; }

        [StringLength(50)]
        [DisplayName("Engine CC")]
        public string engine_cc { get; set; }

        [StringLength(50)]
        [DisplayName("Engine Cyl")]
        public string engine_num_cyl { get; set; }

        [StringLength(50)]
        [DisplayName("Engine Type")]
        public string engine_type { get; set; }

        [StringLength(50)]
        public string engine_valves_per_cyl { get; set; }

        [StringLength(50)]
        public string engine_power_ps { get; set; }

        [StringLength(50)]
        public string engine_power_rpm { get; set; }

        [StringLength(50)]
        public string engine_torque_nm { get; set; }

        [StringLength(50)]
        public string engine_torque_rpm { get; set; }

        [StringLength(50)]
        public string engine_bore_mm { get; set; }

        [StringLength(50)]
        public string engine_stroke_mm { get; set; }

        [StringLength(50)]
        public string engine_compression { get; set; }

        [StringLength(50)]
        public string engine_fuel { get; set; }

        [StringLength(50)]
        public string top_speed_kph { get; set; }

        [StringLength(50)]
        public string zero_to_100_kph { get; set; }

        [StringLength(50)]
        [DisplayName("Drive Type")]
        public string drive_type { get; set; }

        [StringLength(50)]
        public string transmission_type { get; set; }

        [StringLength(50)]
        public string seats { get; set; }

        [StringLength(50)]
        public string doors { get; set; }

        [StringLength(50)]
        public string weight_kg { get; set; }

        [StringLength(50)]
        public string length_mm { get; set; }

        [StringLength(50)]
        public string width_mm { get; set; }

        [StringLength(50)]
        public string height_mm { get; set; }

        [StringLength(50)]
        public string wheelbase { get; set; }

        [StringLength(50)]
        [DisplayName("MPG Highway")]
        public string lkm_hwy { get; set; }

        [StringLength(50)]
        [DisplayName("MPG")]
        public string lkm_mixed { get; set; }

        [StringLength(50)]
        [DisplayName("MPG City")]
        public string lkm_city { get; set; }

        [StringLength(50)]
        public string fuel_capacity_l { get; set; }

        [StringLength(50)]
        public string sold_in_us { get; set; }

        [StringLength(50)]
        public string co2 { get; set; }

        [StringLength(50)]
        public string make_display { get; set; }
    }
}
