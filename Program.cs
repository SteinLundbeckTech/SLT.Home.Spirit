/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.1
    @Latest               : 15.12.2024
*/

using SLT.Assets.Extension;
using SLT.Assets.Setup;
using SLT.Assets.Setup.Feature;

new Assets().Setup(
    new SSL(),
    new Debug(),
    new Route_("slt", "Index"));
