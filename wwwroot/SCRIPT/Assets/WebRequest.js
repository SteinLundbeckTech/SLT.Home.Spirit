class WebResult {
    constructor(response) {
        this.Response = response;
        this.Status = response.status;
        this.StatusText = response.statusText;
    }

    json = async () => {
        let result = "";

        if (this.Status === 200) {
            result = await this.Response.json();
        }

        return result;
    };

    text = async () => {
        let result = "";

        if (this.Status === 200) {
            result = await this.Response.text();
        }

        return result;
    };
}

class WebOptions {
    constructor(controller, action, url, query = {}, routeData = [], method = "post", headers = "common", data = {}, mode = "cors") {
        this.Controller = controller;
        this.Action = action;
        this.Method = method;
        this.Query = query;
        this.RouteData = routeData;
        this.Data = data;
        this.Mode = mode;
        this.Credentials = null;
        this.Url = WebUtility.GetUrl(this.Controller, this.Action, url, this.Query, this.RouteData);
        this.Headers = headers && headers.toUpperCase() !== "COMMON" ? headers : { "Accept": "application/json" };
    }

    set credentials(creds) {
        this.Credentials = creds;
    };
}

class WebUtility {
    static GetUrl = (controller, action, url = null, query = {}, routes = []) => {
        let result = url === null ? "/" + controller + "/" + action : url;
        let i = 0;

        if (query && Object.keys(query).length > 0) {
            query = [query];

            for (let q in query[0]) {
                if (i === 0) {
                    result += "?";
                } else {
                    result += "&";
                }

                result += q + "=" + query[0][q];

                i++;
            }
        }
        else if (routes !== null && routes.length > 0) {
            for (let ii = 0; ii < routes.length; ii++) {
                result += "/" + routes[ii];
            }
        }

        return result;
    }

    static ProcessBodyData = (data) => {
        let result = {};

        Object.keys(data).forEach((key) => {
            let val = data[key];

            if (val !== null && val === "") {
                val = null;
            }

            result[key] = val;
        });

        return result;
    }
};

class WebRequest {
    static fetchAsync = async (options) => {
        let result = null;

        if (!(options instanceof WebOptions)) {
            options = new WebOptions(null, null, options, {}, [], "get");
        }

        try {
            let tmp = await fetch(options.Url, {
                header: options.Headers,
                method: options.Method.toUpperCase(),
                mode: options.Mode,
                body: options.Data && Object.keys(options.Data).length > 0 && options.Method.toUpperCase() !== "GET" ? JSON.stringify(WebUtility.ProcessBodyData(options.Data)) : null
            });

            if (tmp.status === 200) {
                result = new WebResult(tmp);
            }
            else {
                devLog("Error in WebRequestUtility while fetching url \"" + options.Url + "\". Status: (" + tmp.status + ") " + tmp.statusText, true, fetchAsync.caller, result);
            }
        }
        catch (ex) {
            devLog("Error in fetchAsync while fetching url \"" + options.Url + "\". " + ex.message);
        }

        return result;
    }

    static apiAsync = async (action, method = "post", routeData = [], data = {}) => {
        return await WebRequest.fetchAsync(new WebOptions("API", action, null, {}, routeData, method, null, data));
    }

    static localAsync = async (feature = "Site", action = "getCacheValue", query = {}) => {
        return await WebRequest.fetchAsync(new WebOptions("Assets/" + feature, action, null, query, null, "get"));
    };
}

// freeze(WebUtility);

	//# sourceMappingUrl=WebRequest.js.map
