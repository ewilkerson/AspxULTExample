
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace AspxULTExample.Models
    {
    public enum EnumUserInfoAccessLevelID
    {
    SuperAccessLevelSr = 1,
    SuperAccessLevelJr = 2,
    ApproveAccessLevel = 3,
    AccessLevel = 4
    }

    public enum EnumUserInfoStatus
    {
    NotCreated = 0,
    Created = 10,
    Signed = 20,
    Approved = 30,
    Complete = 40,
    Unsigned = 50,
    Rejected = 60,
    Revoked = 70,
    Deleted = 80
    }

    public enum EnumUserInfoStatusACRR
    {
    Approve = 30,
    Complete = 40,
    Reject = 60,
    Revoke = 70,
    }
    }
  