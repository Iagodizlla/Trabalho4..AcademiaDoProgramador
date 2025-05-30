﻿using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Models;

namespace Trabalho4.AP.Extensoes;

public static class FabricanteExtensions
{
    public static Fabricante ParaEntidadeF(this FormularioFabricanteViewModel formularioVM)
    {
        return new Fabricante(formularioVM.Nome, formularioVM.Email, formularioVM.Telefone);
    }

    public static DetalhesFabricanteViewModel ParaDetalhesVMF(this Fabricante fabricante)
    {
        return new DetalhesFabricanteViewModel(
                fabricante.Id,
                fabricante.Nome,
                fabricante.Email,
                fabricante.Telefone
        );
    }
}