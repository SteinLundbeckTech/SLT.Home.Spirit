const setGDPR = () => {
    document.cookie = "GDPR=" + encodeURIComponent("1");
    document.getElementById("GdprWrap").remove();
};

	//# sourceMappingUrl=GDPR.js.map
