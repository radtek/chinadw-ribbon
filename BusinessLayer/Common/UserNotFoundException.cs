using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils.Serializing.Helpers;
using System.Runtime.Serialization;

namespace ARM_User.BusinessLayer.Common
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected UserNotFoundException(System.Runtime.Serialization.SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
