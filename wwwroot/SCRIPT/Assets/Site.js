const setLanguageAsync = async () => {
    let lang = await WebRequest.localAsync("Site", "getCache", { "cmd": "lang" });
    let json = await lang.json();

    document.getElementsByTagName("html")[0].setAttribute("lang", json.value);
};

const toggleBarsMenu = () => {
    let menu = document.getElementById("BarsMenu");
    let barsMenuIcon = document.querySelector("#TopHeader > i.bars-menu-icon");

    if (menu.classList.contains("hide")) {
        menu.classList.remove("hide");
        barsMenuIcon.classList.add("hide");
    }
    else {
        menu.classList.add("hide");
        barsMenuIcon.classList.remove("hide");
    }
};

(async () => {
    await setLanguageAsync();
})();

	//# sourceMappingUrl=Site.js.map
