﻿using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp2019.Core.DomainService
{
    public interface IPetRepository
    {
        FilteredList<Pet> ReadPets(Filter filter);
        Pet Create(Pet pet);
        Pet Delete(int id);
        Pet Update(int id, Pet pet);
        Pet ReadByID(int id);
    }
}
