using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Common
{
    public class EntityCommon
    {
        private DateTime? _createdDate = null;

        public DateTime? CreatedDate
        {
            get { return _createdDate ?? DateTime.Now; }
            set { _createdDate = value; }
        }
    }
}
