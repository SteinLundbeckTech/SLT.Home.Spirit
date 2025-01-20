/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.3
    @Latest               : 20.01.2025
*/

using SLT.Assets.Setup;
using SLT.Assets.Setup.Feature;

Assets
    .Setup(new SetupOptions(1, new SSL(), new Debug(), new SLT.Assets.Setup.Feature.RouteEntry("SLT", "Index")));
