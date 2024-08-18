﻿namespace PetFamily.Domain.Models.Pets
{
    public class PetPhoto
    {
        public Guid Id { get; private set; }

        public string StoragePath { get; private set; } = default!;

        public bool IsMain { get; private set; }
    }
}
