/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.2
    @Latest               : 18.12.2024
*/

using SLT.Assets.Setup;
using SLT.Assets.Setup.Feature;

Assets
    .Setup(new SetupOptions(1, new SSL(), new Debug(), new Route_("SLT", "Index")));
