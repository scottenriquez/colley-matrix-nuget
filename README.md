# Colley Matrix Rankings
A NuGet package for simulating head-to-head matchups and applying the Colley algorithm.

# Usage
The <code>ColleyMatrix</code> client exposes two methods: <code>SimulateGame</code> and <code>Solve</code>. The client contructor takes one argument: <code>numberOfTeams</code>:

<code>ColleyMatrix colleyMatrix = new ColleyMatrix(numberOfTeams);</code>

This will create a client with an underlying sparse matrix where the indexes ranging from <code>0</code> to <code>numberOfTeams - 1</code> correspond to each team's ID. Next, simulate matchups:

<code>colleyMatrix.SimulateGame(winnerId, loserId);</code>

Note that if the <code>winnerId</code> or <code>loserId</code> is not valid respective to the sparse matrix's dimensions, an exception will be thrown.

You can solve the sparse matrix at any point without modifying the internal state.

<code>IEnumerable<double> solvedVector = colleyMatrix.Solve();</code>

# Build Status
[![Build Status](https://travis-ci.org/scottenriquez/colley-matrix-nuget.svg?branch=master)](https://travis-ci.org/scottenriquez/colley-matrix-nuget)
