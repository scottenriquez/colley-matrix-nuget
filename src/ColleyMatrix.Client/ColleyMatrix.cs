﻿using System.Collections.Generic;
using ColleyMatrix.Provider;
using ColleyMatrix.Provider.Matrix.MathDotNet;
using ColleyMatrix.Provider.Serializer.Json.NewtonSoft;
using ColleyMatrix.Service;

namespace ColleyMatrix.Client
{
    /// <inheritdoc />
    public class ColleyMatrix : IColleyMatrixClient
    {
        private readonly int _numberOfTeams;
        private readonly IColleyMatrixService _colleyMatrixService;

        /// <summary>
        /// Instantiates a ColleyMatrix client object; creates an n by n sparse matrix, where n is the number of teams in the defined league
        /// </summary>
        /// <param name="numberOfTeams">Number of teams in the league</param>
        public ColleyMatrix(int numberOfTeams)
        {
            _numberOfTeams = numberOfTeams;
            IJsonSerializationProvider jsonSerializationProvider = new NewtonSoftJsonSerializationProvider();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, numberOfTeams);
            IValidatorService validatorService = new ValidatorService(matrixProvider);
            _colleyMatrixService = new ColleyMatrixService(matrixProvider, validatorService);
        }

        /// <inheritdoc />
        public void SimulateGame(int winnerId, int loserId)
        {
            _colleyMatrixService.SimulateGame(winnerId, loserId);
        }

        /// <inheritdoc />
        public IEnumerable<double> Solve()
        {
            return _colleyMatrixService.Solve();
        }
    }
}
