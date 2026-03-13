using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataClass
{
    [TableName("product")]
    internal class Product
    {
        [IsPrimaryKey]
        [ColumnName("ID")]
        [DisplayName("ID")]
        public uint ID { get; set; } = 0;

        [ColumnName("Name")]
        [DisplayName("Название")]
        public string Name { get; set; } = "";

        [ColumnName("Ed")]
        [DisplayName("Единицы измерения")]
        public string Ed { get; set; } = "";
    }
}
