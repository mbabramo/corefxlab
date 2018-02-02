﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace System.IO.Pipelines
{
    public struct FlushResult
    {
        internal ResultFlags ResultFlags;

        public FlushResult(bool isCancelled, bool isCompleted)
        {
            ResultFlags = ResultFlags.None;

            if (isCancelled)
            {
                ResultFlags |= ResultFlags.Cancelled;
            }

            if (isCompleted)
            {
                ResultFlags |= ResultFlags.Completed;
            }
        }

        /// <summary>
        /// True if the currrent flush was cancelled
        /// </summary>
        public bool IsCancelled => (ResultFlags & ResultFlags.Cancelled) != 0;

        /// <summary>
        /// True if the <see cref="PipeWriter"/> is complete
        /// </summary>
        public bool IsCompleted => (ResultFlags & ResultFlags.Completed) != 0;
    }
}
