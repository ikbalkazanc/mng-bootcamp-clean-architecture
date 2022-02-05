﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules
{
    private IColorRepository _colorRespository;

    public ColorBusinessRules(IColorRepository colorRespository)
    {
        _colorRespository = colorRespository;
    }

    public async Task ColorNameCanNotNeDuplicatedWhenInsertedAndUpdated(string name)
    {
        var colors = await _colorRespository.GetListAsync(x => x.Name == name);
        if (colors.Items.Any())
        {
            throw new BusinessException("Color name cannot duplicated");
        }
    }

    public async Task ColorIdShouldExists(string name)
    {
        var colors = await _colorRespository.GetListAsync(x => x.Name == name);
        if (colors.Items.Any())
        {
            throw new BusinessException("Color name cannot duplicated");
        }
    }
}