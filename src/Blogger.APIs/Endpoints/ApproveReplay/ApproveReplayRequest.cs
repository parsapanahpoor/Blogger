﻿namespace Blogger.APIs.Contracts.ApproveReplay;

public record ApproveReplayRequest([FromQuery]string Link, [FromQuery(Name ="comment-id")] Guid CommentId);
