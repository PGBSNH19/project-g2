﻿using System;

namespace KNet.Web.Data
{
    public abstract class Entity
    {
        public Entity()
        {
            Created = Modified = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public int Version { get; set; } = 1;
        public long Created { get; set; }
        public long Modified { get; set; }
    }
}
