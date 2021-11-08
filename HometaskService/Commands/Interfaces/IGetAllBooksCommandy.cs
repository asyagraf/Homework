﻿using HometaskService.ModelsDTO;
using System.Collections.Generic;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetAllBooksCommand
    {
        List<BookDTO> Execute();
    }
}
