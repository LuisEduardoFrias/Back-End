﻿using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.Intefaces
{
    public interface IRepositoryChangeStatus
    {
        Task<bool> ChangeStatus(int id, bool status);
    }
}
