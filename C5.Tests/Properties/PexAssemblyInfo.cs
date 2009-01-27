// This file should only contain assembly level attributes.
// Do not add any class or struct definitions as it may disable the ability of the tool to
// update the file.

using System;

using System.Runtime.CompilerServices;
using MbUnit.Pex;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Suppression;
using Microsoft.Pex.Graphs;
using SCG = System.Collections.Generic;
using C5;


[assembly: InternalsVisibleTo("Microsoft.Pex, PublicKey=002400000480000094000000060200000024000052534131000400000100010057a289398cc79ca7e46cd08c3994ca4ec229dd91d5ab4047b1bfbef3833332beedad9bec4014cdf721177edb24fe644b0dd95ab436d262cac8640fc5a87082423be9f41db942c8d1fd622dc4b305424d4ce9baf88fd15735b7352a70587997681d7df9dd5635c5cec251fc84423ab0349538bf61ece4d8ee7a6f2d07d169b9ec")]

[assembly: PexAssemblySettings(TestFramework = "MbUnit")]

[assembly: PexMbUnitPackage]
[assembly: PexGraphsPackage]

[assembly: PexInstrumentAssembly("C5")]
[assembly: PexSuppressStaticFieldStore(typeof(Comparer<>), "cachedComparer")]
[assembly: PexSuppressStaticFieldStore(typeof(SCG.Comparer<>), "defaultComparer")]
[assembly: PexSuppressUninstrumentedMethodFromNamespace("System")]
[assembly: PexSuppressUninstrumentedMethodFromNamespace("Microsoft")]
