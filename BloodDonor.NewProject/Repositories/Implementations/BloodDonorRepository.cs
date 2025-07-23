<<<<<<< HEAD
﻿using BloodDonor.Models;
using BloodDonor.NewProject.Data;
=======
﻿using BloodDonor.NewProject.Data;
>>>>>>> Isuue
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BloodDonor.NewProject.Repositories.Implementations
{
    public class BloodDonorRepository : Repository<BloodDonorEntity>, IBloodDonorRepository
    {
<<<<<<< HEAD
        public BloodDonorRepository(BloodDonorDbContext context) : base(context)
=======
        public BloodDonorRepository(DbContext context) : base(context)
>>>>>>> Isuue
        {
        }
    }
}
