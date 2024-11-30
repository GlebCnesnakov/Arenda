using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Arenda
{
    [Table("UserPermissions")]
    public class UserPermissions
    {
        [Key]
        public int ID { get; set; }
        [Column("id_user")]
        public int id_user { get; set; }
        [Column("id_item_menu")]
        public int IdMenuItem {  get; set; }
        [Column("R")]
        public int CanRead {  get; set; }
        [Column("W")]
        public int CanWrite {  get; set; }
        [Column("E")]
        public int CanEdit {  get; set; }
        [Column("D")]
        public int CanDelete { get; set; }
        public UserPermissions() { }
        public UserPermissions(int idUser, int idMenuItem, int CanRead, int CanWrite, int CanEdit, int CanDelete)
        {
   
            id_user = idUser;
            IdMenuItem = idMenuItem;
            this.CanRead = CanRead;
            this.CanWrite = CanWrite;
            this.CanEdit = CanEdit;
            this.CanDelete = CanDelete;
        }
    }
}
