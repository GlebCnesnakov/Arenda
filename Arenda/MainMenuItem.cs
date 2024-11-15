using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda
{
    [Table("Menu")]
    public class MainMenuItem
    {
        [Key]
        public int ID {  get; set; }
        [Column("parrent_id")]
        public int? ParrentID {  get; set; }
        [Column("name")]
        public string Name {  get; set; }
        [Column("dll_name")]
        public string? Module {  get; set; }
        [Column("function_name")]
        public string? Method {  get; set; }
        [Column("sequence")]
        public int Sequence {  get; set; }
        public MainMenuItem() { }
        public MainMenuItem(int parrent_id, string name, string dll_name, string function_name, int sequence)
        {
            ParrentID = parrent_id;
            Name = name;
            Module = dll_name;
            Method = function_name;
            Sequence = sequence;
        }
    }
}
