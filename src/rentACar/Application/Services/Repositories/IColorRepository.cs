﻿using Core.Persistense.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IColorRepository : IAsyncRepository<Color>
{

}