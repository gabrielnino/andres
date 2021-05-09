using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class FieldsValueByUserFlow
    {
        public int IdUser { get; set; }
        public int IdFlow { get; set; }
        public FieldsValue[] fieldsValue { get; set; }

    }
}
