using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARM_User.New.DB
{
    class DIM_ExtraPokaz
    {
        public Int32 abs_dimension_id;
        public Int32 pokaz_id;
        public Int32 parent_id;
        public String name;
        public String code;
        public DateTime report_date;
        public String dim_name;
        public String dim_part;
        public String note;
        public Int32 level_no;
        public DIM_ExtraPokaz(
            Int32 abs_dimension_id,
            Int32 pokaz_id,
            Int32 parent_id,
            String name,
            String code,
            DateTime report_date,
            String dim_name,
            String dim_part,
            String note,
            Int32 level_no)
        {
            this.abs_dimension_id = abs_dimension_id;
            this.pokaz_id = pokaz_id;
            this.parent_id = parent_id;
            this.name = name;
            this.code = code;
            this.report_date = report_date;
            this.dim_name = dim_name;
            this.dim_part = dim_part;
            this.note = note;
            this.level_no = level_no;
        }
        public DIM_ExtraPokaz()
        {
        }
    }
}
