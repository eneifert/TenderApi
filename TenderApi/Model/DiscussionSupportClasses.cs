using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApi.Model
{
    public class DiscussionState
    {
        public static readonly string New = "new";
        public static readonly string Open = "open";
        public static readonly string Assigned = "assigned";
        public static readonly string Resolved = "resolved";
        public static readonly string Pending = "pending";
        public static readonly string Deleted = "deleted";
    }

    public class DiscussionAction
    {
        /// <summary>
        /// Toggle a discussion's private/public status
        /// </summary>
        public static readonly string Toggle = "toggle";

        /// <summary>
        /// Resolve a discussion
        /// </summary>
        public static readonly string Resolve = "resolve";

        /// <summary>
        /// Unresolve (re-open) a discussion
        /// </summary>
        public static readonly string Unresolve = "unresolve";

        /// <summary>
        /// Acknowledge a Discussion (Move the discussion out of the pending inbox, support only).
        /// </summary>
        public static readonly string Acknowledge = "acknowledge";

        /// <summary>
        /// Restore a previously deleted or spammed Discussion
        /// </summary>
        public static readonly string Restore = "restore";

    }
}
