using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_core_mvc_mysql_template.Models {

    public class Fruit{

        public int id { get; set; }

        public string name { get; set; }

        public int? value { get; set; }
    }

}